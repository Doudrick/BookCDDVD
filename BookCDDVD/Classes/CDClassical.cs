
/*
 * 
 * Tyler Doudrick
 * Tai Nguyen
 * 11/23/2019
 * CDClassical Class - Inherits from Product Class
 * Project 4: BookCDDVDShop
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// For serialization
using System.Runtime.Serialization.Formatters.Binary;
using BookCDDVD;

namespace BookCDDVD
{
    // CDClassical inherits the data and methods in Product
    [Serializable()]
    class CDClassical : Product
    {
        private string hiddenLabel;
        private string hiddenArtists;

        // Parameterless Constructor
        public CDClassical()
        {
            hiddenLabel = "";
            hiddenArtists = "";

        } // end CDClassical Parameterless Constructor

        //Takes a dictionary as a parameter which contains everything unique to it and not it's base class (Product)
        public CDClassical(int UPC, decimal price, string title, int quantity,
            IDictionary<string, string> param) : base(UPC, price, title, quantity)
        {
            hiddenLabel = param["CDClassicalLabel"];
            hiddenArtists = param["CDClassicalArtists"];
        }  // end Employee Parameterized Constructor

        // Accessor/mutator for CD Label
        public string getLabel()
        {
            return hiddenLabel;
        } // end getLabel

        // Accessor/mutator for CD Artists
        public string getArtists()
        {
            return hiddenArtists;
        } // end getArtists

        // Save data from form to object
        public override void Save(frmBookCDDVDShop f)
        {
            base.Save(f);
            hiddenLabel = f.txtCDClassicalLabel.Text;
            hiddenArtists = f.txtCDClassicalArtists.Text;
        } // end Save

        // Display data in object on form
        public override void Display(frmBookCDDVDShop f)
        {
            base.Display(f);
            f.txtCDClassicalLabel.Text = hiddenLabel;
            f.txtCDClassicalArtists.Text = hiddenArtists.ToString();
        }  // end Display

        // This toString function overrides the Object toString
        //     function.  The base refers to Object because this class
        //     inherits Object by default.
        public override string ToString()
        {
            string s = base.ToString() + "\n";
            s += "CDClassical Label: " + hiddenLabel + "\n";
            s += "CDClasical Artists: " + hiddenArtists + "\n";
            return s;
        }  // end ToString
    }  // end CDClassical class
}  // end namespace  
