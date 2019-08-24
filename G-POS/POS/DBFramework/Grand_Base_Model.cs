using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrandDBHelperNS
{
    abstract public class Grand_Base_Model
    {
        public Grand_Base_Model() { }
        public abstract void init();
        public abstract string[] my_db_fields();
        public abstract void set_unique_field(string col, string val);


        //return a property from a given string value
        public object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }


    }
}
