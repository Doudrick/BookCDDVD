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
        ProductList InStock = new ProductList();

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
            createButton.Add(btnCreateCDOrchestra);

            txtBookCISArea.DropDownStyle = ComboBoxStyle.DropDownList;
            txtBookCISArea.Items.Add("Computer Sciences");
            txtBookCISArea.Items.Add("Information Sciences");
        }

        // this method load in all of the textboxes as read only
        private void frmBookCDDVDShop_Load(object sender, EventArgs e)
        {        
            // set all textboxes to read only
            grpProduct.Visible = false;
            dtDVDReleaseDate.MaxDate = DateTime.Today;


            lblUniqProducts.Text = InStock.getCount().ToString();
            lblTotalQuant.Text = InStock.getCount().ToString();

            //Disable the search if there's nothing to search!
            if (InStock.getCount() == 0)
            {
                btnSearch.Enabled = false;
            }


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
            hideGroups(grpCDClassical, grpCDOrchestra);

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
            txtBookCISArea.ResetText();
            txtDVDLeadActor.Clear();
            txtDVDRunTime.Clear();
            txtCDClassicalLabel.Clear();
            txtCDClassicalArtists.Clear();
            txtCDOrchestraConductor.Clear();
            txtCDChamberInstrumentList.ResetText();
            txtProductUPC.Focus();
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
                }
            } // end foreach
        } // end hideGroups

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
            if (areVisible.Visible)
            {
                return true;
            }
            return false;
        } // end checkVisibleGroup

        // this method is looking for the group that are visible
        // it an overloading of the method above, taking in two parameters instead
        private bool checkVisibleGroup(GroupBox areVisible, GroupBox areAlsoVisible)
        {
            // this for each loops search for the visible group and return true
            // so user can check the validation for that group input

                if (areVisible.Visible && areAlsoVisible.Visible)
                {
                return true;
                }
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
        private bool checkProduct (TextBox Upc, TextBox Price, TextBox Title,
            TextBox Quantity)
        {
            int num = -1;
            decimal num1 = -1;
            string checkUPC = Convert.ToString(Upc.Text);
            string checkTitle = Convert.ToString(Title.Text);
            string checkPrice = Convert.ToString(Price.Text);
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
            else if (checkQuantity.Equals("") || (!int.TryParse(checkQuantity, out num)))
            {
                txtProductQuantity.Clear();
                MessageBox.Show("Please Enter a valid Quantity");
            }
            // return an error message if the input is empty
            else if (checkTitle.Equals(""))
            {
                MessageBox.Show("Please Enter a Title");
            }
            else
            {
                return true;
            }
            return false;
        } // end checkProduct
        
        // this method validating the group book
        private bool checkBook(TextBox ISBNL, TextBox ISBNR, TextBox Author, TextBox Pages)
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
                txtBookISBNLeft.Clear();
                MessageBox.Show("Please Enter a valid ISBN on the Left text box");
            }
            // return a error message if user is not inputing information or the input is 
            // long then 3, shorter then 3, or a letter
            else if (checkISBNR.Equals("") || checkISBNR.Length < 3 || checkISBNR.Length > 3 ||
                (!int.TryParse(checkISBNR, out num)))
            {
                txtBookISBNRight.Clear();
                MessageBox.Show("Please Enter a valid ISBN on the Right text box");
            }
            // return the error message if the input is blank or is a number
            else if (checkAuthor.Equals("") || (int.TryParse(checkAuthor, out num)))
            {
                txtBookAuthor.Clear();
                MessageBox.Show("Please Enter a valid Author name");
            }
            // return the error message if the input is empty or is a letter
            else if (checkPages.Equals("") || (!int.TryParse(checkPages, out num)))
            {
                txtBookPages.Clear();
                MessageBox.Show("Please Enter a valid page number");
            }
            else
            {
                return true;
            }
            return false;
        } // end checkBook
        
        // this method check the DVD group input validation
        private bool checkDVD (TextBox leadActor, TextBox runTime)
        {
            int num = -1;
            string checkLeadActor = Convert.ToString(leadActor.Text);
            int checkrunTime = Convert.ToInt32(runTime.Text);

            // return an error message if the leadactor textbox are empty or is a number
            if (checkLeadActor.Equals(""))
            {
                txtDVDLeadActor.Clear();
                MessageBox.Show("Please Enter a valid Lead Actor name");
            }
            // return an error message if  the run time is empty, less then 0 or more  then 120 minutes
            else if (checkrunTime.Equals("") || checkrunTime < 0 || checkrunTime > 120 ||
                (!int.TryParse(checkrunTime.ToString(), out num)))
            {
                txtDVDRunTime.Clear();
                MessageBox.Show("Please enter a valid run time");
            }
            else
            {
                return true;
            }
            return false;
        } // end checkDVD

        // this method is validating the CD Classical groupbox
        private bool checkCDClassical(TextBox Label, TextBox Artists)
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
            else
            {
                return true;
            }
            return false;
        } // end CheckCDClassical

        // this method validating the orchestral conductor
        private bool checkOrchestralConductor(TextBox Conductor)
        {
            string checkConductor = Convert.ToString(Conductor.Text);

            // return an error message if the input is empty
            if (checkConductor.Equals(""))
            {
                txtCDOrchestraConductor.Clear();
                MessageBox.Show("Please Enter a Conductor name");
            }
            else
            {
                return true;
            }
            return false;
        } // end checkOrchestralConductor

        // this method find which groupbox are visible and validating those textboxes input\
        private void validatingVisisbleGrp()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            if (checkProduct(txtProductUPC, txtProductPrice, txtProductTitle, txtProductQuantity))
            {
                dict["ProductUPC"] = txtProductUPC.Text;
                dict["ProductPrice"] = txtProductPrice.Text;
                dict["ProductTitle"] = txtProductTitle.Text;
                dict["ProductQuantity"] = txtProductQuantity.Text;

                // if groupbox book are visible or groupbox book and bookCIS are visible, check the input validation
                if (checkVisibleGroup(grpBook) == true)
                {
                    if (checkBook(txtBookISBNLeft, txtBookISBNRight, txtBookAuthor, txtBookPages))
                    {
                        dict["ISBNLeft"] = txtBookISBNLeft.Text;
                        dict["ISBNRight"] = txtBookISBNRight.Text;
                        dict["BookAuthor"] = txtBookAuthor.Text;
                        dict["BookPages"] = txtBookPages.Text;
                        createProduct("Book", dict);
                    }
                }
                else if (checkVisibleGroup(grpBook, grpBookCIS) == true)
                {
                    if(checkBook(txtBookISBNLeft, txtBookISBNRight, txtBookAuthor, txtBookPages))
                    {
                        dict["ISBNLeft"] = txtBookISBNLeft.Text;
                        dict["ISBNRight"] = txtBookISBNRight.Text;
                        dict["BookAuthor"] = txtBookAuthor.Text;
                        dict["BookPages"] = txtBookPages.Text;
                        dict["CISArea"] = txtBookCISArea.Text;
                        createProduct("Book", dict);
                    }
                }
                // if groupbox DVD are visible, check the input validation
                else if (checkVisibleGroup(grpDVD) == true)
                {
                    if(checkDVD(txtDVDLeadActor, txtDVDRunTime))
                    {
                        dict["DVDLeadActor"] = txtDVDLeadActor.Text;
                        dict["DVDReleaseDate"] = dtDVDReleaseDate.ToString();
                        dict["DVDRuntime"] = txtDVDRunTime.Text;
                        createProduct("DVD", dict);
                    }
                }
                // if groupbox CD Classical are visisble, check the input validation
                else if (checkVisibleGroup(grpCDClassical) == true)
                {
                    if(checkCDClassical(txtCDClassicalLabel, txtCDClassicalArtists))
                    {
                        dict["CDClassicalLabel"] = txtCDClassicalLabel.Text;
                        dict["CDClassicalArtists"] = txtCDClassicalArtists.Text;
                        createProduct("CDClassical", dict);

                    }
                }
                // if groupbox CD Orchestra are visible, check the input validation
                else if (checkVisibleGroup(grpCDOrchestra) == true)
                {
                    if (checkOrchestralConductor(txtCDOrchestraConductor))
                    {
                        dict["CDClassicalLabel"] = txtCDClassicalLabel.Text;
                        dict["CDClassicalArtists"] = txtCDClassicalArtists.Text;
                        dict["CDOrchestraConductor"] = txtCDOrchestraConductor.Text;
                        createProduct("CDOrchestra", dict);
                    }
                }
            }
        } // end validatingVisibleGrp

        private void createProduct(string type, IDictionary<string, string> args)
        {
            Product temp = null;
            switch (type){
                case "Book":
                    temp = new Book(Int32.Parse(args["ProductUPC"]), Decimal.Parse(args["ProductPrice"]), args["ProductTitle"], Int32.Parse(args["ProductQuantity"]), args);
                    break;
                case "BookCIS":
                    temp = new BookCIS(Int32.Parse(args["ProductUPC"]), Decimal.Parse(args["ProductPrice"]), args["ProductTitle"], Int32.Parse(args["ProductQuantity"]), args);
                    break;
                case "DVD":
                    temp = new DVD(Int32.Parse(args["ProductUPC"]), Decimal.Parse(args["ProductPrice"]), args["ProductTitle"], Int32.Parse(args["ProductQuantity"]), args);
                    break;
                case "CDClassical":
                    temp = new CDClassical(Int32.Parse(args["ProductUPC"]), Decimal.Parse(args["ProductPrice"]), args["ProductTitle"], Int32.Parse(args["ProductQuantity"]), args);

                    break;
                case "CDOrchestra":
                    temp = new CDOrchestra(Int32.Parse(args["ProductUPC"]), Decimal.Parse(args["ProductPrice"]), args["ProductTitle"], Int32.Parse(args["ProductQuantity"]), args);
                    break;
            }
            InStock.addProduct(temp);

            lblTotalQuant.Text = (Int32.Parse(lblTotalQuant.Text) + Int32.Parse(args["ProductQuantity"])).ToString();

            lblUniqProducts.Text = (Int32.Parse(lblUniqProducts.Text) + 1).ToString();

            btnSearch.Enabled = true;

            //
            //
            //LEAVE THIS COMMENTED WHILE DEBUGGING OR YOU WILL LOSE YOUR MIND RETYPING!!
            //clearForm();
            //
            //
        
        }
        public object GetInstance(string strFullyQualifiedName)
        {
            Type t = Type.GetType(strFullyQualifiedName);
            return Activator.CreateInstance(t);
        }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearchDialog SearchDialog = new frmSearchDialog();

            int enteredUPC = 0;

            if(SearchDialog.ShowDialog(this) == DialogResult.OK)
            {
                if(SearchDialog.returnedUPC.ToString().Length == 5 && Int32.TryParse(SearchDialog.returnedUPC, out enteredUPC))
                {
                    MessageBox.Show("Entered UPC: " + enteredUPC);
                    for(int i = 0; i < InStock.getCount(); i++)
                    {
                        if(InStock[i].getUPC() == enteredUPC)
                        {
                            MessageBox.Show("FOUND PRODUCT!! Title: " + InStock[i].getTitle());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid UPC Was Entered.");
                }
            }
            else
            {
                MessageBox.Show("Search Cancelled.");
            }
            SearchDialog.Dispose();

        }
    } // end frmBookCDDVDShop
} // end namespace BookCDDVD