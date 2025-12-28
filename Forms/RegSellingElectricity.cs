using Microsoft.Data.Sqlite;
using sim4solar.Common;
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
			dateTimePicker2.Value = CommonUtil.GetDefaultDateTime(DateTime.Today.AddMonths(-1));
		}

		private void MappingEvent()
		{
			for (int i = 1; i <= 2; i++)
			{
				var txt = Controls["textBox" + i];
				if (txt == null) { continue; }
				((TextBox)txt).LostFocus += SetNumericValueFormat;
			}
			dateTimePicker2.ValueChanged += SetUsagePeriod;
		}

		private void SetUsagePeriod(object? sender, EventArgs e)
		{
			dateTimePicker3.Value = dateTimePicker2.Value.AddMonths(1).AddDays(-1);
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("登録します。よろしいですか？", "データ登録", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.No) { return; }

			string insertSql = DBUtil.GetSelectSqlStatement(DBUtil.SqlType.Insert, "selling_electricity");

			List<SqliteParameter> parameters =
			[
				new SqliteParameter("year", GetYear()),
				new SqliteParameter("month", GetMonth()),
				new SqliteParameter("salesAmount", CommonUtil.GetDecimalValue(textBox1.Text)),
				new SqliteParameter("usagePeriodFrom", CommonUtil.GetDate(dateTimePicker2.Value)),
				new SqliteParameter("usagePeriodTo", CommonUtil.GetDate(dateTimePicker3.Value)),
				new SqliteParameter("electricEnergy", CommonUtil.GetDecimalValue(textBox2.Text)),
			];

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

		private void TextBox2_Leave(object sender, EventArgs e)
		{
			if (!int.TryParse(textBox2.Text, out int val))
			{
				return;
			}

			textBox1.Text = ((int)(val * 8.5M)).ToString();
			SetNumericValueFormat(textBox1, e);
		}
	}
}
