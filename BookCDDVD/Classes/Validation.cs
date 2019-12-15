
/*
 * 
 * Tyler Doudrick
 * Tai Nguyen
 * 11/23/2019
 * Validation Class - Static - For use in the Main Form Codebehind
 * Project 4: BookCDDVDShop
 * 
 * 
 * Updated 12/13/2019 - Fix leading zeros being allowed : Tyler Doudrick
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using BookCDDVD;

namespace BookCDDVD
{
    public static class Validator
    {       

        // this method search the group categories user is looking for and show them
        public static void hideGroups(GroupBox toShow, List<GroupBox> groupList, Button delete, GroupBox product)
        {
            //Make sure the delete button is hidden!
            delete.Visible = false;

            // show the groupBox product
            product.Visible = true;

            // this for loops scan the categories and show the one user is looking for
            foreach (GroupBox i in groupList)
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
        public static void hideGroups(GroupBox toShow, GroupBox alsoToShow, List<GroupBox> groupList, Button delete, GroupBox product)
        {
            //Make sure the delete button is hidden!
            delete.Visible = false;

            // show the product groupbox
            product.Visible = true;

            // this for each loops search the categories and show the group the user is looking for
            foreach (GroupBox i in groupList)
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
        public static bool checkVisibleGroup(GroupBox areVisible)
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
        public static bool checkVisibleGroup(GroupBox areVisible, GroupBox areAlsoVisible)
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
        public static void disableCreateButton(Button toDisable, List<Button> buttonList)
        {
            // this foreach loops search for the button that was just click and disable it
            // it also enable the button that was not being clicked on (only for createa button)
            foreach (Button i in buttonList)
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
        public static bool checkProduct(TextBox UPC, TextBox Price, TextBox Title,
            TextBox Quantity)
        {
            int num = -1;
            decimal num1 = -1;
            string checkUPC = Convert.ToString(UPC.Text);
            string checkTitle = Convert.ToString(Title.Text);
            string checkPrice = Convert.ToString(Price.Text);
            string checkQuantity = Convert.ToString(Quantity.Text);

            // return an error message if the input is empty, longer or shorter then 5, or is a letter

            //Also check if the parsed int also has a length of 5 (handles leading zeros)
            if (checkUPC.Equals("") || checkUPC.Length != 5 || (!int.TryParse(checkUPC, out num)) || num.ToString().Length != 5)
            {
                UPC.Clear();
                MessageBox.Show("Please Enter A Valid, 5 Digit UPC");
            }
            // return an error message if the input is empty or is a letter
            else if (checkPrice.Equals("") || (!decimal.TryParse(checkPrice, out num1)) || num <= 0)
            {
                Price.Clear();
                MessageBox.Show("Please Enter a valid Price");
            }
            // return an error message if the input is empty or is a letter
            else if (checkQuantity.Equals("") || (!int.TryParse(checkQuantity, out num)) || num <= 0)
            {
                Quantity.Clear();
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
        public static bool checkBook(TextBox ISBNL, TextBox ISBNR, TextBox Author, TextBox Pages)
        {
            int num = -1;
            string checkISBNL = Convert.ToString(ISBNL.Text);
            string checkISBNR = Convert.ToString(ISBNR.Text);
            string checkAuthor = Convert.ToString(Author.Text);
            string checkPages = Convert.ToString(Pages.Text);

            // return a error message if user is not inputing information or the input is 
            // long then 3, shorter then 3, or a letter

            //Also check if the parsed int also has a length of 3 (handles leading zeros)
            if (checkISBNL.Equals("") || checkISBNL.Length < 3 || (!int.TryParse(checkISBNL, out num)) || num.ToString().Length != 3)
            {
                ISBNL.Clear();
                MessageBox.Show("Please Enter a Valid, 3 Digit ISBN in the Left text box");
            }
            // return a error message if user is not inputing information or the input is 
            // long then 3, shorter then 3, or a letter

            //Also check if the parsed int also has a length of 3 (handles leading zeros)
            else if (checkISBNR.Equals("") || checkISBNR.Length < 3 || (!int.TryParse(checkISBNR, out num)) || num.ToString().Length != 3)
            {
                ISBNR.Clear();
                MessageBox.Show("Please Enter a Valid, 3 Digit ISBN in the Right text box");
            }
            // return the error message if the input is blank or is a number
            else if (checkAuthor.Equals("") || (int.TryParse(checkAuthor, out num)))
            {
                Author.Clear();
                MessageBox.Show("Please Enter a valid Author name");
            }
            // return the error message if the input is empty or is a letter
            else if (checkPages.Equals("") || (!int.TryParse(checkPages, out num)) || num <= 0)
            {
                Pages.Clear();
                MessageBox.Show("Please Enter a Valid Page Number");
            }
            else
            {
                return true;
            }
            return false;
        } // end checkBook

        // this method check the DVD group input validation
        public static bool checkDVD(TextBox leadActor, TextBox runTime)
        {
            int num = -1;
            string checkLeadActor = Convert.ToString(leadActor.Text);

            // return an error message if the leadactor textbox are empty or is a number
            if (checkLeadActor.Equals(""))
            {
                leadActor.Clear();
                MessageBox.Show("Please Enter a Valid Lead Actor name");
            }
            // return an error message if  the run time is empty, less then 0 or more  then 120 minutes
            else if (runTime.Text.Equals("") || (!int.TryParse(runTime.Text, out num)) || num <= 0 || num > 120)
            {
                runTime.Clear();
                MessageBox.Show("Please enter a Valid Run Time");
            }
            else
            {
                return true;
            }
            return false;
        } // end checkDVD

        // this method is validating the CD Classical groupbox
        public static bool checkCDClassical(TextBox Label, TextBox Artists)
        {
            string checkLabel = Convert.ToString(Label.Text);
            string checkArtists = Convert.ToString(Artists.Text);

            // return an error message if the input empty
            if (checkLabel.Equals(""))
            {
                Label.Clear();
                MessageBox.Show("Please Enter a Label");
            }
            // return an error message if the input is empty
            else if (checkArtists.Equals(""))
            {
                Artists.Clear();
                MessageBox.Show("Please Enter an Artist Name");
            }
            else
            {
                return true;
            }
            return false;
        } // end CheckCDClassical

        // this method validating the orchestral conductor
        public static bool checkOrchestralConductor(TextBox Conductor)
        {
            string checkConductor = Convert.ToString(Conductor.Text);

            // return an error message if the input is empty
            if (checkConductor.Equals(""))
            {
                Conductor.Clear();
                MessageBox.Show("Please Enter a Conductor name");
            }
            else
            {
                return true;
            }
            return false;
        } // end checkOrchestralConductor
    } // end validator
} // end namespace BookCDDVD
