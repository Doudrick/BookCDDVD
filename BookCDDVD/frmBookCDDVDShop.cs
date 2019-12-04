
/*
 * 
 * Tyler Doudrick
 * Tai Nguyen
 * 11/23/2019
 * Codebehind for main Form
 * Project 4: BookCDDVDShop
 * 
 * 
 */

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
        List<GroupBox> groupList = new List<GroupBox>(6);
        List<Button> buttonList = new List<Button>(5);

        ProductDB dbProducts = new ProductDB();
        NewDBHandler dbTest = new NewDBHandler();
        int indexToDelete = 0;
        bool editingTrigger = false;
        const string persistancePath = "persistance.bin";
        
        public frmBookCDDVDShop()
        {
            InitializeComponent();

            // adding all the groups into the groupList
            groupList.Add(grpBook);
            groupList.Add(grpBookCIS);
            groupList.Add(grpCDChamber);
            groupList.Add(grpCDClassical);
            groupList.Add(grpCDOrchestra);
            groupList.Add(grpDVD);

            // adding all the new entry button into the buttonList
            buttonList.Add(btnCreateBook);
            buttonList.Add(btnCreateBookCIS);
            buttonList.Add(btnCreateDVD);
            buttonList.Add(btnCreateCDOrchestra);
            buttonList.Add(btnCreateCDChamber);
            buttonList.Add(btnCreateCDOrchestra);


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
        } // end frmBookCDDVDShop



        // this method handles some stuff that happens when the form loads
        private void frmBookCDDVDShop_Load(object sender, EventArgs e)
        {        
            // set all textboxes to read only
            grpProduct.Visible = false;
            dtDVDReleaseDate.MaxDate = DateTime.Today;


            int rowCount = dbTest.getRowCount();
            if (rowCount > 0)
            {
                lblUniqProducts.Text = rowCount.ToString();
                btnSearch.Enabled = true;
            }

            setToolTips();
            getProducts();

            if(dbTest.getProduct(66666, out string type, out IDictionary<string, string> outDict)){

                MessageBox.Show(type);
            }
        } // end frmBookCDDVDShop_Load
          // this method show a message at the bottom of textboxes to give the users what they should enter the textboxes

        private void getProducts()
        {

        }
        private void setToolTips()
        {
            // setting value to the tooltips 
            ToolTip tip = new ToolTip();

            tip.ShowAlways = true;
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
        // this method hide and enable textboxes for Create Book button
        private void btnCreateBook_Click(object sender, EventArgs e)
        {
            // hide every other group that are not CreateBook
            Validator.hideGroups(grpBook, groupList, btnDelete, grpProduct);
            // disable CreateaBook button and enable all other new entry button
            Validator.disableCreateButton(btnCreateBook, buttonList);

            // clear the form
            clearForm();
        } // end btnCreateaBook

        // this method hide and enable textboxes for Create Book CIS button
        private void btnCreateBookCIS_Click(object sender, EventArgs e)
        {
            // hide every other group that are not BookCIS and Book
            Validator.hideGroups(grpBook, grpBookCIS, groupList, btnDelete, grpProduct);

            // disable CreateaBookCIS button and enable all other new entry button
            Validator.disableCreateButton(btnCreateBookCIS, buttonList);

            // clear the form
            clearForm();

        } // end btnCreateaBookCIS

        // this method hide and enable textboxes for Create DVD button
        private void btnCreateDVD_Click(object sender, EventArgs e)
        {
            // hide every group that is not DVD
            Validator.hideGroups(grpDVD, groupList, btnDelete, grpProduct);

            // disable btnCreateDVD and enable all other new entry button
            Validator.disableCreateButton(btnCreateDVD, buttonList);

            // clear the form
            clearForm();
        } // end btnCreateaDVD

        // this method only show and enable textboxes for createa DVD Orchestra button
        private void btnCreateCDOrchestra_Click(object sender, EventArgs e)
        {
            // hide every group that are not CDOrchestra and CDClassical
            Validator.hideGroups(grpCDClassical, grpCDOrchestra, groupList, btnDelete, grpProduct);

            // disabe createaDVDOrchestra button and enable other new entry button
            Validator.disableCreateButton(btnCreateCDOrchestra, buttonList);

            // clear the form
            clearForm();

        } // end btnCreateaCDOrchestra

        // this method only show and enable textboxes for createa CD Chamber button
        private void btnCreateCDChamber_Click(object sender, EventArgs e)
        {
            // hide every group that is not related to CD chamber
            Validator.hideGroups(grpCDChamber, grpCDClassical, groupList, btnDelete, grpProduct);

            // disable button createa CD Chamber and enable all other new entry button
            Validator.disableCreateButton(btnCreateCDChamber, buttonList);

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
            cbCDChamberInstrumentList.SelectedIndex = -1;
            cbBookCISArea.SelectedIndex = -1;
            txtProductUPC.Focus();

            dtDVDReleaseDate.Value = DateTime.Today;

            btnDelete.Visible = false;
            //If the form is cleared, we're not editing anymore!
            editingTrigger = false;
            btnInsert.Text = "Insert";
            txtProductUPC.ReadOnly = false;
        } // end clearForm

        // this method find which groupbox are visible and Validator those textboxes input\
        private void ValidatorVisibleGrp()
        {
            //Dictionary to hold the parameters we'll be passing in
            //Basically using an associative array that we can pass attributes to as needed for each type of product
            IDictionary<string, string> dict = new Dictionary<string, string>();

            //First, check if the product textboxes are valid, since all types of products have these fields
            //Set those fields in the dictionary
            if (Validator.checkProduct(txtProductUPC, txtProductPrice, txtProductTitle, txtProductQuantity))
            {
                dict["ProductUPC"] = txtProductUPC.Text;
                dict["ProductPrice"] = txtProductPrice.Text;
                dict["ProductTitle"] = txtProductTitle.Text;
                dict["ProductQuantity"] = txtProductQuantity.Text;

                // if groupbox book are visible or groupbox book and bookCIS are visible, check the input validation
                //After checking validation, set the values in the dictionary. Then create the product.

                if (Validator.checkVisibleGroup(grpBook))
                {
                    if (Validator.checkBook(txtBookISBNLeft, txtBookISBNRight, txtBookAuthor, txtBookPages))
                    {
                        dict["ISBNLeft"] = txtBookISBNLeft.Text;
                        dict["ISBNRight"] = txtBookISBNRight.Text;
                        dict["BookAuthor"] = txtBookAuthor.Text;
                        dict["BookPages"] = txtBookPages.Text;
                        if (Validator.checkVisibleGroup(grpBookCIS))
                        {
                            dict["BookCISArea"] = cbBookCISArea.Text;
                            createProduct("BookCIS", dict);
                        }
                        else
                        {
                            createProduct("Book", dict);
                        }
                    }
                }

                // if groupbox DVD are visible, check the input validation
                //After checking validation, set the values in the dictionary. Then create the product.

                else if (Validator.checkVisibleGroup(grpDVD))
                {
                    if (Validator.checkDVD(txtDVDLeadActor, txtDVDRunTime))
                    {
                        dict["DVDLeadActor"] = txtDVDLeadActor.Text;
                        dict["DVDReleaseDate"] = dtDVDReleaseDate.Value.ToShortDateString();
                        MessageBox.Show(dtDVDReleaseDate.Value.ToString("dd/MM/yyyy"));
                        dict["DVDRuntime"] = txtDVDRunTime.Text;
                        createProduct("DVD", dict);
                    }
                }
                // if groupbox CD Classical are visisble, check the input validation
                //After checking validation, set the values in the dictionary. Then create the product.

                else if (Validator.checkVisibleGroup(grpCDChamber))
                {
                    if (Validator.checkCDClassical(txtCDClassicalLabel, txtCDClassicalArtists))
                    {
                        dict["CDClassicalLabel"] = txtCDClassicalLabel.Text;
                        dict["CDClassicalArtists"] = txtCDClassicalArtists.Text;
                        dict["CDChamberInstrumentList"] = cbCDChamberInstrumentList.Text;
                        createProduct("CDChamber", dict);


                    }
                }
                // if groupbox CD Orchestra are visible, check the input validation
                //After checking validation, set the values in the dictionary. Then create the product.

                else if (Validator.checkVisibleGroup(grpCDOrchestra))
                {
                    if (Validator.checkOrchestralConductor(txtCDOrchestraConductor))
                    {
                        dict["CDClassicalLabel"] = txtCDClassicalLabel.Text;
                        dict["CDClassicalArtists"] = txtCDClassicalArtists.Text;
                        dict["CDOrchestraConductor"] = txtCDOrchestraConductor.Text;
                        createProduct("CDOrchestra", dict);
                    }
                }
            }
        } // end ValidatorVisibleGrp

        private void createProduct(string type, IDictionary<string, string> param)
        {
            //The type of product is passed in as a string for the case/switch statement
            //Create a holder for the product we're creating
            string outString = "";
            MessageBox.Show(type);
           
            if (dbTest.InsertProduct(type, param, ref outString)) MessageBox.Show(outString);
            else MessageBox.Show("FAIL: " + outString);
            if (editingTrigger)
            {
                //The User is editing this product. Delete the old one, then add the new one.

                //Remove one product from the number of products we have using the return from the removeProduct method
                InStock.removeProduct(indexToDelete).ToString();

                //Reset the upc value set before
                indexToDelete = 0;
                //Hide the delete button
                btnDelete.Visible = false;
                //Enable the search button if it was disabled previously due to no product in inventory
                btnSearch.Enabled = true;
                //Add the product to the product list
                //Increase the number of Unique products shown on the form
                lblUniqProducts.Text = InStock.getCount().ToString();

                MessageBox.Show("Updated Product Information!");
            }
            else if (!checkForExisting(Int32.Parse(param["ProductUPC"])))
            {
                    //Enable the search button if it was disabled previously due to no product in inventory
                    btnSearch.Enabled = true;
                    //Add the product to the product list
                    //Increase the number of Unique products shown on the form
                    lblUniqProducts.Text = InStock.getCount().ToString();

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

        // this method calling the ValidatorVisiblegrp, validated the information and adding
        // the information into the persistance to the binary file
        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Validator the visible groupbox

            ValidatorVisibleGrp();
        } // end btnInsert_Click

        // this method exit the program
        private void btnExit_Click(object sender, EventArgs e)
        {
            //Write the persistance to the binary file, and close the form
            //SFManager.writeToFile(InStock, "persistance.bin");
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
                //Check the returnedUPC within the dialog box; That's what the user entered.
                if(SearchDialog.getUPC().ToString().Length == 5 && Int32.TryParse(SearchDialog.getUPC(), out enteredUPC))
                {

                        if(dbTest.getProduct(enteredUPC, out string type, out IDictionary<string, string> outDict))
                        {
                            //We Found it!
                            MessageBox.Show("Found Product!"  + "\nTitle:" + outDict["ProductTitle"] + "\nType of Product: " + type);

                            
                            //Since we made foundProduct as a Product type, we can use these methods to grab some info.
                            //We are showing the info in the form so the user can see what they found.
                            txtProductUPC.Text = enteredUPC.ToString();
                            txtProductTitle.Text = outDict["ProductTitle"];
                            txtProductQuantity.Text = outDict["ProductQuantity"];
                            txtProductPrice.Text = outDict["ProductPrice"];

                        //Switch/Case for each type of product
                        switch (type)
                        {
                            //For each respective type, we show the groups that correspond to that product type.
                            //Then foundProduct is cast to that type so that we can retrieve the attributes for that
                            // specific type using the methods within.
                            //Then, textboxes on the form have their text set to the values of the object

                            case "Book":
                                Validator.hideGroups(grpBook, groupList, btnDelete, grpProduct);
                                txtBookAuthor.Text = outDict["BookAuthor"];
                                txtBookISBNLeft.Text = outDict["BookISBN"].Substring(0, 3);
                                txtBookISBNRight.Text = outDict["BookISBN"].Substring(3);
                                txtBookPages.Text = outDict["BookPages"];
                                break;
                            case "BookCIS":
                                Validator.hideGroups(grpBook, grpBookCIS, groupList, btnDelete, grpProduct);
                                txtBookAuthor.Text = outDict["BookAuthor"];
                                txtBookISBNLeft.Text = outDict["BookISBN"].Substring(0, 3);
                                txtBookISBNRight.Text = outDict["BookISBN"].Substring(3);
                                txtBookPages.Text = outDict["BookPages"];
                                cbBookCISArea.SelectedIndex = cbBookCISArea.FindStringExact(outDict["BookCISArea"]);
                                break;
                            case "DVD":
                                Validator.hideGroups(grpDVD, groupList, btnDelete, grpProduct);
                                txtDVDLeadActor.Text = outDict["DVDLeadActor"];
                                txtDVDRunTime.Text = outDict["DVDRunTime"];
                                dtDVDReleaseDate.Value = DateTime.ParseExact(outDict["DVDReleaseDate"], "dd/MM/yyyy", null);
                                break;
                            case "CDOrchestra":
                                Validator.hideGroups(grpCDClassical, grpCDOrchestra, groupList, btnDelete, grpProduct);
                                txtCDClassicalLabel.Text = outDict["CDClassicalLabel"];
                                txtCDClassicalArtists.Text = outDict["CDClassicalArtists"];
                                txtCDOrchestraConductor.Text = outDict["CDOrchestraConductor"];

                                break;
                            case "CDChamber":
                                Validator.hideGroups(grpCDClassical, grpCDChamber, groupList, btnDelete, grpProduct);
                                txtCDClassicalLabel.Text = outDict["CDClassicalLabel"];
                                txtCDClassicalArtists.Text = outDict["CDClassicalArtists"];
                                cbCDChamberInstrumentList.SelectedIndex = cbCDChamberInstrumentList.FindStringExact(outDict["CDChamberInstrumentList"]);
                                break;
                        }
                        //Set the index to delete just in case the user wants to delete this from the list
                        //      either because they want to edit it, or they want to delete it
                        //Show the delete button
                        btnDelete.Visible = true;
                            editingTrigger = true;
                            txtProductUPC.ReadOnly = true;
                            btnInsert.Text = "Update";
                            return;
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