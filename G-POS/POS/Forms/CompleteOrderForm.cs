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
using G_POS.POS.Utilities;
using G_POS.POS.Controls.POS;
using G_POS.POS.Printers;
using System.IO;

namespace G_POS.POS.Forms
{
    public partial class CompleteOrderForm : Form
    {
        private List<MDB_CustomerModel> customersList;
        private CustomerController customerController;
        private SaleController saleController;
        private ReceiptGeneratorControl ReceiptGenDepartment;
        private List<MDB_SingleItemSale> itemsListForReceipt;
        private CashSummary cashSummary;
        private CommonUtil commonUtil;
       
        private double req_amt;
        private double change_amt;
        private double REQ_AMT { get { return req_amt; } set { req_amt = value; reqAmtLbl.Text = req_amt.ToString("#,##0.00") +""; } }
        private double CHANGE_AMT { get { return change_amt; } set { change_amt = value; changeAmtLbl.Text = change_amt.ToString("#,##0.00") +""; } }



        public CompleteOrderForm()
        {
            InitializeComponent();
            customerController = new CustomerController();
            saleController = new SaleController();
            commonUtil = new CommonUtil();
            this.ReceiptGenDepartment = new ReceiptGeneratorControl();
            this.itemsListForReceipt = new List<MDB_SingleItemSale>();
            this.loadCustomers();
        }

        public CompleteOrderForm(ReceiptGeneratorControl ReceiptGenDepartment, List<MDB_SingleItemSale> itemsListForReceipt)
        {
            InitializeComponent();
            customerController = new CustomerController();
            saleController = new SaleController();
            commonUtil = new CommonUtil();
            this.ReceiptGenDepartment = ReceiptGenDepartment;
            this.itemsListForReceipt = itemsListForReceipt;

            this.loadCustomers();
        }

        public void putSearchOnFocus() {
            this.ActiveControl = this.paidAmtTxt;
            paidAmtTxt.Focus();
            
        }
        private void CompleteOrderForm_Load(object sender, EventArgs e)
        {
            //attemp 1
            //do calculations -- using worker
            cashSummary = this.get_total_amount_to_be_paid(this.itemsListForReceipt);
            REQ_AMT = Math.Round(cashSummary.total_overall,2);
            //paidAmtTxt.Text = cashSummary.total_overall + "";
            paidAmtTxt.Text = "";
            this.ActiveControl = this.paidAmtTxt;
            paidAmtTxt.Focus();
        }



         //load credit sales groups available from the DB
        private void loadCustomers()
        {
            this.customersList = this.customerController.get_customers_list();
            //MessageBox.Show(customersList.Count + ""); 
            //bind to ui 
            for (var i = 0; i < customersList.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = customersList[i].company_name;
                item.Value = customersList[i].id;
                deliveryGrpComboBox.Items.Add(item);
            }
            deliveryGrpComboBox.Text = "CASH";
        }
        //

        private void BTN_UI_CLICKS(object sender, EventArgs e)
        {
            Button input = (Button)sender;
            switch (input.Name)
            {////PARCEL= 2,DELIVERY=3,TABLE = 1,
                case "x": break;
                case "cashOptBtn":
                    {
                        paymentModeTxt.Text = "CASH";
                        break;
                    }
                case "creditOptBtn":
                    {
                        paymentModeTxt.Text = "CREDIT";
                        break;
                    }//
                case "chequeOptBtn":
                    {
                        paymentModeTxt.Text = "CHEQUE";
                        break;
                    }
                case "mobileMoneyBtn":
                    {
                        paymentModeTxt.Text = "MOBILE_MONEY";
                        break;
                    }
                case "receiveOrderBtn":
                    {
                        //receivingAttemp();
                        break;
                    }
                case "payOrderBtn":
                    {
                        if (paidAmtTxt.Text == "" || (paymentModeTxt.Text == "CASH" && paidAmtTxt.Text == "0"))
                        {
                            MessageBox.Show("PAID HOW MUCH?");
                            return;
                        }
                        //
                        //MessageBox.Show("M");
                        DialogResult dialogRes = MessageBox.Show("You want to print EFD receipt?","",MessageBoxButtons.YesNoCancel);
                        if (dialogRes == DialogResult.Yes)
                        {
                            printReceiptCheckBox.Checked = true;
                            paymentAttemp();
                        }
                        else if (dialogRes == DialogResult.No)
                        {
                            printReceiptCheckBox.Checked = false;
                            paymentAttemp();
                        }
                        else if (dialogRes == DialogResult.Cancel)
                        {
                        }
                        else { paymentAttemp();  }
                        break;
                    }
                case "pollDisplayBtn":
                    {
                        pollDisplay(req_amt.ToString("#,##0"));
                        break;
                    }
                case "exitBtn":
                    {
                        pollDisplay(req_amt.ToString("#,##0"));
                        this.Close();
                        break;
                    }
                default: break;
            }
        }

