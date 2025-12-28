using Microsoft.Data.Sqlite;
using sim4solar.Common;

namespace sim4solar.Forms
{
	public partial class ImportPowerGenerationResult : Form
	{
		public ImportPowerGenerationResult()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Select File
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button1_Click(object sender, EventArgs e)
		{
			string filePath = SelectFile();

			if (filePath != string.Empty)
			{
				textBox1.Text = filePath;
			}
		}

		private static string SelectFile()
		{
			string filePath = string.Empty;

			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Title = "ファイル選択";
				openFileDialog.Filter = "csvファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					filePath = openFileDialog.FileName;
				}
			}

			return filePath;
		}

		/// <summary>
		/// Import File
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button2_Click(object sender, EventArgs e)
		{
			try
			{
				string insertSql = DBUtil.GetSelectSqlStatement(DBUtil.SqlType.Insert, "power_generation_results");
				int rowCount = 0;

				using StreamReader sr = new(textBox1.Text);
				string? line;
				while ((line = sr.ReadLine()) != null)
				{
					if (rowCount == 0)
					{
						rowCount++;
						continue;
					}

					rowCount++;
					string[] array = line.Split(",");

					if (string.IsNullOrEmpty(array[1]))
					{
						continue;
					}

					List<SqliteParameter> parameters =
					[
						new SqliteParameter("targetDate", CommonUtil.GetStringWithoutDblQuot(array[0])),
							new SqliteParameter("generateAmount", CommonUtil.GetDecimalValue(array[1])),
							new SqliteParameter("consumptionAmount", CommonUtil.GetDecimalValue(array[2])),
							new SqliteParameter("salesAmount", CommonUtil.GetDecimalValue(array[3])),
							new SqliteParameter("purchasedAmount", CommonUtil.GetDecimalValue(array[4])),
							new SqliteParameter("chargeAmount", CommonUtil.GetDecimalValue(array[5])),
							new SqliteParameter("dischargeAmount", CommonUtil.GetDecimalValue(array[6])),
						];

					_ = DBAccess.Insert(insertSql, parameters.ToArray());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				MessageBox.Show("エラーが発生しました。");
				return;
			}

			MessageBox.Show("取込完了");
		}
	}
}
