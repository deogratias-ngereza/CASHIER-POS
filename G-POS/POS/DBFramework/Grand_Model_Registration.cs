using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using G_POS;
using G_POS.POS.Models;

namespace GrandDBHelperNS
{
    class Grand_Model_Registration
    {
        //get Model instances 
        public Grand_Base_Model getModelInstance(string model)
        {
            switch (model)
            {//
                case "MDB_UserModel": return new MDB_UserModel();
                case "MDB_ProductModel": return new MDB_ProductModel();
                case "MDB_SingleItemSale": return new MDB_SingleItemSale();
                case "MDB_CustomerModel": return new MDB_CustomerModel();
                case "MDB_Sale": return new MDB_Sale();
                case "MDB_CompanyModel": return new MDB_CompanyModel();
                /*case "MDB_SupplierModel": return new MDB_SupplierModel();
                case "MDB_CenterInfoModel": return new MDB_CenterInfoModel();
                
                case "MDB_ActivityModel": return new MDB_ActivityModel();
                case "MDB_ExpireModel": return new MDB_ExpireModel();
                case "MDB_TransactionModel": return new MDB_TransactionModel();
                case "MDB_ImportsModel": return new MDB_ImportsModel();
                case "MDB_CreditSalesModel": return new MDB_CreditSalesModel();
                case "MDB_ProductHasProductCategoryModel": return new MDB_ProductHasProductCategoryModel();*/
                default: return new Grand_Default_Model(); //
            }

        }//end get Model instances


    }
}
