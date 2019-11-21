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
    public partial class frmBookCDDVDShop : Form
    {
        List<GroupBox> test = new List<GroupBox>(6);
        public frmBookCDDVDShop()
        {
            InitializeComponent();
            test.Add(grpBook);
            test.Add(grpBookCIS);
            test.Add(grpCDChamber);
            test.Add(grpCDClassical);
            test.Add(grpCDOrchestra);
            test.Add(grpDVD);

        }

        // this method load in all of the textboxes as read only
        private void frmBookCDDVDShop_Load(object sender, EventArgs e)
        {
            // set all textboxes to read only
            txtProductUPC.ReadOnly = true;
            txtProductPrice.ReadOnly = true;
            txtProductTitle.ReadOnly = true;
            txtProductQuantity.ReadOnly = true;
            txtBookISBNLeft.ReadOnly = true;
            txtBookISBNRight.ReadOnly = true;
            txtBookAuthor.ReadOnly = true;
            txtBookPages.ReadOnly = true;
            txtBookCISCISArea.Enabled = false;
            txtDVDLeadActor.ReadOnly = true;
            txtDVDReleaseDate.ReadOnly = true;
            txtDVDRunTime.ReadOnly = true;
            txtCDClassicalLabel.ReadOnly = true;
            txtCDClassicalArtists.ReadOnly = true;
            txtCDOrchestraConductor.ReadOnly = true;
            txtCDChamberInstrumentList.Enabled = false;
        } // end frmBookCDDVDShop_Load

        // this method hide and enable textboxes for Create Book button
        private void btnCreateBook_Click(object sender, EventArgs e)
        {
            hideGroups(grpBook);

            // disable CreateaBook button and enable all other new entry button
            btnCreateBook.Enabled = false;
            btnCreateBookCIS.Enabled = true;
            btnCreateDVD.Enabled = true;
            btnCreateCDOrchestra.Enabled = true;
            btnCreateCDChamber.Enabled = true;

            // Since all textboxes were disable when the programs loaded, certain
            // textboxes need to enable for the input of CreateaBook
            txtProductUPC.ReadOnly = false;
            txtProductPrice.ReadOnly = false;
            txtProductTitle.ReadOnly = false;
            txtProductQuantity.ReadOnly = false;
            txtBookISBNLeft.ReadOnly = false;
            txtBookISBNRight.ReadOnly = false;
            txtBookAuthor.ReadOnly = false;
            txtBookPages.ReadOnly = false;
        } // end btnCreateaBook

        // this method hide and enable textboxes for Create Book CIS button
        private void btnCreateBookCIS_Click(object sender, EventArgs e)
        {
            // hide every other group that are not BookCIS and Book
            hideGroups(grpBook, grpBookCIS);

            // show group BookCIS and Book
            grpBookCIS.Visible = true;

            // disable CreateaBookCIS button and enable all other new entry button
            btnCreateBook.Enabled = true;
            btnCreateBookCIS.Enabled = false;
            btnCreateDVD.Enabled = true;
            btnCreateCDOrchestra.Enabled = true;
            btnCreateCDChamber.Enabled = true;

            // Since all textboxes were disable when the programs loaded, certain
            // textboxes need to enable for the input of CreateaBookCIS
            txtProductUPC.ReadOnly = false;
            txtProductPrice.ReadOnly = false;
            txtProductTitle.ReadOnly = false;
            txtProductQuantity.ReadOnly = false;
            txtBookISBNLeft.ReadOnly = false;
            txtBookISBNRight.ReadOnly = false;
            txtBookAuthor.ReadOnly = false;
            txtBookPages.ReadOnly = false;
            txtBookCISCISArea.Enabled = true;
        } // end btnCreateaBookCIS

        // this method hide and enable textboxes for Create DVD button
        private void btnCreateDVD_Click(object sender, EventArgs e)
        {
            // hide every group that is not DVD
            grpBook.Visible = false;
            grpBookCIS.Visible = false;
            grpCDClassical.Visible = false;
            grpCDOrchestra.Visible = false;
            grpCDChamber.Visible = false;

            // show DVD group
            grpDVD.Visible = true;

            // disable btnCreateDVD and enable all other new entry button
            btnCreateBook.Enabled = true;
            btnCreateBookCIS.Enabled = true;
            btnCreateDVD.Enabled = false;
            btnCreateCDOrchestra.Enabled = true;
            btnCreateCDChamber.Enabled = true;

            // Since all textboxes were disable when the programs loaded, certain
            // textboxes need to enable for input of CreateaDVD
            txtProductUPC.ReadOnly = false;
            txtProductPrice.ReadOnly = false;
            txtProductTitle.ReadOnly = false;
            txtProductQuantity.ReadOnly = false;
            txtDVDLeadActor.ReadOnly = false;
            txtDVDReleaseDate.ReadOnly = false;
            txtDVDRunTime.ReadOnly = false;
        } // end btnCreateaDVD

        // this method only show and enable textboxes for createa DVD Orchestra button
        private void btnCreateCDOrchestra_Click(object sender, EventArgs e)
        {
            // hide every group that are not CDOrchestra and CDClassical
            grpBook.Visible = false;
            grpBookCIS.Visible = false;
            grpDVD.Visible = false;
            grpCDClassical.Visible = false;
            grpCDChamber.Visible = false;

            // show CDOrchestra and CDClassical group
            grpCDOrchestra.Visible = true;
            grpCDClassical.Visible = true;

            // disabe createaDVDOrchestra button and enable other new entry button
            btnCreateBook.Enabled = true;
            btnCreateBookCIS.Enabled = true;
            btnCreateDVD.Enabled = true;
            btnCreateCDOrchestra.Enabled = false;
            btnCreateCDChamber.Enabled = true;

            // Since all textboxes were disable when the programs loaded, certain
            // textboxes need to enable for the input of CreateaDVDOrchestra
            txtProductUPC.ReadOnly = false;
            txtProductPrice.ReadOnly = false;
            txtProductTitle.ReadOnly = false;
            txtProductQuantity.ReadOnly = false;
            txtCDClassicalLabel.ReadOnly = false;
            txtCDClassicalArtists.ReadOnly = false;
            txtCDOrchestraConductor.ReadOnly = false;
        } // end btnCreateaCDOrchestra

        // this method only show and enable textboxes for createa CD Chamber button
        private void btnCreateCDChamber_Click(object sender, EventArgs e)
        {
            // hide every group that is not related to CD chamber
            grpBook.Visible = false;
            grpBookCIS.Visible = false;
            grpDVD.Visible = false;
            grpCDClassical.Visible = false;
            grpCDOrchestra.Visible = false;


            // show CD Chamber and CD Classical group
            grpCDChamber.Visible = true;
            grpCDClassical.Visible = true;

            // disable button createa CD Chamber and enable all other new entry button
            btnCreateBook.Enabled = true;
            btnCreateBookCIS.Enabled = true;
            btnCreateDVD.Enabled = true;
            btnCreateCDOrchestra.Enabled = true;
            btnCreateCDChamber.Enabled = false;

            // Since all textboxes were disable when the programs loaded in, certain
            // textboxes need to enable for input of Create CD Chamber
            txtProductUPC.ReadOnly = false;
            txtProductPrice.ReadOnly = false;
            txtProductTitle.ReadOnly = false;
            txtProductQuantity.ReadOnly = false;
            txtCDClassicalLabel.ReadOnly = false;
            txtCDClassicalArtists.ReadOnly = false;
            txtCDOrchestraConductor.ReadOnly = false;
            txtCDChamberInstrumentList.Enabled = true;
        } // end btnCreateCDChamber

        // this method clear all of the textboxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            // clearing all the textboxes 
            txtProductUPC.Clear();
            txtProductPrice.Clear();
            txtProductTitle.Clear();
            txtProductQuantity.Clear();
            txtBookISBNLeft.Clear();
            txtBookISBNRight.Clear();
            txtBookAuthor.Clear();
            txtBookPages.Clear();
            txtBookCISCISArea.ResetText();
            txtDVDLeadActor.Clear();
            txtDVDReleaseDate.Clear();
            txtDVDRunTime.Clear();
            txtCDClassicalLabel.Clear();
            txtCDClassicalArtists.Clear();
            txtCDOrchestraConductor.Clear();
            txtCDChamberInstrumentList.ResetText();
        } // end btnClear_Click

        private void btnEnterUPC_Click(object sender, EventArgs e)
        {
            grpControlsNewEntry.Visible = true;
            grpProduct.Visible = true;
        }
        private void hideGroups(GroupBox toShow)
        {
            foreach (GroupBox i in test)
            {
                if (i == toShow)
                {
                    i.Visible = true;
                }
                else
                {
                    i.Visible = false;
                }
            }
        }
        private void hideGroups(GroupBox toShow, GroupBox alsoToShow)
        {
            foreach (GroupBox i in test)
            {
                if (i == toShow || i == alsoToShow)
                {
                    i.Visible = true;
                }
                else
                {
                    i.Visible = false;
                }
            }
        }
    } // end frmBookCDDVDShop
} // end namespace BookCDDVD
