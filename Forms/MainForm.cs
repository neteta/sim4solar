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

            splitContainer1.Panel2.Controls.Add(form1);
            form1.Show();
        }
    }
}
