using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrandDBHelperNS
{
    class Grand_Default_Model : Grand_Base_Model
    {
        //table name
        public string tbl_name { get; set; }


        //col present in a database
        public string test_col { get; set; }

        //constructor
        public Grand_Default_Model()
        {
            this.init();
        }

        //initilizer function
        public override void init()
        {
            this.tbl_name = "todo2";
        }

        //..create more constructor down here

        //define all column fields presents
        public override string[] my_db_fields()
        {
            string[] list = new string[] { "test_col" };
            return list;
        }

        //set the object field to specified type
        public override void set_unique_field(string col, string val)
        {
            switch (col)
            {
                case "test_col": this.test_col = val; break;
                default: break;
            }
        }


    }
}
