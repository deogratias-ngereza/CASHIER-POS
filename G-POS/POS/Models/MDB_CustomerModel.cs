using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrandDBHelperNS;

namespace G_POS.POS.Models
{ 
    public class MDB_CustomerModel : Grand_Base_Model
    {
        //Table name
        public string tbl_name { get; set; }

        public string primary_key { get; set; }

        public int id { get; set; }
        public string is_company { get; set; }
        public string company_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_no { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public string sms_activated { get; set; }
        public string email_activated { get; set; }
        public string created_at { get; set; }
        public string fcm_token { get; set; }
        public string fcm_updated_at { get; set; }
        public int common_served { get; set; }

        //Default constructor

        public MDB_CustomerModel()
        {
            this.init();
        }

        public MDB_CustomerModel(int id, string is_company, string company_name, string first_name, string last_name, string phone_no, string email, string address, string password, string status, string sms_activated, string email_activated, string created_at, string fcm_token, string fcm_updated_at, int common_served)
        {
            this.init();
            this.id = id;
            this.is_company = is_company;
            this.company_name = company_name;
            this.first_name = first_name;
            this.last_name = last_name;
            this.phone_no = phone_no;
            this.email = email;
            this.address = address;
            this.password = password;
            this.status = status;
            this.sms_activated = sms_activated;
            this.email_activated = email_activated;
            this.created_at = created_at;
            this.fcm_token = fcm_token;
            this.fcm_updated_at = fcm_updated_at;
            this.common_served = common_served;
        }

        public override void init()
        {
            this.tbl_name = "customers";
        }

        public override string[] my_db_fields()
        {
            string[] list = new string[] { "id", "is_company", "company_name", "first_name", "last_name", "phone_no", "email", "address", "password", "status", "sms_activated", "email_activated", "created_at", "fcm_token", "fcm_updated_at", "common_served" };
            return list;
        }

        public override void set_unique_field(string col, string val)
        {
            switch (col)
            {
                case "id": this.id = Convert.ToInt32(val); break;
                case "is_company": this.is_company = val; break;
                case "company_name": this.company_name = val; break;
                case "first_name": this.first_name = val; break;
                case "last_name": this.last_name = val; break;
                case "phone_no": this.phone_no = val; break;
                case "email": this.email = val; break;
                case "address": this.address = val; break;
                case "password": this.password = val; break;
                case "status": this.status = val; break;
                case "sms_activated": this.sms_activated = val; break;
                case "email_activated": this.email_activated = val; break;
                case "created_at": this.created_at = val; break;
                case "fcm_token": this.fcm_token = val; break;
                case "fcm_updated_at": this.fcm_updated_at = val; break;
                case "common_served": this.common_served = Convert.ToInt32(val); break;
                default: break;
            }
        }
    }
}
