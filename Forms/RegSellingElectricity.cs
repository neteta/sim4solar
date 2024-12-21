using Microsoft.Data.Sqlite;
using sim4solar.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using TextBox = System.Windows.Forms.TextBox;

namespace sim4solar.Forms
{
	public partial class RegSellingElectricity : Form
	{
		private const int DTM_GETMONTHCAL = 0x1000 + 8;
		private const int MCM_SETCURRENTVIEW = 0x1000 + 32;
		private int year;

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

		public RegSellingElectricity()
		{
			InitializeComponent();
		}
		private void RegSellingElectricity_Load(object sender, EventArgs e)
		{
			MappingEvent();
		}

		private void MappingEvent()
		{
			for (int i = 1; i <= 2; i++)
			{
				var txt = Controls["textBox" + i];
				if (txt == null) { continue; }
				((TextBox)txt).LostFocus += SetNumericValueFormat;
			}
		}

		/// <summary>
		/// Convert csv format for numeric value.
		/// </summary>
		/// <param name="sender">LostFocus object</param>
		/// <param name="e">Event object</param>
		private void SetNumericValueFormat(Object? sender, EventArgs e)
		{
			if (sender == null) { return; }

			TextBox txt = (TextBox)sender;
			if (txt == null) { return; }

			int parseVal;
			if (!int.TryParse(txt.Text, out parseVal)) { return; }
			txt.Text = String.Format("{0:N0}", parseVal);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("登録します。よろしいですか？", "データ登録", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.No) { return; }

			XElement xml = XElement.Load(Environment.CurrentDirectory + "\\" + @"Query\registration.xml");
			var sql = from item in xml.Elements("sql")
								where item?.Attribute("id")?.Value == "selling_electricity"
								select item.Value;
			string insertSql = sql.First().ToString() ?? "";

			List<SqliteParameter> parameters = new List<SqliteParameter>();
			parameters.Add(new SqliteParameter("year", GetYear()));
			parameters.Add(new SqliteParameter("month", GetMonth()));
			parameters.Add(new SqliteParameter("salesAmount", CommonUtil.GetDecimalValue(textBox1.Text)));
			parameters.Add(new SqliteParameter("usagePeriodFrom", CommonUtil.GetDate(dateTimePicker2.Value)));
			parameters.Add(new SqliteParameter("usagePeriodTo", CommonUtil.GetDate(dateTimePicker3.Value)));
			parameters.Add(new SqliteParameter("electricEnergy", CommonUtil.GetDecimalValue(textBox2.Text)));

			_ = DBAccess.Insert(insertSql, parameters.ToArray());

			MessageBox.Show("登録しました。", "データ登録", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private int GetYear()
		{
			return dateTimePicker1.Value.Year;
		}

		private int GetMonth()
		{
			return dateTimePicker1.Value.Month;
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
			}
			else
			{
				dp.Select();
				SendKeys.SendWait("{ENTER}");
			}
		}


	}
}
