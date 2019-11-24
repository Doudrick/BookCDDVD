
/*
 * 
 * Tyler Doudrick
 * Tai Nguyen
 * 11/23/2019
 * Product Class - All product types inherit from this class.
 * Project 4: BookCDDVDShop
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// For serialization
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using BookCDDVD;

namespace BookCDDVD
{
    [Serializable()]
    public abstract class Product
    {
        private int hiddenUPC;
        private decimal hiddenPrice;
        private string hiddenTitle;
        private int hiddenQuantity;

        // Parameterless Constructor
        public Product()
        {
            hiddenUPC = 0;
            hiddenPrice = 0.0m;
            hiddenTitle = "";
            hiddenQuantity = 0;
        }  // end Parameterless Constructor

        // Parameterized Constructor
        public Product(int UPC, decimal price, string title, int quantity)
        {
            hiddenUPC = UPC;
            hiddenPrice = price;
            hiddenTitle = title;
            hiddenQuantity = quantity;
        }  // end Parameterized Constructor


        // Accessor/Mutator for UPC
        public int getUPC()
        {
            return hiddenUPC;
        } // end getUPC

        // Accessor/Mutator for product price 
        public decimal getPrice()
        {
            return hiddenPrice;
        } // end getPrice


        // Accessor/mutator for product title
        public string getTitle()
        {
            return hiddenTitle;
        } // end getTitle


        // Accessor/mutator for product quantity
        public int getQuantity()
        {
            return hiddenQuantity;
        } // getQuantity


        // Save data from form to object
        public virtual void Save(frmBookCDDVDShop f)
        {
            hiddenUPC = Convert.ToInt32(f.txtProductUPC.Text);
            hiddenPrice = Convert.ToDecimal(f.txtProductPrice.Text);
            hiddenTitle = f.txtProductTitle.Text;
            hiddenQuantity = Convert.ToInt32(f.txtProductQuantity.Text);
        }  // end Save


        // Display data in object on form
        public virtual void Display(frmBookCDDVDShop f)
        {
            f.txtProductUPC.Text = hiddenUPC.ToString();
            f.txtProductPrice.Text = hiddenPrice.ToString();
            f.txtProductTitle.Text = hiddenTitle;
            f.txtProductQuantity.Text = hiddenQuantity.ToString();
        }  // end Display


        // This toString function overrides the Object toString
        // function.  The base refers to Object because this class
        // inherits Object by default.
        public override string ToString()
        {
            string s = "Object Type: " + base.ToString() + "\n";
            s += "Product UPC: " + hiddenUPC + "\n";
            s += "Product Title: " +hiddenTitle + "\n";
            s += "Product Price: " + Convert.ToDecimal(hiddenPrice) + "\n";
            s += "Product Quantity: " + Convert.ToInt32(hiddenQuantity) + "\n";
            return s;
        }  // end ToString


    } // end Product Class
} // end namespace
