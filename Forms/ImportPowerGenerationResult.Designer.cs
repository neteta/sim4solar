namespace sim4solar.Forms
{
	partial class ImportPowerGenerationResult
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
			textBox1 = new TextBox();
			button1 = new Button();
			button2 = new Button();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Location = new Point(12, 12);
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new Size(531, 23);
			textBox1.TabIndex = 0;
			// 
			// button1
			// 
			button1.Location = new Point(549, 7);
			button1.Name = "button1";
			button1.Size = new Size(97, 28);
			button1.TabIndex = 1;
			button1.Text = "ファイル選択";
			button1.UseVisualStyleBackColor = true;
			button1.Click += Button1_Click;
			// 
			// button2
			// 
			button2.Location = new Point(549, 41);
			button2.Name = "button2";
			button2.Size = new Size(97, 29);
			button2.TabIndex = 2;
			button2.Text = "ファイル取込";
			button2.UseVisualStyleBackColor = true;
			button2.Click += Button2_Click;
			// 
			// ImportPowerGenerationResult
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(668, 85);
			Controls.Add(button2);
			Controls.Add(button1);
			Controls.Add(textBox1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "ImportPowerGenerationResult";
			Text = "ImportPowerGenerationResult";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private Button button1;
		private Button button2;
	}
}