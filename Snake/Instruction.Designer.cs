namespace Snake
{
    partial class Instruction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instruction));
            this.lblInstrukcii = new System.Windows.Forms.Label();
            this.lblInstruciiText = new System.Windows.Forms.Label();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.cbDontShow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblInstrukcii
            // 
            this.lblInstrukcii.AutoSize = true;
            this.lblInstrukcii.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrukcii.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblInstrukcii.Location = new System.Drawing.Point(122, 46);
            this.lblInstrukcii.Name = "lblInstrukcii";
            this.lblInstrukcii.Size = new System.Drawing.Size(336, 64);
            this.lblInstrukcii.TabIndex = 0;
            this.lblInstrukcii.Text = "Инструкции";
            // 
            // lblInstruciiText
            // 
            this.lblInstruciiText.AutoSize = true;
            this.lblInstruciiText.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruciiText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblInstruciiText.Location = new System.Drawing.Point(3, 159);
            this.lblInstruciiText.Name = "lblInstruciiText";
            this.lblInstruciiText.Size = new System.Drawing.Size(562, 341);
            this.lblInstruciiText.TabIndex = 1;
            this.lblInstruciiText.Text = resources.GetString("lblInstruciiText.Text");
            this.lblInstruciiText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(158, 676);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(199, 55);
            this.btnSaveAndClose.TabIndex = 1;
            this.btnSaveAndClose.Text = "Зачувај и Затвори";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // cbDontShow
            // 
            this.cbDontShow.AutoSize = true;
            this.cbDontShow.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDontShow.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbDontShow.Location = new System.Drawing.Point(40, 626);
            this.cbDontShow.Name = "cbDontShow";
            this.cbDontShow.Size = new System.Drawing.Size(474, 31);
            this.cbDontShow.TabIndex = 3;
            this.cbDontShow.Text = "Не ми го покажувај ова прозоче следен пат";
            this.cbDontShow.UseVisualStyleBackColor = true;
            // 
            // Instruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(566, 762);
            this.Controls.Add(this.cbDontShow);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.lblInstruciiText);
            this.Controls.Add(this.lblInstrukcii);
            this.Name = "Instruction";
            this.Text = "Instruction";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstrukcii;
        private System.Windows.Forms.Label lblInstruciiText;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.CheckBox cbDontShow;
    }
}