using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrandDBHelperNS;
using G_POS.POS.Helpers;
using G_POS.POS.Models;
using System.IO;
using System.Windows.Forms;



namespace G_POS.POS.Controllers
{
    public class BaseController
    {
        private Grand_DB_Manager DBManager;
        private Grand_Custom_Result DBResults;
        private CustomPathHelper PathHelper;
       // private CustomDBActMonitorHelper DBActMonitorHelper;

        //constructor
        public BaseController()
        {
            DBManager = new Grand_DB_Manager();
            PathHelper = new CustomPathHelper();
         //   DBActMonitorHelper = new CustomDBActMonitorHelper();
        }


        #region getCurrentTime() getCurrentDateAndTime()
        //get current time
        public string getCurrentTime()
        {
            return DateTime.Now.ToString("hh:mm:ss");
        }
        public string getCurrentTimeIn24()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        //get current date and time
        public string getCurrentDateAndTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        public string getCurrentDateAndTimeIn24()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public string getCurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        public string getCurrentCompactedTime()
        {
            var dt = DateTime.Now.ToString("tt");
            var AM_PM_BINARY = 0;
            if (dt == "AM") AM_PM_BINARY = 0;
            else AM_PM_BINARY = 1;

            //MessageBox.Show(AM_PM_BINARY + "");

            var yyyyMMdd = DateTime.Now.ToString("yyyyMMdd");
            var hhmmss = DateTime.Now.ToString("hhmmss");
            var res = yyyyMMdd + "" + AM_PM_BINARY + "" + hhmmss;
           // MessageBox.Show(res);
            //return res;
            // DateTime.Now.ToString("hhmmss");
            return res.ToString();
        }
        public string getCurrentCompactedTimeIn24()
        {
            var dt = DateTime.Now.ToString("tt");
            var AM_PM_BINARY = 0;
            if (dt == "AM") AM_PM_BINARY = 0;
            else AM_PM_BINARY = 1;

            //MessageBox.Show(AM_PM_BINARY + "");

            var yyyyMMdd = DateTime.Now.ToString("yyyyMMdd");
            var hhmmss = DateTime.Now.ToString("HHmmss");
            var res = yyyyMMdd + "" + AM_PM_BINARY + "" + hhmmss;
            // MessageBox.Show(res);
            //return res;
            // DateTime.Now.ToString("hhmmss");
            return res.ToString();
        }
        #endregion




        /*
         CUSTOM WARNING
         * 1 - no icon
         * 0 - warning
         * -1 - error
         */
        protected void AlertCustomMsg(string title, string msg, int status, string sys_msg)
        {
            switch (status)
            {
                case 1: System.Windows.Forms.MessageBox.Show(msg, title); break;
                case 0: System.Windows.Forms.MessageBox.Show(msg, title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning); break;
                case -1: System.Windows.Forms.MessageBox.Show(msg, title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); break;
                default: System.Windows.Forms.MessageBox.Show(msg, title); break;
            }
        }//


        #region configConstantFromJSON
        public AppConfigConstantModel getAppConfigs()
        {
            try
            {
                //open the file
                using (StreamReader r = new StreamReader(PathHelper.get_my_path() + @"temp\bin\config.json"))
                {
                    string json = r.ReadToEnd();
                    AppConfigConstantModel configObject = Newtonsoft.Json.JsonConvert.DeserializeObject<AppConfigConstantModel>(json);
                    return configObject;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                return new AppConfigConstantModel();
            }
        }//
        #endregion



        #region getCurrentUser() and saveCurrentUser(MDB_UserModel user)

        /*CURRENT USER OBJECT*/
        public MDB_UserModel getCurrentUser()
        {
            try
            {
                //open the file
                using (StreamReader r = new StreamReader(PathHelper.get_cur_user_path() + @"current.json"))
                {
                    string json = r.ReadToEnd();
                    MDB_UserModel userObject = Newtonsoft.Json.JsonConvert.DeserializeObject<MDB_UserModel>(json);
                    return userObject;
                }
            }
            catch (Exception ex)
            {
                return new MDB_UserModel();
            }
        }//
        //save the current user
        public int saveCurrentUser(MDB_UserModel user)
        {
            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                File.WriteAllText(PathHelper.get_cur_user_path() + @"current.json", json);
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }//

        #endregion





        //record the activity
        protected void record(string crud_type, string act_type, string desc, string auth_name, int auth_id)
        {
            //DBActMonitorHelper.record(crud_type, act_type, desc, auth_name, auth_id);
        }
        //



    }
}
