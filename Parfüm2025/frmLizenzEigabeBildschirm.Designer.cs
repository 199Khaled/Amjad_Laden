namespace Parfüm2025
{
    partial class frmLizenzEigabeBildschirm
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
            this.txtKeyFeld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnForfahren = new System.Windows.Forms.Button();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKeyFeld
            // 
            this.txtKeyFeld.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyFeld.Location = new System.Drawing.Point(39, 85);
            this.txtKeyFeld.Name = "txtKeyFeld";
            this.txtKeyFeld.Size = new System.Drawing.Size(338, 26);
            this.txtKeyFeld.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "geben Sie bitte Ihren Produktschlüssel unten ein.";
            // 
            // btnForfahren
            // 
            this.btnForfahren.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForfahren.Location = new System.Drawing.Point(39, 128);
            this.btnForfahren.Name = "btnForfahren";
            this.btnForfahren.Size = new System.Drawing.Size(150, 33);
            this.btnForfahren.TabIndex = 2;
            this.btnForfahren.Text = "Forfahren";
            this.btnForfahren.UseVisualStyleBackColor = true;
            this.btnForfahren.Click += new System.EventHandler(this.btnForfahren_Click);
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbbrechen.Location = new System.Drawing.Point(227, 128);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(150, 33);
            this.btnAbbrechen.TabIndex = 3;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // frmLizenzEigabeBildschirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 173);
            this.Controls.Add(this.btnAbbrechen);
            this.Controls.Add(this.btnForfahren);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKeyFeld);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLizenzEigabeBildschirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lizenz-Eingabe";
            this.Load += new System.EventHandler(this.frmLizenzEigabeBildschirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKeyFeld;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnForfahren;
        private System.Windows.Forms.Button btnAbbrechen;
    }
}