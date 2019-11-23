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

        //Indexer method to retrieve Products from the list as if it were an array
        public Product this[int index]
        {
            get
            {
                return products[index];
            }
        }
    }
}
