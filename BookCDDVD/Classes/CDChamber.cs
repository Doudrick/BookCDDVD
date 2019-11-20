// CD Classical Chamber Music Class
// This is a node class (not inherited by any other class)
// Responsible for all processing related to a CD Classical Chamber Music

// Written in VB by Joseph Jupin     Fall 2009
// Converted to CSharp by Frank Friedman     Spring 2016

// Modified June 17, 2017 by Frank Friedman
// Modified June 24, 2018 by Frank Friedman
// Modified June 16, 2019 by Frank Friedman

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// For serializati
using System.Runtime.Serialization.Formatters.Binary;
using BookCDDVD;

namespace BookCDDVD
{
    // CDClChamber inherits the data and methods in CDClassical and can be a serialized to a binary file
    [Serializable()]
    class CDChamber : CDClassical
    {
        private string hiddenInstrumentList;

        // Parameterless Constructor
        public CDChamber()
        {
            hiddenInstrumentList = "";
        }  // end Parameterless Constructor


        // Parameterized constructor
        public CDChamber(int UPC, decimal price, string title, int quantity,  // For Product Constructor
            string label, string artists, string instrumentList) : base(UPC, price, title, quantity, label, artists)
        {
            hiddenInstrumentList = instrumentList;
        }  // end parameterized constructor



        // These six methods replace what were VB Properties
        // get or set an item in the List
        // Accessor/mutator for Tuition, Year and Credits
        public string getCDChamberInstrumentList()
        {
            return hiddenInstrumentList;
        }  // end getgradHourlyPay


        public void setCDChamberInstrumentList(string value)
        {
            hiddenInstrumentList = value;
        }  // end get



        // Save data from form to object
        public override void Save(frmBookCDDVDShop f)
        {
            base.Save(f);
            hiddenInstrumentList = f.txtCDChamberInstrumentList.Text;
        }  // end Save


        // Display data in object on form
        public override void Display(frmBookCDDVDShop f)
        {
            base.Display(f);
            f.txtCDChamberInstrumentList.Text = hiddenInstrumentList;
        }  // end Display


        // This toString function overrides the Student toString
        // function.  The base refers to the Student because this class
        // inherits Student by definition.
        public override string ToString()
        {
            string s = base.ToString() + "\n";
            s += "Instrument List:  " + hiddenInstrumentList;
            return s;
        } //  end ToString

    }  // end CDClChamber Class
}  // end namespace

