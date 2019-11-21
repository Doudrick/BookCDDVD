
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// For serializatization
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
            s += "CDChamber Instrument List:  " + hiddenInstrumentList + "\n";
            return s;
        } //  end ToString

    }  // end CDClChamber Class
}  // end namespace

