using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sim4solar
{
    public partial class RegMonthlyData : Form
    {
        private const int DTM_GETMONTHCAL = 0x1000 + 8;
        private const int MCM_SETCURRENTVIEW = 0x1000 + 32;
        private int year;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        public RegMonthlyData()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            DateTimePicker myDt = (DateTimePicker)sender;

            IntPtr cal = SendMessage(dateTimePicker1.Handle, DTM_GETMONTHCAL, IntPtr.Zero, IntPtr.Zero);
            SendMessage(cal, MCM_SETCURRENTVIEW, IntPtr.Zero, (IntPtr)1);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dp = (DateTimePicker)sender;
            if (year != dp.Value.Year)
            {
                year = dp.Value.Year;
            } else {
                dp.Select();
                SendKeys.SendWait("{ENTER}");
            }
        }
    }
}
