﻿
/*
 * 
 * Tyler Doudrick
 * Tai Nguyen
 * 11/23/2019
 * CDOrchestra Class - Inherits from CDClassical Class
 * Project 4: BookCDDVDShop
 * 
 * 
 */
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
    // CDChamber inherits the data and methods in CDClassical and can be a serialized to a binary file
    [Serializable()]
    class CDOrchestra : CDClassical
    {
        private string hiddenConductor;

        // Parameterless Constructor
        public CDOrchestra()
        {
            hiddenConductor = "";
        }  // end Parameterless Constructor

        //Takes a dictionary as a parameter which contains everything unique to it AND everything unique to its base class (CDClassical)
        public CDOrchestra(int UPC, decimal price, string title, int quantity,  // For Product Constructor
            IDictionary<string, string> param) : base(UPC, price, title, quantity, param)
        {
            hiddenConductor = param["CDOrchestraConductor"];
        }  // end parameterized constructor

        // These six methods replace what were VB Properties
        // get or set an item in the List
        // Accessor/mutator for Tuition, Year and Credits
        public string getCDOrchestraConductor()
        {
            return hiddenConductor;
        }  // end getgradHourlyPay

        // Save data from form to object
        public override void Save(frmBookCDDVDShop f)
        {
            base.Save(f);
            hiddenConductor = f.txtCDOrchestraConductor.Text;
        }  // end Save

        // Display data in object on form
        public override void Display(frmBookCDDVDShop f)
        {
            base.Display(f);
            f.txtCDOrchestraConductor.Text = hiddenConductor;
        }  // end Display

        // This toString function overrides the Student toString
        // function.  The base refers to the Student because this class
        // inherits Student by definition.
        public override string ToString()
        {
            string s = base.ToString() + "\n";
            s += "CDOrchestra Instrument List:  " + hiddenConductor + "\n";
            return s;
        } //  end ToString
    }  // end CDClChamber Class
}  // end namespace

