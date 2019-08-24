using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrandDBHelperNS;
/*
namespace G_POS.POS.Models
{
    public class _MDB_UserModel : Grand_Base_Model
    {
        //Table name
        public string tbl_name { get; set; }

        public string primary_key { get; set; }

        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string reg_date { get; set; }
        public string role { get; set; }
        public string password { get; set; }

        //Default constructor

        public _MDB_UserModel()
        {
            this.init();
        }

        public _MDB_UserModel(int id, string first_name, string last_name, string username, string phone, string email, string address, string reg_date, string role, string password)
        {

            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.username = username;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.reg_date = reg_date;
            this.role = role;
            this.password = password;
            this.init();
        }

        public override void init()
        {
            this.tbl_name = "users";
        }

        public override string[] my_db_fields()
        {
            string[] list = new string[] { "id", "first_name", "last_name", "username", "phone", "email", "address", "reg_date", "role", "password" };
            return list;
        }

        public override void set_unique_field(string col, string val)
        {
            switch (col)
            {
                case "id": this.id = Convert.ToInt32(val); break;
                case "first_name": this.first_name = val; break;
                case "last_name": this.last_name = val; break;
                case "username": this.username = val; break;
                case "phone": this.phone = val; break;
                case "email": this.email = val; break;
                case "address": this.address = val; break;
                case "reg_date": this.reg_date = val; break;
                case "role": this.role = val; break;
                case "password": this.password = val; break;
                default: break;
            }
        }
    }
}*/
