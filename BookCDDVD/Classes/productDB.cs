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
    class ProductDB
    {
	// createa a string that connec to the database
        string connectionString = "provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=../../ProductDB.accdb";
	
	// creating a insert method to insert product into the database
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
                            command.CommandText = "INSERT INTO CDClassical (fldUPC, fldLabel, fldArtists) " +
                                 "VALUES(" + UPC + ", '" + param["CDClassicalLabel"] + "', '" + param["CDClassicalArtists"] + "' );";
                            command.ExecuteNonQuery();
                            command.CommandText = "INSERT INTO CDOrchestra (fldUPC, fldConductor) " +
                                 "VALUES(" + UPC + ", '" + param["CDOrchestraConductor"] + "') ;";
                            break;
                        case "CDChamber":
                            command.CommandText = "INSERT INTO CDClassical (fldUPC, fldLabel, fldArtists) " +
                                  "VALUES(" + UPC + ", '" + param["CDClassicalLabel"] + "', '" + param["CDClassicalArtists"] + "' );";
                            command.ExecuteNonQuery();
                            command.CommandText = "INSERT INTO CDChamber (fldUPC, fldInstrumentList) " +
                                  "VALUES(" + UPC + ", '" + param["CDChamberInstrumentList"] + "');";
                            break;
                    } // end switch
                    
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    transaction.Commit();
                    outString = "Product of type " + type + " with UPC of "+UPC+" added to database.";
                    return true;
                } // end try

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
                } // end catch

                // The connection is automatically closed when the
                // code exits the using block.
            } // end using
        } // end InsertProduct

	// creating an update method to update the database information
        public bool updateProduct(int UPC, IDictionary<string, string> param, string type)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand();
                OleDbTransaction transaction = null;

                command.Connection = connection;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    command.Connection = connection;
                    command.Transaction = transaction;
			
		    // update the product price, quantity, title
                    command.CommandText = "UPDATE Product SET " + "fldPrice = '" + param["ProductPrice"] + "', fldTitle = '" +
                        param["ProductTitle"] + "', fldQuantity = '" + param["ProductQuantity"] + "' WHERE fldUPC = " + UPC;

                    command.ExecuteNonQuery();
	            
		    // depend on the product the method will update whatever categories the product is
                    switch (type)
                    {
                        case "Book":
                            command.CommandText = "UPDATE Book SET " + "fldAuthor = '" + param["BookAuthor"] + 
                                "', fldPages = '" + param["BookPages"] + "' WHERE fldUPC = " + UPC;
                            break;
                        case "BookCIS":
                            command.CommandText = "UPDATE Book SET " + "fldAuthor = '" + param["BookAuthor"] +
                                "', fldPages = '" + param["BookPages"] + "' WHERE fldUPC = " + UPC;
                            command.ExecuteNonQuery();
                            command.CommandText = "UPDATE BookCIS SET " + "fldCISArea = '" + param["BookCISArea"]
                                + "' WHERE fldUPC = " + UPC;
                            break;
                        case "DVD":
                            command.CommandText = "UPDATE DVD Set " + "fldLeadActor = '" + param["DVDLeadActor"]
                                + "', fldReleaseDate = '" + param["DVDReleaseDate"] + "', fldRunTime = '" + param["DVDRuntime"]
                                + "' WHERE fldUPC = " + UPC;
                            break;
                        case "CDClassical":
                            command.CommandText = "UPDATE CDClassical Set " + "fldLabel = '" + param["CDClassicalLabel"]
                                + "', fldArtists = '" + param["CDClassicalArtists"] + "' WHERE fldUPC = " + UPC;
                            break;
                        case "CDOrchestra":
                            command.CommandText = "UPDATE CDClassical Set " + "fldLabel = '" + param["CDClassicalLabel"]
                                + "', fldArtists = '" + param["CDClassicalArtists"] + "'WHERE fldUPC = " + UPC;
                            command.ExecuteNonQuery();
                            command.CommandText = "UPDATE CDOrchestra SET " + "fldConductor = '" + param["CDOrchestraConductor"] + "' WHERE fldUPC = " + UPC;
                            break;
                        case "CDChamber":
                            command.CommandText = "UPDATE CDClassical Set " + "fldLabel = '" + param["CDClassicalLabel"]
                                + "', fldArtists = '" + param["CDClassicalArtists"] + "'WHERE fldUPC = " + UPC;
                            command.ExecuteNonQuery();
                            command.CommandText = "UPDATE CDChamber SET " + "fldInstrumentList = '" + param["CDChamberInstrumentList"]
                                + "' WHERE fldUPC = " + UPC;
                            break;    
                    } // end switch

                    command.ExecuteNonQuery();

		    // commit transaction
                    transaction.Commit();
                    return true;
                } // end try

		catch (OleDbException ex)
                {
                    MessageBox.Show("SQL Error: " + ex.Message);
                } // end catch
            } // end using
            return false;
        } // end updateProduct
	

	// this method delete the product in the database
        public bool deleteProduct(int UPC, string type)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand();
                OleDbTransaction transaction = null;

                command.Connection = connection;
		
		// delete the product
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    command.Connection = connection;
                    command.Transaction = transaction;

                    command.CommandText = "DELETE FROM Product" + " WHERE fldUPC =" + UPC;
                    command.ExecuteNonQuery();
                  
                    command.CommandText = "DELETE FROM Book" + " WHERE fldUPC = " + UPC;
                    command.ExecuteNonQuery();
                  
                    command.CommandText = "DELETE FROM BookCIS" + " WHERE fldUPC = " + UPC;
                    command.ExecuteNonQuery();
                  
                    command.CommandText = "DELETE FROM DVD " + " WHERE fldUPC = " + UPC;
                    command.ExecuteNonQuery();
                  
                    command.CommandText = "DELETE FROM CDClassical " + " WHERE fldUPC = " + UPC;
                    command.ExecuteNonQuery();
                  
                    command.CommandText = "DELETE FROM CDOrchestra " + " WHERE fldUPC = " + UPC;
                    command.ExecuteNonQuery();
                  
                    command.CommandText = "DELETE FROM CDChamber " + " WHERE fldUPC = " + UPC;
                    command.ExecuteNonQuery();
                    
		    // commit transaction
                    transaction.Commit();
                    return true;
                } // end try

                catch(OleDbException ex)
                {
                    MessageBox.Show("SQL Error: " + ex.Message);
                } // end catch
            } // end using
            return false;
        } // end deleteProduct

	// this method get the information from the database to display on the form
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
                                outDict["BookPages"] = reader["fldPages"].ToString();
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
                    } // end switch
                    return true;
                } // end if
                reader.Close();
            } // end using
            return false;
        } // end get product

	// count how many product is in the database
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
                reader.Close();
            } // end using
            return 0;

        } // end getRowCount
    } // end class productDB
} // end namespace BookCDDVD
