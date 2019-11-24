using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using BookCDDVD;

namespace BookCDDVD
{
    public class Validation
    {
        List<GroupBox> groupCategories = new List<GroupBox>(6);
        List<Button> createButton = new List<Button>(5);
        private frmBookCDDVDShop f;

        public Validation(frmBookCDDVDShop parentForm)
        {
            f = parentForm;

            // adding all the groups into the groupCategories list
            groupCategories.Add(f.grpBook);
            groupCategories.Add(f.grpBookCIS);
            groupCategories.Add(f.grpCDChamber);
            groupCategories.Add(f.grpCDClassical);
            groupCategories.Add(f.grpCDOrchestra);
            groupCategories.Add(f.grpDVD);

            // adding all the new entry button into the createaButton list
            createButton.Add(f.btnCreateBook);
            createButton.Add(f.btnCreateBookCIS);
            createButton.Add(f.btnCreateDVD);
            createButton.Add(f.btnCreateCDOrchestra);
            createButton.Add(f.btnCreateCDChamber);
            createButton.Add(f.btnCreateCDOrchestra);
        } // end validation

        // this method search the group categories user is looking for and show them
        public void hideGroups(GroupBox toShow)
        {
            // show the groupBox product
            f.grpProduct.Visible = true;

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
        public void hideGroups(GroupBox toShow, GroupBox alsoToShow)
        {
            f.btnDelete.Visible = false;

            // show the product groupbox
            f.grpProduct.Visible = true;

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
        public bool checkVisibleGroup(GroupBox areVisible)
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
        public bool checkVisibleGroup(GroupBox areVisible, GroupBox areAlsoVisible)
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
        public void disableCreateButton(Button toDisable)
        {
            // this foreach loops search for the button that was just click and disable it
            // it also enable the button that was not being clicked on (only for createa button)
            foreach (Button i in createButton)
            {
                if (i == toDisable)
                {
                    i.Enabled = false;
                }
                else
                {
                    i.Enabled = true;
                }
            } // end foreach 
        } // end disableCreateButton

        // this method validating the product group box
        public bool checkProduct(TextBox Upc, TextBox Price, TextBox Title,
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
                f.txtProductUPC.Clear();
                MessageBox.Show("Please Enter A Valid UPC");
            }
            // return an error message if the input is empty or is a letter
            else if (checkPrice.Equals("") || (!decimal.TryParse(checkPrice, out num1)))
            {
                f.txtProductPrice.Clear();
                MessageBox.Show("Please Enter a valid Price");
            }
            // return an error message if the input is empty or is a letter
            else if (checkQuantity.Equals("") || (!int.TryParse(checkQuantity, out num)))
            {
                f.txtProductQuantity.Clear();
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
        public bool checkBook(TextBox ISBNL, TextBox ISBNR, TextBox Author, TextBox Pages)
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
                f.txtBookISBNLeft.Clear();
                MessageBox.Show("Please Enter a valid ISBN on the Left text box");
            }
            // return a error message if user is not inputing information or the input is 
            // long then 3, shorter then 3, or a letter
            else if (checkISBNR.Equals("") || checkISBNR.Length < 3 || (!int.TryParse(checkISBNR, out num)))
            {
                f.txtBookISBNRight.Clear();
                MessageBox.Show("Please Enter a valid ISBN on the Right text box");
            }
            // return the error message if the input is blank or is a number
            else if (checkAuthor.Equals("") || (int.TryParse(checkAuthor, out num)))
            {
                f.txtBookAuthor.Clear();
                MessageBox.Show("Please Enter a valid Author name");
            }
            // return the error message if the input is empty or is a letter
            else if (checkPages.Equals("") || (!int.TryParse(checkPages, out num)))
            {
                f.txtBookPages.Clear();
                MessageBox.Show("Please Enter a valid page number");
            }
            else
            {
                return true;
            }
            return false;
        } // end checkBook

        // this method check the DVD group input validation
        public bool checkDVD(TextBox leadActor, TextBox runTime)
        {
            int num = -1;
            string checkLeadActor = Convert.ToString(leadActor.Text);
            int checkrunTime = Convert.ToInt32(runTime.Text);

            // return an error message if the leadactor textbox are empty or is a number
            if (checkLeadActor.Equals(""))
            {
                f.txtDVDLeadActor.Clear();
                MessageBox.Show("Please Enter a valid Lead Actor name");
            }
            // return an error message if  the run time is empty, less then 0 or more  then 120 minutes
            else if (checkrunTime.Equals("") || checkrunTime < 0 || checkrunTime > 120 ||
                (!int.TryParse(checkrunTime.ToString(), out num)))
            {
                f.txtDVDRunTime.Clear();
                MessageBox.Show("Please enter a valid run time");
            }
            else
            {
                return true;
            }
            return false;
        } // end checkDVD

        // this method is validating the CD Classical groupbox
        public bool checkCDClassical(TextBox Label, TextBox Artists)
        {
            string checkLabel = Convert.ToString(Label.Text);
            string checkArtists = Convert.ToString(Artists.Text);

            // return an error message if the input empty
            if (checkLabel.Equals(""))
            {
                f.txtCDClassicalLabel.Clear();
                MessageBox.Show("Please Enter a label");
            }
            // return an error message if the input is empty
            else if (checkArtists.Equals(""))
            {
                f.txtCDClassicalArtists.Clear();
                MessageBox.Show("Please Enter an Artist Name");
            }
            else
            {
                return true;
            }
            return false;
        } // end CheckCDClassical

        // this method validating the orchestral conductor
        public bool checkOrchestralConductor(TextBox Conductor)
        {
            string checkConductor = Convert.ToString(Conductor.Text);

            // return an error message if the input is empty
            if (checkConductor.Equals(""))
            {
                f.txtCDOrchestraConductor.Clear();
                MessageBox.Show("Please Enter a Conductor name");
            }
            else
            {
                return true;
            }
            return false;
        } // end checkOrchestralConductor

    }
    
    

}
