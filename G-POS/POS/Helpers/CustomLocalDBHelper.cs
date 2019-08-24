/***
 * HELP TO GET DATA FROM LOCAL .mdb
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.OleDb;
using System.Data;
using System.IO;
using G_POS.POS.Models;

namespace G_POS.POS.Helpers
{
    public class CustomLocalDBHelper
    {
        public CustomLocalDBHelper() {
        
        }

        public string get_my_path()
        {
            var executing_path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            string targetDir = string.Format(executing_path);
            return targetDir;
        }


        /*JSON DB OBJECT*/
        public LocalDBConstantModel getDBSetting()
        {
            try
            {
                //open the file
                using (StreamReader r = new StreamReader(this.get_my_path() + @"\temp\bin\db_constants.json"))
                {
                    string json = r.ReadToEnd();
                    LocalDBConstantModel userObject = Newtonsoft.Json.JsonConvert.DeserializeObject<LocalDBConstantModel>(json);
                    return userObject;
                }
            }
            catch (Exception ex)
            {
                return new LocalDBConstantModel();
            }
        }
       
        public void test() {
           /* var myDataTable = new DataTable();
            //"Provider=Microsoft.JET.OLEDB.4.0;" + "data source=C:\\menus\\newmenus\\menu.mdb;Password=****")
            var connection_string = "Provider=Microsoft.JET.OLEDB.4.0;" + "data source=" +  (this.get_my_path() + @"\temp\bin\grand_master.mdb") + ";Password=gmtech.co.tz;";
            using (var conection = new OleDbConnection(connection_string))
            {
                conection.Open();
                var query = "Select * From _constants";
                var command = new OleDbCommand(query, conection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                    //textBox1.Text = reader[0].ToString();

            }*/
        }




    }
}
