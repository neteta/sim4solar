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
		private void button1_Click(object sender, EventArgs e)
		{
			string filePath = SelectFile();

			if (filePath != string.Empty)
			{
				textBox1.Text = filePath;
			}
		}

		private string SelectFile()
		{
			string filePath = String.Empty;

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
		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				XElement xml = XElement.Load(Environment.CurrentDirectory + "\\" + @"Query\registration.xml");
				var sql = from item in xml.Elements("sql")
									where item?.Attribute("id")?.Value == "power_generation_results"
									select item.Value;
				string insertSql = sql.First().ToString() ?? "";
				int rowCount = 0;

				using (StreamReader sr = new StreamReader(textBox1.Text))
				{
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

						List<SqliteParameter> parameters = new List<SqliteParameter>();
						parameters.Add(new SqliteParameter("targetDate", array[0]));
						parameters.Add(new SqliteParameter("generateAmount", CommonCalc.GetDecimalValue(array[1])));
						parameters.Add(new SqliteParameter("consumptionAmount", CommonCalc.GetDecimalValue(array[2])));
						parameters.Add(new SqliteParameter("salesAmount", CommonCalc.GetDecimalValue(array[3])));
						parameters.Add(new SqliteParameter("purchasedAmount", CommonCalc.GetDecimalValue(array[4])));
						parameters.Add(new SqliteParameter("chargeAmount", CommonCalc.GetDecimalValue(array[5])));
						parameters.Add(new SqliteParameter("dischargeAmount", CommonCalc.GetDecimalValue(array[6])));

						_ = DBAccess.Insert(insertSql, parameters.ToArray());
					}
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
