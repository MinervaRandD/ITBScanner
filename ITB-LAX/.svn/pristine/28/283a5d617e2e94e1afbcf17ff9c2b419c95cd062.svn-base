using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Asi.Itb.Bll;
using Asi.Itb.Bll.Entities;

namespace Asi.Itb.UI
{
    public partial class OverrideForm : BaseForm
    {
        /// <summary>
        /// List of all locations available from database
        /// </summary>
        private List<Bll.Entities.Location> _locations;

        private Dictionary<Scan.ScanOperation, string> _operationCodeMap;

        public OverrideForm()
        {
            InitializeComponent();

            _operationCodeMap = new Dictionary<Scan.ScanOperation, string>();
            _operationCodeMap.Add(Scan.ScanOperation.HandlerPickUp, "Handler Pick Up");
            _operationCodeMap.Add(Scan.ScanOperation.HandlerDropOff, "Handler Drop Off");
            _operationCodeMap.Add(Scan.ScanOperation.CarrierPickUp, "Carrier Pick Up");
            _operationCodeMap.Add(Scan.ScanOperation.CarrierDropOff, "Carrier Drop Off");
            _operationCodeMap.Add(Scan.ScanOperation.GatePickUp, "Gate Pick Up");
            _operationCodeMap.Add(Scan.ScanOperation.GateDropOff, "Gate Drop Off");
            _operationCodeMap.Add(Scan.ScanOperation.OvernightIn, "Overnight In");
            _operationCodeMap.Add(Scan.ScanOperation.OvernightOut, "Overnight Out");
        }

        public override void Populate()
        {
            LocationManager mgr = new LocationManager();
            this._locations = mgr.GetLocations();

            SessionData sd = SessionData.Current;
            List<string> curPermissions = sd.User.Permissions;

            this.locationComboBox.Items.Clear();
            bool allowP = curPermissions.Contains("Handler Pick Up") || curPermissions.Contains("Carrier Drop Off"); 
            bool allowD = curPermissions.Contains("Handler Drop Off") || curPermissions.Contains("Carrier Pick Up");
            bool allowI = curPermissions.Contains("Overnight In");
            bool allowO = curPermissions.Contains("Overnight Out");

            foreach (Bll.Entities.Location row in this._locations)
            {
                if ((row.Type == "D" && allowD) 
                 || (row.Type == "P" && allowP)
                 || (row.Type == "I" && allowI)
                 || (row.Type == "O" && allowO))
                {
                    this.locationComboBox.Items.Add(row.Barcode);
                }
            }

            this.codeComboBox.Items.Clear();
            foreach (KeyValuePair<Scan.ScanOperation, string> pair in _operationCodeMap)
            {
                if (curPermissions.Contains(pair.Value))
                {
                    this.codeComboBox.Items.Add(pair.Key.ToString());
                }
            }

            if (sd.Location != null)
            {
                this.locationComboBox.SelectedItem = sd.Location.Barcode;
            }
            if (sd.OperationCode != null)
            {
                this.codeComboBox.SelectedItem = sd.OperationCode.Value.ToString();
            }
        }

        private void locationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curLoc = this.locationComboBox.SelectedItem.ToString();

            if (this._locations != null)
            {
                foreach (Bll.Entities.Location loc in this._locations)
                {
                    if (loc.Barcode == curLoc)
                    {
                        Scan.ScanOperation? opCode = loc.AllowedOperation;
                        if (opCode != null)
                        {
                            this.codeComboBox.SelectedItem = loc.AllowedOperation.Value.ToString();
                        }
                        break;
                    }
                }
            }
        }

        private void codeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curCode = this.codeComboBox.SelectedItem.ToString();

            if (curCode == Scan.ScanOperation.GatePickUp.ToString() 
                || curCode == Scan.ScanOperation.GateDropOff.ToString())
            {
                this.gateLabel.Visible = true;
                this.gateTextBox.Visible = true;
            }
            else
            {
                this.gateLabel.Visible = false;
                this.gateTextBox.Visible = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            if (this.codeComboBox.SelectedItem == null || 
                this.codeComboBox.SelectedItem.ToString() == string.Empty)
            {
                MessageBox.Show("Please select operation type.", "Input Error");
                return;
            }
            else
            {
                string curCodeStr = this.codeComboBox.SelectedItem.ToString();

                Scan.ScanOperation curCode = (Scan.ScanOperation)Enum.Parse(typeof(Scan.ScanOperation), curCodeStr, true);
                if (curCode == Scan.ScanOperation.GatePickUp || curCode == Scan.ScanOperation.GateDropOff)
                {
                    string gateNumber = this.gateTextBox.Text.Trim();
                    if (gateNumber == string.Empty)
                    {
                        MessageBox.Show("Please enter Gate number.", "Input Error");
                        return;
                    }
                    else
                    {
                        Location loc = new Location();
                        loc.Barcode = gateNumber;
                        loc.Source = LocationSource.OverrideForm;
                        SessionData.Current.Location = loc;
                        SessionData.Current.OperationCode = curCode;
                    }
                }
                else
                {
                    if (this.locationComboBox.SelectedItem == null || 
                        this.locationComboBox.SelectedItem.ToString() == string.Empty)
                    {
                        MessageBox.Show("Please select location.", "Input Error");
                        return;
                    }
                    else
                    {
                        string locStr = this.locationComboBox.SelectedItem.ToString();
                        Location loc = new Location();
                        loc.Barcode = locStr;
                        loc.Source = LocationSource.OverrideForm;
                        SessionData.Current.Location = loc;
                        SessionData.Current.OperationCode = curCode;
                    }
                }
            }

            Program.formStack.Pop(1, true);
        }
    }
}