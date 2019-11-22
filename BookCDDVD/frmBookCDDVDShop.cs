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
            textInput.Add(txtCDOrchestralConductor);
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
            // hide every other group that are not CreateBook
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
            txtCDOrchestralConductor.Clear();
            txtCDChamberInstrumentList.ResetText();
        } // end clearForm

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
                }
            }
        }

        // this method is an overloading of the method above hideGroups
        // it take in two parameter of two different groupbxoes
        private void hideGroups(GroupBox toShow, GroupBox alsoToShow)
        {
            // show the product groupbox
            grpProduct.Visible = true;

            // this for each loops search the categories and show the group the user is looking for
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
            } // ense foreach
        } // end hideGroups

        // this method is looking for the group that are visible
        private bool checkVisibleGroup(GroupBox areVisible)
        {
            // this for each loops search for the visible group and return true
            // so user can check the validation for that group input
            foreach (GroupBox i in groupCategories)
            {
                if (i == areVisible)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } // end foreach
            return true;
        } // end checkVisibleGroup

        // this method is looking for the group that are visible
        // it an overloading of the method above, taking two parameters instead
        private bool checkVisibleGroup(GroupBox areVisible, GroupBox areAlsoVisible)
        {
            // this for each loops search for the visible group and return true
            // so user can check the validation for that group input
            foreach (GroupBox i in groupCategories)
            {
                if (i == areVisible || i == areAlsoVisible)
                {
                    return true;
                } else
                {
                    return false;
                }
            } // end foreach
            return false;
        } // end checkVisibleGroup

        // this method disable the button that was clicked for new entry

        // this method disable the button that are being clicked on
        private void disableCreateButton(Button toDisable)
        {
        // this foreach loops search for the button that was just click and disable it
        // it also enable the button that was not being clicked on (only for createa button)
            foreach (Button i in createButton)
            {
                  if(i == toDisable)
                {
                    i.Enabled = false;
                } else
                {
                    i.Enabled = true;
                }
            } // end foreach 
        } // end disableCreateButton

        // this method validating the product group box
        private void checkProduct (TextBox Upc, TextBox Price, TextBox Title,
            TextBox Quantity)
        {
            int num = -1;
            decimal num1 = -1;
            string checkUPC = Convert.ToString(Upc.Text);
            string checkTitle = Convert.ToString(Price.Text);
            string checkPrice = Convert.ToString(Title.Text);
            string checkQuantity = Convert.ToString(Quantity.Text);

            // return an error message if the input is empty, longer or shorter then 5, or is a letter
            if (checkUPC.Equals("") || checkUPC.Length < 5 || checkUPC.Length > 5 ||
                (!int.TryParse(checkUPC, out num)))
            {
                txtProductUPC.Clear();
                MessageBox.Show("Please Enter A Valid UPC");
            }
            // return an error message if the input is empty or is a letter
            else if (checkPrice.Equals("") || (!decimal.TryParse(checkPrice, out num1)))
            {
                txtProductPrice.Clear();
                MessageBox.Show("Please Enter a valid Price");
            }
            // return an error message if the input is empty or is a letter
            else if (checkQuantity.Equals("") || (!int.TryParse(checkQuantity, out num))){
                txtProductQuantity.Clear();
                MessageBox.Show("Please Enter a valid Quantity");
            }
            // return an error message if the input is empty
            else if (checkTitle.Equals(""))
            {
                MessageBox.Show("Please Enter a Title");
            }
        } // end checkProduct
        
        // this method validating the group book
        private void checkBook(TextBox ISBNL, TextBox ISBNR, TextBox Author, TextBox Pages)
        {
            int num = -1;
            string checkISBNL = Convert.ToString(ISBNL.Text);
            string checkISBNR = Convert.ToString(ISBNR.Text);
            string checkAuthor = Convert.ToString(Author.Text);
            string checkPages = Convert.ToString(Pages.Text);

            // return a error message if user is not inputing information or the input is 
            // long then 3, shorter then 3, or a letter
            if (checkISBNL.Equals("") || checkISBNL.Length < 3 || checkISBNL.Length > 3 ||
                (!int.TryParse(checkISBNL, out num)))
            {
                ISBNL.Clear();
                MessageBox.Show("Please Enter a valid ISBN on the Left text box");
            }
            // return a error message if user is not inputing information or the input is 
            // long then 3, shorter then 3, or a letter
            else if (checkISBNR.Equals("") || checkISBNR.Length < 3 || checkISBNR.Length > 3 ||
                (!int.TryParse(checkISBNR, out num)))
            {
                ISBNR.Clear();
                MessageBox.Show("Please Enter a valid ISBN on the Right text box");
            }
            // return the error message if the input is blank or is a number
            else if (checkAuthor.Equals("") || (int.TryParse(checkAuthor, out num)))
            {
                txtBookAuthor.Clear();
                MessageBox.Show("Please Enter a valid Author name");
            }
            // return the error message if the input is empty or is a letter
            else if (checkPages.Equals("") || (!int.TryParse(checkISBNL, out num)))
            {
                txtBookPages.Clear();
                MessageBox.Show("Please Enter a valid page number");
            }
        } // end checkBook
        
        // NOT SURE ABOUT THIS ONE YET, HAVE TO CHECK RELEASE DATE VALIDATION
        private void checkDVD (TextBox leadActor, TextBox ReleaseDate, TextBox runTime)
        {
            string checkLeadActor = Convert.ToString(leadActor);
            string checkReleasedate = Convert.ToString(ReleaseDate.Text);
            string checkrunTime = Convert.ToString(runTime.Text);

        }

        // this method is validating the CD Classical groupbox
        private void checkCDClassical(TextBox Label, TextBox Artists)
        {
            string checkLabel = Convert.ToString(Label.Text);
            string checkArtists = Convert.ToString(Artists.Text);

            // return an error message if the input empty
            if (checkLabel.Equals(""))
            {
                txtCDClassicalLabel.Clear();
                MessageBox.Show("Please Enter a label");
            } 
            // return an error message if the input is empty
            else if (checkArtists.Equals(""))
            {
                txtCDClassicalArtists.Clear();
                MessageBox.Show("Please Enter an Artist Name");
            }
        } // end CheckCDClassical

        // this method validating the orchestral conductor
        private void checkOrchestralConductor(TextBox Conductor)
        {
            string checkConductor = Convert.ToString(Conductor.Text);

            // return an error message if the input is empty
            if (checkConductor.Equals(""))
            {
                txtCDOrchestralConductor.Clear();
                MessageBox.Show("Please Enter a Conductor name");
            }
        } // end checkOrchestralConductor

        // this method find which groupbox are visible and validating those textboxes input\
        private void validatingVisisbleGrp()
        {
            // if groupbox book are visible or groupbox book and bookCIS are visible, check the input validation
            if (checkVisibleGroup(grpBook) == true || checkVisibleGroup(grpBook, grpBookCIS) == true)
            {
                checkProduct(txtProductUPC, txtProductPrice, txtProductTitle, txtProductQuantity);
                checkBook(txtBookISBNLeft, txtBookISBNRight, txtBookAuthor, txtBookPages);
            }
            // if groupbox DVD are visible, check the input validation
            else if (checkVisibleGroup(grpDVD) == true)
            {
                checkProduct(txtProductUPC, txtProductPrice, txtProductTitle, txtProductQuantity);
            }
            // if groupbox CD Classical are visisble, check the input validation
            else if (checkVisibleGroup(grpCDClassical) == true)
            {
                checkProduct(txtProductUPC, txtProductPrice, txtProductTitle, txtProductQuantity);
                checkCDClassical(txtCDClassicalLabel, txtCDClassicalArtists);
            }
            // if groupbox CD Orchestra are visible, check the input validation
            else if (checkVisibleGroup(grpCDOrchestra) == true)
            {
                checkProduct(txtProductUPC, txtProductPrice, txtProductTitle, txtProductQuantity);
                checkOrchestralConductor(txtCDOrchestralConductor);
            }
        } // end validatingVisibleGrp

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // validating the visible groupbox
            validatingVisisbleGrp();
        } // end btnInsert_Click

        // this nethod exit the program
        private void btnExit_Click(object sender, EventArgs e)
        {
            // close the program
            this.Close();
        } // end btnExit_Click
    } // end frmBookCDDVDShop
} // end namespace BookCDDVD