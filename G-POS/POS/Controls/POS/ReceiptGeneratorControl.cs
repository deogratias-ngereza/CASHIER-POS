using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using G_POS.POS.Models;
using G_POS.POS.Forms;
using G_POS.POS.Helpers;

namespace G_POS.POS.Controls.POS
{
    public partial class ReceiptGeneratorControl : UserControl
    {
        private BindingList<MDB_SingleItemSale> itemsListForReceipt;
        private int ITEM_COUNTER = 0;
        private int MAX_ITEMS_COUNTS = 150;     
        private CustomSoundHelper soundHelper;



        public ReceiptGeneratorControl()
        {
            InitializeComponent();
            itemsListForReceipt = new BindingList<MDB_SingleItemSale>();
            soundHelper = new CustomSoundHelper();
        }

        private void ReceiptGeneratorControl_Load(object sender, EventArgs e)
        {

            //Bind list to the datagrid
            itemsForReceiptDataGridView.DataSource = itemsListForReceipt;
            itemsListForReceipt.Clear();

            //this.Width = Convert.ToInt32(this.Parent.Width * 0.2);
        }

        #region connectors
        public void connector_in_clear_all_items_in_order(){
            //MessageBox.Show("Clear all items");
            clearAllItems();
        }
        public void connector_in_push_item_for_receipt(MDB_ProductModel product)
        {
            //check for item already exists or not
            bool res = checkIfProductExist(product);

            //** check if negative qty **//
            /*if (product.current_qty <= 0) {
                MessageBox.Show("SORRY ITEM OUT OF STOCK!!\nPlease refer to stock keeper!");
                return;
            }*/
            if(product.retail_price == 0){
                MessageBox.Show("SORRY NO PRICE ITEM DETECTED!! \n DONT SELL THIS ITEM TILL PRICE FIX!!");
                return;
            }
            //****//
            if (res == true)
            {
                //sound
                soundHelper.getDefaultTone(); 
                this.updateTheExistingProduct(product);
            }
            else
            {
                //depend on the size on the receipt
                if (this.ITEM_COUNTER >= this.MAX_ITEMS_COUNTS)
                {
                    MessageBox.Show("MAX ITEMS FOR FIRST RECEIPT\nSAVE / PRINT THIS FIRST\nTHEN CLEAR", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    //sound
                    soundHelper.getDefaultTone(); 
                    this.addItemToTheList(product);
                    this.ITEM_COUNTER += 1;
                }
            }
        }
        public void Connector_in_clearAllItemsForReceipt()
        {
            this.clearAllItems();
        }
        // -1 ,0 pending ,1-success
        public void Connecter_in_internal_order_status_results(int status)
        {

            //TODO:: check status
            if (status == 0)
            {
                this.clearAllItems();
                POSForm pf = (POSForm)this.ParentForm;
                pf.connect_receipt_2_store_clear_search_Key_after_sale();
            }
            else
            {
            }

        }

        public void Connector_in_shortcuts(string cmd) {
            switch(cmd){
                case "ENTER":
                    //MessageBox.Show("Enter pressed");
                    break;
                case "TAB":
                    if (this.itemsListForReceipt.Count != 0)
                    {
                        CompleteOrderForm frm = new CompleteOrderForm(this, this.itemsListForReceipt.ToList());
                        frm.ShowDialog();
                    }
                    break;
                case "CLEAR":
                    this.clearAllItems();
                    break;
                case "QTY":
                    this.qtyCounterNumericUpDown.Focus();
                    break;
                case "APPLY_QTY":
                    int qty = Convert.ToInt32(qtyCounterNumericUpDown.Value);
                    applyQtyToSelectedItem(qty);
                    break;
                case "TABLE":
                    this.itemsForReceiptDataGridView.Focus();
                    break;
                default : break;
            }
        }
        #endregion connectors




        private string getSimpleName(string name) {
            //return name.Replace(" \'", " ").Replace("\' ", " ");
            string Result1 = name.Replace("'", " ").Replace("`"," ");
            return Result1;
        }


        //add item to the list
        private void addItemToTheList(MDB_ProductModel product)
        {

            //create new product
            MDB_SingleItemSale item = new MDB_SingleItemSale()
            {
                id = product.id,
                item_id = product.id,
                name = this.getSimpleName(product.name),//product.name,//remove all the app
                price = product.retail_price,
                discount = product.discount_amt,//if product is on offer
                vat = (product.vat_inclusive == 1)? Convert.ToSingle((product.retail_price * 0.18)) : product.vat_amt,//product.vat_amt,
                vat_inclusive = product.vat_inclusive,
                qty = 1
            };
            //MessageBox.Show(item.name);

            //itemsListForReceipt.Add(item);
            itemsListForReceipt.Insert(0,item);
            itemsForReceiptDataGridView.Update();
            itemsForReceiptDataGridView.Refresh(); //refresh the list
            this.do_calculations();

            //command the parent form to clear the search for the next scan
            POSForm pf = (POSForm)this.ParentForm;
            pf.connect_receipt_2_store_clear_search_Key();
        }//

        private void removeItemFromTheList(int id)
        {
            try
            {
                var itemToRemove = this.itemsListForReceipt.Single(i => i.id == id);
                this.itemsListForReceipt.Remove(itemToRemove);
                itemsForReceiptDataGridView.Refresh(); //refresh the list
                this.do_calculations();
                this.ITEM_COUNTER -= 1;
            }
            catch (Exception)
            {
            }
        }//

        //add qty and amount for ready existing item
        private bool checkIfProductExist(MDB_ProductModel product)
        {
            bool truth = false;
            List<MDB_SingleItemSale> list = itemsListForReceipt.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (Convert.ToInt32(list[i].id) == Convert.ToInt32(product.id))
                {
                    truth = true; break;
                }
            }
            return truth;
        }//


