using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using G_POS.POS.Helpers;
using G_POS.POS.Models;
using G_POS.POS.Controllers;
using System.IO;
using G_POS.POS.Forms;
using System.Reflection;
using G_POS.POS.Utilities;

namespace G_POS.POS.Controls.POS
{
   
    public partial class ProductFinderControl : UserControl
    {
        
         #region constructors declarations and load
        private ProductController productController;
        private CustomSoundHelper SoundHelper;
        private CustomPathHelper PathHelper;
        private MDB_UserModel currentUser;
        private List<MDB_ProductModel> currentListOfProducts;
        private int TABLE_NO_SHOW = 0;

        private string CURRENT_DISPLAY_FORMAT = "DATAGRID";//BOX_LAYOUT


        //for next and prev
        private int CURRENT_PAGE = 1;
        private int COUNTS_PER_PAGE = 15;
        private int COUNTS_REMAINDER = 0;

        

        public ProductFinderControl()
        {
            InitializeComponent();
            
            productController = new ProductController();
            SoundHelper = new CustomSoundHelper();
            PathHelper = new CustomPathHelper();
            currentListOfProducts = new List<MDB_ProductModel>();

            storeItemsDataGridView.DoubleBuffered(true);

            currentUser = productController.getCurrentUser();
            currentUserLbl.Text = currentUser.full_name;

            //logo
            Image image = Image.FromFile(PathHelper.get_app_images_path() + "logo.png");
            this.goToDashBoardBtn.BackgroundImage = image;

        }
        //onload
        private void ProductFinderControl_Load(object sender, EventArgs e)
        {
            currentListOfProducts = productController.getStartUpProductsFromStore();
            this.renderProductsUI();
            this.putSearchOnFocus();
            //MessageBox.Show(currentListOfProducts[0].vat_inclusive + "");

            //this.Width = Convert.ToInt32(this.Parent.Width * 0.8);
        }
        public void switchCurrentDisplayFormat() {
            if (this.CURRENT_DISPLAY_FORMAT == "DATAGRID")
            {
                this.CURRENT_DISPLAY_FORMAT = "BOX_LAYOUT";
            }
            else {
                this.CURRENT_DISPLAY_FORMAT = "DATAGRID";
            }
        }
        public void putSearchOnFocus() {
            this.ActiveControl = this.searchKeyTxt;
            
        }

        public void connector_in_clear_searchKey() {
            if(this.autoSelectItemCheckBox.Checked == true){
                
                this.ActiveControl = this.searchKeyTxt;
                this.searchKeyTxt.Text = "";
            }
        }
        public void connector_in_clear_searchKey_after_sale()
        {
           // this.searchKeyTxt.Text = "";
            //this.ActiveControl = this.searchKeyTxt;
            //searchBtn.PerformClick();
            //this.Act
            //this.ActiveControl = this.searchKeyTxt
            this.searchKeyTxt.Focus();
            this.ActiveControl = this.searchKeyTxt;
            
            searchBtn.PerformClick();

        }
        public void Connector_in_shortcuts(string cmd)
        {//
            switch (cmd)
            {
                case "FOCUS":
                    //MessageBox.Show("Enter pressed");
                    this.putSearchOnFocus();
                    break;
                case "REFRESH_ITEMS":
                    currentListOfProducts = productController.getStartUpProductsFromStore();
                    this.renderProductsUI();
                    this.searchKeyTxt.Text = "";
                    this.putSearchOnFocus();
                    break;
                case "INPUT":
                    this.putSearchOnFocus();
                    break;
                default: break;
            }
        }
        #endregion constructors declarations and load
        //



