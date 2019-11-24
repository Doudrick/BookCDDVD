
/*
 * 
 * Tyler Doudrick
 * Tai Nguyen
 * 11/23/2019
 * DVD Class - Inherits from Product Class
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
    class DVD : Product
    {
        string hiddenLeadActor = "";
        DateTime hiddenReleaseDate = new DateTime();
        int hiddenRunTime = 0;


        //Takes a dictionary as a parameter which contains everything unique to it and not it's base class (Product)
        public DVD(int UPC, decimal price, string title, int quantity, IDictionary<string, string> param) : base(UPC, price, title, quantity)
        {
            hiddenLeadActor = param["DVDLeadActor"];
            hiddenReleaseDate = DateTime.Parse(param["DVDReleaseDate"]);
            hiddenRunTime = Int32.Parse(param["DVDRuntime"]);
        } // end DVD

        public string getActor()
        {
            return hiddenLeadActor;
        } // end getActor

        public DateTime getReleaseDate()
        {
            return hiddenReleaseDate;
        } // end getReleaseDate

        public int getRunTime()
        {
            return hiddenRunTime;
        } // end getRunTime

        public override string ToString()
        {
            string s = base.ToString() + "\n";
            s += "DVD Lead Actor: " + hiddenLeadActor + "\n";
            s += "DVD Release Date: " + hiddenReleaseDate + "\n";
            s += "DVD Run Time: " + hiddenRunTime + "\n";
            return s;
        }  // end ToString
    } // end classDVD
} // end namespace BookDVD
