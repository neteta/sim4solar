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
			button1_Click(sender, e);
		}

		private void SetTitle(string title)
		{
			lblTitle.Text = title;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			RegMonthlyData form = new RegMonthlyData();
			ShowForm(form, "電気料金登録");
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ImportPowerGenerationResult form = new ImportPowerGenerationResult();
			ShowForm(form, "発電実績取込");
		}

		private void ShowForm(Form form, string title)
		{
			form.TopLevel = false;
			SetTitle(title);
			splitContainer2.Panel2.Controls.Clear();
			splitContainer2.Panel2.Controls.Add(form);
			form.Show();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			RegSellingElectricity form = new RegSellingElectricity();
			ShowForm(form, "売電実績登録");
		}
	}
}
