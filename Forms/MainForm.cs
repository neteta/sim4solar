﻿using sim4solar.Forms;

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
			Button1_Click(sender, e);
		}

		private void SetTitle(string title)
		{
			lblTitle.Text = title;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			RegMonthlyData form = new();
			ShowForm(form, "電気料金登録");
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			ImportPowerGenerationResult form = new();
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

		private void Button5_Click(object sender, EventArgs e)
		{
			RegSellingElectricity form = new();
			ShowForm(form, "売電実績登録");
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Not implemented.");
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			CostComparison form = new();
			ShowForm(form, "料金比較");
		}
	}
}