        #region render product ui
        //they will render the UI based on the current items
        private void renderProductsUI()
        {

            if(this.CURRENT_DISPLAY_FORMAT == "DATAGRID"){
                storeItemsDataGridView.Visible = true;
                storeItemsFlowLayoutPanel.Visible = false;

                try
                {
                    var prodList = new SortableBindingList<MDB_ProductModel>(currentListOfProducts);
                    storeItemsDataGridView.DataSource = prodList;
                    storeItemsDataGridView.Update();
                    storeItemsDataGridView.Refresh();

                    storeItemsDataGridView.RowTemplate.Height = 30;
                    this.storeItemsDataGridView.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                    this.storeItemsDataGridView.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                }
                catch (Exception ex)
                {
                }
                return;//prevent to go to the box plan
            }
            //else old box layoutformat

            //enable layout
            storeItemsFlowLayoutPanel.Visible = true;
            storeItemsDataGridView.Visible = false;
            


            

            try {
                //reach pages
                int max_page = (this.currentListOfProducts.Count / this.COUNTS_PER_PAGE);
                int first_i = this.CURRENT_PAGE != max_page + 1 && this.COUNTS_REMAINDER == 0 ? (CURRENT_PAGE - 1) * COUNTS_PER_PAGE : 0;
                int last_i = this.CURRENT_PAGE != max_page + 1 && this.COUNTS_REMAINDER == 0 ? (CURRENT_PAGE * COUNTS_PER_PAGE) : this.COUNTS_REMAINDER;

                //poor page
                first_i = this.CURRENT_PAGE == 1 && currentListOfProducts.Count <= COUNTS_PER_PAGE ? 0 : first_i;
                last_i = this.CURRENT_PAGE == 1 && currentListOfProducts.Count <= COUNTS_PER_PAGE ? currentListOfProducts.Count : last_i;


                storeItemsFlowLayoutPanel.Controls.Clear();
                for (int i = first_i; i < last_i; i++)
                {

                    //create a panel
                    Panel itemBox = new Panel();
                    //itemBox.Click += p_Click;//click event
                    int ii = i;//make local copy of i while using within the delegate
                    itemBox.Click += delegate(object sender, EventArgs e) { Product_Clicked(sender, e, this.currentListOfProducts[ii]); };
                    itemBox.SuspendLayout();
                    //itemBox.AutoSize = true;
                    itemBox.Width = 300;
                    itemBox.Height = 100;
                    itemBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
                    itemBox.BackColor = System.Drawing.Color.DimGray; // Allows to see that the panel is resized for dispay
                    // itemBox.Location = new System.Drawing.Point(0, yPos);
                    //itemBox.Size = new System.Drawing.Size(200, 0);


                    /*//picture box
                    PictureBox imageControl = new PictureBox();
                    //imageControl.Click += p_Click;
                    imageControl.Click += delegate(object sender, EventArgs e) { Product_Clicked(sender, e, this.currentListOfProducts[ii]); };
                    imageControl.Width = 100;
                    imageControl.Height = 100;
                    imageControl.Location = new Point(0, 0);
                    imageControl.SizeMode = PictureBoxSizeMode.StretchImage;

                    //img
                    //Bitmap image = new Bitmap(this.getRandomImg());
                    //imageControl.Image = (Image)image;
                    imageControl.Load(@"http://localhost:1213/default.jpg");
                    itemBox.Controls.Add(imageControl);*/




                    //add label to itembox
                    Label itemName = new Label();
                    itemName.Location = new Point(0, 20);
                    itemName.Click += delegate(object sender, EventArgs e) { Product_Clicked(sender, e, this.currentListOfProducts[ii]); };
                    //itemName.Font = new Font(itemName.Font, itemName.Font.Style & ~FontStyle.Bold);
                    itemName.Font = new Font("Serif", 8, FontStyle.Bold);
                    itemName.Text = this.currentListOfProducts[i].name;//this.currentListOfProducts[i].id + " - " + this.currentListOfProducts[i].main_category_id + " - " + this.currentListOfProducts[i].name;
                    itemName.ForeColor = System.Drawing.Color.White;
                    itemName.Width = 300;
                    itemName.TextAlign = ContentAlignment.MiddleCenter;
                    itemBox.Controls.Add(itemName);

                    //description
                    Label itemDiscr = new Label();
                    itemDiscr.Location = new Point(0, 45);
                    itemDiscr.Click += delegate(object sender, EventArgs e) { Product_Clicked(sender, e, this.currentListOfProducts[ii]); };
                    //itemDiscr.Font = new Font(itemName.Font, itemName.Font.Style & ~FontStyle.Bold);
                    itemDiscr.Font = new Font("Serif", 7, FontStyle.Bold);
                   // itemDiscr.Text = this.currentListOfProducts[i].description;//this.currentListOfProducts[i].id + " - " + this.currentListOfProducts[i].main_category_id + " - " + this.currentListOfProducts[i].name;
                    //itemDiscr.Text = this.currentListOfProducts[i].vat_inclusive + "-" + this.currentListOfProducts[i].vat_amt;

                    //hide remains counts
                    if (productController.getAppConfigs().SHOW_CURRENT_QTY == true)
                    {
                        itemDiscr.Text = "( " + this.currentListOfProducts[i].current_qty + "rem ) " + this.currentListOfProducts[i].description;
         
                    }else{
                        itemDiscr.Text = /*"( " + this.currentListOfProducts[i].current_qty + "rem ) "*/"( # rem ) " + this.currentListOfProducts[i].description;
                    
                    }
                    
                    itemDiscr.ForeColor = System.Drawing.Color.Orange;
                    itemDiscr.Width = 300;
                    itemDiscr.TextAlign = ContentAlignment.MiddleCenter;
                    itemBox.Controls.Add(itemDiscr);

                    Label itemPrice = new Label();
                    itemPrice.Location = new Point(0, 70);
                    itemPrice.Click += delegate(object sender, EventArgs e) { Product_Clicked(sender, e, this.currentListOfProducts[ii]); };
                    itemPrice.Text = "" + this.currentListOfProducts[i].retail_price.ToString("#,##0.00");
                    itemDiscr.Font = new Font("Serif", 9, FontStyle.Bold);
                    //itemPrice.Text = "" + String.Format("{0:C}", this.currentListOfProducts[i].retail_price); //--has $ sign + ,
                    itemPrice.ForeColor = System.Drawing.Color.White;
                    itemPrice.Width = 300;
                    itemPrice.TextAlign = ContentAlignment.MiddleCenter;
                    itemBox.Controls.Add(itemPrice);


                    storeItemsFlowLayoutPanel.Controls.Add(itemBox);
                    this.putSearchOnFocus();
                }
            }catch(Exception ex){
            
            }
          
        }//
        #endregion

