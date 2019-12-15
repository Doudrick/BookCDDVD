/*
 * 
 * Tyler Doudrick
 * Tai Nguyen
 * 11/23/2019
 * DB Handler
 * Project 4: BookCDDVDShop
 * 
 * The original DB class given by Frank was a total mess of code.
 * My plan was to rewrite it using transactions and method overriding
 *      
 *      {Ex. public void insertProduct(Product input)
 *      public void insertProduct(Book input)
 *      public void insertProduct(BookCIS input)}
 *      
 *      in order to avoid calling 20 different methods and trying to figure it all out.
 *      
 *      Once we came to the conclusion that we don't need the classes, I ended up with this,
 *      which is super easy. -- Tyler
 *     
 * 
 */



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
	// Connection string for the DB using the OLEDB 12 Provider.
        string connectionString = "provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=../../ProductDB.accdb";
	
	// Insert a Product into the DB. Takes the producct type and a dictionary of parameters. Has a ref
    //      string which is useful for passing info back to the form
        public bool InsertProduct(string type, IDictionary<string, string> param, ref string outString)
        {
            int UPC = Int32.Parse(param["fldUPC"]);
            decimal price = Decimal.Parse(param["fldPrice"]);
            string title = param["fldTitle"];
            int quantity = Int32.Parse(param["fldQuantity"]);

            outString = "";

            using (OleDbConnection connection =
                       new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand();

                //Create a transaction to store all queries until a commit occurs. 
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
                                "VALUES(" + UPC + ", '" + (param["fldISBN"]) + "', '" + param["fldAuthor"] + "', " + param["fldPages"] + " );";
                            break;
                        case "BookCIS":
                            command.CommandText = "INSERT INTO Book (fldUPC, fldISBN, fldAuthor, fldPages) " +
                                "VALUES(" + UPC + ", '" + (param["fldISBN"]) + "', '" + param["fldAuthor"] + "', " + param["fldPages"] + " );";
                            command.ExecuteNonQuery();
                            command.CommandText = "INSERT INTO BookCIS (fldUPC, fldCISArea) " +
                                "VALUES(" + UPC + ", '" + param["fldCISArea"] + "' );";
                            break;
                        case "DVD":
                            command.CommandText = "INSERT INTO DVD (fldUPC, fldLeadActor, fldReleaseDate, fldRunTime) " +
                                 "VALUES(" + UPC + ", '" + param["fldLeadActor"] + "', '" + param["fldReleaseDate"] + "', " + param["fldRunTime"] + " );";
                            break;
                        case "CDOrchestra":
                            command.CommandText = "INSERT INTO CDClassical (fldUPC, fldLabel, fldArtists) " +
                                 "VALUES(" + UPC + ", '" + param["fldLabel"] + "', '" + param["fldArtists"] + "' );";
                            command.ExecuteNonQuery();
                            command.CommandText = "INSERT INTO CDOrchestra (fldUPC, fldConductor) " +
                                 "VALUES(" + UPC + ", '" + param["fldConductor"] + "') ;";
                            break;
                        case "CDChamber":
                            command.CommandText = "INSERT INTO CDClassical (fldUPC, fldLabel, fldArtists) " +
                                  "VALUES(" + UPC + ", '" + param["fldLabel"] + "', '" + param["fldArtists"] + "' );";
                            command.ExecuteNonQuery();
                            command.CommandText = "INSERT INTO CDChamber (fldUPC, fldInstrumentList) " +
                                  "VALUES(" + UPC + ", '" + param["fldInstrumentList"] + "');";
                            break;
                    } // end switch
                    
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    transaction.Commit();

                    //If it worked, the out string is now set to tell the user that it worked.

                    outString = "Product of type " + type + " with UPC of "+UPC+" added to database.";
                    return true;
                } // end try

                catch (OleDbException ex)
                {
                    //Something broke! If the Error Number is 3022 in particular, it means that the primary key already exists
                    //      Meaning the UPC already exists in the system.
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

                // Set the Connection to the new OleDbConnection.
                command.Connection = connection;

                try
                {
                    // open a connection
                    connection.Open();

                    // Start a local transaction with ReadCommitted isolation level.
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    // Assign transaction object for a pending local transaction.
                    command.Connection = connection;
                    command.Transaction = transaction;

                    // Execute the commands.
                    command.CommandText = "UPDATE Product SET " + "fldPrice = '" + param["fldPrice"] + "', fldTitle = '" +
                        param["fldTitle"] + "', fldQuantity = '" + param["fldQuantity"] + "' WHERE fldUPC = " + UPC;

                    command.ExecuteNonQuery();
	            
		            // depend on the product the method will update whatever categories the product is
                    switch (type)
                    {
                        case "Book":
                            command.CommandText = "UPDATE Book SET " + "fldAuthor = '" + param["fldAuthor"] +
                                "', fldPages = '" + param["fldPages"] + "', fldISBN = '" + param["fldISBN"] + "' WHERE fldUPC = " + UPC;
                            break;
                        case "BookCIS":
                            command.CommandText = "UPDATE Book SET " + "fldAuthor = '" + param["fldAuthor"] +
                            "', fldPages = '" + param["fldPages"] + "', fldISBN = '" + param["fldISBN"] + "' WHERE fldUPC = " + UPC;
                            command.ExecuteNonQuery();
                            command.CommandText = "UPDATE BookCIS SET " + "fldCISArea = '" + param["fldCISArea"]
                                + "' WHERE fldUPC = " + UPC;
                            break;
                        case "DVD":
                            command.CommandText = "UPDATE DVD Set " + "fldLeadActor = '" + param["fldLeadActor"]
                                + "', fldReleaseDate = '" + param["fldReleaseDate"] + "', fldRunTime = '" + param["fldRunTime"]
                                + "' WHERE fldUPC = " + UPC;
                            break;
                        case "CDClassical":
                            command.CommandText = "UPDATE CDClassical Set " + "fldLabel = '" + param["fldLabel"]
                                + "', fldArtists = '" + param["fldArtists"] + "' WHERE fldUPC = " + UPC;
                            break;
                        case "CDOrchestra":
                            command.CommandText = "UPDATE CDClassical Set " + "fldLabel = '" + param["fldLabel"]
                                + "', fldArtists = '" + param["fldArtists"] + "'WHERE fldUPC = " + UPC;
                            command.ExecuteNonQuery();
                            command.CommandText = "UPDATE CDOrchestra SET " + "fldConductor = '" + param["fldConductor"] + "' WHERE fldUPC = " + UPC;
                            break;
                        case "CDChamber":
                            command.CommandText = "UPDATE CDClassical Set " + "fldLabel = '" + param["fldLabel"]
                                + "', fldArtists = '" + param["fldArtists"] + "'WHERE fldUPC = " + UPC;
                            command.ExecuteNonQuery();
                            command.CommandText = "UPDATE CDChamber SET " + "fldInstrumentList = '" + param["fldInstrumentList"]
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

                // Set the Connection to the new OleDbConnection.
                command.Connection = connection;
		
		        // Carpet bomb all of the tables. We don't care if the product is in that table or not.
                try
                {
                    // open a connection
                    connection.Open();

                    // Start a local transaction with ReadCommitted isolation level.
                    transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

                    command.Connection = connection;
                    command.Transaction = transaction;

                    // Execute the commands.
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
                //No transaction for this one. The type of product is queried from the products table first
                //That product type is used for a case/switch to determine which query gets used
                //To make it simple, the queries use inner joins for products that exist on more than one table.

                //The SQL string is first set, then at the end of the switch, it is executed.
                if (reader.Read())
                {

                    //The dictionary gets filled with the table values using the field names as keys for consistency.
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            outDict[reader.GetName(i)] = reader[i].ToString();
                        }
                    type = outDict["fldProductType"];
                    switch (outDict["fldProductType"])
                    {
                        case "Book":
                            selectString = "SELECT * FROM Book WHERE fldUPC=" + UPC;
                            break;
                        case "BookCIS":
                            selectString = "SELECT * FROM BookCIS INNER JOIN BOOK ON BOOKCIS.fldUPC = BOOK.fldUPC WHERE BookCIS.fldUPC="+UPC;
                            break;
                        case "DVD":
                            selectString = "SELECT * FROM DVD WHERE fldUPC=" + UPC;
                            break;
                        case "CDOrchestra":
                            selectString = "SELECT * FROM CDOrchestra INNER JOIN CDClassical ON CDOrchestra.fldUPC = CDClassical.fldUPC WHERE CDOrchestra.fldUPC=" + UPC;
                            break;
                        case "CDChamber":
                            selectString = "SELECT * FROM CDChamber INNER JOIN CDClassical ON CDChamber.fldUPC = CDClassical.fldUPC WHERE CDChamber.fldUPC=" + UPC;
                            break;
                    } // end switch
                    command = new OleDbCommand(selectString, connection);
                    reader = command.ExecuteReader();


                    //Execute, and fill the dictionary with the product information.
                    if (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            outDict[reader.GetName(i)] = reader[i].ToString();
                        }
                    }
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
