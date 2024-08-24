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
            button2 = new Button();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Size = new Size(1214, 507);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(0, 163);
            button2.Name = "button2";
            button2.Size = new Size(247, 34);
            button2.TabIndex = 0;
            button2.Text = "残債確認";
            button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            label2.Location = new Point(7, 135);
            label2.Name = "label2";
            label2.Size = new Size(89, 25);
            label2.TabIndex = 0;
            label2.Text = "データ参照";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            label1.Location = new Point(7, 8);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 0;
            label1.Text = "データ登録";
            // 
            // button1
            // 
            button1.Location = new Point(0, 38);
            button1.Name = "button1";
            button1.Size = new Size(247, 34);
            button1.TabIndex = 0;
            button1.Text = "月次データ登録";
            button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 507);
            Controls.Add(splitContainer1);
            Name = "MainForm";
            Text = "sim4solar";
            Load += MainForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button button2;
        private Label label2;
        private Label label1;
        private Button button1;
    }
}