        //onclick panel item
        void Product_Clicked(object sender, EventArgs e, MDB_ProductModel product)
        {
            G_POS.POS.Forms.POSForm pf = (G_POS.POS.Forms.POSForm)this.ParentForm;
            pf.connect_store_n_receipt_send_this_item(product);
            this.putSearchOnFocus();
            connector_in_clear_search();
        }


        public void connector_in_clear_search() {
            this.searchKeyTxt.Text = "";
            this.putSearchOnFocus();
        }

        private void pollDisplay(string value)
        {
            //save the command to the display poll
            string path = @"c:\gpoll\data.txt";
            System.IO.File.WriteAllText(path, value);
        }


        //clicks eg buttons
        #region ui_clicks
        private void UI_BTN_CLICKS(object sender, EventArgs e)
        {
            Button input = (Button)sender;
            switch (input.Name)
            {//
                case "salesBtn": {
                    SalesForm sform = new SalesForm();
                    sform.ShowDialog();
                    break;
                    }
                case "refreshRecentlyListBtn":
                    {
                        currentListOfProducts = productController.getStartUpProductsFromStore();
                        this.renderProductsUI();
                        break;
                    }
                case "switchDisplayFormatBtn": {
                    this.switchCurrentDisplayFormat();
                    this.searchKeyTxt.Text = "";
                    currentListOfProducts = productController.getStartUpProductsFromStore();
                    this.renderProductsUI();
                    break;
                }
                case "goToDashBoardBtn":
                    {
                        //F_OrdersMaintainer pf = (F_OrdersMaintainer)this.ParentForm;
                        //pf.Connector_2_dashboard();
                        break;
                    }
                case "searchBtn":
                    {
                        //currentListOfProducts = productController.getProductsBasedOnSearchKey(searchKeyTxt.Text);
                        if (searchKeyTxt.Text == "")
                        {
                            currentListOfProducts = productController.getStartUpProductsFromStore();
                        }
                        else
                        {
                            currentListOfProducts = productController.getProductsBasedOnSearchKey(searchKeyTxt.Text);
                        }
                        this.renderProductsUI();
                        if (this.autoSelectItemCheckBox.Checked == true && currentListOfProducts.Count == 1)
                        {
                            //MessageBox.Show("Auto select");
                            G_POS.POS.Forms.POSForm pf = (G_POS.POS.Forms.POSForm)this.ParentForm;
                            pf.connect_store_n_receipt_send_this_item(currentListOfProducts[0]);

                            this.putSearchOnFocus();
                            this.searchKeyTxt.Text = "";
                        }
                        break;
                    }
                case "btnClearSearchBox":
                    {
                        this.searchKeyTxt.Text = "";
                        currentListOfProducts = productController.getStartUpProductsFromStore();
                        this.renderProductsUI();
                        break;
                    }
                case "EXITBtn"://clearReceiptSectBtn
                    {
                        pollDisplay("0");
                        Application.Exit();
                        /*F_OrdersMaintainer pf = (F_OrdersMaintainer)this.ParentForm;
                        pf.Connector_store_2_receipt_clear_receipt_items();
                        //hide table no show
                        tableNoLbl.Visible = false;
                        tableNoTxt.Visible = false;
                        tableNoTxt.Text = -1 + "";
                        this.TABLE_NO_SHOW = 0;*/
                        //this.putSearchOnFocus();
                        break;
                    }
                case "forTableBtn":
                    {
                        if ((tableNoLbl.Visible == true) && (tableNoTxt.Visible = true))
                        {
                            tableNoLbl.Visible = false;
                            tableNoTxt.Visible = false;
                            this.TABLE_NO_SHOW = 0;
                        }
                        else
                        {
                            tableNoLbl.Visible = true;
                            tableNoTxt.Visible = true;
                            this.TABLE_NO_SHOW = 1;
                        }
                        break;
                    }

                //prev and next btn
                case "nextBtn":
                    {
                        int max_page = (this.currentListOfProducts.Count / this.COUNTS_PER_PAGE);
                        if (this.CURRENT_PAGE == max_page)
                        {
                            this.COUNTS_REMAINDER = (this.currentListOfProducts.Count % this.COUNTS_PER_PAGE);
                        }

                        if (this.COUNTS_REMAINDER != 0) max_page += 1;
                        //MessageBox.Show("items :" + currentListOfProducts.Count + "\nmax:" + max_page + "\nCurr:" + this.CURRENT_PAGE + "\nRemainder" + this.COUNTS_REMAINDER);
                        //check 

                        if (!(this.CURRENT_PAGE >= max_page))
                        {
                            this.CURRENT_PAGE += 1;
                            this.renderProductsUI();
                        }
                        else { }//max page
                        this.putSearchOnFocus();
                        break;
                    }
                case "prevBtn":
                    {
                        this.COUNTS_REMAINDER = 0;
                        //basic
                        if (!(this.CURRENT_PAGE - 1 == 0))
                        {
                            this.CURRENT_PAGE -= 1;
                            this.renderProductsUI();
                        }
                        else { }//-1
                        this.putSearchOnFocus();
                        break;
                    }
                case "currentOrdersBtn":
                    //MyRestaurant.Restaurant.Controls.OrdersFlow.CurrentOrders.CurrentOrdersForm fm = new MyRestaurant.Restaurant.Controls.OrdersFlow.CurrentOrders.CurrentOrdersForm();
                    //fm.ShowDialog();
                    break;
                case "x": break;
            }
        }
        #endregion ui_clicks









