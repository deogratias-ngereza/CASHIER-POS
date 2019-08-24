using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




using GrandDBHelperNS;
using G_POS.POS.Models;
using System.Windows.Forms;

namespace G_POS.POS.Controllers
{
    public class ProductController : BaseController
    {
        private Grand_DB_Manager DBManager;
        private Grand_Custom_Result DBResults;
        //private CustomDBProductMapper DBProductMapper;
        //private CustomDBActMonitorHelper DBActMonitor;


         
        //constructor
        public ProductController()
        {
            DBManager = new Grand_DB_Manager();
           // DBProductMapper = new CustomDBProductMapper();
           // DBActMonitor = new CustomDBActMonitorHelper();
        }//


        //retrieve startup products from store
        public List<MDB_ProductModel> getStartUpProductsFromStore()
        {
            try
            {
                string q = "SELECT * FROM pos_items WHERE deleted=0 ORDER BY last_updated_trans DESC LIMIT 30";
                    
                DBResults = DBManager.getListFromQuery(q, "MDB_ProductModel");
                if (DBResults.status == 0)
                {
                    List<MDB_ProductModel> list = new List<MDB_ProductModel>(DBResults.result_data.Cast<MDB_ProductModel>());
                    return list;
                }
                else
                {
                    MessageBox.Show(DBResults.sys_message);
                    return new List<MDB_ProductModel>();
                }
            }
            catch (Exception ex) { 
                
                return new List<MDB_ProductModel>(); 
            }
        }//


        public List<MDB_ProductModel> getProductsBasedOnSearchKey(string KEY)
        {
            try
            {

                DBResults = DBManager.getListFromQuery("SELECT * FROM `pos_items` WHERE  deleted=0 AND visible=1 AND (name LIKE '%" + KEY + "%' OR barcode_id  LIKE '%" + KEY + "%') ORDER BY name,last_updated_trans DESC LIMIT 30", "MDB_ProductModel");
                if (DBResults.status == 0)
                {
                    List<MDB_ProductModel> list = new List<MDB_ProductModel>(DBResults.result_data.Cast<MDB_ProductModel>());
                    return list;
                }
                else
                {
                    //MessageBox.Show("ERR:" + DBResults.sys_message);
                    return new List<MDB_ProductModel>();
                }
            }
            catch (Exception ex) { return new List<MDB_ProductModel>(); }
        }//






    }
}
