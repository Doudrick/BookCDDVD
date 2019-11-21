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
            int ISBN1, int ISBN2, string author, int pages, string area) : base(UPC, price, title, quantity, ISBN1, ISBN2, author, pages)
        {
            hiddenArea = area;
        }
        public override string ToString()
        {
            string s = base.ToString() + "\n";
            s += "CISBook Area: " + hiddenArea + "\n";
            return s;
        }  // end ToString
    }
}
