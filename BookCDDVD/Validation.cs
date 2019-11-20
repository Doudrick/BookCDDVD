using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCDDVD
{
    class Validation
    {
        public static Boolean checkUPC(string upcInput)
        {
            int num = -1;

            // this check if it's a number 
            if (!int.TryParse(upcInput, out num))
            {
                return false;
            }
            return false;
        }
    }
}
