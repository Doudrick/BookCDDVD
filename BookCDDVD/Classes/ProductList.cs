using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCDDVD;

namespace BookCDDVD
{
    public class ProductList
    {
        List<Product> products = new List<Product>();
        public ProductList()
        {

        }
        public void addProduct(Product input)
        {
            products.Add(input);
        }
        public int getCount()
        {
            return products.Count;
        }
        //this can't be in product list. Product list should not know about its contents.
        //public bool findProduct(int upc, out Product foundProduct)
        //{
        //    foundProduct = null;
        //    foreach (Product i in products)
        //    {
        //        if(i.ProductUPC == upc)
        //        {
        //            foundProduct = i;
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
