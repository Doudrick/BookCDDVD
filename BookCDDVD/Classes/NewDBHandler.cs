using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookCDDVD
{
    class NewDBHandler
    {
        string connectionString = "provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=../../ProductDB.accdb";

        public bool InsertProduct(string type, IDictionary<string, string> param, ref string outString)
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
                            command.CommandText = "INSERT INTO DVD (fldUPC, fldLeadActor, fldReleaseDate, fldRunTime) " +
                                 "VALUES(" + UPC + ", '" + param["DVDLeadActor"] + "', '" + param["DVDReleaseDate"] + "', " + param["DVDRuntime"] + " );";
                            break;
                        case "CDOrchestra":
                            command.CommandText = "INSERT INTO CDCLASSICAL (fldUPC, fldLabel, fldArtists) " +
                                 "VALUES(" + UPC + ", '" + param["CDClassicalLabel"] + "', '" + param["CDClassicalArtists"] + "' );";
                            command.ExecuteNonQuery();
                            command.CommandText = "INSERT INTO CDOrchestra (fldUPC, fldConductor) " +
                                 "VALUES(" + UPC + ", '" + param["CDOrchestraConductor"] + "') ;";
                            break;
                        case "CDChamber":
                            command.CommandText = "INSERT INTO CDCLASSICAL (fldUPC, fldLabel, fldArtists) " +
                                  "VALUES(" + UPC + ", '" + param["CDClassicalLabel"] + "', '" + param["CDClassicalArtists"] + "' );";
                            command.ExecuteNonQuery();
                            command.CommandText = "INSERT INTO CDChamber (fldUPC, fldInstrumentList) " +
                                  "VALUES(" + UPC + ", '" + param["CDChamberInstrumentList"] + "');";
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

        public bool getProduct(int UPC, out string type, out IDictionary<string, string> outDict)
        {
            type = "";
            outDict = new Dictionary<string, string>();
            string selectString = "SELECT * FROM Product WHERE fldUPC="+UPC;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(selectString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    type = reader["fldProductType"].ToString();

                    outDict["ProductUPC"] = UPC.ToString();
                    outDict["ProductPrice"] = reader["fldPrice"].ToString();
                    outDict["ProductTitle"] = reader["fldTitle"].ToString();
                    outDict["ProductQuantity"] = reader["fldQuantity"].ToString();
                    switch (type)
                    {
                        case "Book":
                            selectString = "SELECT * FROM Book WHERE fldUPC=" + UPC;
                            command = new OleDbCommand(selectString, connection);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                outDict["BookISBN"] = reader["fldISBN"].ToString();
                                outDict["BookAuthor"] = reader["fldAuthor"].ToString();
                                outDict["BookPages"] = reader["fldPages"].ToString();
                            }
                            break;
                        case "BookCIS":
                            selectString = "SELECT * FROM BookCIS INNER JOIN BOOK ON BOOKCIS.fldUPC = BOOK.fldUPC WHERE BookCIS.fldUPC="+UPC;
                            command = new OleDbCommand(selectString, connection);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                outDict["BookISBN"] = reader["fldISBN"].ToString();
                                outDict["BookAuthor"] = reader["fldAuthor"].ToString();
                                outDict["BookCISArea"] = reader["fldCISArea"].ToString();
                                outDict["BookPages"] = reader["fldPages"].ToString();
                            }
                            break;
                        case "DVD":
                            selectString = "SELECT * FROM DVD WHERE fldUPC=" + UPC;
                            command = new OleDbCommand(selectString, connection);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                outDict["DVDLeadActor"] = reader["fldLeadActor"].ToString();
                                outDict["DVDReleaseDate"] = Convert.ToDateTime(reader["fldReleaseDate"]).ToString("dd/MM/yyyy");
                                outDict["DVDRunTime"] = reader["fldRunTime"].ToString();
                            }
                            break;
                        case "CDOrchestra":
                            selectString = "SELECT * FROM CDOrchestra INNER JOIN CDClassical ON CDOrchestra.fldUPC = CDClassical.fldUPC WHERE CDOrchestra.fldUPC=" + UPC;
                            command = new OleDbCommand(selectString, connection);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                outDict["CDClassicalLabel"] = reader["fldLabel"].ToString();
                                outDict["CDClassicalArtists"] = reader["fldArtists"].ToString();
                                outDict["CDOrchestraConductor"] = reader["fldConductor"].ToString();
                            }
                            break;
                        case "CDChamber":
                            selectString = "SELECT * FROM CDChamber INNER JOIN CDClassical ON CDChamber.fldUPC = CDClassical.fldUPC WHERE CDChamber.fldUPC=" + UPC;
                            command = new OleDbCommand(selectString, connection);
                            reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                outDict["CDClassicalLabel"] = reader["fldLabel"].ToString();
                                outDict["CDClassicalArtists"] = reader["fldArtists"].ToString();
                                outDict["CDChamberInstrumentList"] = reader["fldInstrumentList"].ToString();
                            }
                            break;
                    }

                    return true;
                }
                else
                {
                    MessageBox.Show("FAILED TO FIND FROM UPC!!");
                }
                reader.Close();
            }
            return false;

        }
        public bool updateProduct()
        {
            return false;
        }
        public bool deleteProduct()
        {
            return false;
        }
        public int getRowCount()
        {
            string selectString = "SELECT COUNT(*) FROM Product;";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(selectString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    
                    return reader.GetInt32(0);
                }
                else
                {
                    MessageBox.Show("FAILED TO RUN");
                }
                reader.Close();
            }
            return 0;

        }
    }
}
