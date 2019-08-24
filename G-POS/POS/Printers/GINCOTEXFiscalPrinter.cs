using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G_POS.POS.Models;
using G_POS.POS.Controllers;
using System.IO;
using System.Windows.Forms;


namespace G_POS.POS.Printers
{
    public class GINCOTEXFiscalPrinter
    {
        private List<MDB_SingleItemSale> list;
        private MDB_Sale trans_model;
        private CompanyController companyController;
        private MDB_CompanyModel companyModelData;
        private MDB_UserModel currentCashier;

        public GINCOTEXFiscalPrinter(List<MDB_SingleItemSale> list, MDB_Sale trans_model)
        {
            companyController = new CompanyController();
            companyModelData = companyController.get_company_details();
            this.list = list;
            this.trans_model = trans_model;
            this.currentCashier = companyController.getCurrentUser();
        }
        private string getValidItemNameForPrinting(String s)
        {
            s = s.Replace("\"", "");
            var len = 30;
            if (s.Length > len)
            {
                return s.Substring(0, len - 1);
            }
            return s;
        }
        private string getVatInclusiveValueForFiscal(int v) {
            if (v == 1) return "V2";
            else return "V1";
        }
        public void PRINT_NOW()
        {
            //var x_no = new Random().Next(1000, 9999);
            string dt = "";
            /*dt += "R_NAM \"Deogracious\"";
            dt += "R_VRN \"####\"";
            dt += "R_TIN \"11223344\"";
            dt += "R_ADR \"Mbezi beach\"" + Environment.NewLine;*/
            //dt += "R_TRP \"Coca cola\"2pcs.*1400.00V2";
            for (var i = 0; i < list.Count; i++)
            {
                dt += "R_TRP \"" + getValidItemNameForPrinting(list[i].name) + "\"" + list[i].qty + ".*" + list[i].price + "" + getVatInclusiveValueForFiscal(list[i].vat_inclusive) + Environment.NewLine;
            }
            //dt += "R_PM1 10000";
           // dt += "R_TXT \"--------------------------\"" + Environment.NewLine;
            dt += "R_TXT \"     REC NO. " + this.trans_model.trans_no + " ( By: "+this.currentCashier.full_name+" )"+ "    \"" + Environment.NewLine;
           // dt += "R_TXT \"     THANK YOU.     \"" + Environment.NewLine;
            dt += "R_TXT \"     by: GMTech Consult LTD.     \"" + Environment.NewLine;
            dt += "R_TXT \"     call: +255 688-059-688/+255 684-983-533.     \"" + Environment.NewLine;
           // dt += "R_TXT \"--------------------------\"" + Environment.NewLine;

            string path = @"c:\dpool\in\" + this.trans_model.trans_no + ".txt";
            File.WriteAllText(path, dt);
        }

    }
}
