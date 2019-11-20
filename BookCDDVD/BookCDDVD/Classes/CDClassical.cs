// Classical CD Class
// This node is inherited by the Classical Orchestra CD and Clasical Chamber Music CD classes
// Responsible for all processing related to a Classical Music CD

// Written in VB by Joseph Jupin     Fall 2009
// Converted to CSharp by Frank Friedman     Spring 2016

// Revised June 17, 2017 by Frank Friedman
// Revised June 16, 2019 by Frank Friedman

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// For serialization
using System.Runtime.Serialization.Formatters.Binary;
using BookCDDVD;
// using BookCDDVDShop.Classes;

namespace BookCDDVDShop.Classes
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


        // Parameterized Constructor
        public CDClassical(int UPC, decimal price, string title, int quantity,
            string label, string artists) : base(UPC, price, title, quantity)
        {
            hiddenLabel = "";
            hiddenArtists = "";
        }  // end Employee Parameterized Constructor


        // Accessor/mutator for CD Label
        public string CDClassicalLabel
        {
            get
            {
                return hiddenLabel;
            }  // end get
            set   // (string value)
            {
                hiddenLabel = value;
            }  // end get
        }  // end Property


        // Accessor/mutator for CD Artists
        public string CDClassicalArtists
        {
            get
            {
                return hiddenArtists;
            }  // end get
            set   // (string value)
            {
                hiddenArtists = value;
            }  // end get
        }  // end Property

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
            s += "CDClassical Info: " + hiddenArtists + hiddenArtists;
            return s;
        }  // end ToString

    }  // end CDClassical class
}  // end namespace  
