namespace sim4solar.Forms
{
	partial class CostComparison
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			dataGridView1 = new DataGridView();
			label1 = new Label();
			dateTimePicker1 = new DateTimePicker();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			button1 = new Button();
			label6 = new Label();
			label7 = new Label();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(12, 38);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.Size = new Size(648, 108);
			dataGridView1.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(55, 15);
			label1.TabIndex = 1;
			label1.Text = "請求年月";
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.CustomFormat = "yyyy/MM";
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			dateTimePicker1.Location = new Point(73, 8);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(86, 23);
			dateTimePicker1.TabIndex = 2;
			dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
			dateTimePicker1.DropDown += DateTimePicker1_DropDown;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(186, 9);
			label2.Name = "label2";
			label2.Size = new Size(55, 15);
			label2.TabIndex = 3;
			label2.Text = "使用期間";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(247, 9);
			label3.Name = "label3";
			label3.Size = new Size(73, 15);
			label3.TabIndex = 4;
			label3.Text = "XXXX/XX/XX";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(326, 9);
			label4.Name = "label4";
			label4.Size = new Size(19, 15);
			label4.TabIndex = 5;
			label4.Text = "～";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(351, 9);
			label5.Name = "label5";
			label5.Size = new Size(73, 15);
			label5.TabIndex = 6;
			label5.Text = "XXXX/XX/XX";
			// 
			// button1
			// 
			button1.Location = new Point(613, 9);
			button1.Name = "button1";
			button1.Size = new Size(47, 24);
			button1.TabIndex = 7;
			button1.Text = "検索";
			button1.UseVisualStyleBackColor = true;
			button1.Click += Button1_Click;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(447, 9);
			label6.Name = "label6";
			label6.Size = new Size(31, 15);
			label6.TabIndex = 8;
			label6.Text = "差益";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(484, 9);
			label7.Name = "label7";
			label7.Size = new Size(0, 15);
			label7.TabIndex = 9;
			// 
			// CostComparison
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(673, 158);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(button1);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(dateTimePicker1);
			Controls.Add(label1);
			Controls.Add(dataGridView1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "CostComparison";
			Text = "CostComparison";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
		private Label label1;
		private DateTimePicker dateTimePicker1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Button button1;
		private Label label6;
		private Label label7;
	}
}