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
    public partial class BagDetailForm : BaseForm
    {
        private Bag _bag;
        private List<Scan> _scans;
        private int? _onhandTimeInSeconds;

        public BagDetailForm()
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            InitializeComponent();
        }

        public override void LoadData()
        {
            base.LoadData();

            _bag = SessionData.Current.Bag;
            _scans = ScanManager.GetScansByBarcode(_bag.Barcode);
            _onhandTimeInSeconds = ScanManager.GetOnhandTimeInSeconds(_bag.Barcode);
        }

        public override void Populate()
        {
            base.Populate();

            this.barcodeTextBox.Text = _bag.Barcode;
            this.inboundCarrierTextBox.Text = _bag.InboundCarrier;
            this.outboundCarrierTextBox.Text = _bag.OutboundCarrier;
            this.destTextBox.Text = _bag.DestinationLocationCode;
            if (_onhandTimeInSeconds != null)
            {
                this.onhandTimeTextBox.Text = TimeSpan.FromSeconds(_onhandTimeInSeconds.Value).ToString();
            }
            else
            {
                this.onhandTimeTextBox.Text = string.Empty;
            }

            this.scansListView.Items.Clear();
            foreach (Scan row in _scans)
            {
                ListViewItem item = new ListViewItem(new string[] { row.ScanTime.ToString(), row.Operation.ToString(), row.LocationCode });
                this.scansListView.Items.Add(item);
            }
        }
    }
}