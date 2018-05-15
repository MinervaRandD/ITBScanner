using System;
using System.ComponentModel;
using System.Threading;

namespace Asi.Itb.UI
{
	public delegate void FormClose();

	public class StackForm : System.Windows.Forms.Form 
    {
		public event FormClose FormClosed;

        private EventWaitHandle _waitHandler = new EventWaitHandle(false, EventResetMode.ManualReset);

		// all derived classes must call this custructor!
		public StackForm() {
			this.Closing += new System.ComponentModel.CancelEventHandler(Form1_Closing);
		}

		public void Form1_Closing(Object sender, CancelEventArgs args) {			
			this.Visible = false;
			args.Cancel = true;
			FormClosed();
		}

        /// <summary>
        /// Call LoadData in another thread.
        /// </summary>
		public void BeginLoadData() 
        {
			Thread workerThread = new Thread(new ThreadStart(LoadDataThread));

			// set out synchronization object
			_waitHandler.Reset();

			// start the thread
			workerThread.Start();
		}

        private void LoadDataThread()
        {
            LoadData();
			_waitHandler.Set();
        }

        /// <summary>
        /// Load data for the form.
        /// </summary>
		public virtual void LoadData() {}
		
        /// <summary>
		/// overload this method if you need to populate controls with data
		/// retrieved in the data thread
        /// </summary>
		public virtual void Populate() {}

        /// <summary>
        /// overload this method to initialize UI controls on the form. 
        /// One typical use is to move the designer InitilizeComponent() method
        /// from constructor here.
        /// </summary>
		public virtual void Initialize() {}

        /// <summary>
		/// wait for the data thread to finish
        /// </summary>
        internal void EndLoadData()
        {
			this._waitHandler.WaitOne();
        }
    }
}
