using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Threading = System.Threading;
using GpsLocation = Microsoft.WindowsMobile.Samples.Location;
using ProcessManager = Asi.Itb.Utilities.ProcessManager;
using Asi.Itb.Bll.Entities;

namespace Asi.Itb.UI
{
    static class Program
    {
        public static FormStack formStack;

        private static GpsLocation.Gps gps;

        /// <summary>
        /// Event raised when user/gps idle time exceeded limit.
        /// </summary>
        public static event EventHandler IdleTimedOut;

        /// <summary>
        /// Program main timer to perform various maintenance tasks, including
        /// update GPS data, checking for idle timeout etc.
        /// </summary>
        public static Threading.Timer mainTimer;

        /// <summary>
        /// Timestamp when last user activity occurred.
        /// </summary>
        public static DateTime LastUserActivity
        {
            get;
            set;
        }

        /// <summary>
        /// Timestamp when last GPS movement occurred.
        /// </summary>
        public static DateTime LastGpsMovement
        {
            get;
            set;
        }

        /// <summary>
        /// Number of seconds for idle user activity time out limit
        /// </summary>
        public static int IdleTimeOutLimit
        {
            get;
            set;
        }

        /// <summary>
        /// Number of seconds for no GPS movement time out limit
        /// </summary>
        public static int GpsIdleTimeOutLimit
        {
            get;
            set;
        }

        public static Threading.Timer batteryTimer;
        public static Threading.Timer cellularTimer;
        private static System.Uri pingUri;

        private static Hardware.Device.TAPI tapi;
        private static Hardware.Networking.Ping ping;
        private static Hardware.Networking.Connection gprsConn;
        private static Hardware.Networking.GPRS gprs;
                        
        public static int BatteryWarningPercent
        {
            get;
            set;
        }

        private static bool CheckingBattery
        {
            get;
            set;
        }

        private static Hardware.Networking.GPRS.SignalBars gprsSignalBar;
        public static Hardware.Networking.GPRS.SignalBars radioStrength
        {
            get
            {
                if (tapi == null)
                {
                    tapi = new Hardware.Device.TAPI();
                }
                if (tapi.IsRadioOn())
                {
                    return gprsSignalBar;
                }
                else
                {
                    return Hardware.Networking.GPRS.SignalBars.RadioOff;
                }
            }
        }
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            KillDuplicateProcess();
            StartupTasks();
            InitGprsSignalStrengthRcv();
                       
            string logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\itblog.txt";
            int BatteryDueTime = 60000;

            try
            {
                File.Delete(logFilePath); // clear it first
            }
            catch
            {
                try
                {
                    Trace.Close();
                    KillDuplicateProcess();
                    File.Delete(logFilePath);
                }
                catch
                {
                }
            }

            TextWriterTraceListener traceListener = new TextWriterTraceListener(logFilePath, "LogFile");
            Trace.Listeners.Add(traceListener);
            Debug.AutoFlush = true;            

            Trace.WriteLine(string.Format("{0}: Program started.", DateTime.Now));

            InitializeGps();

            InitializeIdleTimeOut();
            SetBatteryWarningPercent();

            mainTimer = new Threading.Timer(new Threading.TimerCallback(Program.DoMaintenance), null, 5000, 5000);
            batteryTimer = new Threading.Timer(new Threading.TimerCallback(Program.CheckBatteryLevel), null, BatteryDueTime, BatteryDueTime);
            cellularTimer = new Threading.Timer(new Threading.TimerCallback(Program.TurnOnCellular), null, 3000, 3000);

            Hardware.Device device = new Hardware.Device();
            device.DisableFunctionKey();

            Bll.ScanManager.Init();            
            
            formStack = new FormStack();
            formStack.Push(typeof(LoginForm), true);
            formStack.Run();   

            _maintResetEvent.WaitOne(5000, false);
            _batteryResetEvent.WaitOne(BatteryDueTime, false);
            _cellularResetEvent.WaitOne(3000, false);
            
            mainTimer.Dispose();
            batteryTimer.Dispose();
            if (tapi != null) { tapi.Dispose(); }
            if (ping != null) { ping.Dispose(); }

