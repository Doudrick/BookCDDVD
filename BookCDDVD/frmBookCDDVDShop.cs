using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BookCDDVD
{
    public partial class frmBookCDDVDShop : Form
    {
        ProductList InStock = new ProductList();

        int indexToDelete = 0;

        List<GroupBox> groupCategories = new List<GroupBox>(6);
        List<Button> createButton = new List<Button>(5);

        const string persistancePath = "persistance.bin";
        
        public frmBookCDDVDShop()
        {
            InitializeComponent();

            // adding all the groups into the groupCategories list
            groupCategories.Add(grpBook);
            groupCategories.Add(grpBookCIS);
            groupCategories.Add(grpCDChamber);
            groupCategories.Add(grpCDClassical);
            groupCategories.Add(grpCDOrchestra);
            groupCategories.Add(grpDVD);

            // adding all the new entry button into the createaButton list
            createButton.Add(btnCreateBook);
            createButton.Add(btnCreateBookCIS);
            createButton.Add(btnCreateDVD);
            createButton.Add(btnCreateCDOrchestra);
            createButton.Add(btnCreateCDChamber);
            createButton.Add(btnCreateCDOrchestra);

            // adding options into the CIS Area dropdown
            cbBookCISArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBookCISArea.Items.Add("Computer Sciences");
            cbBookCISArea.Items.Add("Information Sciences");

            // adding options into the Instrument List dropdown
            cbCDChamberInstrumentList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCDChamberInstrumentList.Items.Add("Percussion");
            cbCDChamberInstrumentList.Items.Add("String");
            cbCDChamberInstrumentList.Items.Add("Woodwind");
            cbCDChamberInstrumentList.Items.Add("Brass");

            // showing a tips of what user should enter in their textboxes
            setToolTips();
        } // end frmBookCDDVDShop

        // this method show a message at the bottom of textboxes to give the users what they should enter the textboxes
        private void setToolTips()
        {
            // setting value to the tooltips 
            ToolTip tip = new ToolTip();
            tip.AutomaticDelay = 500;
            tip.ReshowDelay = 10000;
            tip.AutoPopDelay = 500000;
            tip.InitialDelay = 0;

            // setting a specific values to textboxes and button on the form
            tip.SetToolTip(this.txtProductUPC, "Enter a 5 digits UPC");
            tip.SetToolTip(this.txtProductPrice, "Enter a price, decimal will be rounded up to 2 decimals");
            tip.SetToolTip(this.txtProductTitle, "Enter the book title");
            tip.SetToolTip(this.txtProductQuantity, "Enter the quantity");
            tip.SetToolTip(this.txtBookISBNLeft, "Enter the first 3 digits of ISBN");
            tip.SetToolTip(this.txtBookISBNRight, "Enter the last 3 digits of ISBN");
            tip.SetToolTip(this.txtBookAuthor, "Enter the Author name, Number are not allowed");
            tip.SetToolTip(this.txtBookPages, "Enter a number of pages, cannot be more then 9999");
            tip.SetToolTip(this.txtDVDLeadActor, "Enter the Lead Actor name");
            tip.SetToolTip(this.dtDVDReleaseDate, "Choose a date");
            tip.SetToolTip(this.cbBookCISArea, "Choose a CIS area");
            tip.SetToolTip(this.txtDVDRunTime, "enter a run time that cannot be less then 0 or more than 120 minutes");
            tip.SetToolTip(this.txtCDClassicalLabel, "Enter a label name");
            tip.SetToolTip(this.txtCDClassicalArtists, "Enter the Artist name");
            tip.SetToolTip(this.txtCDOrchestraConductor, "Enter the Conductor name");
            tip.SetToolTip(this.cbCDChamberInstrumentList, "Choose an Instrument");
            tip.SetToolTip(this.btnInsert, "Add the inputed information into the data entry");
            tip.SetToolTip(this.btnDelete, "Delete the information");
            tip.SetToolTip(this.btnClear, "Clear the textboxes on the form");
            tip.SetToolTip(this.btnExit, "Exit the program");
        } // end setToolTips

        // this method load in all of the textboxes as read only
        private void frmBookCDDVDShop_Load(object sender, EventArgs e)
        {        
            // set all textboxes to read only
            grpProduct.Visible = false;
            dtDVDReleaseDate.MaxDate = DateTime.Today;

            try
            {
                SFManager.readFromFile(ref InStock, persistancePath);
            }
            catch
            {
                //Do nothing, we don't NEED that persistant file. It will be created on exit.
            }

            lblUniqProducts.Text = InStock.getCount().ToString();

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
            cbBookCISArea.ResetText();
            txtDVDLeadActor.Clear();
            txtDVDRunTime.Clear();
            txtCDClassicalLabel.Clear();
            txtCDClassicalArtists.Clear();
            txtCDOrchestraConductor.Clear();
            cbCDChamberInstrumentList.ResetText();
            txtProductUPC.Focus();
        } // end clearForm

        // this method search the group categories user is looking for and show them
        private void hideGroups(GroupBox toShow)
        {
            btnDelete.Visible = false;
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
            btnDelete.Visible = false;

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
            if (checkUPC.Equals("") || checkUPC.Length < 5 || (!int.TryParse(checkUPC, out num)))
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
            if (checkISBNL.Equals("") || checkISBNL.Length < 3 || (!int.TryParse(checkISBNL, out num)))
            {
                txtBookISBNLeft.Clear();
                MessageBox.Show("Please Enter a valid ISBN on the Left text box");
            }
            // return a error message if user is not inputing information or the input is 
            // long then 3, shorter then 3, or a letter
            else if (checkISBNR.Equals("") || checkISBNR.Length < 3 || (!int.TryParse(checkISBNR, out num)))
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
            //Dictionary to hold the parameters we'll be passing in
            //Basically using an associative array that we can pass attributes to as needed for each type of product
            IDictionary<string, string> dict = new Dictionary<string, string>();

            //First, check if the product textboxes are valid, since all types of products have these fields
            //Set those fields in the dictionary
            if (checkProduct(txtProductUPC, txtProductPrice, txtProductTitle, txtProductQuantity))
            {
                dict["ProductUPC"] = txtProductUPC.Text;
                dict["ProductPrice"] = txtProductPrice.Text;
                dict["ProductTitle"] = txtProductTitle.Text;
                dict["ProductQuantity"] = txtProductQuantity.Text;

                // if groupbox book are visible or groupbox book and bookCIS are visible, check the input validation
                //After checking validation, set the values in the dictionary. Then create the product.

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
                        dict["CISArea"] = cbBookCISArea.Text;
                        createProduct("Book", dict);
                    }
                }
                // if groupbox DVD are visible, check the input validation
                //After checking validation, set the values in the dictionary. Then create the product.

                else if (checkVisibleGroup(grpDVD) == true)
                {
                    if(checkDVD(txtDVDLeadActor, txtDVDRunTime))
                    {
                        dict["DVDLeadActor"] = txtDVDLeadActor.Text;
                        dict["DVDReleaseDate"] = dtDVDReleaseDate.Value.ToShortDateString();
                        dict["DVDRuntime"] = txtDVDRunTime.Text;
                        createProduct("DVD", dict);
                    }
                }
                // if groupbox CD Classical are visisble, check the input validation
                //After checking validation, set the values in the dictionary. Then create the product.

                else if (checkVisibleGroup(grpCDChamber) == true)
                {
                    if(checkCDClassical(txtCDClassicalLabel, txtCDClassicalArtists))
                    {
                        dict["CDClassicalLabel"] = txtCDClassicalLabel.Text;
                        dict["CDClassicalArtists"] = txtCDClassicalArtists.Text;
                        dict["CDChamberInstrumentList"] = cbCDChamberInstrumentList.Text;
                        createProduct("CDChamber", dict);

                    }
                }
                // if groupbox CD Orchestra are visible, check the input validation
                //After checking validation, set the values in the dictionary. Then create the product.

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

        private void createProduct(string type, IDictionary<string, string> param)
        {
            //The type of product is passed in as a string for the case/switch statement
            //Create a holder for the product we're creating
            Product temp = null;
            switch (type){
                //For each type, set the temp to that type. Then, pass in the parameters for its creation.
                case "Book":
                    temp = new Book(Int32.Parse(param["ProductUPC"]), Decimal.Parse(param["ProductPrice"]), param["ProductTitle"], Int32.Parse(param["ProductQuantity"]), param);
                    break;
                case "BookCIS":
                    temp = new BookCIS(Int32.Parse(param["ProductUPC"]), Decimal.Parse(param["ProductPrice"]), param["ProductTitle"], Int32.Parse(param["ProductQuantity"]), param);
                    break;
                case "DVD":
                    temp = new DVD(Int32.Parse(param["ProductUPC"]), Decimal.Parse(param["ProductPrice"]), param["ProductTitle"], Int32.Parse(param["ProductQuantity"]), param);
                    break;
                case "CDOrchestra":
                    temp = new CDOrchestra(Int32.Parse(param["ProductUPC"]), Decimal.Parse(param["ProductPrice"]), param["ProductTitle"], Int32.Parse(param["ProductQuantity"]), param);
                    MessageBox.Show(temp.getUPC().ToString());
                    break;
                case "CDChamber":
                    temp = new CDChamber(Int32.Parse(param["ProductUPC"]), Decimal.Parse(param["ProductPrice"]), param["ProductTitle"], Int32.Parse(param["ProductQuantity"]), param);
                    break;
            }
            if (!checkForExisting(Int32.Parse(param["ProductUPC"])))
            {
                //Enable the search button if it was disabled previously due to no product in inventory
                btnSearch.Enabled = true;
                //Add the product to the product list
                InStock.addProduct(temp);
                //Increase the number of Unique products shown on the form
                lblUniqProducts.Text = InStock.getCount().ToString();

                MessageBox.Show("Added Product to Inventory!");
            }
            else
            {
                //UPC is already in the system, so we don't want to insert that product
                MessageBox.Show("Error! UPC already exists in the system. Please try again.");
                txtProductUPC.Text = "";
                txtProductUPC.Focus();
            }
            //clear the form
            clearForm();
        }

        // this method check for a matching UPC when searched
        public bool checkForExisting(int UPC)
        { 
            //Loop through the ProductList and check for a UPC match
            for (int i = 0; i < InStock.getCount(); i++)
            {
                if (InStock[i].getUPC() == UPC)
                {
                    return true;
                }
            }
                return false;
       } // end checkforExisting

        // this method calling the validatingVisiblegrp, validated the information and adding
        // the information into the persistance to the binary file
        private void btnInsert_Click(object sender, EventArgs e)
        {
            // validating the visible groupbox
            validatingVisisbleGrp();
        } // end btnInsert_Click

        // this method exit the program
        private void btnExit_Click(object sender, EventArgs e)
        {
            //Write the persistance to the binary file, and close the form
            SFManager.writeToFile(InStock, "persistance.bin");
            this.Close();
        } // end btnExit_Click

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Show the search box when the search button is clicked
            frmSearchDialog SearchDialog = new frmSearchDialog();

            int enteredUPC = 0;
            //The searchbox will return a dialogresult of OK when the search button within it is clicked
            
            if(SearchDialog.ShowDialog(this) == DialogResult.OK)
            {
                //Check the public returnedUPC within the dialog box; That's what the user entered.
                if(SearchDialog.getUPC().ToString().Length == 5 && Int32.TryParse(SearchDialog.getUPC(), out enteredUPC))
                {
                    //Find the UPC within the product list
                    for(int i = 0; i < InStock.getCount(); i++)
                    {
                        if(InStock[i].getUPC() == enteredUPC)
                        {
                            //We Found it!
                            MessageBox.Show("FOUND PRODUCT!!"  + "\nTitle:" + InStock[i].getTitle() + "\nType of Product: " + InStock[i].GetType().ToString().Split('.')[1]);

                            //Set a variable for the found product
                            Product foundProduct = InStock[i];

                            //We use the type for the case/switch below
                            string productType = foundProduct.GetType().ToString().Split('.')[1];
                            
                            //Since we made foundProduct as a Product type, we can use these methods to grab some info.
                            //We are showing the info in the form so the user can see what they found.
                            txtProductUPC.Text = foundProduct.getUPC().ToString();
                            txtProductTitle.Text = foundProduct.getTitle();
                            txtProductQuantity.Text = foundProduct.getQuantity().ToString();
                            txtProductPrice.Text = foundProduct.getPrice().ToString();

                            //Switch/Case for each type of product
                            switch (productType.ToLower())
                            {
                             //For each respective type, we show the groups that correspond to that product type.
                             //Then foundProduct is cast to that type so that we can retrieve the attributes for that
                             // specific type using the methods within.
                             //Then, textboxes on the form have their text set to the values of the object

                                case "book":
                                    hideGroups(grpBook);
                                    Book foundBook = (Book)foundProduct;
                                    txtBookAuthor.Text = foundBook.getAuthor();
                                    txtBookISBNLeft.Text = foundBook.getISBN1().ToString();
                                    txtBookISBNRight.Text = foundBook.getISBN2().ToString();
                                    txtBookPages.Text = foundBook.getPages().ToString();
                                    break;
                                case "bookcis":
                                    hideGroups(grpBook, grpBookCIS);    
                                    BookCIS foundBookCIS = (BookCIS)foundProduct;
                                    txtBookAuthor.Text = foundBookCIS.getAuthor();
                                    txtBookISBNLeft.Text = foundBookCIS.getISBN1().ToString();
                                    txtBookISBNRight.Text = foundBookCIS.getISBN2().ToString();
                                    txtBookPages.Text = foundBookCIS.getPages().ToString();
                                    cbBookCISArea.SelectedValue = foundBookCIS.getArea();
                                    break;
                                case "dvd":
                                    hideGroups(grpDVD);
                                    DVD foundDVD = (DVD)foundProduct;
                                    txtDVDLeadActor.Text = foundDVD.getActor();
                                    txtDVDRunTime.Text = foundDVD.getRunTime().ToString();
                                    dtDVDReleaseDate.Value = foundDVD.getReleaseDate();
                                    break;
                                case "cdorchestra":
                                    hideGroups(grpCDClassical, grpCDOrchestra);
                                    CDOrchestra foundCDOrchestra = (CDOrchestra)foundProduct;
                                    txtCDOrchestraConductor.Text = foundCDOrchestra.getCDOrchestraConductor();
                                    txtCDClassicalLabel.Text = foundCDOrchestra.getLabel();
                                    txtCDClassicalArtists.Text = foundCDOrchestra.getArtists();
                                    break;
                                case "cdchamber":
                                    hideGroups(grpCDClassical, grpCDChamber);
                                    CDChamber foundCDChamber = (CDChamber)foundProduct;
                                    cbCDChamberInstrumentList.Text = foundCDChamber.getCDChamberInstrumentList();
                                    txtCDClassicalLabel.Text = foundCDChamber.getLabel();
                                    txtCDClassicalArtists.Text = foundCDChamber.getArtists();
                                    break;
                            }
                            //Set the index to delete just in case the user wants to delete this from the list
                            //      either because they want to edit it, or they want to delete it
                            indexToDelete = i;
                            //Show the delete button
                            btnDelete.Visible = true;
                            return;
                        }
                    }
                    MessageBox.Show("Product with UPC " + enteredUPC + " was not found.");
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
            //Dispose of the search dialog since we're done with it
            SearchDialog.Dispose();
        } // end btnSearch_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            clearForm();
            //Remove one product from the number of products we have using the return from the removeProduct method
            lblUniqProducts.Text = (InStock.removeProduct(indexToDelete).ToString());

            //Inform the user of what's going on
            MessageBox.Show("Successfully removed this product from Inventory.\n If you would like to edit it, do so now.\nOtherwise, clear the form.");
            //Reset the upc value set before
            indexToDelete = 0;
            //Hide the delete button
            btnDelete.Visible = false;
        } // end btnDelete_Click

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            clearForm();
        }
    } // end frmBookCDDVDShop
} // end namespace BookCDDVD