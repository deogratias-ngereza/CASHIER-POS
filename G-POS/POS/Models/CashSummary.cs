using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G_POS.POS.Models
{
    public class CashSummary
    {
        public int counts { get; set; }
        public float total_overall { get; set; } // on removing the tax and offers stffs
        public float total_amount { get; set; }//for prices
        public float total_discount { get; set; }
        public float total_tax { get; set; }
        //public int pass_kitchen { get; set; }
    }
}
