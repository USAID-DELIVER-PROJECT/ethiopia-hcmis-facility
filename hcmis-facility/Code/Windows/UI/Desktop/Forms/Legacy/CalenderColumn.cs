using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PharmInventory
{
    class CalenderColumn : DataGridViewColumn
    {
        public CalenderColumn() : base(new CalenderCell())
        {
            ;
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                base.CellTemplate = value;
            }
        }
    }

    class CalenderCell : DataGridViewTextBoxCell
    {

        public CalenderCell()
        {
            this.Style.Format = "MM/dd/yyyy";
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            CalendarEditingControl ctrl = (CalendarEditingControl)DataGridView.EditingControl;
            try
            {
                ctrl.Value = DateTime.Parse(this.Value.ToString());
            }
            catch
            {
                ctrl.Value = DateTime.Now;
            }
        }

        public override Type EditType
        {
            get
            {
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return DateTime.Now;
            }
        }
    }

    public class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        private DataGridView dataGridViewControl;
        private Boolean valueIsChanged;
        private int rowIndexNum;

        public CalendarEditingControl()
        {
            this.Format = DateTimePickerFormat.Short;
        }

         Object IDataGridViewEditingControl.EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToShortDateString();
            }
            set
            {
                
                    this.Value = DateTime.Parse((string)value);
                
            }
        }

         Object IDataGridViewEditingControl.GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
           return this.Value.ToShortDateString();
        }

         void IDataGridViewEditingControl.ApplyCellStyleToEditingControl(DataGridViewCellStyle dgridView)
        {
            this.Font = dgridView.Font;
            this.CalendarForeColor = dgridView.ForeColor;
            this.CalendarMonthBackground = dgridView.BackColor;
        }

         int IDataGridViewEditingControl.EditingControlRowIndex
        {
            get {
                return rowIndexNum;
            }
            set {
                rowIndexNum = value;
            }
        }

         Boolean IDataGridViewEditingControl.EditingControlWantsInputKey(Keys key, bool b)
        {
            switch (key)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Space: return true;
                default: return false;
            }
        }

         void IDataGridViewEditingControl.PrepareEditingControlForEdit(bool b)
        {

        }

          bool IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        {
            get {
                return false;
            }
        }

         DataGridView IDataGridViewEditingControl.EditingControlDataGridView
        {
            get
            {
                return dataGridViewControl;
            }
            set
            {
                dataGridViewControl = value;
            }
        }

         bool IDataGridViewEditingControl.EditingControlValueChanged
        {
            get { return valueIsChanged; }
            set { valueIsChanged = value; }
        }

          Cursor IDataGridViewEditingControl.EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        
        protected override void OnValueChanged(EventArgs eventargs)
        {
            valueIsChanged = true;
           //TODO: Fix this
            dataGridViewControl.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);

        }
    }

}
