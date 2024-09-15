using sim4solar.Forms;
using System.Windows.Forms;

namespace sim4solar
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			RegMonthlyData form1 = new RegMonthlyData();
			form1.TopLevel = false;
			SetTitle("電気料金登録");
			splitContainer2.Panel2.Controls.Add(form1);
			form1.Show();
		}

		private void SetTitle(string title)
		{
			lblTitle.Text = title;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ImportPowerGenerationResult result = new ImportPowerGenerationResult();
			result.TopLevel = false;
			SetTitle("発電実績取込");
			splitContainer2.Panel2.Controls.Clear();
			splitContainer2.Panel2.Controls.Add(result);
			result.Show();
		}
	}
}
