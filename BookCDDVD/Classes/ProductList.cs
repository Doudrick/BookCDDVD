
/*
 * 
 * Tyler Doudrick
 * Tai Nguyen
 * 11/23/2019
 * ProductList - Contains a list of Products and methods to interact with it.
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
    public class ProductList
    {
        private List<Product> products = new List<Product>();
        public ProductList()
        {
        } // end products
        public void addProduct(Product input)
        {
            products.Add(input);
        } // end addProduct
        public int getCount()
        {
            return products.Count;
        } // end getCount

        public int removeProduct(int index)
        {
            products.RemoveAt(index);
            products.TrimExcess();
            return getCount();
        } // end removeProduct

        //Indexer method to retrieve Products from the list as if it were an array
        public Product this[int index]
        {
            get
            {
                return products[index];
            }
        } // end Product
    } // end ProductList
} // end namespace BookDVD
