using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrandDBHelperNS;
using G_POS.POS.Models;
using System.Windows.Forms;

namespace G_POS.POS.Controllers
{
    public class CustomerController : BaseController
    {
        private Grand_DB_Manager DBManager;
        private Grand_Custom_Result DBResults;

        public CustomerController() {
            DBManager = new Grand_DB_Manager();
        }


        //get list of all customers
        public List<MDB_CustomerModel> get_customers_list()
        {
            try
            {
                DBResults = DBManager.getListFromQuery("SELECT * FROM customers" + " ORDER BY id", "MDB_CustomerModel");
                if (DBResults.status == 0)
                {
                    return new List<MDB_CustomerModel>(DBResults.result_data.Cast<MDB_CustomerModel>());
                }
                else
                {
                    MessageBox.Show("ERR : " + DBResults.sys_message);
                    return new List<MDB_CustomerModel>();
                }
            }
            catch (Exception ex)
            {
                this.AlertCustomMsg("", "FAIL TO LOAD CUSTOMERS LIST", 1, ex.Message);
                return new List<MDB_CustomerModel>();
            }
        }//


    }
}
