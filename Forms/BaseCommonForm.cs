namespace sim4solar.Forms
{
	/// <summary>
	/// Base Class For Common Form
	/// </summary>
	public class BaseCommonForm : Form
	{
		private const int DTM_GETMONTHCAL = 0x1000 + 8;
		private const int MCM_SETCURRENTVIEW = 0x1000 + 32;
		private int year;

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern nint SendMessage(nint hWnd, int msg, nint wp, nint lp);

		protected void MonthlyDateTimePicker_DropDown(object sender, EventArgs e)
		{
			DateTimePicker myDt = (DateTimePicker)sender;

			nint cal = SendMessage(myDt.Handle, DTM_GETMONTHCAL, nint.Zero, nint.Zero);
			SendMessage(cal, MCM_SETCURRENTVIEW, nint.Zero, 1);
		}

		protected void MonthlyDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			DateTimePicker dp = (DateTimePicker)sender;
			if (year != dp.Value.Year)
			{
				year = dp.Value.Year;
			}

			dp.Select();
			SendKeys.SendWait("{ENTER}");
		}

		/// <summary>
		/// Convert csv format for numeric value.
		/// </summary>
		/// <param name="sender">LostFocus object</param>
		/// <param name="e">Event object</param>
		protected void SetNumericValueFormat(Object? sender, EventArgs e)
		{
			if (sender == null) { return; }

			TextBox txt = (TextBox)sender;
			if (txt == null) { return; }

			int parseVal;
			if (!int.TryParse(txt.Text, out parseVal)) { return; }
			txt.Text = String.Format("{0:N0}", parseVal);
		}
	}
}
