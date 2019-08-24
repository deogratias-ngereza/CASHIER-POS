using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrandDBHelperNS;

using System.Drawing;
//using System.Net;
using System.IO;
using System.Net;
//using System.Net;

namespace G_POS.POS.Models
{
    public class MDB_ProductModel : Grand_Base_Model
    {
        //Table name
        public string tbl_name { get; set; }

        public string primary_key { get; set; }

        public int id { get; set; }
        public string common_uid { get; set; }
        public string barcode_id { get; set; }
        public string name { get; set; }
        public string img_name { get; set; }

        
        public Image ImgPicture {
            get {

                try {
                    return null;
                    /*var webClient = new G_POS.POS.Utilities.TimeoutWebClient(TimeSpan.FromSeconds(1));
                    byte[] imageDataBytes = webClient.DownloadData(@"http://localhost:1213/" + img_name); //DownloadData function from here
                    MemoryStream stream = new MemoryStream(imageDataBytes);
                    Image img = Image.FromStream(stream);
                    return img;*/

                    /*
                    var webClient = new WebClient();
                    //webc
                    byte[] imageDataBytes = webClient.DownloadData(@"http://localhost:1213/" + img_name); //DownloadData function from here
                    MemoryStream stream = new MemoryStream(imageDataBytes);
                    Image img = Image.FromStream(stream);
                    return img;*/
                    //return Image.GetInstance(@"http://localhost:1213/" + img_name);

                    return Image.FromFile(@"D:\GRAND_PRO\PROJECTS\POA_SUPERMARKET\APPS\SERVER\public\items_media\default.jpg"); 
                
                }
                catch(WebException ex) {
                    return null;
                    return Image.FromFile(@"D:\GRAND_PRO\PROJECTS\POA_SUPERMARKET\APPS\SERVER\public\items_media\default.jpg"); 
                
                }

                //if (!string.IsNullOrEmpty(img_name))
                {
                    var webClient = new WebClient();
                    byte[] imageDataBytes = webClient.DownloadData(@"http://localhost:1213/" + img_name); //DownloadData function from here
                    MemoryStream stream = new MemoryStream(imageDataBytes);
                    Image img = Image.FromStream(stream);
                    return img;
                    //stream.Close();
                    //return img;
                    
                    //return Image.FromFile(@"D:\GRAND_PRO\PROJECTS\POA_SUPERMARKET\APPS\SERVER\public\items_media\default.jpg");
                }
               // else
                {
                   // return null;
                }
            }
        }
        public int major_cat_id { get; set; }
        public int minor_cat_id { get; set; }
        public int brand_id { get; set; }
        public string description { get; set; }
        public string item_category { get; set; }
        public int current_qty { get; set; }
        public int reorder_level { get; set; }
        public float wholesale_price { get; set; }
        public float retail_price { get; set; }
        public float vat_amt { get; set; }
        public int vat_inclusive { get; set; }
        public float discount_amt { get; set; }
        public string currency { get; set; }
        public string last_updated_at { get; set; }
        public int visible { get; set; }
        public int has_vat { get; set; }
        public string last_updated_trans { get; set; }
        public string updated_at { get; set; }
        public int supplier_id { get; set; }
        public int deleted { get; set; }

        //Default constructor

        public MDB_ProductModel()
        {
            this.init();
        }
        //common_uid
        public MDB_ProductModel(int id, string barcode_id, string name, string img_name, int major_cat_id, int minor_cat_id, int brand_id, string description, string item_category, int current_qty, int reorder_level, float wholesale_price, float retail_price, float vat_amt, int vat_inclusive, float discount_amt, string currency, string last_updated_at, int visible, int has_vat, string last_updated_trans, string updated_at, int supplier_id, int deleted)
        {
            this.init();
            this.id = id;
            this.common_uid = common_uid;
            this.barcode_id = barcode_id;
            this.name = name;
            this.img_name = img_name;
            this.major_cat_id = major_cat_id;
            this.minor_cat_id = minor_cat_id;
            this.brand_id = brand_id;
            this.description = description;
            this.item_category = item_category;
            this.current_qty = current_qty;
            this.reorder_level = reorder_level;
            this.wholesale_price = wholesale_price;
            this.retail_price = retail_price;
            this.vat_amt = vat_amt;
            this.vat_inclusive = vat_inclusive;
            this.discount_amt = discount_amt;
            this.currency = currency;
            this.last_updated_at = last_updated_at;
            this.visible = visible;
            this.has_vat = has_vat;
            this.last_updated_trans = last_updated_trans;
            this.updated_at = updated_at;
            this.supplier_id = supplier_id;
            this.deleted = deleted;
        }

        public override void init()
        {
            this.tbl_name = "pos_items";
        }

        public override string[] my_db_fields()
        {//common_uid
            string[] list = new string[] { "id", "barcode_id", "name", "img_name", "major_cat_id", "minor_cat_id", "brand_id", "description", "item_category", "current_qty", "reorder_level", "wholesale_price", "retail_price", "vat_amt", "vat_inclusive", "discount_amt", "currency", "last_updated_at", "visible", "has_vat", "last_updated_trans", "updated_at", "supplier_id", "deleted" };
            return list;
        }

        public override void set_unique_field(string col, string val)
        {
            switch (col)
            {
                case "id": this.id = Convert.ToInt32(val); break;
                //case "common_uid": this.common_uid = val; break;
                case "barcode_id": this.barcode_id = val; break;
                case "name": this.name = val; break;
                case "img_name": this.img_name = val; break;
                case "major_cat_id": this.major_cat_id = Convert.ToInt32(val); break; 
                case "minor_cat_id": this.minor_cat_id = Convert.ToInt32(val); break;
                case "brand_id": this.brand_id = Convert.ToInt32(val); break;
                case "description": this.description = val; break;
                case "item_category": this.item_category = val; break;
                case "current_qty": this.current_qty = Convert.ToInt32(val); break;
                case "reorder_level": this.reorder_level = Convert.ToInt32(val); break;
                case "wholesale_price": this.wholesale_price = Convert.ToSingle(val); break;
                case "retail_price": this.retail_price = Convert.ToSingle(val); break;
                case "vat_amt": this.vat_amt = Convert.ToSingle(val); break;
                case "vat_inclusive": this.vat_inclusive = Convert.ToInt32(val); break;
                case "discount_amt": this.discount_amt = Convert.ToSingle(val); break;
                case "currency": this.currency = val; break;
                case "last_updated_at": this.last_updated_at = val; break;
                case "visible": this.visible = Convert.ToInt32(val); break;
                case "has_vat": this.has_vat = Convert.ToInt32(val); break;
                case "last_updated_trans": this.last_updated_trans = val; break;
                case "updated_at": this.updated_at = val; break;
                case "supplier_id": this.supplier_id = Convert.ToInt32(val); break;
                case "deleted": this.deleted = Convert.ToInt32(val); break; 
                default: break;
            }
        }
    }
}
