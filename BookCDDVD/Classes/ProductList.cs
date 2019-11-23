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
            products.TrimExcess();
        }
        public void addProduct(Product input)
        {
            products.Add(input);
            products.TrimExcess();
        }
        public int getCount()
        {
            return products.Count;
        }

        public int removeProduct(int index)
        {
            products.RemoveAt(index);
            products.TrimExcess();
            return getCount();
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
