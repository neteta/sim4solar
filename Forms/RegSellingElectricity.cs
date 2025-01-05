using Microsoft.Data.Sqlite;
using sim4solar.Common;
using System.Data;
using System.Xml.Linq;
using TextBox = System.Windows.Forms.TextBox;

namespace sim4solar.Forms
{
	public partial class RegSellingElectricity : BaseCommonForm
	{

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

		private void DateTimePicker1_DropDown(object sender, EventArgs e)
		{
			base.MonthlyDateTimePicker_DropDown(sender, e);
		}

		private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			base.MonthlyDateTimePicker_ValueChanged(sender, e);
		}


	}
}
