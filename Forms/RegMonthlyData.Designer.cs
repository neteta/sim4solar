namespace sim4solar
{
    partial class RegMonthlyData
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
			label1 = new Label();
			textBox1 = new TextBox();
			dateTimePicker1 = new DateTimePicker();
			label2 = new Label();
			label3 = new Label();
			textBox2 = new TextBox();
			label4 = new Label();
			label5 = new Label();
			textBox3 = new TextBox();
			textBox4 = new TextBox();
			label6 = new Label();
			textBox5 = new TextBox();
			label7 = new Label();
			dateTimePicker2 = new DateTimePicker();
			dateTimePicker3 = new DateTimePicker();
			label8 = new Label();
			button1 = new Button();
			label9 = new Label();
			label10 = new Label();
			label11 = new Label();
			textBox6 = new TextBox();
			textBox7 = new TextBox();
			textBox8 = new TextBox();
			label12 = new Label();
			textBox9 = new TextBox();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(26, 18);
			label1.Margin = new Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new Size(55, 15);
			label1.TabIndex = 0;
			label1.Text = "請求年月";
			// 
			// textBox1
			// 
			textBox1.ImeMode = ImeMode.Off;
			textBox1.Location = new Point(152, 73);
			textBox1.Margin = new Padding(2);
			textBox1.MaxLength = 6;
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(106, 23);
			textBox1.TabIndex = 4;
			textBox1.TextAlign = HorizontalAlignment.Right;
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.CustomFormat = "yyyy/MM";
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			dateTimePicker1.Location = new Point(152, 12);
			dateTimePicker1.Margin = new Padding(2);
			dateTimePicker1.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(106, 23);
			dateTimePicker1.TabIndex = 1;
			dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
			dateTimePicker1.DropDown += DateTimePicker1_DropDown;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(24, 76);
			label2.Name = "label2";
			label2.Size = new Size(99, 15);
			label2.TabIndex = 4;
			label2.Text = "電気料金合計[円]";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(26, 103);
			label3.Name = "label3";
			label3.Size = new Size(75, 15);
			label3.TabIndex = 5;
			label3.Text = "基本料金[円]";
			// 
			// textBox2
			// 
			textBox2.ImeMode = ImeMode.Off;
			textBox2.Location = new Point(152, 100);
			textBox2.Margin = new Padding(2);
			textBox2.MaxLength = 10;
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(106, 23);
			textBox2.TabIndex = 5;
			textBox2.TextAlign = HorizontalAlignment.Right;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(24, 130);
			label4.Name = "label4";
			label4.Size = new Size(93, 15);
			label4.TabIndex = 7;
			label4.Text = "電力量料金1[円]";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(24, 157);
			label5.Name = "label5";
			label5.Size = new Size(93, 15);
			label5.TabIndex = 8;
			label5.Text = "電力量料金2[円]";
			// 
			// textBox3
			// 
			textBox3.ImeMode = ImeMode.Off;
			textBox3.Location = new Point(152, 127);
			textBox3.Margin = new Padding(2);
			textBox3.MaxLength = 10;
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(106, 23);
			textBox3.TabIndex = 6;
			textBox3.TextAlign = HorizontalAlignment.Right;
			// 
			// textBox4
			// 
			textBox4.ImeMode = ImeMode.Off;
			textBox4.Location = new Point(152, 154);
			textBox4.Margin = new Padding(2);
			textBox4.MaxLength = 10;
			textBox4.Name = "textBox4";
			textBox4.Size = new Size(106, 23);
			textBox4.TabIndex = 7;
			textBox4.TextAlign = HorizontalAlignment.Right;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(24, 211);
			label6.Name = "label6";
			label6.Size = new Size(99, 15);
			label6.TabIndex = 11;
			label6.Text = "燃料費調整額[円]";
			// 
			// textBox5
			// 
			textBox5.ImeMode = ImeMode.Off;
			textBox5.Location = new Point(152, 208);
			textBox5.Margin = new Padding(2);
			textBox5.MaxLength = 10;
			textBox5.Name = "textBox5";
			textBox5.Size = new Size(106, 23);
			textBox5.TabIndex = 9;
			textBox5.TextAlign = HorizontalAlignment.Right;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(24, 49);
			label7.Margin = new Padding(2, 0, 2, 0);
			label7.Name = "label7";
			label7.Size = new Size(55, 15);
			label7.TabIndex = 13;
			label7.Text = "使用期間";
			// 
			// dateTimePicker2
			// 
			dateTimePicker2.CustomFormat = "yyyy/MM/dd";
			dateTimePicker2.Format = DateTimePickerFormat.Custom;
			dateTimePicker2.Location = new Point(152, 43);
			dateTimePicker2.Name = "dateTimePicker2";
			dateTimePicker2.Size = new Size(106, 23);
			dateTimePicker2.TabIndex = 2;
			// 
			// dateTimePicker3
			// 
			dateTimePicker3.CustomFormat = "yyyy/MM/dd";
			dateTimePicker3.Format = DateTimePickerFormat.Custom;
			dateTimePicker3.Location = new Point(287, 43);
			dateTimePicker3.Name = "dateTimePicker3";
			dateTimePicker3.Size = new Size(106, 23);
			dateTimePicker3.TabIndex = 3;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(263, 49);
			label8.Margin = new Padding(2, 0, 2, 0);
			label8.Name = "label8";
			label8.Size = new Size(19, 15);
			label8.TabIndex = 16;
			label8.Text = "～";
			// 
			// button1
			// 
			button1.Location = new Point(572, 294);
			button1.Name = "button1";
			button1.Size = new Size(90, 30);
			button1.TabIndex = 13;
			button1.Text = "登録";
			button1.UseVisualStyleBackColor = true;
			button1.Click += Button1_Click;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(24, 238);
			label9.Name = "label9";
			label9.Size = new Size(101, 15);
			label9.TabIndex = 18;
			label9.Text = "セット割引額等[円]";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(24, 265);
			label10.Name = "label10";
			label10.Size = new Size(118, 15);
			label10.TabIndex = 19;
			label10.Text = "再エネ促進賦課金[円]";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(26, 292);
			label11.Name = "label11";
			label11.Size = new Size(75, 15);
			label11.TabIndex = 20;
			label11.Text = "使用量[kWh]";
			// 
			// textBox6
			// 
			textBox6.ImeMode = ImeMode.Off;
			textBox6.Location = new Point(152, 235);
			textBox6.Margin = new Padding(2);
			textBox6.MaxLength = 10;
			textBox6.Name = "textBox6";
			textBox6.Size = new Size(106, 23);
			textBox6.TabIndex = 10;
			textBox6.TextAlign = HorizontalAlignment.Right;
			// 
			// textBox7
			// 
			textBox7.ImeMode = ImeMode.Off;
			textBox7.Location = new Point(152, 262);
			textBox7.Margin = new Padding(2);
			textBox7.MaxLength = 10;
			textBox7.Name = "textBox7";
			textBox7.Size = new Size(106, 23);
			textBox7.TabIndex = 11;
			textBox7.TextAlign = HorizontalAlignment.Right;
			// 
			// textBox8
			// 
			textBox8.ImeMode = ImeMode.Off;
			textBox8.Location = new Point(152, 289);
			textBox8.Margin = new Padding(2);
			textBox8.MaxLength = 10;
			textBox8.Name = "textBox8";
			textBox8.Size = new Size(106, 23);
			textBox8.TabIndex = 12;
			textBox8.TextAlign = HorizontalAlignment.Right;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(24, 184);
			label12.Name = "label12";
			label12.Size = new Size(93, 15);
			label12.TabIndex = 24;
			label12.Text = "電力量料金3[円]";
			// 
			// textBox9
			// 
			textBox9.ImeMode = ImeMode.Off;
			textBox9.Location = new Point(152, 181);
			textBox9.Margin = new Padding(2);
			textBox9.MaxLength = 10;
			textBox9.Name = "textBox9";
			textBox9.Size = new Size(106, 23);
			textBox9.TabIndex = 8;
			textBox9.TextAlign = HorizontalAlignment.Right;
			// 
			// RegMonthlyData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(674, 336);
			Controls.Add(textBox9);
			Controls.Add(label12);
			Controls.Add(textBox8);
			Controls.Add(textBox7);
			Controls.Add(textBox6);
			Controls.Add(label11);
			Controls.Add(label10);
			Controls.Add(label9);
			Controls.Add(button1);
			Controls.Add(label8);
			Controls.Add(dateTimePicker3);
			Controls.Add(dateTimePicker2);
			Controls.Add(label7);
			Controls.Add(textBox5);
			Controls.Add(label6);
			Controls.Add(textBox4);
			Controls.Add(textBox3);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(textBox2);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(dateTimePicker1);
			Controls.Add(textBox1);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.None;
			Margin = new Padding(2);
			Name = "RegMonthlyData";
			Text = "Form1";
			Load += RegMonthlyData_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private Label label5;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label6;
        private TextBox textBox5;
        private Label label7;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker3;
        private Label label8;
        private Button button1;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label12;
        private TextBox textBox9;
    }
}