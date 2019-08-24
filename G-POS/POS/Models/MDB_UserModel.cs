using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrandDBHelperNS;

namespace G_POS.POS.Models
{
    public class MDB_UserModel : Grand_Base_Model
    {
        //Table name
        public string tbl_name { get; set; }

        public string primary_key { get; set; }

        public int id { get; set; }
        public int company_id { get; set; }
        public string full_name { get; set; }
        public string username { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string role { get; set; }
        public string created_at { get; set; }
        public string fcm_token { get; set; }
        public string fcm_updated_at { get; set; }
        public int deleted { get; set; }

        //Default constructor

        public MDB_UserModel()
        {
            this.init();
        }

        public MDB_UserModel(int id, int company_id, string full_name, string username, string phone, string email, string password, string address, string role, string created_at, string fcm_token, string fcm_updated_at,int deleted)
        {
            this.init();
            this.id = id;
            this.company_id = company_id;
            this.full_name = full_name;
            this.username = username;
            this.phone = phone;
            this.email = email;
            this.password = password;
            this.address = address;
            this.role = role;
            this.created_at = created_at;
            this.fcm_token = fcm_token;
            this.fcm_updated_at = fcm_updated_at;
            this.deleted = deleted;
        }

        public override void init()
        {
            this.tbl_name = "workers";
        }

        public override string[] my_db_fields()
        {
            string[] list = new string[] { "id", "company_id", "full_name", "username", "phone", "email", "password", "address", "role", "created_at", "fcm_token", "fcm_updated_at","deleted" };
            return list;
        }

        public override void set_unique_field(string col, string val)
        {
            switch (col)
            {
                case "id": this.id = Convert.ToInt32(val); break;
                case "company_id": this.company_id = Convert.ToInt32(val); break;
                case "full_name": this.full_name = val; break;
                case "username": this.username = val; break;
                case "phone": this.phone = val; break;
                case "email": this.email = val; break;
                case "password": this.password = val; break;
                case "address": this.address = val; break;
                case "role": this.role = val; break;
                case "created_at": this.created_at = val; break;
                case "fcm_token": this.fcm_token = val; break;
                case "fcm_updated_at": this.fcm_updated_at = val; break;
                case "deleted": this.deleted = Convert.ToInt32(val);break;
                default: break;
            }
        }
    }
}
