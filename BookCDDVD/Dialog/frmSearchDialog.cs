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
        public string returnedUPC;
        public frmSearchDialog()
        {
            InitializeComponent();
        }

        private void btnSearchSubmit_Click(object sender, EventArgs e)
        {
            returnedUPC = txtUPC.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
