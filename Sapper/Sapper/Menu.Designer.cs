namespace Sapper
{
    partial class Menu
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
            this.btn9 = new System.Windows.Forms.Button();
            this.btn16 = new System.Windows.Forms.Button();
            this.btnRand = new System.Windows.Forms.Button();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(96, 29);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(137, 49);
            this.btn9.TabIndex = 0;
            this.btn9.Text = "Режим 9х9 (10 бомб)";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btn16
            // 
            this.btn16.Location = new System.Drawing.Point(96, 93);
            this.btn16.Name = "btn16";
            this.btn16.Size = new System.Drawing.Size(137, 53);
            this.btn16.TabIndex = 1;
            this.btn16.Text = "Режим 16х16 (40 бомб)";
            this.btn16.UseVisualStyleBackColor = true;
            this.btn16.Click += new System.EventHandler(this.btn16_Click);
            // 
            // btnRand
            // 
            this.btnRand.Location = new System.Drawing.Point(96, 212);
            this.btnRand.Name = "btnRand";
            this.btnRand.Size = new System.Drawing.Size(137, 23);
            this.btnRand.TabIndex = 2;
            this.btnRand.Text = "произвольный режим";
            this.btnRand.UseVisualStyleBackColor = true;
            this.btnRand.Click += new System.EventHandler(this.btnRand_Click);
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(170, 162);
            this.tbHeight.Multiline = true;
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(63, 20);
            this.tbHeight.TabIndex = 3;
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(170, 188);
            this.tbWidth.Multiline = true;
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(63, 20);
            this.tbWidth.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ширина";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Высота";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 259);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbWidth);
            this.Controls.Add(this.tbHeight);
            this.Controls.Add(this.btnRand);
            this.Controls.Add(this.btn16);
            this.Controls.Add(this.btn9);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn16;
        private System.Windows.Forms.Button btnRand;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}