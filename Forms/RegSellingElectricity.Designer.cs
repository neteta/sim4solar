namespace sim4solar.Forms
{
	partial class RegSellingElectricity
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
			dateTimePicker1 = new DateTimePicker();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			textBox1 = new TextBox();
			label4 = new Label();
			textBox2 = new TextBox();
			dateTimePicker2 = new DateTimePicker();
			label5 = new Label();
			dateTimePicker3 = new DateTimePicker();
			button1 = new Button();
			SuspendLayout();
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.CustomFormat = "yyyy/MM";
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			dateTimePicker1.Location = new Point(93, 3);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(106, 23);
			dateTimePicker1.TabIndex = 0;
			dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
			dateTimePicker1.DropDown += DateTimePicker1_DropDown;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(55, 15);
			label1.TabIndex = 1;
			label1.Text = "対象年月";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 40);
			label2.Name = "label2";
			label2.Size = new Size(75, 15);
			label2.TabIndex = 2;
			label2.Text = "売電金額[円]";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 75);
			label3.Name = "label3";
			label3.Size = new Size(55, 15);
			label3.TabIndex = 3;
			label3.Text = "使用期間";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(93, 37);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(106, 23);
			textBox1.TabIndex = 4;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(12, 106);
			label4.Name = "label4";
			label4.Size = new Size(75, 15);
			label4.TabIndex = 5;
			label4.Text = "電力量[kWh]";
			// 
			// textBox2
			// 
			textBox2.Location = new Point(93, 103);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(106, 23);
			textBox2.TabIndex = 6;
			// 
			// dateTimePicker2
			// 
			dateTimePicker2.CustomFormat = "yyyy/MM/dd";
			dateTimePicker2.Format = DateTimePickerFormat.Custom;
			dateTimePicker2.Location = new Point(93, 69);
			dateTimePicker2.Name = "dateTimePicker2";
			dateTimePicker2.Size = new Size(106, 23);
			dateTimePicker2.TabIndex = 7;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(205, 75);
			label5.Name = "label5";
			label5.Size = new Size(19, 15);
			label5.TabIndex = 8;
			label5.Text = "～";
			// 
			// dateTimePicker3
			// 
			dateTimePicker3.CustomFormat = "yyyy/MM/dd";
			dateTimePicker3.Format = DateTimePickerFormat.Custom;
			dateTimePicker3.Location = new Point(230, 69);
			dateTimePicker3.Name = "dateTimePicker3";
			dateTimePicker3.Size = new Size(106, 23);
			dateTimePicker3.TabIndex = 9;
			// 
			// button1
			// 
			button1.Location = new Point(584, 292);
			button1.Name = "button1";
			button1.Size = new Size(78, 32);
			button1.TabIndex = 10;
			button1.Text = "登録";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// RegSellingElectricity
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(674, 336);
			Controls.Add(button1);
			Controls.Add(dateTimePicker3);
			Controls.Add(label5);
			Controls.Add(dateTimePicker2);
			Controls.Add(textBox2);
			Controls.Add(label4);
			Controls.Add(textBox1);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(dateTimePicker1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "RegSellingElectricity";
			Text = "RegSellingElectricity";
			Load += RegSellingElectricity_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DateTimePicker dateTimePicker1;
		private Label label1;
		private Label label2;
		private Label label3;
		private TextBox textBox1;
		private Label label4;
		private TextBox textBox2;
		private DateTimePicker dateTimePicker2;
		private Label label5;
		private DateTimePicker dateTimePicker3;
		private Button button1;
	}
}