        //do calculations
        private void do_calculations()
        {
           // if (itemsListForReceipt is Nullable) return;

            List<MDB_SingleItemSale> list = itemsListForReceipt.ToList();
            double sum = 0, tax = 0, discounts = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int no_of_products = list[i].qty == 0 ? 1 : list[i].qty;
                double temp_sum = list[i].price * no_of_products;
                double temp_tax = list[i].vat * no_of_products;
                double temp_discounts = list[i].discount * no_of_products;
                sum += temp_sum;
                tax += temp_tax;
                discounts += temp_discounts;
            }

            //minus discount from sale


            //update the UI
            totalPriceLbl.Text = (sum - discounts).ToString("#,##0.00");//"" + sum.ToString("#,##0.00");
            totalDiscountsLbl.Text = "" + discounts.ToString("#,##0.00");
            totalTaxesLbl.Text = "" + tax.ToString("#,##0.00");

            //save the command to the display poll
            string path = @"c:\gpoll\data.txt";
            System.IO.File.WriteAllText(path, sum.ToString("#,##0"));

        }//

        private void clearAllItems()
        {
            //command the parent form to clear the search for the next scan
            POSForm pf = (POSForm)this.ParentForm;
            pf.connect_receipt_2_store_clear_search_Key();

            this.itemsListForReceipt.Clear();
            itemsForReceiptDataGridView.DataSource = itemsListForReceipt;
            itemsForReceiptDataGridView.Refresh();
            this.ITEM_COUNTER = 0;
            this.qtyCounterNumericUpDown.Value = 1;
            this.do_calculations();

            
        }
        //


