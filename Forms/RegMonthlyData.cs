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
using System.Xml;
using System.Xml.Linq;

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

		/// <summary>
		/// Loading
		/// </summary>
		/// <param name="sender">send Object</param>
		/// <param name="e">Event Object</param>
		private void RegMonthlyData_Load(object sender, EventArgs e)
		{
			MappingEvent();
			/*
						DBAccess.InitializeDatabase();
						DBAccess.CreateTable();
						//DBAccess.CreateTable("create table if not exists test  (id integer, val text)");
						DBAccess.Delete("delete from test", null);

						List<SqliteParameter> parameters = new List<SqliteParameter>();
						parameters.Add(new SqliteParameter("p1", 1));
						parameters.Add(new SqliteParameter("p2", "111"));

						DBAccess.Insert("insert into test(id, val) values(@p1, @p2)", parameters.ToArray());
						DataTable dt = DBAccess.Select("select * from test where id = 2");
						foreach (DataRow dr in dt.Rows)
						{
							System.Diagnostics.Debug.WriteLine(dr[0]);
						}
			*/
		}

		private void MappingEvent()
		{
			for (int i = 1; i < 10; i++)
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

		private void DateTimePicker1_DropDown(object sender, EventArgs e)
		{
			DateTimePicker myDt = (DateTimePicker)sender;

			IntPtr cal = SendMessage(dateTimePicker1.Handle, DTM_GETMONTHCAL, IntPtr.Zero, IntPtr.Zero);
			SendMessage(cal, MCM_SETCURRENTVIEW, IntPtr.Zero, (IntPtr)1);
		}

		private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
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

		private void Button1_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("登録します。よろしいですか？", "データ登録", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.No) { return; }

			RegData();

			MessageBox.Show("登録しました。", "データ登録", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void RegData()
		{
			XElement xml = XElement.Load(Environment.CurrentDirectory + "\\" + @"Query\registration.xml");
			var sql = from item in xml.Elements("sql")
								where item?.Attribute("id")?.Value == "electricity_bill"
								select item.Value;
			string insertSql = sql.First().ToString() ?? "";

			List<SqliteParameter> parameters = new List<SqliteParameter>();
			parameters.Add(new SqliteParameter("year", GetYear()));
			parameters.Add(new SqliteParameter("month", GetMonth()));
			parameters.Add(new SqliteParameter("total_cost", textBox1.Text));
			parameters.Add(new SqliteParameter("basic_price", textBox2.Text));
			parameters.Add(new SqliteParameter("price1", textBox3.Text));
			parameters.Add(new SqliteParameter("price2", textBox4.Text));
			parameters.Add(new SqliteParameter("price3", textBox9.Text));
			parameters.Add(new SqliteParameter("adjust_price", textBox5.Text));
			parameters.Add(new SqliteParameter("discount_price", textBox6.Text));
			parameters.Add(new SqliteParameter("re_energy_charge", textBox7.Text));
			parameters.Add(new SqliteParameter("usage_period_from", CommonUtil.GetDate(dateTimePicker2.Value)));
			parameters.Add(new SqliteParameter("usage_period_to", CommonUtil.GetDate(dateTimePicker3.Value)));
			parameters.Add(new SqliteParameter("usage_amount", textBox8.Text));

			_ = DBAccess.Insert(insertSql, parameters.ToArray());
		}

		private int GetYear()
		{
			return dateTimePicker1.Value.Year;
		}

		private int GetMonth()
		{
			return dateTimePicker1.Value.Month;
		}
	}
}
