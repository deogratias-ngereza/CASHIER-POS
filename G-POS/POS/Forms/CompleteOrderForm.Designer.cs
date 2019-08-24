namespace G_POS.POS.Forms
{
    partial class CompleteOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompleteOrderForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.printReceiptCheckBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.paidAmtTxt = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.reqAmtLbl = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.deliveryGrpComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.customerPhoneTxt = new System.Windows.Forms.TextBox();
            this.customerNameTxt = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.paymentModeTxt = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.changeAmtLbl = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.pollDisplayBtn = new System.Windows.Forms.Button();
            this.cashOptBtn = new System.Windows.Forms.Button();
            this.payOrderBtn = new System.Windows.Forms.Button();
            this.chequeOptBtn = new System.Windows.Forms.Button();
            this.creditOptBtn = new System.Windows.Forms.Button();
            this.mobileMoneyBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.printReceiptCheckBox);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.paidAmtTxt);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Controls.Add(this.pollDisplayBtn);
            this.panel1.Controls.Add(this.cashOptBtn);
            this.panel1.Controls.Add(this.payOrderBtn);
            this.panel1.Controls.Add(this.mobileMoneyBtn);
            this.panel1.Controls.Add(this.chequeOptBtn);
            this.panel1.Controls.Add(this.creditOptBtn);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 341);
            this.panel1.TabIndex = 1;
            // 
            // printReceiptCheckBox
            // 
            this.printReceiptCheckBox.AutoSize = true;
            this.printReceiptCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printReceiptCheckBox.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.printReceiptCheckBox.Location = new System.Drawing.Point(492, 256);
            this.printReceiptCheckBox.Name = "printReceiptCheckBox";
            this.printReceiptCheckBox.Size = new System.Drawing.Size(58, 20);
            this.printReceiptCheckBox.TabIndex = 6;
            this.printReceiptCheckBox.Text = "Print";
            this.printReceiptCheckBox.UseVisualStyleBackColor = true;
            this.printReceiptCheckBox.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(699, 306);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Exit";
            this.label11.Click += new System.EventHandler(this.closeCompleteForm);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(329, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Amt Paid";
            // 
            // paidAmtTxt
            // 
            this.paidAmtTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidAmtTxt.Location = new System.Drawing.Point(270, 53);
            this.paidAmtTxt.Name = "paidAmtTxt";
            this.paidAmtTxt.Size = new System.Drawing.Size(216, 35);
            this.paidAmtTxt.TabIndex = 3;
            this.paidAmtTxt.TextChanged += new System.EventHandler(this.paidAmtTxt_TextChanged);
            this.paidAmtTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.paidAmtTxt_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.reqAmtLbl);
            this.panel3.Location = new System.Drawing.Point(9, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(248, 106);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(15, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "To be paid";
            // 
            // reqAmtLbl
            // 
            this.reqAmtLbl.AutoSize = true;
            this.reqAmtLbl.BackColor = System.Drawing.Color.Transparent;
            this.reqAmtLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reqAmtLbl.ForeColor = System.Drawing.Color.Yellow;
            this.reqAmtLbl.Location = new System.Drawing.Point(13, 25);
            this.reqAmtLbl.Name = "reqAmtLbl";
            this.reqAmtLbl.Size = new System.Drawing.Size(103, 37);
            this.reqAmtLbl.TabIndex = 0;
            this.reqAmtLbl.Text = "0 Tsh";
            this.reqAmtLbl.Click += new System.EventHandler(this.reqAmtLbl_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Controls.Add(this.deliveryGrpComboBox);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.customerPhoneTxt);
            this.panel5.Controls.Add(this.customerNameTxt);
            this.panel5.Location = new System.Drawing.Point(9, 185);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(401, 91);
            this.panel5.TabIndex = 2;
            // 
            // deliveryGrpComboBox
            // 
            this.deliveryGrpComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.deliveryGrpComboBox.FormattingEnabled = true;
            this.deliveryGrpComboBox.Location = new System.Drawing.Point(129, 7);
            this.deliveryGrpComboBox.Name = "deliveryGrpComboBox";
            this.deliveryGrpComboBox.Size = new System.Drawing.Size(269, 37);
            this.deliveryGrpComboBox.TabIndex = 5;
            this.deliveryGrpComboBox.Text = "CASH";
            this.deliveryGrpComboBox.SelectedIndexChanged += new System.EventHandler(this.deliveryGrpComboBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label10.Location = new System.Drawing.Point(11, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Phone";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(11, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Name";
            // 
            // customerPhoneTxt
            // 
            this.customerPhoneTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerPhoneTxt.Location = new System.Drawing.Point(129, 45);
            this.customerPhoneTxt.Name = "customerPhoneTxt";
            this.customerPhoneTxt.Size = new System.Drawing.Size(269, 35);
            this.customerPhoneTxt.TabIndex = 3;
            this.customerPhoneTxt.Text = "NOT_MENTIONED";
            // 
            // customerNameTxt
            // 
            this.customerNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerNameTxt.Location = new System.Drawing.Point(138, 9);
            this.customerNameTxt.Name = "customerNameTxt";
            this.customerNameTxt.Size = new System.Drawing.Size(23, 35);
            this.customerNameTxt.TabIndex = 3;
            this.customerNameTxt.Text = "NOT_MENTIONED";
            this.customerNameTxt.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Controls.Add(this.paymentModeTxt);
            this.panel4.Location = new System.Drawing.Point(492, 123);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 58);
            this.panel4.TabIndex = 2;
            // 
            // paymentModeTxt
            // 
            this.paymentModeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentModeTxt.AutoSize = true;
            this.paymentModeTxt.BackColor = System.Drawing.Color.Transparent;
            this.paymentModeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentModeTxt.ForeColor = System.Drawing.Color.White;
            this.paymentModeTxt.Location = new System.Drawing.Point(19, 15);
            this.paymentModeTxt.Name = "paymentModeTxt";
            this.paymentModeTxt.Size = new System.Drawing.Size(74, 25);
            this.paymentModeTxt.TabIndex = 0;
            this.paymentModeTxt.Text = "CASH";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.changeAmtLbl);
            this.panel2.Location = new System.Drawing.Point(492, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 106);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(19, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "change";
            // 
            // changeAmtLbl
            // 
            this.changeAmtLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.changeAmtLbl.AutoSize = true;
            this.changeAmtLbl.BackColor = System.Drawing.Color.Transparent;
            this.changeAmtLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeAmtLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.changeAmtLbl.Location = new System.Drawing.Point(17, 25);
            this.changeAmtLbl.Name = "changeAmtLbl";
            this.changeAmtLbl.Size = new System.Drawing.Size(103, 37);
            this.changeAmtLbl.TabIndex = 0;
            this.changeAmtLbl.Text = "0 Tsh";
            // 
            // exitBtn
            // 
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(270, 282);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(179, 40);
            this.exitBtn.TabIndex = 1;
            this.exitBtn.Text = "EXIT";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.BTN_UI_CLICKS);
            // 
            // pollDisplayBtn
            // 
            this.pollDisplayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pollDisplayBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pollDisplayBtn.Location = new System.Drawing.Point(9, 282);
            this.pollDisplayBtn.Name = "pollDisplayBtn";
            this.pollDisplayBtn.Size = new System.Drawing.Size(252, 40);
            this.pollDisplayBtn.TabIndex = 1;
            this.pollDisplayBtn.Text = "POLL DISPLAY";
            this.pollDisplayBtn.UseVisualStyleBackColor = true;
            this.pollDisplayBtn.Click += new System.EventHandler(this.BTN_UI_CLICKS);
            // 
            // cashOptBtn
            // 
            this.cashOptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashOptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashOptBtn.Location = new System.Drawing.Point(9, 123);
            this.cashOptBtn.Name = "cashOptBtn";
            this.cashOptBtn.Size = new System.Drawing.Size(123, 40);
            this.cashOptBtn.TabIndex = 1;
            this.cashOptBtn.Text = "CASH";
            this.cashOptBtn.UseVisualStyleBackColor = true;
            this.cashOptBtn.Click += new System.EventHandler(this.BTN_UI_CLICKS);
            // 
            // payOrderBtn
            // 
            this.payOrderBtn.BackColor = System.Drawing.Color.Lime;
            this.payOrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.payOrderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payOrderBtn.ForeColor = System.Drawing.Color.Black;
            this.payOrderBtn.Location = new System.Drawing.Point(492, 187);
            this.payOrderBtn.Name = "payOrderBtn";
            this.payOrderBtn.Size = new System.Drawing.Size(240, 59);
            this.payOrderBtn.TabIndex = 1;
            this.payOrderBtn.Text = "RECEIVE";
            this.payOrderBtn.UseVisualStyleBackColor = false;
            this.payOrderBtn.Click += new System.EventHandler(this.BTN_UI_CLICKS);
            // 
            // chequeOptBtn
            // 
            this.chequeOptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chequeOptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chequeOptBtn.Location = new System.Drawing.Point(238, 123);
            this.chequeOptBtn.Name = "chequeOptBtn";
            this.chequeOptBtn.Size = new System.Drawing.Size(97, 40);
            this.chequeOptBtn.TabIndex = 1;
            this.chequeOptBtn.Text = "CHEQUE";
            this.chequeOptBtn.UseVisualStyleBackColor = true;
            this.chequeOptBtn.Click += new System.EventHandler(this.BTN_UI_CLICKS);
            // 
            // creditOptBtn
            // 
            this.creditOptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.creditOptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditOptBtn.Location = new System.Drawing.Point(138, 123);
            this.creditOptBtn.Name = "creditOptBtn";
            this.creditOptBtn.Size = new System.Drawing.Size(94, 40);
            this.creditOptBtn.TabIndex = 1;
            this.creditOptBtn.Text = "CREDIT";
            this.creditOptBtn.UseVisualStyleBackColor = true;
            this.creditOptBtn.Click += new System.EventHandler(this.BTN_UI_CLICKS);
            // 
            // mobileMoneyBtn
            // 
            this.mobileMoneyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mobileMoneyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobileMoneyBtn.Location = new System.Drawing.Point(341, 123);
            this.mobileMoneyBtn.Name = "mobileMoneyBtn";
            this.mobileMoneyBtn.Size = new System.Drawing.Size(129, 40);
            this.mobileMoneyBtn.TabIndex = 1;
            this.mobileMoneyBtn.Text = "MOBILE M.";
            this.mobileMoneyBtn.UseVisualStyleBackColor = true;
            this.mobileMoneyBtn.Click += new System.EventHandler(this.BTN_UI_CLICKS);
            // 
            // CompleteOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(776, 365);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "CompleteOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Complete Order";
            this.Load += new System.EventHandler(this.CompleteOrderForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompleteOrderForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox printReceiptCheckBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox paidAmtTxt;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label reqAmtLbl;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox deliveryGrpComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox customerPhoneTxt;
        private System.Windows.Forms.TextBox customerNameTxt;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label paymentModeTxt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label changeAmtLbl;
        private System.Windows.Forms.Button cashOptBtn;
        private System.Windows.Forms.Button payOrderBtn;
        private System.Windows.Forms.Button chequeOptBtn;
        private System.Windows.Forms.Button creditOptBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button pollDisplayBtn;
        private System.Windows.Forms.Button mobileMoneyBtn;
    }
}