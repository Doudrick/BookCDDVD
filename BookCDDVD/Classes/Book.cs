using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// For serialization
using System.Runtime.Serialization.Formatters.Binary;
using BookCDDVD;

namespace BookCDDVD
{
    [Serializable()]

    class Book : Product
    {
        private int hiddenISBN1;
        private int hiddenISBN2;
        private string hiddenAuthor;
        private int hiddenPages;

        public Book()
        {
            hiddenISBN1 = 0;
            hiddenISBN2 = 0;
            hiddenAuthor = "";
            hiddenPages = 0;
        }

        public Book(int UPC, decimal price, string title, int quantity,
            int ISBN1, int ISBN2, string author, int pages) : base(UPC, price, title, quantity)
        {
            hiddenISBN1 = ISBN1;
            hiddenISBN2 = ISBN2;
            hiddenAuthor = author;
            hiddenPages = pages;
        }
    }
}
