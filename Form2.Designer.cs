namespace try_catch
{
    partial class Form2
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
            this.label_Fehlermeldung = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Fehlermeldung
            // 
            this.label_Fehlermeldung.AutoSize = true;
            this.label_Fehlermeldung.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_Fehlermeldung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Fehlermeldung.ForeColor = System.Drawing.Color.IndianRed;
            this.label_Fehlermeldung.Location = new System.Drawing.Point(12, 259);
            this.label_Fehlermeldung.Name = "label_Fehlermeldung";
            this.label_Fehlermeldung.Size = new System.Drawing.Size(142, 22);
            this.label_Fehlermeldung.TabIndex = 0;
            this.label_Fehlermeldung.Text = "Fehlermeldung";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::try_catch.Properties.Resources.Patrik;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(642, 384);
            this.Controls.Add(this.label_Fehlermeldung);
            this.MaximumSize = new System.Drawing.Size(664, 440);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(664, 440);
            this.Name = "Form2";
            this.Text = "Fehlermeldung";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Fehlermeldung;
    }
}