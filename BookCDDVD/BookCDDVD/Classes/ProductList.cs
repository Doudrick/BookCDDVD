using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCDDVDShop;

namespace BookCDDVDShop

{
    public class ProductList
    {
        List<Product> pList;
    
        public ProductList()
        {
            pList = new List<Product>();
        }

        public void addToList(Product product)
        {
            pList.Add(product);
        }

        public void removeToList(Product product)
        {
            pList.Remove(product);
        }

        public int getCount()
        {
           return pList.Count(); 
        }
    }
}
