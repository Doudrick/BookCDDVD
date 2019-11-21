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
        public BookCIS(int UPC, decimal price, string title, int quantity,
            int ISBN1, int ISBN2, string author, int pages) : base(UPC, price, title, quantity)
        {

        }
    }
}
