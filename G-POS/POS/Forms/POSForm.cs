using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using G_POS.POS.Models;
using G_POS.POS.Controllers;

namespace G_POS.POS.Forms
{
    public partial class POSForm : Form
    {
        public POSForm()
        {
            InitializeComponent();
        }

        private void POSForm_Load(object sender, EventArgs e)
        {
            //this.receiptGeneratorControl.Width = Convert.ToInt32(this.Width * 0.2);
            //this.productFinderControl.Width = Convert.ToInt32(this.Width * 0.8);
            //MessageBox.Show(Convert.ToInt32(this.Width * 0.2) + ""); //1366

            //this.receiptGeneratorControl.Width = 300;
            //this.productFinderControl.Width = 900;

            //this.productFinderControl.Width = this.Width - this.receiptGeneratorControl.Width - 22;
        }

        private void productFinderControl1_Load(object sender, EventArgs e)
        {
            
        }

        //connectos
        public void connect_store_n_receipt_gen_clear_all() {
            this.receiptGeneratorControl.connector_in_clear_all_items_in_order();
        }

        public void connect_store_n_receipt_send_this_item(MDB_ProductModel product)
        {
            this.receiptGeneratorControl.connector_in_push_item_for_receipt(product);
        }
        public void connect_receipt_2_store_clear_search_Key()
        {
            this.productFinderControl.connector_in_clear_searchKey();
        }
        public void connect_receipt_2_store_clear_search_Key_after_sale()
        {
            this.productFinderControl.connector_in_clear_searchKey_after_sale();
            this.productFinderControl.Connector_in_shortcuts("FOCUS");
        }
        



        /*clear buffering
       *https://stackoverflow.com/questions/2612487/how-to-fix-the-flickering-in-user-controls
       */
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        

        /*******KEY PreSSED ***********/
        private void POSForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.receiptGeneratorControl.Connector_in_shortcuts("ENTER");
            }
            else if (e.KeyCode == Keys.Tab)
            {
                this.receiptGeneratorControl.Connector_in_shortcuts("TAB");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.receiptGeneratorControl.Connector_in_shortcuts("CLEAR");
            }
            else if (e.Control && e.KeyCode.ToString() == "F")
            {
                this.productFinderControl.Connector_in_shortcuts("FOCUS");
            }
            else if (e.Control && e.KeyCode.ToString() == "R")
            {
                this.productFinderControl.Connector_in_shortcuts("REFRESH_ITEMS");
            }
            else if (e.Control && e.KeyCode.ToString() == "Q")
            {
                this.receiptGeneratorControl.Connector_in_shortcuts("QTY");
            }
            else if (e.Control && e.KeyCode.ToString() == "T")
            {
                this.receiptGeneratorControl.Connector_in_shortcuts("TABLE");
            }
            else if (e.KeyCode == Keys.Space)
            {
                //sthis.receiptGeneratorControl.Connector_in_shortcuts("APPLY_QTY");
            }
            else {
            }
        }
        
    }
}
