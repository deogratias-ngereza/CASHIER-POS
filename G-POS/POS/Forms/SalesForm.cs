using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using G_POS.POS.Controllers;
using G_POS.POS.Models;
using G_POS.POS.Utilities;
using G_POS.POS.Printers;
using System.IO;

namespace G_POS.POS.Forms
{
    public partial class SalesForm : Form
    {
        private SaleController saleController;
        private SortableBindingList<MDB_Sale> currentTransctionsList;
        private SortableBindingList<MDB_Sale> currentWrongTransctionsList;

        public SalesForm()
        {
            InitializeComponent();
            saleController = new SaleController();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            var li = saleController.get_my_sales_list();
            var li2 = saleController.get_my_wrong_sales_list();
            currentTransctionsList = new SortableBindingList<MDB_Sale>(li);
            currentWrongTransctionsList = new SortableBindingList<MDB_Sale>(li2);
            salesDataGridView.DataSource = this.currentTransctionsList;
            wrongSalesdataGridView.DataSource = this.currentWrongTransctionsList;
        }


        //get current row
        private int get_selected_row()
        {
            try
            {
                int i = salesDataGridView.CurrentCell.RowIndex;
                string id = salesDataGridView.Rows[i].Cells["id"].Value.ToString();
                return Convert.ToInt32(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry we cannot find specified row!", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }
        private MDB_Sale getThisSale(int id) {
            MDB_Sale obj = new MDB_Sale();
            for (var i = 0; i < currentTransctionsList.Count;i++ )
            {
                if (currentTransctionsList[i].id == id) {
                    obj = currentTransctionsList[i];
                    break;
                }
            }
            return obj;
        }

        private void reprintBtn_Click(object sender, EventArgs e)
        {
            DialogResult diagRes = MessageBox.Show("Do you want to reprint receipt?","Confirmation",MessageBoxButtons.YesNo);
            if (diagRes == DialogResult.No) return;
            try {
                //MessageBox.Show(this.get_selected_row() + "");
                var _selected_id = this.get_selected_row();
                if (_selected_id == -1) return;
                MDB_Sale saleObjModel = this.getThisSale(_selected_id);

                List<MDB_SingleItemSale> itemsListForReceipt = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MDB_SingleItemSale>>(saleObjModel.json_sales);

                GINCOTEXFiscalPrinter printer = new GINCOTEXFiscalPrinter(itemsListForReceipt, saleObjModel);
                printer.PRINT_NOW();

                //update printed counts
                saleController.addPrintCountToSale(_selected_id);

                //refresh the list
                var li = saleController.get_my_sales_list();
                currentTransctionsList = new SortableBindingList<MDB_Sale>(li);
                salesDataGridView.DataSource = this.currentTransctionsList;

            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void clearFailedRecBtn_Click(object sender, EventArgs e)
        {
            //clear all failed receipts
            try
            {

                String directoryName = "C:\\dpool\\failed";
                DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
                if (dirInfo.Exists == false)
                    Directory.CreateDirectory(directoryName);

                List<String> efdsReceipts = Directory
                                   .GetFiles("C:\\dpool\\in", "*.*", SearchOption.AllDirectories).ToList();

                foreach (string file in efdsReceipts)
                {
                    FileInfo mFile = new FileInfo(file);
                    // to remove name collisions
                    if (new FileInfo(dirInfo + "\\" + mFile.Name).Exists == false)
                    {
                        mFile.MoveTo(dirInfo + "\\" + mFile.Name);
                    }
                }
                MessageBox.Show("All previous receipts cleared.","",MessageBoxButtons.OK);
            }
            catch { }
        }
        //
    }
}