            Bll.ScanManager.Dispose();

            device.EnableFunctionKey();
            
            CloseGPS();

            Trace.Close();
        }

        /// <summary>
        /// Set value of IdleTimeOutLimit from db
        /// </summary>
        public static void SetIdleTimeOut()
        {
            Asi.Itb.Bll.ProgramManager smgr = new Asi.Itb.Bll.ProgramManager();
            IdleTimeOutLimit = smgr.GetIdleTimeOutLimit();
        }

        /// <summary>
        /// Set value of GpsIdleTimeOutLimit from db
        /// </summary>
        public static void SetGpsIdleTimeOut()
        {
            Asi.Itb.Bll.ProgramManager smgr = new Asi.Itb.Bll.ProgramManager();
            GpsIdleTimeOutLimit = smgr.GetGpsIdleTimeOutLimit();
        }

        public static void SetBatteryWarningPercent()
        {
            Asi.Itb.Bll.ProgramManager smgr = new Asi.Itb.Bll.ProgramManager();
            BatteryWarningPercent = smgr.GetBatteryWarningPercent();
        }

        private static System.Threading.ManualResetEvent _maintResetEvent = new System.Threading.ManualResetEvent(true);
        private static System.Threading.ManualResetEvent _batteryResetEvent = new System.Threading.ManualResetEvent(true);
        private static System.Threading.ManualResetEvent _cellularResetEvent = new System.Threading.ManualResetEvent(true);

        /// <summary>
        /// Perform various maintenance work on periodic basis
        /// </summary>
        private static void DoMaintenance(object stateInfo)
        {
            Debug.WriteLine("Entering", "DoMaintenance");

            _maintResetEvent.Reset();

            GpsLocation.GpsDeviceState deviceState = gps.GetDeviceState();
            if (deviceState != null && deviceState.DeviceState == GpsServiceState.On)
            {
                GpsLocation.GpsPosition pos = gps.GetPosition();
                if (pos != null && pos.LatitudeValid && pos.LongitudeValid)
                {
                    SessionData.Current.SetGpsPosition(pos.Latitude, pos.Longitude);
                    Debug.WriteLine("GPS: " + SessionData.Current.GpsPosition.ToString(), "DoMaintenance");
                }
                else
                {
                    SessionData.Current.ClearGpsPosition();
                    Debug.WriteLine("GPS Device On w/o data", "DoMaintenance");
                }
            }
            else
            {
                SessionData.Current.ClearGpsPosition();
                Debug.WriteLine("GPS Device off", "DoMaintenance");
            }

            DateTime curTime = DateTime.Now;

            if (IdleTimeOutLimit > 0 &&
                curTime.Subtract(Program.LastUserActivity).TotalSeconds > IdleTimeOutLimit
                ||
                GpsIdleTimeOutLimit > 0 &&
                SessionData.Current.GpsPosition != null &&
                curTime.Subtract(LastGpsMovement).TotalSeconds > GpsIdleTimeOutLimit)
            {
                if (Program.IdleTimedOut != null)
                {
                    Program.IdleTimedOut(null, null);
                }
            }            

            _maintResetEvent.Set();

            Debug.WriteLine("Exiting", "DoMaintenance");
        }

        /// <summary>
        /// Initialized and open GPS device
        /// </summary>
        private static void InitializeGps()
        {
            gps = new GpsLocation.Gps();
            if (!gps.Opened)
            {
                gps.Open();
            }

            SessionData.Current.GpsChanged += new EventHandler(Current_GpsChanged);
        }

        /// <summary>
        /// Set up idle timeout values.
        /// </summary>
        public static void InitializeIdleTimeOut()
        {
            SetIdleTimeOut();
            LastUserActivity = DateTime.Now;

            SetGpsIdleTimeOut();
            LastGpsMovement = DateTime.Now;
        }

        /// <summary>
        /// Event handler for GpsChanged event of session data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Current_GpsChanged(object sender, EventArgs e)
        {
            Program.LastGpsMovement = DateTime.Now;
        }