        private void pollDisplay(string value) {
            //save the command to the display poll
            string path = @"c:\gpoll\data.txt";
            System.IO.File.WriteAllText(path, value);
        }

        private void closeCompleteForm(object sender, EventArgs e)
        {
            pollDisplay(req_amt.ToString("#,##0"));
            this.Close();
        }

        private void deliveryGrpComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string value = (deliveryGrpComboBox.SelectedItem as ComboBoxItem).Value.ToString();
                string text = deliveryGrpComboBox.Text;
                for (var i = 0; i < this.customersList.Count; i++)
                {
                    if (Convert.ToInt32(value) == this.customersList[i].id)
                    {
                        customerPhoneTxt.Text = this.customersList[i].phone_no;
                    }
                }
            }
            catch (Exception ex)
            {
                customerPhoneTxt.Text = "";
            }
        }



        //transation worker
        // he will do all math for u
        public CashSummary get_total_amount_to_be_paid(List<MDB_SingleItemSale> itemsListForReceipt)
        {
            float total = 0, total_disc = 0, total_tx = 0, total_amt = 0;
            int counter = 0;
            foreach (MDB_SingleItemSale receipt in itemsListForReceipt)
            {

                total_disc = (receipt.discount * receipt.qty);
                total_tx = (receipt.vat * receipt.qty);
                total_amt = (receipt.price * receipt.qty);
                //total += ((total_amt + total_tx) - total_disc);
                total += ((total_amt) - total_disc);
                counter++;

            }
            CashSummary summary = new CashSummary { counts = counter, total_amount = total_amt, total_discount = total_disc, total_tax = total_tx, total_overall = total };
            return summary;
        }

        //text changed in here
        private void paidAmtTxt_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; //MessageBox.Show("Fine");
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        //TEXT CHANGED
        private void paidAmtTxt_TextChanged(object sender, EventArgs e)
        {
            try { CHANGE_AMT = Math.Round(Convert.ToDouble(paidAmtTxt.Text),2) - req_amt; }
            catch { }
        }

        private string removeQuotes(String s){
            s = s.Replace("\"", "");
            var len = 30;
            if (s.Length > len) {
                return s.Substring(0,len -1);
            }
            return s;
        }

        private void xxxxpaymentAttemp() { 
            //write a text file with c#

            var x_no = new Random().Next(1000, 9999);
            string dt = "";
            dt += "R_NAM \"Deogracious\"";
            dt += "R_VRN \"####\"";
            dt += "R_TIN \"11223344\"";
            dt += "R_ADR \"Mbezi beach\"" + Environment.NewLine;
            //dt += "R_TRP \"Coca cola\"2pcs.*1400.00V2";
            for (var i = 0; i < itemsListForReceipt.Count; i++)
            {
                dt += "R_TRP \"" + removeQuotes(itemsListForReceipt[i].name) + "\"" + itemsListForReceipt[i].qty + ".*" + itemsListForReceipt[i].price + "V2" + Environment.NewLine;
            }
            //dt += "R_PM1 10000";
            dt += "R_TXT \"--------------------------\"" + Environment.NewLine;
            dt += "R_TXT \"     REC NO. " + x_no + "    \"" + Environment.NewLine;
            //dt += "R_TXT \"     THANK YOU.     \"" + Environment.NewLine;
            dt += "R_TXT \"     Tech: GMTech Consult LTD.     \"" + Environment.NewLine;
            dt += "R_TXT \"--------------------------\"" + Environment.NewLine;
       
            string path = @"c:\dpool\in\" + x_no + ".txt";
            File.WriteAllText(path, dt);
            


        }
        //
        //paying attemp 2 --paying:
        private void paymentAttemp()
        {
            //current user
            MDB_UserModel workerObj = this.saleController.getCurrentUser();

            if (customerNameTxt.Text == "") customerNameTxt.Text = "CASH";
            try{
            
                MDB_Sale model = new MDB_Sale
                {
                    trans_no = commonUtil.getRandomReceiptTransNo(),
                    customer_id = -1,
                    store_id = -1,
                    worker_id = workerObj.id,
                    sales_count = cashSummary.counts,
                    description = "",
                    payment_method = paymentModeTxt.Text,
                    amt_req = cashSummary.total_overall,
                    amt_paid = Convert.ToSingle(paidAmtTxt.Text),
                    amt_change = Convert.ToSingle(changeAmtLbl.Text),
                    amt_vat = printReceiptCheckBox.Checked == true ?  cashSummary.total_tax : 0,//VAT added if receipt printed
                    amt_discount = cashSummary.total_discount,
                    source = "OFFICE",
                    customer_name = customerNameTxt.Text,
                    customer_phone = customerPhoneTxt.Text,
                    paid = paymentModeTxt.Text == "CASH" ? 1 : 0,
                    printed = printReceiptCheckBox.Checked == true? 1 : 0,
                    paid_date = saleController.getCurrentDate(),
                    created_date = saleController.getCurrentDate(),
                    created_time = Convert.ToDouble(saleController.getCurrentCompactedTimeIn24()),
                    created_datetime = saleController.getCurrentDateAndTimeIn24(),
                    //remarks = remarks,
                    json_sales = Newtonsoft.Json.JsonConvert.SerializeObject(this.itemsListForReceipt),
                    
                };

                //save
                int res = saleController.saveThisTransaction(model, this.itemsListForReceipt);
                if (res != 0)
                {
                    MessageBox.Show("FAIL TO SAVE ORDER", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //fiscal printer / normal thermal printer
                    //printing option
                    if (printReceiptCheckBox.Checked == true)
                    {
                        //GThermalPrinter printer = new GThermalPrinter(itemsListForReceipt, model);
                        //printer.PRINT_NOW();
                        GINCOTEXFiscalPrinter printer = new GINCOTEXFiscalPrinter(itemsListForReceipt, model);
                        printer.PRINT_NOW();
                    }
                    //return back
                    //this.SendPushNotificationCommandToKitchenDepartment(); 
                    ReceiptGenDepartment.Connecter_in_internal_order_status_results(0);
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("FAIL TO RECEIVE ORDER", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void reqAmtLbl_Click(object sender, EventArgs e)
        {
            string amt = Math.Round(this.REQ_AMT, 2) + "";
            this.paidAmtTxt.Text = amt;
        }

        //end pay attemp



        /**************************************************************************detect key pressed*/
        

        private void CompleteOrderForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Check here tab press or not
            if (e.KeyCode == Keys.Tab)
            {
               // MessageBox.Show("TAB");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (paidAmtTxt.Text == "" || (paymentModeTxt.Text == "CASH" && paidAmtTxt.Text == "0"))
                {
                    MessageBox.Show("PAID HOW MUCH?");
                    return;
                }
                //
                //MessageBox.Show("M");
                DialogResult dialogRes = MessageBox.Show("You want to print EFD receipt?", "", MessageBoxButtons.YesNoCancel);
                if (dialogRes == DialogResult.Yes)
                {
                    printReceiptCheckBox.Checked = true;
                    paymentAttemp();
                }
                else if (dialogRes == DialogResult.No)
                {
                    printReceiptCheckBox.Checked = false;
                    paymentAttemp();
                }
                else if (dialogRes == DialogResult.Cancel)
                {
                    this.putSearchOnFocus();
                }
                else { paymentAttemp(); }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                pollDisplay(req_amt.ToString("#,##0"));
                this.Close();
            }
            else if (e.Control && e.KeyCode.ToString() == "E")
            {
                string amt = Math.Round(this.REQ_AMT, 2) + "";
                this.paidAmtTxt.Text = amt;
            }
            else if (e.Control && e.KeyCode.ToString() == "F")
            {
                this.putSearchOnFocus();
            }
            else if (e.Control && e.KeyCode.ToString() == "D")
            {
                pollDisplay(req_amt.ToString("#,##0"));
            }
            //Check for the Shift Key as well
            else if (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Tab)
            {
                MessageBox.Show("TAB + SHIFT");
            }
            else {
                
            }
        }


     

    }
}