        private void goToDashBoardBtn_Click(object sender, EventArgs e)
        {
            pollDisplay("0");
            Application.Exit();
        }

        private void clearReceiptSectBtn_Click(object sender, EventArgs e)
        {
            //clearReceiptSectBtn //tell parent form want to tell the receipt control that am done...
            G_POS.POS.Forms.POSForm pf = (G_POS.POS.Forms.POSForm)this.ParentForm;
            pf.connect_store_n_receipt_gen_clear_all();

        }

        /// <summary>
        /// //////////
        /// </summary>
        public class Pager
        {
            public int START_INDEX { get; set; }
            public int END_INDEX { get; set; }
            public int NO_PER_SECTION { get; set; }
            public int NO_ITEMS { get; set; }
            public Pager()
            {

            }
            public Pager(int i, int j, int k, int l)
            {
                START_INDEX = i;
                END_INDEX = j;
                NO_PER_SECTION = k;
                NO_ITEMS = l;
            }

        }
        /*on search changed*/
        private void searchKeyTxt_TextChanged(object sender, EventArgs e)
        {
            /*if (searchKeyTxt.Text.Length < 3)
            {
                return;
            }*/
            if (searchKeyTxt.Text == "")
            {
                currentListOfProducts = productController.getStartUpProductsFromStore();
            }
            else {
                currentListOfProducts = productController.getProductsBasedOnSearchKey(searchKeyTxt.Text);
            }
            this.renderProductsUI();

            //check if the auto select the item checked
            /*if (this.autoSelectItemCheckBox.Checked == true && currentListOfProducts.Count == 1)
            {
                //MessageBox.Show("Auto select");
                G_POS.POS.Forms.POSForm pf = (G_POS.POS.Forms.POSForm)this.ParentForm;
                pf.connect_store_n_receipt_send_this_item(currentListOfProducts[0]);
                
                //System.Threading.Thread.Sleep(100);
                this.searchKeyTxt.Text = "";
                //this.putSearchOnFocus();
                //this.searchKeyTxt.Text = "X";
            }*/
        }

