
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


        //Takes a dictionary as a parameter which contains everything unique to it AND everything unique to its base class (CDClassical)
        public CDChamber(int UPC, decimal price, string title, int quantity,  // For Product Constructor
            IDictionary<string, string> param) : base(UPC, price, title, quantity, param)
        {
            hiddenInstrumentList = param["CDChamberInstrumentList"];
        }  // end parameterized constructor



        // These six methods replace what were VB Properties
        // get or set an item in the List
        // Accessor/mutator for Tuition, Year and Credits
        public string getCDChamberInstrumentList()
        {
            return hiddenInstrumentList;
        }  // end getgradHourlyPay


        // Save data from form to object
        public override void Save(frmBookCDDVDShop f)
        {
            base.Save(f);
            hiddenInstrumentList = f.cbCDChamberInstrumentList.Text;
        }  // end Save


        // Display data in object on form
        public override void Display(frmBookCDDVDShop f)
        {
            base.Display(f);
            f.cbCDChamberInstrumentList.Text = hiddenInstrumentList;
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

