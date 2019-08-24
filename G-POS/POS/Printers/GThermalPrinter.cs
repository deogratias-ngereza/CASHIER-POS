
/*
 * https://stackoverflow.com/questions/13390313/pos-application-development-receipt-printing
 * https://www.codeproject.com/Tips/453871/Simple-Receipt-Like-Printing-Using-the-Csharp-Prin -- very nice
 */

using System;
using System.Collections.Generic; 
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using G_POS.POS.Models;
using G_POS.POS.Controllers;

namespace G_POS.POS.Printers
{
    public class GThermalPrinter
    {
        private List<MDB_SingleItemSale> list;
        private MDB_Sale trans_model;
        private CompanyController companyController;
        private MDB_CompanyModel companyModelData;


        public GThermalPrinter(List<MDB_SingleItemSale> list,MDB_Sale trans_model) {
            companyController = new CompanyController();
            companyModelData = companyController.get_company_details();
            this.list = list;
            this.trans_model = trans_model;
        }
        //

        //called outside
        public void PRINT_NOW() { 
            PrintReceiptForTransaction();
        }//

        /*******************/
        public void PrintReceiptForTransaction()
        {
            PrintDocument recordDoc = new PrintDocument();

            recordDoc.DocumentName = "Customer Receipt";
            recordDoc.PrintPage += new PrintPageEventHandler(PrintReceiptPage); // function below
            recordDoc.PrintController = new StandardPrintController(); // hides status dialog popup
            // Comment if debugging 
            PrinterSettings ps = new PrinterSettings();
            //ps.PrinterName = "EPSON TM-T20II Receipt";
            recordDoc.PrinterSettings = ps;
            recordDoc.Print();
            // --------------------------------------

            // Uncomment if debugging - shows dialog instead
            /*PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
            printPrvDlg.Document = recordDoc;
            printPrvDlg.Width = 800;
            printPrvDlg.Height = 500;
            printPrvDlg.ShowDialog();*/
            // --------------------------------------

            recordDoc.Dispose();
        }

        private void PrintReceiptPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 10, FontStyle.Regular);
            Font drawFontCourier14Bold = new Font("Courier New", 14, FontStyle.Bold);
            Font drawFontCourier14Regular = new Font("Courier New", 14, FontStyle.Regular);
            Font drawFontCourier12Bold = new Font("Courier New", 12, FontStyle.Bold);
            Font drawFontCourier12Regular = new Font("Courier New", 12, FontStyle.Regular);
            Font drawFontCourier10Bold = new Font("Courier New", 10, FontStyle.Bold);
            Font drawFontCourier10Regular = new Font("Courier New", 10, FontStyle.Regular);
            Font drawFontCourier9Bold = new Font("Courier New", 9, FontStyle.Bold);
            Font drawFontCourier9Regular = new Font("Courier New", 9, FontStyle.Regular);
            String starLine =   "*********************************";
            String simpleLine = "_________________________________";


            float fontHeight = font.GetHeight();
            int startX = 10;
            int startY = 0;
            int Offset = 10;

            //start
            graphics.DrawString(starLine, drawFontCourier14Bold,
                                new SolidBrush(Color.Black), startX, startY + Offset);

            //intro abt the company
            Offset = Offset + 15;
            graphics.DrawString(companyModelData.name, drawFontCourier12Regular, new SolidBrush(Color.Black), startX + 20, startY + Offset);
            Offset = Offset + 15;
            graphics.DrawString(companyModelData.address_1, drawFontCourier12Regular, new SolidBrush(Color.Black), startX + 20, startY + Offset);
            Offset = Offset + 15;
            graphics.DrawString(companyModelData.phone_1 + " or " + companyModelData.phone_2, drawFontCourier12Regular, new SolidBrush(Color.Black), startX + 20, startY + Offset);
            Offset = Offset + 15;
            graphics.DrawString(companyModelData.address_2, drawFontCourier12Regular, new SolidBrush(Color.Black), startX + 20, startY + Offset);
            Offset = Offset + 15;
            graphics.DrawString(companyController.getCurrentDateAndTime(), drawFontCourier12Regular, new SolidBrush(Color.Black), startX + 20, startY + Offset);
            Offset = Offset + 15;
            graphics.DrawString(starLine, drawFontCourier12Regular, new SolidBrush(Color.Black), startX, startY + Offset);

            /*draw the item header present*/
            Offset = Offset + 20;
            string header_row = string.Format("{0,-10}{1,-4}{2,-6}{3,-7}{4,-7}", "Particular", "Qty", "Disc", " Price", " Amt");
            graphics.DrawString(header_row, drawFontCourier10Bold, new SolidBrush(Color.Black), startX, startY + Offset);
            /*draw all the items here */
            Random rand = new Random();
            for (var i = 0; i < this.list.Count;i++)
            {

                string particular = list[i].name;
                int qty = list[i].qty;
                double disc = list[i].discount;
                double price = list[i].price;
                string amt = " " + (price * qty);
                //string row = string.Format("{0,-15}{1,-3}{2,-7}{3,-7}",particular,qty,disc,price,amt);
                string row = string.Format("{0,-13}{1,-4}{2,-6}{3,-7}{4,-7}", particular.Length > 12 ? particular.Substring(0,11) + ".." : particular, qty, disc, " " + price, " " + amt);
                Offset = Offset + 20;
                graphics.DrawString(row, drawFontCourier9Regular, new SolidBrush(Color.Black), startX, startY + Offset);
            
            }

            //summary
            Offset = Offset + 10;
            graphics.DrawString(simpleLine, drawFontCourier14Bold, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 30;
            string summary_row = string.Format("{0,-11}{1,-4}{2,-2}{3,-8}", "TOTAL(Tsh)", "/" + trans_model.sales_count, "",trans_model.amt_req);
            graphics.DrawString(summary_row, drawFontCourier14Bold, new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 10;
            graphics.DrawString(simpleLine, drawFontCourier14Bold, new SolidBrush(Color.Black), startX, startY + Offset);


            //more 
            string servedBy = "By : " + companyController.getCurrentUser().username;
            //string table_no = trans_model.type == "TABLE" ? "TABLE NO : " + trans_model.table_no : trans_model.type; //table_no = "PARCEL"; = 
            string table_no = trans_model.payment_method;
            string servedByAndTbl = string.Format("{0,-10}{1,15}", table_no, servedBy);
            Offset = Offset + 25;
            graphics.DrawString(servedByAndTbl, drawFontCourier12Regular, new SolidBrush(Color.Black), startX, startY + Offset);

            /*//sent to kitchen:
            if (trans_model.pass_kitchen == 1) {
                Offset = Offset + 20;
                graphics.DrawString("+ KITCHEN", drawFontCourier12Regular, new SolidBrush(Color.Black), startX, startY + Offset);
            }*/
            
            //developer 
            Offset = Offset + 20;
            graphics.DrawString("Developer : grand123grand1@gmail.com", drawFontCourier10Regular, new SolidBrush(Color.Black), startX, startY + Offset);

            //thankyou
            Offset = Offset + 20;
            graphics.DrawString("   -- THANK YOU --", drawFontCourier12Regular, new SolidBrush(Color.Black), startX, startY + Offset);

            //end
        }


        /*********************************************/

    }
}
