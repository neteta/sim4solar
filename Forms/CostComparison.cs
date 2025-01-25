using Microsoft.Data.Sqlite;
using sim4solar.Common;
using System.Data;

namespace sim4solar.Forms
{
	public partial class CostComparison : BaseCommonForm
	{
		public CostComparison()
		{
			InitializeComponent();
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
			ShowCostCmparison(sender);
		}

		private void ShowCostCmparison(object sender)
		{
			GetTargetCost(sender);
		}

		private void GetTargetCost(object sender)
		{
			DateTime targetYM = dateTimePicker1.Value;
			string sql = DBUtil.GetSelectSqlStatement(DBUtil.SqlType.Select, "electricity_bill");

			List<SqliteParameter> parameters =
				[
					new SqliteParameter("year", targetYM.Year),
					new SqliteParameter("month", targetYM.Month)
				];

			DataTable dt = DBAccess.Select(sql, parameters.ToArray());
			if (dt.Rows.Count == 0)
			{
				MessageBox.Show("対象データがありません。");
				return;
			}

			sql = DBUtil.GetSelectSqlStatement(DBUtil.SqlType.Select, "power_generation_results");
			parameters.Clear();
			parameters.Add(new SqliteParameter("start", (string)dt.Rows[0]["usage_period_from"]));
			parameters.Add(new SqliteParameter("end", (string)dt.Rows[0]["usage_period_to"]));

			DataTable dtPowerGenResult = DBAccess.Select(sql, parameters.ToArray());

			if (dtPowerGenResult.Rows.Count == 0)
			{
				MessageBox.Show("対象データがありません。");
				return;
			}

			GetComparisonRow(dt, dtPowerGenResult);
			GetHeaderLabel(dt);

			dataGridView1.DataSource = dt;
			SetColumnsName();
			SetFormat();
			InsertColumn();
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
		}

		private void GetHeaderLabel(DataTable dt)
		{
			label3.Text = ((string)dt.Rows[0]["usage_period_from"]).Replace("-", "/");
			label5.Text = ((string)dt.Rows[0]["usage_period_to"]).Replace("-", "/");
			label7.Text = String.Format("{0:N0}",
				((long)dt.Rows[1]["total_cost"] - (long)dt.Rows[0]["total_cost"])) + "円";
		}

		private void GetComparisonRow(DataTable dt, DataTable dtPowerGenResult)
		{
			// 制約を解除しておく
			dt.Constraints.Clear();

			DataRow achiveDr = dt.Rows[0];

			String sql = DBUtil.GetSelectSqlStatement(DBUtil.SqlType.Select, "mst_code");
			List<SqliteParameter> parameters =
			[
				new SqliteParameter("code", MainCode.C001),
				// 使用期間の開始日を基準に取得
				new SqliteParameter("targetDate", achiveDr["usage_period_from"]),
			];
			DataTable dtMst = DBAccess.Select(sql, parameters.ToArray());
			if (dtMst.Rows.Count == 0)
			{
				MessageBox.Show("マスタデータが見つかりません。");
				return;
			}

			parameters.Clear();
			parameters.Add(new SqliteParameter("code", MainCode.C001));
			// 燃料調整費については、請求年月を基準に取得
			parameters.Add(new SqliteParameter("targetDate", dateTimePicker1.Value.ToString("yyyy-MM-dd")));
			DataTable dtMst4Adjust = DBAccess.Select(sql, parameters.ToArray());

			if (dtMst4Adjust.Rows.Count == 0)
			{
				MessageBox.Show("マスタデータが見つかりません。");
				return;
			}

			DataRow dr = dt.NewRow();
			double usageAmount = CommonCalc.GetUsageAmount(dtPowerGenResult);
			int intUsageAmount = (int)usageAmount;
			double reEnergeChage = CommonCalc.GetReEnergyCharge(intUsageAmount,
				CommonUtil.GetDoubleValue(dtMst, SubCode.C001_05));

			dr["year"] = achiveDr["year"];
			dr["month"] = achiveDr["month"];
			dr["basic_price"] = achiveDr["basic_price"];
			dr["price1"] = CommonCalc.GetPrice1(intUsageAmount, CommonUtil.GetDoubleValue(dtMst, SubCode.C001_02));
			dr["price2"] = CommonCalc.GetPrice2(intUsageAmount, CommonUtil.GetDoubleValue(dtMst, SubCode.C001_03));
			dr["price3"] = CommonCalc.GetPrice3(intUsageAmount, CommonUtil.GetDoubleValue(dtMst, SubCode.C001_04));
			dr["adjust_price"] = CommonCalc.GetAdjustPrice(intUsageAmount, CommonUtil.GetDoubleValue(dtMst4Adjust, SubCode.C001_06));
			dr["discount_price"] = CommonCalc.GetDiscountPrice(dr, reEnergeChage, 0.005);
			dr["re_energy_charge"] = reEnergeChage;
			dr["usage_period_from"] = achiveDr["usage_period_from"];
			dr["usage_period_to"] = achiveDr["usage_period_to"];
			dr["usage_amount"] = usageAmount;
			dr["total_cost"] = CommonCalc.GetTotalCost(dr);

			dt.Rows.Add(dr);
		}

