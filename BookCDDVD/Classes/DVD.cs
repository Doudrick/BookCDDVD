using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCDDVD
{
    class DVD : Product
    {
        string hiddenLeadActor = "";
        DateTime hiddenReleaseDate = new DateTime();
        int hiddenRunTime = 0;

        public DVD(int UPC, decimal price, string title, int quantity, string leadActor, DateTime releaseDate, int runTime) : base(UPC, price, title, quantity)
        {
            hiddenLeadActor = leadActor;
            hiddenReleaseDate = releaseDate;
            hiddenRunTime = runTime;
        }

        public string getActor()
        {
            return hiddenLeadActor;
        }
        public DateTime getReleaseDate()
        {
            return hiddenReleaseDate;
        }

        public int getRunTime()
        {
            return hiddenRunTime;
        }

        public override string ToString()
        {
            string s = base.ToString() + "\n";
            s += "DVD Lead Actor: " + hiddenLeadActor + "\n";
            s += "DVD Release Date: " + hiddenReleaseDate + "\n";
            s += "DVD Run Time: " + hiddenRunTime + "\n";
            return s;
        }  // end ToString
    }
}
