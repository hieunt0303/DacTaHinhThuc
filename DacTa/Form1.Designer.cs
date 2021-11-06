
namespace DacTa
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBUILD = new System.Windows.Forms.Button();
            this.textINPUT = new System.Windows.Forms.RichTextBox();
            this.textOUTPUT = new System.Windows.Forms.RichTextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.txbNameFile = new System.Windows.Forms.TextBox();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1339, 24);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1339, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // btnBUILD
            // 
            this.btnBUILD.Location = new System.Drawing.Point(318, 139);
            this.btnBUILD.Name = "btnBUILD";
            this.btnBUILD.Size = new System.Drawing.Size(75, 23);
            this.btnBUILD.TabIndex = 3;
            this.btnBUILD.Text = "Build";
            this.btnBUILD.UseVisualStyleBackColor = true;
            this.btnBUILD.Click += new System.EventHandler(this.button1_Click);
            // 
            // textINPUT
            // 
            this.textINPUT.Location = new System.Drawing.Point(12, 200);
            this.textINPUT.Name = "textINPUT";
            this.textINPUT.Size = new System.Drawing.Size(618, 371);
            this.textINPUT.TabIndex = 4;
            this.textINPUT.Text = "";
            // 
            // textOUTPUT
            // 
            this.textOUTPUT.Location = new System.Drawing.Point(652, 70);
            this.textOUTPUT.Name = "textOUTPUT";
            this.textOUTPUT.Size = new System.Drawing.Size(674, 665);
            this.textOUTPUT.TabIndex = 5;
            this.textOUTPUT.Text = "";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(482, 139);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txbNameFile
            // 
            this.txbNameFile.Location = new System.Drawing.Point(36, 137);
            this.txbNameFile.Name = "txbNameFile";
            this.txbNameFile.Size = new System.Drawing.Size(157, 25);
            this.txbNameFile.TabIndex = 7;
            this.txbNameFile.Text = "Name file";
            this.txbNameFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txbNameFile_MouseClick);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(12, 598);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(618, 146);
            this.txtInfo.TabIndex = 8;
            this.txtInfo.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 576);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Output Information";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(1338, 747);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.txbNameFile);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.textOUTPUT);
            this.Controls.Add(this.textINPUT);
            this.Controls.Add(this.btnBUILD);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Formular Specification";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnBUILD;
        private System.Windows.Forms.RichTextBox textINPUT;
        private System.Windows.Forms.RichTextBox textOUTPUT;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txbNameFile;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.Label label1;
    }
}

