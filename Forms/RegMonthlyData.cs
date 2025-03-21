﻿using Microsoft.Data.Sqlite;
using sim4solar.Common;
using sim4solar.Forms;

namespace sim4solar
{
	public partial class RegMonthlyData : BaseCommonForm
	{
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
		}

		private void MappingEvent()
		{
			for (int i = 1; i < 10; i++)
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

        private void DateTimePicker1_DropDown(object sender, EventArgs e)
		{
			base.MonthlyDateTimePicker_DropDown(sender, e);
		}

		private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			base.MonthlyDateTimePicker_ValueChanged(sender, e);
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("登録します。よろしいですか？", "データ登録", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.No) { return; }

			if (!CheckInputData())
			{
				MessageBox.Show("入力データの整合性が取れていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			RegData();

			MessageBox.Show("登録しました。", "データ登録", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private bool CheckInputData()
		{
			int totalCost = int.Parse(CommonUtil.GetDecimalValue(textBox1.Text).ToString());
			decimal basicPrice = CommonUtil.GetDecimalValue(textBox2.Text);
			decimal price1 = CommonUtil.GetDecimalValue(textBox3.Text);
			decimal price2 = CommonUtil.GetDecimalValue(textBox4.Text);
			decimal price3 = CommonUtil.GetDecimalValue(textBox9.Text);
			decimal adjustPrice = CommonUtil.GetDecimalValue(textBox5.Text);
			decimal discountPrice = CommonUtil.GetDecimalValue(textBox6.Text);
			decimal reEnergyCharge = CommonUtil.GetDecimalValue(textBox7.Text);

			return totalCost == (int)(basicPrice + price1 + price2 + price3 + adjustPrice + discountPrice + reEnergyCharge);
		}

		private void RegData()
		{
			string insertSql = DBUtil.GetSelectSqlStatement(DBUtil.SqlType.Insert, "electricity_bill");

			List<SqliteParameter> parameters =
			[
				new SqliteParameter("year", GetYear()),
				new SqliteParameter("month", GetMonth()),
				new SqliteParameter("total_cost", CommonUtil.GetDecimalValue(textBox1.Text)),
				new SqliteParameter("basic_price", CommonUtil.GetDecimalValue(textBox2.Text)),
				new SqliteParameter("price1", CommonUtil.GetDecimalValue(textBox3.Text)),
				new SqliteParameter("price2", CommonUtil.GetDecimalValue(textBox4.Text)),
				new SqliteParameter("price3", CommonUtil.GetDecimalValue(textBox9.Text)),
				new SqliteParameter("adjust_price", CommonUtil.GetDecimalValue(textBox5.Text)),
				new SqliteParameter("discount_price", CommonUtil.GetDecimalValue(textBox6.Text)),
				new SqliteParameter("re_energy_charge", CommonUtil.GetDecimalValue(textBox7.Text)),
				new SqliteParameter("usage_period_from", CommonUtil.GetDate(dateTimePicker2.Value)),
				new SqliteParameter("usage_period_to", CommonUtil.GetDate(dateTimePicker3.Value)),
				new SqliteParameter("usage_amount", CommonUtil.GetDecimalValue(textBox8.Text)),
			];

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
