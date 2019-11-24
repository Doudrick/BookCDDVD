
/*
 * 
 * Tyler Doudrick
 * Tai Nguyen
 * 11/23/2019
 * Book Class - Inherits from Product Class
 * Project 4: BookCDDVDShop
 * 
 * 
 */

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
        } // end Book

        //Takes a dictionary as a parameter which contains everything unique to it and not it's base class (Product)

        public Book(int UPC, decimal price, string title, int quantity, IDictionary<string, string> param) : base(UPC, price, title, quantity)
        {
            hiddenISBN1 = Int32.Parse(param["ISBNLeft"]);
            hiddenISBN2 = Int32.Parse(param["ISBNRight"]);
            hiddenAuthor = param["BookAuthor"];
            hiddenPages = Int32.Parse(param["BookPages"]);
        } // end Book

        public string getAuthor()
        {
            return hiddenAuthor;
        } // end getAuthor
        public int getPages()
        {
            return hiddenPages;
        } // end getHiddenAuthor
        public int getISBN1()
        {
            return hiddenISBN1;
        } // end getISBN1
        public int getISBN2()
        {
            return hiddenISBN2;
        } // end getISBN2
        public override string ToString()
        {
            string s = base.ToString() + "\n";
            s += "Book ISBN: " + hiddenISBN1 + hiddenISBN2 + "\n";
            s += "Book Author: " + hiddenAuthor + "\n";
            s += "Book Pages: " + hiddenPages + "\n";
            return s;
        }  // end ToString
    } // end class Book
} // end namespace BookDVD
