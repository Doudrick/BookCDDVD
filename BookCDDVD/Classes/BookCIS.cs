
/*
 * 
 * Tyler Doudrick
 * Tai Nguyen
 * 11/23/2019
 * BookCIS Class - Inherits from Book Class
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

    class BookCIS : Book
    {
        private string hiddenArea;

        public BookCIS()
        {
            hiddenArea = "";
        } // end BookCIS

        //Takes a dictionary as a parameter which contains everything unique to it AND everything unique to its base class (Book)
        public BookCIS(int UPC, decimal price, string title, int quantity,
            IDictionary<string, string> param) : base(UPC, price, title, quantity, param)
        {
            hiddenArea = param["CISArea"];
        } // end BookCIS

        public string getArea()
        {
            return hiddenArea;
        } // end getArea

        // save datae from form to object
        public override void Save(frmBookCDDVDShop f)
        {
            base.Save(f);
            hiddenArea = f.cbBookCISArea.Text;
        } // end save

        // display data in object on form
        public override void Display(frmBookCDDVDShop f)
        {
            base.Display(f);
            f.cbBookCISArea.Text = hiddenArea;
        } // end display

        // This toString function overrides the Student toString
        // function.  The base refers to the Student because this class
        // inherits Student by definition.
        public override string ToString()
        {
            string s = base.ToString() + "\n";
            s += "CISBook Area: " + hiddenArea + "\n";
            return s;
        }  // end ToString
    }
}
