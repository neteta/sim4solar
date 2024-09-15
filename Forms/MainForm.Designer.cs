namespace sim4solar
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			splitContainer1 = new SplitContainer();
			button4 = new Button();
			button3 = new Button();
			label3 = new Label();
			button2 = new Button();
			label2 = new Label();
			label1 = new Label();
			button1 = new Button();
			splitContainer2 = new SplitContainer();
			lblTitle = new Label();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Margin = new Padding(2);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(button4);
			splitContainer1.Panel1.Controls.Add(button3);
			splitContainer1.Panel1.Controls.Add(label3);
			splitContainer1.Panel1.Controls.Add(button2);
			splitContainer1.Panel1.Controls.Add(label2);
			splitContainer1.Panel1.Controls.Add(label1);
			splitContainer1.Panel1.Controls.Add(button1);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(splitContainer2);
			splitContainer1.Size = new Size(850, 361);
			splitContainer1.SplitterDistance = 175;
			splitContainer1.SplitterWidth = 3;
			splitContainer1.TabIndex = 0;
			// 
			// button4
			// 
			button4.Location = new Point(0, 48);
			button4.Name = "button4";
			button4.Size = new Size(172, 23);
			button4.TabIndex = 0;
			button4.Text = "発電実績取込";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// button3
			// 
			button3.Location = new Point(2, 213);
			button3.Margin = new Padding(2);
			button3.Name = "button3";
			button3.Size = new Size(173, 20);
			button3.TabIndex = 2;
			button3.Text = "設定";
			button3.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
			label3.Location = new Point(5, 196);
			label3.Margin = new Padding(2, 0, 2, 0);
			label3.Name = "label3";
			label3.Size = new Size(61, 15);
			label3.TabIndex = 1;
			label3.Text = "メンテナンス";
			// 
			// button2
			// 
			button2.Location = new Point(0, 98);
			button2.Margin = new Padding(2);
			button2.Name = "button2";
			button2.Size = new Size(173, 20);
			button2.TabIndex = 0;
			button2.Text = "残債確認";
			button2.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
			label2.Location = new Point(5, 81);
			label2.Margin = new Padding(2, 0, 2, 0);
			label2.Name = "label2";
			label2.Size = new Size(58, 15);
			label2.TabIndex = 0;
			label2.Text = "データ参照";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
			label1.Location = new Point(5, 5);
			label1.Margin = new Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new Size(58, 15);
			label1.TabIndex = 0;
			label1.Text = "データ登録";
			// 
			// button1
			// 
			button1.Location = new Point(0, 23);
			button1.Margin = new Padding(2);
			button1.Name = "button1";
			button1.Size = new Size(173, 20);
			button1.TabIndex = 0;
			button1.Text = "電気料金登録";
			button1.UseVisualStyleBackColor = true;
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = DockStyle.Fill;
			splitContainer2.Location = new Point(0, 0);
			splitContainer2.Name = "splitContainer2";
			splitContainer2.Orientation = Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(lblTitle);
			splitContainer2.Size = new Size(672, 361);
			splitContainer2.SplitterDistance = 26;
			splitContainer2.TabIndex = 0;
			// 
			// lblTitle
			// 
			lblTitle.AutoSize = true;
			lblTitle.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
			lblTitle.Location = new Point(3, 5);
			lblTitle.Name = "lblTitle";
			lblTitle.Size = new Size(39, 15);
			lblTitle.TabIndex = 0;
			lblTitle.Text = "label4";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(850, 361);
			Controls.Add(splitContainer1);
			Margin = new Padding(2);
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "sim4solar";
			Load += MainForm_Load;
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainer1;
        private Button button2;
        private Label label2;
        private Label label1;
        private Button button1;
        private Button button3;
        private Label label3;
        private SplitContainer splitContainer2;
        private Label lblTitle;
        private Button button4;
    }
}
