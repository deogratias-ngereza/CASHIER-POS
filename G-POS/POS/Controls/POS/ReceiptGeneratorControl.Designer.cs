namespace G_POS.POS.Controls.POS
{
    partial class ReceiptGeneratorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptGeneratorControl));
            this.panel4 = new System.Windows.Forms.Panel();
            this.totalTaxesLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.itemsForReceiptDataGridView = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.completeOrder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.totalDiscountsLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.totalPriceLbl = new System.Windows.Forms.Label();
            this.clearOrderBtn = new System.Windows.Forms.Button();
            this.applyQtyBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.removeItemBtn = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.qtyCounterNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.removeItemPictureBox = new System.Windows.Forms.PictureBox();
            this.mDBSingleItemSaleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transtimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createddateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelledDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsForReceiptDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyCounterNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeItemPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDBSingleItemSaleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.totalTaxesLbl);
            this.panel4.Location = new System.Drawing.Point(78, 80);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(143, 16);
            this.panel4.TabIndex = 0;
            // 
            // totalTaxesLbl
            // 
            this.totalTaxesLbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.totalTaxesLbl.AutoSize = true;
            this.totalTaxesLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalTaxesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTaxesLbl.ForeColor = System.Drawing.Color.White;
            this.totalTaxesLbl.Location = new System.Drawing.Point(57, 0);
            this.totalTaxesLbl.Name = "totalTaxesLbl";
            this.totalTaxesLbl.Size = new System.Drawing.Size(32, 13);
            this.totalTaxesLbl.TabIndex = 0;
            this.totalTaxesLbl.Text = "0.00";
            this.totalTaxesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Discounts";
            // 
            // itemsForReceiptDataGridView
            // 
            this.itemsForReceiptDataGridView.AllowUserToAddRows = false;
            this.itemsForReceiptDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsForReceiptDataGridView.AutoGenerateColumns = false;
            this.itemsForReceiptDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.itemsForReceiptDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.itemsForReceiptDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsForReceiptDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.itemsForReceiptDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemsForReceiptDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.itemsForReceiptDataGridView.ColumnHeadersHeight = 40;
            this.itemsForReceiptDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.itemsForReceiptDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transnoDataGridViewTextBoxColumn,
            this.item_id,
            this.nameDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.discountDataGridViewTextBoxColumn,
            this.vatDataGridViewTextBoxColumn,
            this.transdateDataGridViewTextBoxColumn,
            this.transtimeDataGridViewTextBoxColumn,
            this.remarksDataGridViewTextBoxColumn,
            this.createddateDataGridViewTextBoxColumn,
            this.cancelledDataGridViewTextBoxColumn,
            this.deletedDataGridViewTextBoxColumn});
            this.itemsForReceiptDataGridView.DataSource = this.mDBSingleItemSaleBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Minion Pro", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsForReceiptDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemsForReceiptDataGridView.EnableHeadersVisualStyles = false;
            this.itemsForReceiptDataGridView.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.itemsForReceiptDataGridView.Location = new System.Drawing.Point(13, 109);
            this.itemsForReceiptDataGridView.Name = "itemsForReceiptDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemsForReceiptDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.itemsForReceiptDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.itemsForReceiptDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.itemsForReceiptDataGridView.RowTemplate.Height = 40;
            this.itemsForReceiptDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.itemsForReceiptDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemsForReceiptDataGridView.ShowCellErrors = false;
            this.itemsForReceiptDataGridView.ShowCellToolTips = false;
            this.itemsForReceiptDataGridView.ShowEditingIcon = false;
            this.itemsForReceiptDataGridView.Size = new System.Drawing.Size(356, 314);
            this.itemsForReceiptDataGridView.TabIndex = 22;
            this.itemsForReceiptDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsForReceiptDataGridView_CellValueChanged);
            this.itemsForReceiptDataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.itemsForReceiptDataGridView_UserDeletedRow);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // completeOrder
            // 
            this.completeOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.completeOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.completeOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.completeOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeOrder.ForeColor = System.Drawing.Color.White;
            this.completeOrder.Location = new System.Drawing.Point(12, 102);
            this.completeOrder.Name = "completeOrder";
            this.completeOrder.Size = new System.Drawing.Size(328, 48);
            this.completeOrder.TabIndex = 2;
            this.completeOrder.Text = "Accept";
            this.completeOrder.UseVisualStyleBackColor = false;
            this.completeOrder.Click += new System.EventHandler(this.UI_BTN_CLICKS);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.completeOrder);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 153);
            this.panel1.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Tax";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.totalDiscountsLbl);
            this.panel3.Location = new System.Drawing.Point(78, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(143, 16);
            this.panel3.TabIndex = 0;
            // 
            // totalDiscountsLbl
            // 
            this.totalDiscountsLbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.totalDiscountsLbl.AutoSize = true;
            this.totalDiscountsLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalDiscountsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDiscountsLbl.ForeColor = System.Drawing.Color.White;
            this.totalDiscountsLbl.Location = new System.Drawing.Point(57, 0);
            this.totalDiscountsLbl.Name = "totalDiscountsLbl";
            this.totalDiscountsLbl.Size = new System.Drawing.Size(32, 13);
            this.totalDiscountsLbl.TabIndex = 0;
            this.totalDiscountsLbl.Text = "0.00";
            this.totalDiscountsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Goldenrod;
            this.panel2.Controls.Add(this.totalPriceLbl);
            this.panel2.Location = new System.Drawing.Point(12, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 52);
            this.panel2.TabIndex = 0;
            // 
            // totalPriceLbl
            // 
            this.totalPriceLbl.AutoSize = true;
            this.totalPriceLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalPriceLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceLbl.ForeColor = System.Drawing.Color.Black;
            this.totalPriceLbl.Location = new System.Drawing.Point(53, 0);
            this.totalPriceLbl.Name = "totalPriceLbl";
            this.totalPriceLbl.Size = new System.Drawing.Size(32, 33);
            this.totalPriceLbl.TabIndex = 0;
            this.totalPriceLbl.Text = "0";
            this.totalPriceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clearOrderBtn
            // 
            this.clearOrderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.clearOrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearOrderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearOrderBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clearOrderBtn.Location = new System.Drawing.Point(52, 57);
            this.clearOrderBtn.Name = "clearOrderBtn";
            this.clearOrderBtn.Size = new System.Drawing.Size(58, 46);
            this.clearOrderBtn.TabIndex = 25;
            this.clearOrderBtn.Text = "Clear";
            this.clearOrderBtn.UseVisualStyleBackColor = false;
            this.clearOrderBtn.Click += new System.EventHandler(this.UI_BTN_CLICKS);
            // 
            // applyQtyBtn
            // 
            this.applyQtyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.applyQtyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyQtyBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.applyQtyBtn.Location = new System.Drawing.Point(116, 57);
            this.applyQtyBtn.Name = "applyQtyBtn";
            this.applyQtyBtn.Size = new System.Drawing.Size(52, 46);
            this.applyQtyBtn.TabIndex = 27;
            this.applyQtyBtn.Text = "Apply Qty";
            this.applyQtyBtn.UseVisualStyleBackColor = false;
            this.applyQtyBtn.Click += new System.EventHandler(this.UI_BTN_CLICKS);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "TOTAL";
            // 
            // removeItemBtn
            // 
            this.removeItemBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.removeItemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeItemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeItemBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.removeItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("removeItemBtn.Image")));
            this.removeItemBtn.Location = new System.Drawing.Point(174, 56);
            this.removeItemBtn.Name = "removeItemBtn";
            this.removeItemBtn.Size = new System.Drawing.Size(36, 46);
            this.removeItemBtn.TabIndex = 24;
            this.removeItemBtn.UseVisualStyleBackColor = false;
            this.removeItemBtn.Visible = false;
            this.removeItemBtn.Click += new System.EventHandler(this.UI_BTN_CLICKS);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(265, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 20);
            this.dateTimePicker1.TabIndex = 23;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(97, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // qtyCounterNumericUpDown
            // 
            this.qtyCounterNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.qtyCounterNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyCounterNumericUpDown.Location = new System.Drawing.Point(303, 59);
            this.qtyCounterNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.qtyCounterNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qtyCounterNumericUpDown.Name = "qtyCounterNumericUpDown";
            this.qtyCounterNumericUpDown.Size = new System.Drawing.Size(81, 44);
            this.qtyCounterNumericUpDown.TabIndex = 30;
            this.qtyCounterNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // removeItemPictureBox
            // 
            this.removeItemPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("removeItemPictureBox.Image")));
            this.removeItemPictureBox.Location = new System.Drawing.Point(17, 57);
            this.removeItemPictureBox.Name = "removeItemPictureBox";
            this.removeItemPictureBox.Size = new System.Drawing.Size(29, 44);
            this.removeItemPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.removeItemPictureBox.TabIndex = 31;
            this.removeItemPictureBox.TabStop = false;
            this.removeItemPictureBox.DoubleClick += new System.EventHandler(this.removeItemPictureBox_DoubleClick);
            // 
            // mDBSingleItemSaleBindingSource
            // 
            this.mDBSingleItemSaleBindingSource.DataSource = typeof(G_POS.POS.Models.MDB_SingleItemSale);
            // 
            // transnoDataGridViewTextBoxColumn
            // 
            this.transnoDataGridViewTextBoxColumn.DataPropertyName = "trans_no";
            this.transnoDataGridViewTextBoxColumn.HeaderText = "trans_no";
            this.transnoDataGridViewTextBoxColumn.Name = "transnoDataGridViewTextBoxColumn";
            this.transnoDataGridViewTextBoxColumn.ReadOnly = true;
            this.transnoDataGridViewTextBoxColumn.Visible = false;
            this.transnoDataGridViewTextBoxColumn.Width = 88;
            // 
            // item_id
            // 
            this.item_id.DataPropertyName = "item_id";
            this.item_id.HeaderText = "item_id";
            this.item_id.Name = "item_id";
            this.item_id.Visible = false;
            this.item_id.Width = 80;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 200F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 190;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 50;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.Width = 64;
            // 
            // discountDataGridViewTextBoxColumn
            // 
            this.discountDataGridViewTextBoxColumn.DataPropertyName = "discount";
            this.discountDataGridViewTextBoxColumn.HeaderText = "discount";
            this.discountDataGridViewTextBoxColumn.Name = "discountDataGridViewTextBoxColumn";
            this.discountDataGridViewTextBoxColumn.Width = 86;
            // 
            // vatDataGridViewTextBoxColumn
            // 
            this.vatDataGridViewTextBoxColumn.DataPropertyName = "vat";
            this.vatDataGridViewTextBoxColumn.HeaderText = "vat";
            this.vatDataGridViewTextBoxColumn.Name = "vatDataGridViewTextBoxColumn";
            this.vatDataGridViewTextBoxColumn.ReadOnly = true;
            this.vatDataGridViewTextBoxColumn.Width = 50;
            // 
            // transdateDataGridViewTextBoxColumn
            // 
            this.transdateDataGridViewTextBoxColumn.DataPropertyName = "trans_date";
            this.transdateDataGridViewTextBoxColumn.HeaderText = "trans_date";
            this.transdateDataGridViewTextBoxColumn.Name = "transdateDataGridViewTextBoxColumn";
            this.transdateDataGridViewTextBoxColumn.Visible = false;
            // 
            // transtimeDataGridViewTextBoxColumn
            // 
            this.transtimeDataGridViewTextBoxColumn.DataPropertyName = "trans_time";
            this.transtimeDataGridViewTextBoxColumn.HeaderText = "trans_time";
            this.transtimeDataGridViewTextBoxColumn.Name = "transtimeDataGridViewTextBoxColumn";
            this.transtimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // remarksDataGridViewTextBoxColumn
            // 
            this.remarksDataGridViewTextBoxColumn.DataPropertyName = "remarks";
            this.remarksDataGridViewTextBoxColumn.HeaderText = "remarks";
            this.remarksDataGridViewTextBoxColumn.Name = "remarksDataGridViewTextBoxColumn";
            this.remarksDataGridViewTextBoxColumn.Visible = false;
            this.remarksDataGridViewTextBoxColumn.Width = 84;
            // 
            // createddateDataGridViewTextBoxColumn
            // 
            this.createddateDataGridViewTextBoxColumn.DataPropertyName = "created_date";
            this.createddateDataGridViewTextBoxColumn.HeaderText = "created_date";
            this.createddateDataGridViewTextBoxColumn.Name = "createddateDataGridViewTextBoxColumn";
            this.createddateDataGridViewTextBoxColumn.Visible = false;
            this.createddateDataGridViewTextBoxColumn.Width = 116;
            // 
            // cancelledDataGridViewTextBoxColumn
            // 
            this.cancelledDataGridViewTextBoxColumn.DataPropertyName = "cancelled";
            this.cancelledDataGridViewTextBoxColumn.HeaderText = "cancelled";
            this.cancelledDataGridViewTextBoxColumn.Name = "cancelledDataGridViewTextBoxColumn";
            this.cancelledDataGridViewTextBoxColumn.Visible = false;
            this.cancelledDataGridViewTextBoxColumn.Width = 94;
            // 
            // deletedDataGridViewTextBoxColumn
            // 
            this.deletedDataGridViewTextBoxColumn.DataPropertyName = "deleted";
            this.deletedDataGridViewTextBoxColumn.HeaderText = "deleted";
            this.deletedDataGridViewTextBoxColumn.Name = "deletedDataGridViewTextBoxColumn";
            this.deletedDataGridViewTextBoxColumn.Visible = false;
            this.deletedDataGridViewTextBoxColumn.Width = 80;
            // 
            // ReceiptGeneratorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.removeItemPictureBox);
            this.Controls.Add(this.clearOrderBtn);
            this.Controls.Add(this.removeItemBtn);
            this.Controls.Add(this.itemsForReceiptDataGridView);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.applyQtyBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.qtyCounterNumericUpDown);
            this.Name = "ReceiptGeneratorControl";
            this.Size = new System.Drawing.Size(381, 598);
            this.Load += new System.EventHandler(this.ReceiptGeneratorControl_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsForReceiptDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtyCounterNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeItemPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDBSingleItemSaleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label totalTaxesLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView itemsForReceiptDataGridView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button completeOrder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label totalDiscountsLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label totalPriceLbl;
        private System.Windows.Forms.Button clearOrderBtn;
        private System.Windows.Forms.Button applyQtyBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button removeItemBtn;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.NumericUpDown qtyCounterNumericUpDown;
        private System.Windows.Forms.BindingSource mDBSingleItemSaleBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.PictureBox removeItemPictureBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn transnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transtimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createddateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cancelledDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deletedDataGridViewTextBoxColumn;

    }
}
