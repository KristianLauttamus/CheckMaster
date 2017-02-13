using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMaster
{
    [Serializable]
    public class ListBoxItem
    {
        public string row;
        public bool disallowed;
        public List<string> items;

        public override string ToString()
        {
            String toString = row + "\n";

            foreach (string item in items)
            {
                toString += " - " + item + "\n";
            }

            return toString;
        }
    }
}
