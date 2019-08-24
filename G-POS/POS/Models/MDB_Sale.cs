using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrandDBHelperNS;

namespace G_POS.POS.Models
{
    public class MDB_Sale : Grand_Base_Model
    {
        //Table name
        public string tbl_name { get; set; }

        public string primary_key { get; set; }

        public int id { get; set; }
        public string trans_no { get; set; }
        public int customer_id { get; set; }
        public int store_id { get; set; }
        public int worker_id { get; set; }
        public float sales_count { get; set; }
        public string description { get; set; }
        public string payment_method { get; set; }
        public float amt_req { get; set; }
        public float amt_paid { get; set; }
        public float amt_change { get; set; }
        public float amt_vat { get; set; }
        public float amt_discount { get; set; }
        public string source { get; set; }
        public string customer_name { get; set; }
        public string customer_phone { get; set; }
        public int paid { get; set; }
        public int printed { get; set; }
        public int deleted { get; set; }
        public string paid_date { get; set; }
        public string created_date { get; set; }
        public double created_time { get; set; }
        public string created_datetime { get; set; }
        public string remarks { get; set; }
        public string json_sales { get; set; }

        //Default constructor

        public MDB_Sale()
        {
            this.init();
        }

        public MDB_Sale(int id, string trans_no, int customer_id, int store_id, int worker_id, float sales_count, string description, string payment_method, float amt_req, float amt_paid, float amt_change, float amt_vat, float amt_discount, string source, string customer_name, string customer_phone, int paid, int printed, int deleted, string paid_date, string created_date, double created_time, string created_datetime, string remarks, string json_sales)
        {
            this.init();
            this.id = id;
            this.trans_no = trans_no;
            this.customer_id = customer_id;
            this.store_id = store_id;
            this.worker_id = worker_id;
            this.sales_count = sales_count;
            this.description = description;
            this.payment_method = payment_method;
            this.amt_req = amt_req;
            this.amt_paid = amt_paid;
            this.amt_change = amt_change;
            this.amt_vat = amt_vat;
            this.amt_discount = amt_discount;
            this.source = source;
            this.customer_name = customer_name;
            this.customer_phone = customer_phone;
            this.paid = paid;
            this.printed = printed;
            this.deleted = deleted;
            this.paid_date = paid_date;
            this.created_date = created_date;
            this.created_time = created_time;
            this.created_datetime = created_datetime;
            this.remarks = remarks;
            this.json_sales = json_sales;
        }

        public override void init()
        {
            this.tbl_name = "pos_sales";
        }

        public override string[] my_db_fields()
        {
            string[] list = new string[] { "id", "trans_no", "customer_id", "store_id", "worker_id", "sales_count", "description", "payment_method", "amt_req", "amt_paid", "amt_change", "amt_vat", "amt_discount", "source", "customer_name", "customer_phone", "paid", "printed", "deleted", "paid_date", "created_date", "created_time", "created_datetime", "remarks", "json_sales" };
            return list;
        }

        public override void set_unique_field(string col, string val)
        {
            switch (col)
            {
                case "id": this.id = Convert.ToInt32(val); break;
                case "trans_no": this.trans_no = val; break;
                case "customer_id": this.customer_id = Convert.ToInt32(val); break;
                case "store_id": this.store_id = Convert.ToInt32(val); break;
                case "worker_id": this.worker_id = Convert.ToInt32(val); break;
                case "sales_count": this.sales_count = Convert.ToSingle(val); break;
                case "description": this.description = val; break;
                case "payment_method": this.payment_method = val; break;
                case "amt_req": this.amt_req = Convert.ToSingle(val); break;
                case "amt_paid": this.amt_paid = Convert.ToSingle(val); break;
                case "amt_change": this.amt_change = Convert.ToSingle(val); break;
                case "amt_vat": this.amt_vat = Convert.ToSingle(val); break;
                case "amt_discount": this.amt_discount = Convert.ToSingle(val); break;
                case "source": this.source = val; break;
                case "customer_name": this.customer_name = val; break;
                case "customer_phone": this.customer_phone = val; break;
                case "paid": this.paid = Convert.ToInt32(val); break;
                case "printed": this.printed = Convert.ToInt32(val); break;
                case "deleted": this.deleted = Convert.ToInt32(val); break;
                case "paid_date": this.paid_date = val; break;
                case "created_date": this.created_date = val; break;
                case "created_time": this.created_time = Convert.ToDouble(val); break;
                case "created_datetime": this.created_datetime = val; break;
                case "remarks": this.remarks = val; break;
                case "json_sales": this.json_sales = val; break;
                default: break;
            }
        }
    }
}
