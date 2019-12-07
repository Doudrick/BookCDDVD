
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
        }

        private string UPC = "";

        private void btnSearchSubmit_Click(object sender, EventArgs e)
        {
            //When the search button is clicked, set the public variable equal to the entered UPC.
            //Set the dialog result of this to OK, and close.
            UPC = txtUPC.Text;
            txtUPC.Text = "";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

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
            }
        } // end txtUPC_TextChanged 

        public string getUPC()
        {
            return UPC;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    } // end frmSearchDialog
} // end namespace BookCDDVD