		private void SetColumnsName()
		{
			dataGridView1.Columns["year"].HeaderText = "年";
			dataGridView1.Columns["month"].HeaderText = "月";
			dataGridView1.Columns["total_cost"].HeaderText = "電気料金\r\n合計";
			dataGridView1.Columns["basic_price"].HeaderText = "基本料金";
			dataGridView1.Columns["price1"].HeaderText = "電気料金\r\n1段階目";
			dataGridView1.Columns["price2"].HeaderText = "電気料金\r\n2段階目";
			dataGridView1.Columns["price3"].HeaderText = "電気料金\r\n3段階目";
			dataGridView1.Columns["adjust_price"].HeaderText = "燃料費\r\n調整額";
			dataGridView1.Columns["discount_price"].HeaderText = "セット\r\n割引額等";
			dataGridView1.Columns["re_energy_charge"].HeaderText = "再エネ\r\n促進賦課金";
			dataGridView1.Columns["usage_period_from"].HeaderText = "使用期間\r\n開始日";
			dataGridView1.Columns["usage_period_to"].HeaderText = "使用期間\r\n終了日";
			dataGridView1.Columns["usage_amount"].HeaderText = "使用量[kWh]";
		}

		private void SetFormat()
		{
			dataGridView1.Columns["total_cost"].DefaultCellStyle.Format = "N0";
			dataGridView1.Columns["basic_price"].DefaultCellStyle.Format = "#,0.##";
			dataGridView1.Columns["price1"].DefaultCellStyle.Format = "#,0.##";
			dataGridView1.Columns["price2"].DefaultCellStyle.Format = "#,0.##";
			dataGridView1.Columns["price3"].DefaultCellStyle.Format = "#,0.##";
			dataGridView1.Columns["adjust_price"].DefaultCellStyle.Format = "#,0.##";
			dataGridView1.Columns["discount_price"].DefaultCellStyle.Format = "#,0.##";
			dataGridView1.Columns["usage_amount"].DefaultCellStyle.Format = "N0";
		}

		private void InsertColumn()
		{
			if (dataGridView1.ColumnCount == 13)
			{
				DataGridViewTextBoxColumn textColumn = new()
				{
					DataPropertyName = "kind",
					Name = "kind",
					HeaderText = "データ区分"
				};
				dataGridView1.Columns.Insert(0, textColumn);
			}

			dataGridView1.Rows[0].Cells["kind"].Value = "請求実績";
			dataGridView1.Rows[1].Cells["kind"].Value = "太陽光発電なし";
		}
	}
}
