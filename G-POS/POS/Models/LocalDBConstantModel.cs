/**
 * deals withdb_constant.json
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G_POS.POS.Models
{
    public class LocalDBConstantModel
    {
        public string server_ip { get; set; }
        public string password { get; set; }
        public string user { get; set; }
        public string database { get; set; }
        public int port { get; set; }
    }
}
