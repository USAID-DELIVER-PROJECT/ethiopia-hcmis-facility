using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Globalization;

namespace PharmInventory
{
    // Implements the manual sorting of items by column.
    // Implements the manual sorting of items by columns.
    class ListViewItemComparer : IComparer
    {
        private int col;
        private SortOrder order;
        int number = 0;
        // number is 0 for String, 1 for Number and 2 for decimals, 3 for datetime and 4 for money
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order, int no)
        {
            col = column;
            this.order = order;
            this.number = no;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            if (number == 1)
            {
                try
                {

                    returnVal = Int64.Parse(((ListViewItem)x).SubItems[col].Text, NumberStyles.AllowThousands).CompareTo(Int64.Parse(((ListViewItem)y).SubItems[col].Text, NumberStyles.AllowThousands));
                }
                catch
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                  ((ListViewItem)y).SubItems[col].Text);
                }
            }
            else if (number == 2)
            {
                try
                {

                    returnVal = Decimal.Parse(((ListViewItem)x).SubItems[col].Text, NumberStyles.AllowDecimalPoint).CompareTo(Decimal.Parse(((ListViewItem)y).SubItems[col].Text, NumberStyles.AllowDecimalPoint));
                }
                catch 
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                  ((ListViewItem)y).SubItems[col].Text);
                }
            }
            else if (number == 3)
            {
                 try
                {
                    returnVal = DateTime.Parse(((ListViewItem)x).SubItems[col].Text).CompareTo(DateTime.Parse(((ListViewItem)y).SubItems[col].Text));
                }
                catch
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                  ((ListViewItem)y).SubItems[col].Text);
                }
            }
            else if (number == 4)
            { 
            // sort by money
                try
                {
                    returnVal = Decimal.Parse(((ListViewItem)x).SubItems[col].Text, NumberStyles.AllowCurrencySymbol).CompareTo(Decimal.Parse(((ListViewItem)y).SubItems[col].Text, NumberStyles.AllowCurrencySymbol));
                }
                catch 
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                  ((ListViewItem)y).SubItems[col].Text);
                }
            }
            else
            {
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                   ((ListViewItem)y).SubItems[col].Text);
            }

            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }


    }
}