        /// <summary>
        /// Close GPS device
        /// </summary>
        private static void CloseGPS()
        {
            if (gps != null && gps.Opened)
            {
                gps.Close();
            }
        }

        private static void CheckBatteryLevel(object stateinfo)
        {
            _batteryResetEvent.Reset();

            if (!CheckingBattery)
            {
                CheckBatteryLevelSub();
            }

            _batteryResetEvent.Set();
        }        

        private static void CheckBatteryLevelSub()
        {
            CheckingBattery = true; // prevent multiple msgbox
            Debug.WriteLine("Entering", "CheckBatteryLevel");

            int UnknownBatteryPercent = 100; // defined in Hardware
            int BatteryPercent = Hardware.Power.BatteryPercent();

            if (BatteryPercent != UnknownBatteryPercent)
            {
                if (BatteryPercent <= BatteryWarningPercent)
                {
                    string msg = "Low Scanner Battery\nBattery Remaining: " + BatteryPercent + "%";
                    Assembly assembly = Assembly.LoadFrom("Hardware.dll");
                    using (Stream wavfile = assembly.GetManifestResourceStream("Hardware.Mistake.wav"))
                    {
                        Hardware.Device.Sound snd = new Hardware.Device.Sound(wavfile);
                        snd.Play();
                        snd.Dispose();
                    }                    
                    DialogResult dr = MessageBox.Show(msg, "LOW BATTERY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);                    
                }
            }            
            Debug.WriteLine("Exiting [Battery " + BatteryPercent + "%]", "CheckBatteryLevel");
            CheckingBattery = false;
        }

        private static void TurnOnCellular(object stateinfo)
        {
            _cellularResetEvent.Reset();
            int BatteryPercent = Hardware.Power.BatteryPercent();           
            
            if (BatteryPercent > BatteryWarningPercent)
            {
                if (tapi == null)
                {
                    tapi = new Hardware.Device.TAPI();
                }
                tapi.TurnOnCellularRadio();
            }
            _cellularResetEvent.Set();
        }

         
                        
        public static void KillDuplicateProcess()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ProcessManager.Process[] procs = ProcessManager.Process.GetProcesses();
                Process currentproc = Process.GetCurrentProcess();

                foreach (ProcessManager.Process proc in procs)
                {
                    if (proc.ProcessName == Path.GetFileName(Assembly.GetExecutingAssembly().GetName().CodeBase))
                    {
                        if (currentproc.Id != proc.Handle.ToInt32())
                        {
                            proc.Kill();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // This error will occur (rarely) when the application freezes while debugging, and you force a warmboot
                if (ex.Message != "Unable to create snapshot")
                {
                    throw new Exception(ex.Message);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // Ping doesn't work with ActiveSync (by design)
        public static bool IsPingSuccess()
        {
            if (ping == null)
            {
                ping = new Hardware.Networking.Ping();
            }
            if (pingUri == null)
            {
                pingUri = new System.Uri(Itb.Bll.Configuration.Instance.WebServiceUri);
            }            
            return ping.SendPing(pingUri.Host);
        }

        private static void StartupTasks()
        {
            Threading.Thread startupThread = new Threading.Thread(new Threading.ThreadStart(StartupTasksThread));
            startupThread.Start();
        }

        private static void StartupTasksThread()
        {
            // Turn off WIFI
            Hardware.Networking.WiFi wifi = new Hardware.Networking.WiFi();
            wifi.TurnOffWiFi();
            wifi.Dispose();

            // Open GPRS connection
            gprsConn = new Hardware.Networking.Connection();
            gprsConn.DoConnect("http://www.google.com");
        }

        private static void InitGprsSignalStrengthRcv()
        {
            // Get GPRS signal strength
            gprs = new Hardware.Networking.GPRS();
            gprs.SignalStrengthChanged += new Hardware.Networking.GPRS.SignalStrengthChangedDel(gprs_SignalStrengthChanged);
            gprsSignalBar = gprs.GetFirstSignalStrength();
        }
        
        private static void gprs_SignalStrengthChanged(Hardware.Networking.GPRS.SignalBars SignalStrength)
        {
            gprsSignalBar = SignalStrength;
        }
    } 
}