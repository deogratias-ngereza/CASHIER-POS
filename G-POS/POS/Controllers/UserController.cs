using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using GrandDBHelperNS;
using G_POS.POS.Models;
using System.Windows.Forms;

namespace G_POS.POS.Controllers
{
    class UserController : BaseController
    {
        private Grand_DB_Manager DBManager;
        private Grand_Custom_Result DBResults;

        //constructors
        public UserController()
        {
            DBManager = new Grand_DB_Manager();
        }//


        //login
        public MDB_UserModel login_user(MDB_UserModel user)
        {
            try {
                string q = "SELECT * FROM workers WHERE username= '" + user.username + "' AND password='" + user.password + "' LIMIT 1;";
                DBResults = DBManager.getListFromQuery(q, "MDB_UserModel");
               // System.Windows.Forms.MessageBox.Show(DBResults.sys_message);
                if (DBResults.status == 0)
                {
                    var li = new List<MDB_UserModel>(DBResults.result_data.Cast<MDB_UserModel>());
                    return li[0];
                }
                else
                {
                    MessageBox.Show("" + DBResults.sys_message);
                    //System.Windows.Forms.MessageBox.Show(DBResults.sys_message);
                    return null;
                }
            }catch(Exception ex){
                
                return null;
            }
        }




    }
}
