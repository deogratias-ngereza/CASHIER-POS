using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G_POS.POS.Models;
using GrandDBHelperNS;
using System.Windows.Forms;

namespace G_POS.POS.Controllers
{
    public class SaleController : BaseController
    {
        private Grand_DB_Manager DBManager;
        private Grand_Custom_Result DBResults;
        private List<MDB_SingleItemSale> itemsListForReceipt;
        private MDB_Sale currentSaleOrder;

        public SaleController()
        {
            DBManager = new Grand_DB_Manager();
        }

        //get list of all sales0
        public List<MDB_Sale> get_my_sales_list()
        {
            try
            {
                string q = "SELECT * FROM pos_sales WHERE (amt_paid NOT LIKE '%e%' AND amt_change NOT LIKE '%e%') AND worker_id=" + this.getCurrentUser().id + " ORDER BY id DESC LIMIT 800";//AND worker_id=" + this.getCurrentUser().id + "
                //MessageBox.Show(q);
                DBResults = DBManager.getListFromQuery(q, "MDB_Sale");
                if (DBResults.status == 0)
                {
                    return new List<MDB_Sale>(DBResults.result_data.Cast<MDB_Sale>());
                }
                else
                {
                    MessageBox.Show("ERR : " + DBResults.sys_message);
                    return new List<MDB_Sale>();
                }
            }
            catch (Exception ex)
            {
                this.AlertCustomMsg("", "FAIL TO LOAD SALES LIST", 1, ex.Message);
                return new List<MDB_Sale>();
            }
        }//
        //get list of all sales0
        public List<MDB_Sale> get_my_wrong_sales_list()
        {
            try
            {
                string q = "SELECT * FROM pos_sales WHERE (amt_paid LIKE '%e%' OR amt_change LIKE '%e%') AND worker_id=" + this.getCurrentUser().id + " ORDER BY id DESC LIMIT 800";//AND worker_id=" + this.getCurrentUser().id + "
                //MessageBox.Show(q);
                DBResults = DBManager.getListFromQuery(q, "MDB_Sale");
                if (DBResults.status == 0)
                {
                    return new List<MDB_Sale>(DBResults.result_data.Cast<MDB_Sale>());
                }
                else
                {
                    MessageBox.Show("ERR : " + DBResults.sys_message);
                    return new List<MDB_Sale>();
                }
            }
            catch (Exception ex)
            {
                this.AlertCustomMsg("", "FAIL TO LOAD SALES LIST", 1, ex.Message);
                return new List<MDB_Sale>();
            }
        }//

