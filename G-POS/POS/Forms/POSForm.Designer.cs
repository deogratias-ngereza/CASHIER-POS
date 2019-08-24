namespace G_POS.POS.Forms
{
    partial class POSForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POSForm));
            this.receiptGeneratorControl = new G_POS.POS.Controls.POS.ReceiptGeneratorControl();
            this.productFinderControl = new G_POS.POS.Controls.POS.ProductFinderControl();
            this.SuspendLayout();
            // 
            // receiptGeneratorControl
            // 
            this.receiptGeneratorControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiptGeneratorControl.AutoSize = true;
            this.receiptGeneratorControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.receiptGeneratorControl.Location = new System.Drawing.Point(782, 12);
            this.receiptGeneratorControl.Name = "receiptGeneratorControl";
            this.receiptGeneratorControl.Size = new System.Drawing.Size(325, 459);
            this.receiptGeneratorControl.TabIndex = 1;
            // 
            // productFinderControl
            // 
            this.productFinderControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productFinderControl.AutoScroll = true;
            this.productFinderControl.AutoSize = true;
            this.productFinderControl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.productFinderControl.Location = new System.Drawing.Point(12, 12);
            this.productFinderControl.Name = "productFinderControl";
            this.productFinderControl.Size = new System.Drawing.Size(764, 469);
            this.productFinderControl.TabIndex = 0;
            this.productFinderControl.Load += new System.EventHandler(this.productFinderControl1_Load);
            // 
            // POSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1119, 464);
            this.Controls.Add(this.receiptGeneratorControl);
            this.Controls.Add(this.productFinderControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "POSForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GMTech POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.POSForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.POSForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.POS.ProductFinderControl productFinderControl;
        private Controls.POS.ReceiptGeneratorControl receiptGeneratorControl;

    }
}