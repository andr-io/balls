
namespace Graphics_1
{
    partial class Form1
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnMedia = new System.Windows.Forms.Button();
            this.btnFigure = new System.Windows.Forms.Button();
            this.pbSpinner = new System.Windows.Forms.PictureBox();
            this.panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(655, 385);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(133, 53);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnMedia
            // 
            this.btnMedia.Location = new System.Drawing.Point(12, 385);
            this.btnMedia.Name = "btnMedia";
            this.btnMedia.Size = new System.Drawing.Size(133, 53);
            this.btnMedia.TabIndex = 1;
            this.btnMedia.Text = "Media";
            this.btnMedia.UseVisualStyleBackColor = true;
            this.btnMedia.Click += new System.EventHandler(this.btnMedia_Click);
            // 
            // btnFigure
            // 
            this.btnFigure.Location = new System.Drawing.Point(151, 385);
            this.btnFigure.Name = "btnFigure";
            this.btnFigure.Size = new System.Drawing.Size(133, 53);
            this.btnFigure.TabIndex = 2;
            this.btnFigure.Text = "Figure";
            this.btnFigure.UseVisualStyleBackColor = true;
            this.btnFigure.Click += new System.EventHandler(this.btnFigure_Click);
            // 
            // pbSpinner
            // 
            this.pbSpinner.Location = new System.Drawing.Point(655, 119);
            this.pbSpinner.Name = "pbSpinner";
            this.pbSpinner.Size = new System.Drawing.Size(64, 64);
            this.pbSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSpinner.TabIndex = 3;
            this.pbSpinner.TabStop = false;
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(591, 338);
            this.panel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.pbSpinner);
            this.Controls.Add(this.btnFigure);
            this.Controls.Add(this.btnMedia);
            this.Controls.Add(this.btnClear);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnMedia;
        private System.Windows.Forms.Button btnFigure;
        private System.Windows.Forms.PictureBox pbSpinner;
        private System.Windows.Forms.Panel panel;
    }
}