        //update the existing item
        private void updateTheExistingProduct(MDB_ProductModel product)
        {
            /*MessageBox.Show(itemsListForReceipt.Count + " items");
            List<M_ReceiptDataModel> list = itemsListForReceipt.ToList();
            //check if item is present in the list item
            M_ReceiptDataModel existing_product = list.Find(i => i.item_id == product.id);
            if (existing_product != null)
            {
                //item already exists
                list.Where(i => i.item_id == existing_product.item_id).ToList().ForEach(s => s.Qty = existing_product.Qty + 1);
                itemsListForReceipt = new BindingList<M_ReceiptDataModel>(list);

                itemsForReceiptDataGridView.Update();
                itemsForReceiptDataGridView.Refresh(); //refresh the list
                this.do_calculations();
            }
            else { MessageBox.Show("Is null"); }*/
            /*List<M_ReceiptDataModel> list = itemsListForReceipt.ToList(); 
            for (int i = 0; i < list.Count; i++)
            {
                if (Convert.ToInt32(list[i].item_id) == Convert.ToInt32(product.id))
                {
                   // MessageBox.Show(list.Count + " items f");
                    //update
                    list[i].Qty = list[i].Qty + 1;
                    itemsListForReceipt = new BindingList<M_ReceiptDataModel>(list);//update entirelist
                   // break;
                }
            }
            itemsForReceiptDataGridView.Update();
            itemsForReceiptDataGridView.Refresh(); //refresh the list
            this.do_calculations();*/

            List<MDB_SingleItemSale> list = itemsListForReceipt.ToList();
            for (int i = 0; i < itemsListForReceipt.Count; i++)
            {
                if (Convert.ToInt32(itemsListForReceipt[i].id) == Convert.ToInt32(product.id))
                {
                    //update
                    itemsListForReceipt[i].qty = itemsListForReceipt[i].qty + 1;
                    break;
                }
            }
            itemsForReceiptDataGridView.Update();
            itemsForReceiptDataGridView.Refresh(); //refresh the list
            this.do_calculations();

            //command the parent form to clear the search for the next scan
            POSForm pf = (POSForm)this.ParentForm;
            pf.connect_receipt_2_store_clear_search_Key();
        }



        //apply the quantity to the selected item
        private void applyQtyToSelectedItem(int quantity_counts)
        {
            try
            {
                int ii = itemsForReceiptDataGridView.CurrentCell.RowIndex;
                string id = itemsForReceiptDataGridView.Rows[ii].Cells["item_id"].Value.ToString();

                List<MDB_SingleItemSale> list = itemsListForReceipt.ToList();
                for (int i = 0; i < itemsListForReceipt.Count; i++)
                {
                    if (Convert.ToInt32(itemsListForReceipt[i].id) == Convert.ToInt32(id))
                    {
                        //update
                        itemsListForReceipt[i].qty = quantity_counts;
                        break;
                    }
                }
                itemsForReceiptDataGridView.Update();
                itemsForReceiptDataGridView.Refresh(); //refresh the list
                this.do_calculations();

                //
                qtyCounterNumericUpDown.Value = 1;
            }
            catch (Exception ex)
            {
            }
        }
        //

        //get current selected id from gridview
        private int getCurrentSelectedIdFromGridView()
        {
            try
            {
                int i = itemsForReceiptDataGridView.CurrentCell.RowIndex;
                string id = itemsForReceiptDataGridView.Rows[i].Cells["item_id"].Value.ToString();
                return Convert.ToInt32(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry we cannot find specified row!", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        //
        //on qty change
        private void qtyCounterNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int qty = Convert.ToInt32(qtyCounterNumericUpDown.Value);
            applyQtyToSelectedItem(qty);
        }//



        #region UI CLICKS
        private void UI_BTN_CLICKS(object sender, EventArgs e)
        {
            //
            Button input = (Button)sender;
            switch (input.Name)
            {
                case "clearOrderBtn":
                    {
                        this.clearAllItems();
                        break;
                    }
                case "removeItemBtn":
                    {
                        //int id = this.getCurrentSelectedIdFromGridView();
                        //this.removeItemFromTheList(id);

                        break;
                    }
                case "completeOrder":
                    {
                        if (this.itemsListForReceipt.Count != 0)
                        {
                            CompleteOrderForm frm = new CompleteOrderForm(this, this.itemsListForReceipt.ToList());
                            frm.ShowDialog();
                        }
                        break;
                    }
                case "applyQtyBtn":
                    int qty = Convert.ToInt32(qtyCounterNumericUpDown.Value);
                    applyQtyToSelectedItem(qty);
                    POSForm pf = (POSForm)this.ParentForm;
                    pf.connect_receipt_2_store_clear_search_Key();
                    break;
                case "x": break;//applyQtyBtn
            }
        }

        //on single item delete

        private void itemsForReceiptDataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.do_calculations();
        }

        private void itemsForReceiptDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(this.itemsListForReceipt != null){
                this.do_calculations();
            }
            //
        }

        
        /*
         since button has no double click imutate via picture BOx
         */
        private void removeItemPictureBox_DoubleClick(object sender, EventArgs e)
        {
            int id = this.getCurrentSelectedIdFromGridView();
            this.removeItemFromTheList(id); 
        }
        ///
        #endregion

    }
}
