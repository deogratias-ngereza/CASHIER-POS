using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G_POS.POS.Utilities
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
