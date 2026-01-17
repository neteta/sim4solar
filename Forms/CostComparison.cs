using Microsoft.Data.Sqlite;
using sim4solar.Common;
using sim4solar.Entity;
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
			string sql = DBUtil.GetSelectSqlStatement(DBUtil.SqlType.Select, DBConsts.QUERY_ID_ELECTRICITY_BILL);

			List<SqliteParameter> parameters =
				[
					new SqliteParameter(ElectricityBill.YEAR, targetYM.Year),
					new SqliteParameter(ElectricityBill.MONTH, targetYM.Month)
				];

			DataTable dt = DBAccess.Select(sql, parameters.ToArray());
			if (dt.Rows.Count == 0)
			{
				MessageBox.Show("対象データがありません。");
				return;
			}

			sql = DBUtil.GetSelectSqlStatement(DBUtil.SqlType.Select, DBConsts.QUERY_ID_POWER_GENERATION_RESULTS);
			parameters.Clear();
			parameters.Add(new SqliteParameter(PowerGenerationResults.SEARCH_START_DATE, (string)dt.Rows[0][ElectricityBill.USAGE_PERIOD_FROM]));
			parameters.Add(new SqliteParameter(PowerGenerationResults.SEARCH_END_DATE, (string)dt.Rows[0][ElectricityBill.USAGE_PERIOD_TO]));

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
			label3.Text = ((string)dt.Rows[0][ElectricityBill.USAGE_PERIOD_FROM]).Replace("-", "/");
			label5.Text = ((string)dt.Rows[0][ElectricityBill.USAGE_PERIOD_TO]).Replace(" -", "/");
			label7.Text = string.Format("{0:N0}",
				(long)dt.Rows[1][ElectricityBill.TOTAL_COST] - (long)dt.Rows[0][ElectricityBill.TOTAL_COST]) + "円";
		}

		private void GetComparisonRow(DataTable dt, DataTable dtPowerGenResult)
		{
			// 制約を解除しておく
			dt.Constraints.Clear();

			DataRow achiveDr = dt.Rows[0];

			string sql = DBUtil.GetSelectSqlStatement(DBUtil.SqlType.Select, DBConsts.QUERY_ID_MST_CODE);
			List<SqliteParameter> parameters =
			[
				new SqliteParameter(MstCode.CODE, MainCode.C001),
				// 使用期間の開始日を基準に取得
				new SqliteParameter(MstCode.TARGET_DATE, achiveDr[ElectricityBill.USAGE_PERIOD_FROM]),
			];
			DataTable dtMst = DBAccess.Select(sql, parameters.ToArray());
			if (dtMst.Rows.Count == 0)
			{
				MessageBox.Show("マスタデータが見つかりません。");
				return;
			}

			parameters.Clear();
			parameters.Add(new SqliteParameter(MstCode.CODE, MainCode.C001));
			// 燃料調整費については、請求年月を基準に取得
			parameters.Add(new SqliteParameter(MstCode.TARGET_DATE, dateTimePicker1.Value.ToString("yyyy-MM-dd")));
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

			dr[ElectricityBill.YEAR] = achiveDr[ElectricityBill.YEAR];
			dr[ElectricityBill.MONTH] = achiveDr[ElectricityBill.MONTH];
			dr[ElectricityBill.BASIC_PRICE] = achiveDr[ElectricityBill.BASIC_PRICE];
			dr[ElectricityBill.PRICE1] = CommonCalc.GetPrice1(intUsageAmount, CommonUtil.GetDoubleValue(dtMst, SubCode.C001_02));
			dr[ElectricityBill.PRICE2] = CommonCalc.GetPrice2(intUsageAmount, CommonUtil.GetDoubleValue(dtMst, SubCode.C001_03));
			dr[ElectricityBill.PRICE3] = CommonCalc.GetPrice3(intUsageAmount, CommonUtil.GetDoubleValue(dtMst, SubCode.C001_04));
			dr[ElectricityBill.ADJUST_PRICE] = CommonCalc.GetAdjustPrice(intUsageAmount, CommonUtil.GetDoubleValue(dtMst4Adjust, SubCode.C001_06));
			dr[ElectricityBill.DISCOUNT_PRICE] = CommonCalc.GetDiscountPrice(dr);
			dr[ElectricityBill.RE_ENERGY_CHARGE] = reEnergeChage;
			dr[ElectricityBill.USAGE_PERIOD_FROM] = achiveDr[ElectricityBill.USAGE_PERIOD_FROM];
			dr[ElectricityBill.USAGE_PERIOD_TO] = achiveDr[ElectricityBill.USAGE_PERIOD_TO];
			dr[ElectricityBill.USAGE_AMOUNT] = usageAmount;
			dr[ElectricityBill.TOTAL_COST] = CommonCalc.GetTotalCost(dr);

			dt.Rows.Add(dr);
		}

		private void SetColumnsName()
		{
			dataGridView1.Columns[ElectricityBill.YEAR].HeaderText = "年";
			dataGridView1.Columns[ElectricityBill.MONTH].HeaderText = "月";
			dataGridView1.Columns[ElectricityBill.TOTAL_COST].HeaderText = "電気料金\r\n合計";
			dataGridView1.Columns[ElectricityBill.BASIC_PRICE].HeaderText = "基本料金";
			dataGridView1.Columns[ElectricityBill.PRICE1].HeaderText = "電気料金\r\n1段階目";
			dataGridView1.Columns[ElectricityBill.PRICE2].HeaderText = "電気料金\r\n2段階目";
			dataGridView1.Columns[ElectricityBill.PRICE3].HeaderText = "電気料金\r\n3段階目";
			dataGridView1.Columns[ElectricityBill.ADJUST_PRICE].HeaderText = "燃料費\r\n調整額";
			dataGridView1.Columns[ElectricityBill.DISCOUNT_PRICE].HeaderText = "セット\r\n割引額等";
			dataGridView1.Columns[ElectricityBill.RE_ENERGY_CHARGE].HeaderText = "再エネ\r\n促進賦課金";
			dataGridView1.Columns[ElectricityBill.USAGE_PERIOD_FROM].HeaderText = "使用期間\r\n開始日";
			dataGridView1.Columns[ElectricityBill.USAGE_PERIOD_TO].HeaderText = "使用期間\r\n終了日";
			dataGridView1.Columns[ElectricityBill.USAGE_AMOUNT].HeaderText = "使用量[kWh]";
		}

		private void SetFormat()
		{
			dataGridView1.Columns[ElectricityBill.TOTAL_COST].DefaultCellStyle.Format = "N0";
			dataGridView1.Columns[ElectricityBill.BASIC_PRICE].DefaultCellStyle.Format = "#,0.##";
			dataGridView1.Columns[ElectricityBill.PRICE1].DefaultCellStyle.Format = "#,0.##";
			dataGridView1.Columns[ElectricityBill.PRICE2].DefaultCellStyle.Format = "#,0.##";
			dataGridView1.Columns[ElectricityBill.PRICE3].DefaultCellStyle.Format = "#,0.##";
			dataGridView1.Columns[ElectricityBill.ADJUST_PRICE].DefaultCellStyle.Format = "#,0.##";
			dataGridView1.Columns[ElectricityBill.DISCOUNT_PRICE].DefaultCellStyle.Format = "#,0.##";
			dataGridView1.Columns[ElectricityBill.USAGE_AMOUNT].DefaultCellStyle.Format = "N0";
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
