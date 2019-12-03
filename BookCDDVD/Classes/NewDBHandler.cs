using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCDDVD
{
    class NewDBHandler
    {
        string connectionString = "provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=../Debug/ProductDB.accdb";

        public bool ExecuteTransaction(string type, IDictionary<string, string> param, out string outString)
        {
            int UPC = Int32.Parse(param["ProductUPC"]);
            decimal price = Decimal.Parse(param["ProductPrice"]);
            string title = param["ProductTitle"];
            int quantity = Int32.Parse(param["ProductQuantity"]);

            outString = "";
            using (OleDbConnection connection =
                       new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand();
                OleDbTransaction transaction = null;

                // Set the Connection to the new OleDbConnection.
                command.Connection = connection;

                // Open the connection and execute the transaction.
                try
                {
                    connection.Open();

                    // Start a local transaction with ReadCommitted isolation level.
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    // Assign transaction object for a pending local transaction.
                    command.Connection = connection;
                    command.Transaction = transaction;

                    // Execute the commands.
                    command.CommandText = "INSERT INTO Product (fldUPC, fldPrice, fldTitle, fldQuantity, fldProductType) " +
                        "VALUES(" + UPC + " , " + price + " , '" + title + "', " + quantity + ", '" + type + "');";
                    command.ExecuteNonQuery();
                    switch (type)
                    {
                        //For each type, execute the insert(s) for that table
                        case "Book":
                            command.CommandText = "INSERT INTO Book (fldUPC, fldISBN, fldAuthor, fldPages) " +
                            "VALUES(" + UPC + ", '" + (param["ISBNLeft"]+param["ISBNRight"]) + "', '" + param["BookAuthor"] + "', " + param["BookPages"] + " );";
                            break;
                        case "BookCIS":
                            command.CommandText = "INSERT INTO Book (fldUPC, fldISBN, fldAuthor, fldPages) " +
                                "VALUES(" + UPC + ", '" + (param["ISBNLeft"] + param["ISBNRight"]) + "', '" + param["BookAuthor"] + "', " + param["BookPages"] + " );";
                            command.ExecuteNonQuery();
                            command.CommandText = "INSERT INTO BookCIS (fldUPC, fldCISArea) " +
                                "VALUES(" + UPC + ", '" + param["BookCISArea"] + "' );";
                            break;
                        case "DVD":
                            break;
                        case "CDOrchestra":
                            break;
                        case "CDChamber":
                            break;
                    }
                    
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    transaction.Commit();
                    outString = "Product of type " + type + " with UPC of "+UPC+" added to database.";
                    return true;
                }
                catch (OleDbException ex)
                {
                        if(ex.Errors[0].SQLState.Equals(3022.ToString()))
                    {
                        outString = "Failed to insert product.\nThe UPC entered already exists in the database.\nPlease enter a unique UPC!";
                    }else outString = "Faled to execute: " + ex.Message + " Err no= " + ex.Errors[0].SQLState;

                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction.Rollback();
                        return false;
                    }
                    catch
                    {
                        // Do nothing here; transaction is not active.
                    }
                    return false;
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
        }
    }
}
