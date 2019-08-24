
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrandDBHelperNS;
using G_POS.POS.Models;
using System.Windows.Forms;

namespace G_POS.POS.Controllers
{
    public class CompanyController : BaseController
    {
        private Grand_DB_Manager DBManager;
        private Grand_Custom_Result DBResults;

        public CompanyController()
        {
            DBManager = new Grand_DB_Manager();
        }


        //get list of all companies
        public MDB_CompanyModel get_company_details()
        {
            try
            {
                DBResults = DBManager.getListFromQuery("SELECT * FROM companies" + " ORDER BY id", "MDB_CompanyModel");
                if (DBResults.status == 0)
                {
                    var list = new List<MDB_CompanyModel>(DBResults.result_data.Cast<MDB_CompanyModel>());
                    if(list.Count >= 1)
                        return list[0];
                    return new MDB_CompanyModel();
                }
                else
                {
                    MessageBox.Show("ERR : " + DBResults.sys_message);
                    return new MDB_CompanyModel();
                }
            }
            catch (Exception ex)
            {
                this.AlertCustomMsg("", "FAIL TO LOAD COMPANY DETAILS", 1, ex.Message);
                return new MDB_CompanyModel();
            }
        }//


    }
}
