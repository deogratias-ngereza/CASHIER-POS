using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrandDBHelperNS;

namespace G_POS.POS.Models
{
    public class MDB_CompanyModel : Grand_Base_Model
    {
        //Table name
        public string tbl_name { get; set; }

        public string primary_key { get; set; }

        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public int box_no { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string phone_1 { get; set; }
        public string phone_2 { get; set; }
        public string email_1 { get; set; }
        public string email_2 { get; set; }
        public string url { get; set; }
        public string tin { get; set; }
        public string vrn { get; set; }
        public string inv_swift_code { get; set; }
        public string inv_tzs_acc { get; set; }
        public string inv_usd_acc { get; set; }
        public string inv_bank_name { get; set; }
        public string inv_bank_branch { get; set; }

        //Default constructor

        public MDB_CompanyModel()
        {
            this.init();
        }

        public MDB_CompanyModel(int id, string name, string country, string region, int box_no, string address_1, string address_2, string phone_1, string phone_2, string email_1, string email_2, string url, string tin, string vrn, string inv_swift_code, string inv_tzs_acc, string inv_usd_acc, string inv_bank_name, string inv_bank_branch)
        {
            this.init();
            this.id = id;
            this.name = name;
            this.country = country;
            this.region = region;
            this.box_no = box_no;
            this.address_1 = address_1;
            this.address_2 = address_2;
            this.phone_1 = phone_1;
            this.phone_2 = phone_2;
            this.email_1 = email_1;
            this.email_2 = email_2;
            this.url = url;
            this.tin = tin;
            this.vrn = vrn;
            this.inv_swift_code = inv_swift_code;
            this.inv_tzs_acc = inv_tzs_acc;
            this.inv_usd_acc = inv_usd_acc;
            this.inv_bank_name = inv_bank_name;
            this.inv_bank_branch = inv_bank_branch;
        }

        public override void init()
        {
            this.tbl_name = "_companies";
        }

        public override string[] my_db_fields()
        {
            string[] list = new string[] { "id", "name", "country", "region", "box_no", "address_1", "address_2", "phone_1", "phone_2", "email_1", "email_2", "url", "tin", "vrn", "inv_swift_code", "inv_tzs_acc", "inv_usd_acc", "inv_bank_name", "inv_bank_branch" };
            return list;
        }

        public override void set_unique_field(string col, string val)
        {
            switch (col)
            {
                case "id": this.id = Convert.ToInt32(val); break;
                case "name": this.name = val; break;
                case "country": this.country = val; break;
                case "region": this.region = val; break;
                case "box_no": this.box_no = Convert.ToInt32(val); break;
                case "address_1": this.address_1 = val; break;
                case "address_2": this.address_2 = val; break;
                case "phone_1": this.phone_1 = val; break;
                case "phone_2": this.phone_2 = val; break;
                case "email_1": this.email_1 = val; break;
                case "email_2": this.email_2 = val; break;
                case "url": this.url = val; break;
                case "tin": this.tin = val; break;
                case "vrn": this.vrn = val; break;
                case "inv_swift_code": this.inv_swift_code = val; break;
                case "inv_tzs_acc": this.inv_tzs_acc = val; break;
                case "inv_usd_acc": this.inv_usd_acc = val; break;
                case "inv_bank_name": this.inv_bank_name = val; break;
                case "inv_bank_branch": this.inv_bank_branch = val; break;
                default: break;
            }
        }
    }
}
