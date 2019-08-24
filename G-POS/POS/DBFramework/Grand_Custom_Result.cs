using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrandDBHelperNS
{
    class Grand_Custom_Result
    {
        public int status { get; set; }
        public string message { get; set; }
        public string sys_message { get; set; }
        public List<Grand_Base_Model> result_data;

        public Grand_Custom_Result(int status, string message, string sys_message, List<Grand_Base_Model> result_data)
        {
            this.status = status;
            this.message = message;
            this.sys_message = sys_message;
            this.result_data = result_data;
        }
    }
}