        public int addPrintCountToSale(int id) {
            String q = "UPDATE pos_sales as SL SET printed = (SL.printed + 1) WHERE id=" + id;
            try
            {
                DBResults = DBManager.RunBasicQuery(q.ToString());
                if (DBResults.status == 0)
                {
                    return 0;
                }
                else
                {
                    MessageBox.Show("" + DBResults.sys_message);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                return -1;
            }
        }

        private int updateStockQty() {
            StringBuilder qAll = new StringBuilder();
            for (var i = 0; i < this.itemsListForReceipt.Count; i++)
            {
                //generate 
                StringBuilder q = new StringBuilder();
                q.Append(@"UPDATE pos_items as item SET ");
                //q.Append("updated_at='" + this.getCurrentDateAndTime() + "',");
                q.Append("last_updated_trans='" + this.getCurrentDateAndTimeIn24() + "',");
                q.Append("current_qty=(item.current_qty - " + this.itemsListForReceipt[i].qty + ") ");
                q.Append("WHERE id = " + this.itemsListForReceipt[i].item_id);//
                q.Append(";");//
                qAll.Append(q);

            }
            try
            {
                DBResults = DBManager.RunBasicQuery(qAll.ToString());
                if (DBResults.status == 0)
                {
                    return 0;
                }
                else
                {
                    MessageBox.Show("" + DBResults.sys_message);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                return -1;
            }

        }

        private int saveIndividualTransactionsForSale() {
            StringBuilder qAll = new StringBuilder();
            for (var i = 0; i < this.itemsListForReceipt.Count; i++ )
            {
                //generate 
                StringBuilder q = new StringBuilder();
                q.Append(@"INSERT INTO `pos_sales_transactions`(`trans_no`, `name`, `item_id`, `qty`, `price`, 
                    `vat`, `discount`, `trans_date`, `trans_time`, `remarks`, `created_date`, `cancelled`, `deleted`) VALUES (");
                q.Append("'" + currentSaleOrder.trans_no + "',");//trans_no
                q.Append("'" + itemsListForReceipt[i].name + "',");//name
                q.Append("" + itemsListForReceipt[i].id + ",");//item_id
                q.Append("" + itemsListForReceipt[i].qty + ",");//qty
                q.Append("" + ((itemsListForReceipt[i].price * itemsListForReceipt[i].qty) - (itemsListForReceipt[i].discount * itemsListForReceipt[i].qty)) + ",");//price = price -discount
                q.Append("" + (itemsListForReceipt[i].vat * itemsListForReceipt[i].qty) + ",");//vat
                q.Append("" + (itemsListForReceipt[i].discount * itemsListForReceipt[i].qty) + ",");//discount
                q.Append("'" + currentSaleOrder.created_date + "',");//trans_date
                q.Append("" + currentSaleOrder.created_time + ",");//trans_time
                q.Append("'" + "" + "',");//remarks
                q.Append("'" + currentSaleOrder.created_datetime + "',");//created_date
                q.Append("" + 0 + ",");//cancelled
                q.Append("" + 0 + "");//deleted
                q.Append(");");//
                qAll.Append(q);
            }
            
            //run all the queries
            try
            {
                DBResults = DBManager.RunBasicQuery(qAll.ToString());
                if (DBResults.status == 0)
                {
                    updateStockQty();
                    return 0;
                }
                else
                {
                    MessageBox.Show("" + DBResults.sys_message);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                return -1;
            }

        }

        public int saveThisTransaction(MDB_Sale trans_model,List<MDB_SingleItemSale> items)
        {
            this.itemsListForReceipt = items;
            this.currentSaleOrder = trans_model;

            //save a sale general transactions
            StringBuilder q = new StringBuilder();
            q.Append(@"INSERT INTO `pos_sales`( `trans_no`, `customer_id`, `store_id`, `worker_id`, 
                        `sales_count`, `description`, `payment_method`, `amt_req`, `amt_paid`, `amt_change`,
                        `amt_vat`, `amt_discount`, `source`, `customer_name`, `customer_phone`, `paid`, `printed`, 
                        `deleted`, `paid_date`, `created_date`, `created_time`, `created_datetime`, `remarks`,
                        `json_sales`) VALUES (");
            q.Append("'" + trans_model.trans_no + "',");//trans_no
            q.Append("" + trans_model.customer_id + ",");//customer_id
            q.Append("" + trans_model.store_id + ",");//store_id
            q.Append("" + trans_model.worker_id + ",");//worker_id
            q.Append("" + trans_model.sales_count + ",");//sales_count
            q.Append("'" + trans_model.description + "',");//description
            q.Append("'" + trans_model.payment_method + "',");//payment_method
            q.Append("" + trans_model.amt_req + ",");//amt_req
            q.Append("" + trans_model.amt_paid + ",");//amt_paid
            q.Append("" + trans_model.amt_change + ",");//amt_change
            q.Append("" + trans_model.amt_vat + ",");//amt_vat
            q.Append("" + trans_model.amt_discount + ",");//amt_discount
            q.Append("'" + trans_model.source + "',");//source
            q.Append("'" + trans_model.customer_name + "',");//customer_name
            q.Append("'" + trans_model.customer_phone + "',");//customer_phone
            q.Append("" + trans_model.paid + ",");//paid
            q.Append("" + trans_model.printed + ",");//printed
            q.Append("" + trans_model.deleted + ",");//deleted
            q.Append("'" + trans_model.paid_date + "',");//paid_date
            q.Append("'" + trans_model.created_date + "',");//created_date
            q.Append("" + trans_model.created_time + ",");//created_time
            q.Append("'" + trans_model.created_datetime + "',");//created_datetime
            q.Append("'" + trans_model.remarks + "',");//remarks
            q.Append("'" + trans_model.json_sales.ToString() + "'");//json_sales
            q.Append(");");//
           // MessageBox.Show(q.ToString());
            try {
                DBResults = DBManager.RunBasicQuery(q.ToString());
                if (DBResults.status == 0)
                {
                    int r = saveIndividualTransactionsForSale();//save individual transactions
                    //TODO :: reverse transactions on fail
                    return 0;
                }
                else
                {
                    MessageBox.Show("" + DBResults.sys_message);
                    return 1;
                }
            }catch(Exception ex){
                MessageBox.Show("" + ex.Message);
                return -1;
            }
            /*try
            {
                return 0;
                string o_summary1 = "" + trans_model.order_counts + " Orders, Req-Amt : " + trans_model.req_amount + " And " + trans_model.paid_amount + " was paid - " + trans_model.change_amount + " change," + " Table: " + trans_model.table_no + " - (" + trans_model.type + ") on " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");//paid
                string o_summary2 = ".. " + trans_model.order_counts + " Orders, Req-Amt : " + trans_model.req_amount + " NOT PAID - " + " Table: " + trans_model.table_no + " - (" + trans_model.type + ") on " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");//pending

                StringBuilder q = new StringBuilder();
                q.Append("INSERT INTO `order_transactions`(`id`, `auth_by`, `created_at`, `ordered_at`, `completed_at`, `updated_at`, `req_amount`, `paid_amount`, `change_amount`, `on_hold`,`customer_served`, `order_summary`, `json_data`, `type`, `table_no`, `customer_name`, `customer_phone`, `customer_email`, `pass_kitchen`, `tran_source`, `on_hold_to_table`, `paid`, `waiter_name`, `progress`, `printed`, `RETURN_STATUS`,`order_counts`) VALUES (");
                q.Append("0,");//id
                q.Append("'" + this.getCurrentUser().username + "',");//auth_by
                q.Append("'" + this.getCurrentDateAndTime() + "',");//created_at
                q.Append("'" + this.getCurrentTime() + "',");//ordered_at
                q.Append("'" + this.getCurrentDateAndTime() + "',");//completed_at
                q.Append("'" + this.getCurrentDateAndTime() + "',");//updated_at
                q.Append("" + trans_model.req_amount + ",");//req_amount
                q.Append("" + trans_model.paid_amount + ",");//paid_amount
                q.Append("" + trans_model.change_amount + ",");//change_amount
                q.Append((pay_hold == 0 ? 0 : 1) + ",");//on_hold 0/1 
                q.Append(trans_model.customer_served + ",");//customer_served 0/1
                q.Append("'" + (pay_hold == 0 ? o_summary1 : o_summary2) + "',");//order_summary
                q.Append("'" + trans_model.json_data + "',");//json_data
                q.Append("'" + trans_model.type + "',");//type
                q.Append("'" + trans_model.table_no + "',");//table_no
                q.Append("'" + trans_model.customer_name + "',");//customer_name
                q.Append("'" + trans_model.customer_phone + "',");//customer_phone
                q.Append("'" + trans_model.customer_email + "',");//customer_email
                q.Append(trans_model.pass_kitchen + ",");//pass_kitchen
                q.Append("'" + trans_model.tran_source + "',");//tran_source
                q.Append((pay_hold == 1 ? 1 : 0) + ",");//on_hold_to_table
                q.Append((pay_hold == 0 ? 1 : 0) + ",");//paid --
                q.Append("'" + trans_model.waiter_name + "',");//waiter_name
                q.Append("' " + trans_model.progress + "',");//progress
                q.Append(trans_model.printed + ",");//printed
                q.Append(trans_model.RETURN_STATUS + ",");//RETURN_STATUS  
                q.Append(trans_model.order_counts + "");//order_counts 
                q.Append(");");//id

                DBResults = DBManager.RunBasicQuery(q.ToString());
                if (DBResults.status == 0)
                {
                    //maintain counts 
                    this.MaintainProductCountsByReducing(trans_model.json_data);
                    return 0;
                }
                else
                {
                    MessageBox.Show("" + DBResults.sys_message);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                //this.AlertCustomMsg("", "FAIL TO ADD SUPPLIER", 1, ex.Message);
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return -1;
            }*/
        }
        //


    }
}
