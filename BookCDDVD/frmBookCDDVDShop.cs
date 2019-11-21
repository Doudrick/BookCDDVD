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
        List<GroupBox> groupCategories = new List<GroupBox>(6);
        List<Button> createButton = new List<Button>(5);
        List<TextBox> textInput = new List<TextBox>(16);
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
            createButton.Add(btnInsert);
            createButton.Add(btnExit);
            createButton.Add(btnClear);

            textInput.Add(txtProductUPC);
            textInput.Add(txtProductPrice);
            textInput.Add(txtProductTitle);
            textInput.Add(txtProductQuantity);
            textInput.Add(txtBookISBNLeft);
            textInput.Add(txtBookISBNRight);
            textInput.Add(txtBookAuthor);
            textInput.Add(txtBookPages);
            textInput.Add(txtDVDLeadActor);
            textInput.Add(txtDVDReleaseDate);
            textInput.Add(txtDVDRunTime);
            textInput.Add(txtCDClassicalLabel);
            textInput.Add(txtCDClassicalArtists);
            textInput.Add(txtCDOrchestraConductor);
        }

        // this method load in all of the textboxes as read only
        private void frmBookCDDVDShop_Load(object sender, EventArgs e)
        {
            // set all textboxes to read only
            grpProduct.Visible = false;
        } // end frmBookCDDVDShop_Load

        // this method hide and enable textboxes for Create Book button
        private void btnCreateBook_Click(object sender, EventArgs e)
        {
            hideGroups(grpBook);

            // disable CreateaBook button and enable all other new entry button
            disableCreateButton(btnCreateBook);

            // clear the form
            clearForm();
        } // end btnCreateaBook

        // this method hide and enable textboxes for Create Book CIS button
        private void btnCreateBookCIS_Click(object sender, EventArgs e)
        {
            // hide every other group that are not BookCIS and Book
            hideGroups(grpBook, grpBookCIS);

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

        // this method clear all the textboxes
        private void clearForm()
        {
            // clearing the textboxes
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
        } // end clearForm
        
        // this method search the group categories user is looking for and show them
        private void hideGroups(GroupBox toShow)
        {
            // show the groupBox product
            grpProduct.Visible = true;

            // this for loops scan the categories and show the one user is looking for
            foreach (GroupBox i in groupCategories)
            {
                if (i == toShow)
                {
                    i.Visible = true;
                }
                else
                {
                    i.Visible = false;
                } // end else
            } // end foreach
        } // end hideGroups

        // this method is an overloading of the method above hideGroups
        // it take in two parameter of two different groupbxoes
        private void hideGroups(GroupBox toShow, GroupBox alsoToShow)
        {
            // show the product groupbox
            grpProduct.Visible = true;

            // this forloops search for two different group boxes user is looking for and show them
            foreach (GroupBox i in groupCategories)
            {
                if (i == toShow || i == alsoToShow)
                {
                    i.Visible = true;
                }
                else
                {
                    i.Visible = false;
                } // end else
            } // end foreach
        } // end hideGroups

        // this method disable the button that was clicked for new entry
        private void disableCreateButton(Button toDisable)
        {
            // this for loops search for the button user just click and disable it 
            foreach (Button i in createButton)
            {
                if (i == toDisable)
                {
                    i.Enabled = false;
                } else
                {
                    i.Enabled = true;
                } // end else
            } // end foreach
        } // end disableCreateButton

        private bool checkBook(TextBox Upc, TextBox Price, TextBox Title, 
            TextBox Quantity, TextBox ISBNL, TextBox ISBNR, TextBox Author, TextBox Pages)
        {
            bool check = false;
            int num = -1;
            string checkUPC = Convert.ToString(Upc);
            string checkPrice = Convert.ToString(Price);
            string checkTitle = Convert.ToString(Title);
            string checkQuantity = Convert.ToString(Quantity);
            string checkISBNL = Convert.ToString(ISBNL);
            string checkISBNR = Convert.ToString(ISBNR);
            string checkAuthor = Convert.ToString(Author);
            string checkPages = Convert.ToString(Pages);

            if (!int.TryParse(checkUPC, out num))
            {
                check = false;      
            } else if (!int.TryParse(checkPrice, out num))
            {
                MessageBox.Show("Please Enter a valid Price");
            } else
            {
                
            }
            return check;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            checkBook(txtProductUPC, txtProductPrice, txtProductTitle, txtProductQuantity, txtBookISBNLeft,
                txtBookISBNRight, txtBookAuthor, txtBookPages);
        }

    } // end frmBookCDDVDShop
} // end namespace BookCDDVD
