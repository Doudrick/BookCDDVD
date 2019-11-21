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
        List<Product> testProducts = new List<Product>();

        List<GroupBox> groupCategories = new List<GroupBox>(6);
        List<Button> createButton = new List<Button>(5);
        public frmBookCDDVDShop()
        {
            InitializeComponent();
            groupCategories.Add(grpBook);
            groupCategories.Add(grpBookCIS);
            groupCategories.Add(grpCDChamber);
            groupCategories.Add(grpCDClassical);
            groupCategories.Add(grpCDOrchestra);
            groupCategories.Add(grpDVD);

            createButton.Add(btnCreateBook);
            createButton.Add(btnCreateBookCIS);
            createButton.Add(btnCreateDVD);
            createButton.Add(btnCreateCDOrchestra);
            createButton.Add(btnCreateCDChamber);
        }

        // this method load in all of the textboxes as read only
        private void frmBookCDDVDShop_Load(object sender, EventArgs e)
        {
            createTestProducts();
        
            // set all textboxes to read only
            grpProduct.Visible = false;
        } // end frmBookCDDVDShop_Load

        // this method hide and enable textboxes for Create Book button
        private void btnCreateBook_Click(object sender, EventArgs e)
        {

            // disable CreateaBook button and enable all other new entry button
            disableCreateButton(btnCreateBook);

            // clear the form
            clearForm();
        } // end btnCreateaBook

        // this method hide and enable textboxes for Create Book CIS button
        private void btnCreateBookCIS_Click(object sender, EventArgs e)
        {
            // hide every other group that are not BookCIS and Book

            // show group BookCIS and Book
            grpBookCIS.Visible = true;

            // disable CreateaBookCIS button and enable all other new entry button
            disableCreateButton(btnCreateBookCIS);

            // clear the form
            clearForm();

        } // end btnCreateaBookCIS

        // this method hide and enable textboxes for Create DVD button
        private void btnCreateDVD_Click(object sender, EventArgs e)
        {
            // hide every group that is not DVD
            hideGroups(grpDVD);

            // disable btnCreateDVD and enable all other new entry button
            disableCreateButton(btnCreateDVD);

            // clear the form
            clearForm();
        } // end btnCreateaDVD

        // this method only show and enable textboxes for createa DVD Orchestra button
        private void btnCreateCDOrchestra_Click(object sender, EventArgs e)
        {
            // hide every group that are not CDOrchestra and CDClassical
            hideGroups(grpCDOrchestra, grpCDChamber);

            // disabe createaDVDOrchestra button and enable other new entry button
            disableCreateButton(btnCreateCDOrchestra);

            // clear the form
            clearForm();
        } // end btnCreateaCDOrchestra

        // this method only show and enable textboxes for createa CD Chamber button
        private void btnCreateCDChamber_Click(object sender, EventArgs e)
        {
            // hide every group that is not related to CD chamber
            hideGroups(grpCDChamber, grpCDClassical);

            // disable button createa CD Chamber and enable all other new entry button
            disableCreateButton(btnCreateCDChamber);

            // clear the form
            clearForm();
        } // end btnCreateCDChamber

        // this method clear all of the textboxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            // clearing all the textboxes 
            clearForm();
        } // end btnClear_Click

        private void clearForm()
        {
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
        }

        private void createTestProducts()
        {
            Book tester = new Book(100, 20.20m, "hello world", 2, 856, 824, "me", 400);
            MessageBox.Show(tester.ToString());
            CDChamber testChamber = new CDChamber(83941, 20.37m, "Violins and Stuff", 100,  // For Product Constructor
            "Black Heart Musik", "Some old dude", "Violins, Cellos");
            MessageBox.Show(testChamber.ToString());
            testProducts.Add(tester);
            testProducts.Add(testChamber);
        }
            private void hideGroups(GroupBox toShow)
            {
                grpProduct.Visible = true;
                foreach (GroupBox i in groupCategories)
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
                grpProduct.Visible = true;
                foreach (GroupBox i in groupCategories)
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

            private void disableCreateButton(Button toDisable)
            {
                foreach (Button i in createButton)
                {
                    if (i == toDisable)
                    {
                        i.Enabled = false;
                    } else
                    {
                        i.Enabled = true;
                    }
                }
            }
     
    } // end frmBookCDDVDShop
} // end namespace BookCDDVD
