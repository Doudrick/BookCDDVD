﻿using System;
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
        public string returnedUPC;
        public frmSearchDialog()
        {
            InitializeComponent();
        }

        private void btnSearchSubmit_Click(object sender, EventArgs e)
        {
            //When the search button is clicked, set the public variable equal to the entered UPC.
            //Set the dialog result of this to OK, and close.
            returnedUPC = txtUPC.Text;
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
    } // end frmSearchDialog
} // end namespace BookCDDVD