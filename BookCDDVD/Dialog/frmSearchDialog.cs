
/*
 * 
 * Tyler Doudrick
 * Tai Nguyen
 * 11/23/2019
 * Codebehind for Search Dialog Box
 * Project 4: BookCDDVDShop
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookCDDVD
{
    public partial class frmSearchDialog : Form
    {
        public frmSearchDialog()
        {
            InitializeComponent();
            txtUPC.Focus();
        } // end frmSearchDialog

        private string UPC = "";

        // this button search after being click
        private void btnSearchSubmit_Click(object sender, EventArgs e)
        {
            //When the search button is clicked, set the public variable equal to the entered UPC.
            //Set the dialog result of this to OK, and close.
            UPC = txtUPC.Text;
            txtUPC.Text = "";
            txtUPC.Focus();
            this.DialogResult = DialogResult.OK;
            this.Close();
        } // end btnSearchSubmit

        //You're searching for 5 UPCs, or you aren't searching at all.
        private void txtUPC_TextChanged(object sender, EventArgs e)
        {
            if(((TextBox)sender).Text.ToString().Length == 5)
            {
                btnSearchSubmit.Enabled = true;
            }
            else
            {
                btnSearchSubmit.Enabled = false;
            } // end else
        } // end txtUPC_TextChanged 

        // return a upc
        public string getUPC()
        {
            return UPC;
        } // end getUPC

        // this button cancel the search
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } // end btnCancel_Click

        // load search form
        private void frmSearchDialog_Load(object sender, EventArgs e)
        {
            txtUPC.Focus();
        } // end frmSearchDialog_Load
    } // end frmSearchDialog
} // end namespace BookCDDVD
