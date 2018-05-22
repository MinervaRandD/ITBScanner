using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Asi.Itb.Bll;
using Asi.Itb.Bll.Entities;
using Asi.Itb.Utilities.ListViewSort;

namespace Asi.Itb.UI
{
    public partial class BagCountForm : BaseForm
    {
        private List<Bag> _bags;

        public BagCountForm()
        {
        }

        public override void LoadData()
        {
            base.LoadData();

            _bags = ScanManager.GetBags(SessionData.Current.BagCountStatus);
        }

        public override void Populate()
        {
            string title = "";
            switch (SessionData.Current.BagCountStatus)
            {
                case Bag.Status.All:
                    title = "Bag Count Detail";
                    break;
                case Bag.Status.OnHand:
                    title = "On Hand";
                    break;
                case Bag.Status.DroppedOff:
                    title = "Dropped Off";
                    break;
            }
            this.TitleLabelText = title;
            this.InitSortHeaderColumns(bagsListView);
            this.bagsListView.Items.Clear();
            
            foreach (Bag bag in _bags)
            {
                ListViewItem item = new ListViewItem(
                    new string[]{
                        bag.Barcode, 
                        bag.DestinationLocationCode == null? string.Empty : bag.DestinationLocationCode
                    });
                item.Tag = bag;
                if (bag.Damaged != null && bag.Damaged.Value)
                {
                    item.BackColor = Color.Coral;
                }

                this.bagsListView.Items.Add(item);
            }

            this.bagsListView.ColumnClick += new ColumnClickEventHandler(bagsListView_ColumnClick);
        }

        public override void Initialize()
        {
            base.Initialize();

            InitializeComponent();
        }

        private void bagsListView_ItemActivate(object sender, EventArgs e)
        {
            if (this.bagsListView.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.bagsListView.SelectedIndices[0];
                if (selectedIndex >= 0 && this.bagsListView.Items.Count > selectedIndex)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    ListViewItem curItem = this.bagsListView.Items[selectedIndex];
                    SessionData.Current.Bag = curItem.Tag as Bag;

                    Program.formStack.Push(typeof(BagDetailForm), true);

                    Cursor.Current = Cursors.Default;
                }
            }
        }
        
        private void InitSortHeaderColumns(ListView lv)
        {
            if (lv.Columns.Count > 0)
            {
                lv.Columns.Clear();
            }
            int xr = this.Width / 240;
            lv.Columns.Add(new ColHeader("Barcode", xr * 120, HorizontalAlignment.Left, true));
            lv.Columns.Add(new ColHeader("Destination", xr * 110, HorizontalAlignment.Left, false));
        }

        private void bagsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Create an instance of the ColHeader class.
            ColHeader clickedCol = (ColHeader)this.bagsListView.Columns[e.Column];

            // Set the ascending property to sort in the opposite order.
            clickedCol.ascending = !clickedCol.ascending;

            // Get the number of items in the list.
            int numItems = this.bagsListView.Items.Count;

            // Turn off display while data is repoplulated.
            this.bagsListView.BeginUpdate();

            // Populate an ArrayList with a SortWrapper of each list item.
            ArrayList SortArray = new ArrayList();
            for (int i = 0; i < numItems; i++)
            {
                SortArray.Add(new SortWrapper(this.bagsListView.Items[i], e.Column));
            }

            // Sort the elements in the ArrayList using a new instance of the SortComparer
            // class. The parameters are the starting index, the length of the range to sort,
            // and the IComparer implementation to use for comparing elements. Note that
            // the IComparer implementation (SortComparer) requires the sort
            // direction for its constructor; true if ascending, othwise false.
            SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(clickedCol.ascending));

            // Clear the list, and repopulate with the sorted items.
            this.bagsListView.Items.Clear();
            for (int i = 0; i < numItems; i++)
                this.bagsListView.Items.Add(((SortWrapper)SortArray[i]).sortItem);

            // Turn display back on.
            this.bagsListView.EndUpdate();
        }
    }
}