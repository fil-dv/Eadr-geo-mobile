using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsCsvCreator
{
    public class XlsData
    {
        public int Number { get; set; }
        public List<string> ListStr { get; set; }

        public XlsData()
        {
            Number = -1;
            ListStr = new List<string>();
        }

        public override string ToString()
        {
            string res = "";
            foreach (var item in ListStr)
            {
                res += (item + "  |  ");
            }
            return res;
        }
    }
}
