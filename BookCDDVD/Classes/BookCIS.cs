using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCDDVD
{
    class BookCIS : Book
    {
        string hiddenArea = "";

        public BookCIS()
        {
            hiddenArea = "";
        }

        public BookCIS(int UPC, decimal price, string title, int quantity,
            IDictionary<string, string> param) : base(UPC, price, title, quantity, param)
        {
            hiddenArea = param["CISArea"];
        }
        public override string ToString()
        {
            string s = base.ToString() + "\n";
            s += "CISBook Area: " + hiddenArea + "\n";
            return s;
        }  // end ToString
    }
}