        private void autoSelectItemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.putSearchOnFocus();
        }

        //on focus
        private void searchKeyTxt_Enter(object sender, EventArgs e)
        { }

        private void searchKeyTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                searchBtn.PerformClick();
                //MessageBox.Show("Enter");

            }
            //else if(e.KeyChar == (char)Keys.Down){
              //  MessageBox.Show("Down pressed");
            //}
        }
        private void searchKeyTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                // Place logic for textbox here
                storeItemsDataGridView.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                storeItemsDataGridView.Focus();
            }
        }


        /*DATAGRID*/
        //get current row
        private int get_selected_row()
        {
            try
            {
                int i = storeItemsDataGridView.CurrentCell.RowIndex;
                string id = storeItemsDataGridView.Rows[i].Cells["id"].Value.ToString();
                return Convert.ToInt32(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry we cannot find specified row!", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        //

        //get product prod from given id
        private MDB_ProductModel getProductObjectFromId(int id)
        {
            MDB_ProductModel _model = null;
            for (var i = 0; i < currentListOfProducts.Count; i++)
            {
                if (currentListOfProducts[i].id == id)
                {
                    //MessageBox.Show(productsList[i].is_raw + "");
                    _model = currentListOfProducts[i];
                }
            }
            return _model;
        }
        //

        private void storeItemsDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == 13) //'Enter Key
            {
                 this.storeItemsDataGridView.CurrentRow.Selected = true;
                 e.Handled = true;

                 var selIndex = get_selected_row();
                 if (selIndex == -1) return;
                 var prodObj = getProductObjectFromId(selIndex);

                 //MessageBox.Show("selce");
                 G_POS.POS.Forms.POSForm pf = (G_POS.POS.Forms.POSForm)this.ParentForm;
                 pf.connect_store_n_receipt_send_this_item(prodObj);
                 this.putSearchOnFocus();
                 connector_in_clear_search();

                 storeItemsDataGridView.Refresh();
            }
        }

        private void storeItemsDataGridView_DoubleClick(object sender, EventArgs e)
        {
            var selIndex = get_selected_row();
            if (selIndex == -1) return;
            var prodObj = getProductObjectFromId(selIndex);

            //MessageBox.Show("selce");
            G_POS.POS.Forms.POSForm pf = (G_POS.POS.Forms.POSForm)this.ParentForm;
            pf.connect_store_n_receipt_send_this_item(prodObj);
            this.putSearchOnFocus();
            connector_in_clear_search();

            storeItemsDataGridView.Refresh();
        }


      

        ///////////////



    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
