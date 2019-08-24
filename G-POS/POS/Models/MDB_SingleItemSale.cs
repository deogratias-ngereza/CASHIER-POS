using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrandDBHelperNS;

namespace G_POS.POS.Models
{
    public class MDB_SingleItemSale : Grand_Base_Model
    {
        //Table name
        public string tbl_name { get; set; }

        public string primary_key { get; set; }

        public int id { get; set; }
        public string trans_no { get; set; }
        public string name { get; set; }
        public int item_id { get; set; }
        public int qty { get; set; }
        public float price { get; set; }
        public float vat { get; set; }
        public int vat_inclusive { get; set; }
        public float discount { get; set; }
        public string trans_date { get; set; }
        public float trans_time { get; set; }
        public string remarks { get; set; }
        public string created_date { get; set; }
        public int cancelled { get; set; }
        public int deleted { get; set; }

        //Default constructor

        public MDB_SingleItemSale()
        {
            this.init();
        }

        public MDB_SingleItemSale(int id, string trans_no, string name, int item_id, int qty, float price, float vat, int vat_inclusive, float discount, string trans_date, float trans_time, string remarks, string created_date, int cancelled, int deleted)
        {
            this.init();
            this.id = id;
            this.trans_no = trans_no;
            this.name = name;
            this.item_id = item_id;
            this.qty = qty;
            this.price = price;
            this.vat = vat;
            this.vat_inclusive = vat_inclusive;
            this.discount = discount;
            this.trans_date = trans_date;
            this.trans_time = trans_time;
            this.remarks = remarks;
            this.created_date = created_date;
            this.cancelled = cancelled;
            this.deleted = deleted;
        }

        public override void init()
        {
            this.tbl_name = "pos_sales_transactions";
        }

        public override string[] my_db_fields()
        {
            string[] list = new string[] { "id", "trans_no", "name", "item_id", "qty", "price", "vat", "vat_inclusive", "discount", "trans_date", "trans_time", "remarks", "created_date", "cancelled", "deleted" };
            return list;
        }

        public override void set_unique_field(string col, string val)
        {
            switch (col)
            {
                case "id": this.id = Convert.ToInt32(val); break;
                case "trans_no": this.trans_no = val; break;
                case "name": this.name = val; break;
                case "item_id": this.item_id = Convert.ToInt32(val); break;
                case "qty": this.qty = Convert.ToInt32(val); break;
                case "price": this.price = Convert.ToSingle(val); break;
                case "vat": this.vat = Convert.ToSingle(val); break;
                case "vat_inclusive": this.vat_inclusive = vat_inclusive; break;
                case "discount": this.discount = Convert.ToSingle(val); break;
                case "trans_date": this.trans_date = val; break;
                case "trans_time": this.trans_time = Convert.ToSingle(val); break;
                case "remarks": this.remarks = val; break;
                case "created_date": this.created_date = val; break;
                case "cancelled": this.cancelled = Convert.ToInt32(val); break;
                case "deleted": this.deleted = Convert.ToInt32(val); break;
                default: break;
            }
        }
    }
}
