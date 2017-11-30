using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLDatabase.Net.SQLDatabaseClient;
using System.IO;
using System.Diagnostics;

namespace SQLDatabase.Net.Examples
{
    public partial class Form1 : Form
    {
        //holds database file name.
        static string ExampleDatabaseFile = string.Empty;

        //Extended Result Set and Active ResultSet are 
        SqlDatabaseConnectionStringBuilder cb = new SqlDatabaseConnectionStringBuilder();

        public Form1()
        {
            InitializeComponent();
            
            ExampleDatabaseFile = Path.Combine(Directory.GetParent(Path.GetDirectoryName(Application.ExecutablePath)).Parent.FullName, "Orders.db");
            if (!File.Exists(ExampleDatabaseFile))
                ExampleDatabaseFile = string.Empty;
            else
                Debug.WriteLine(ExampleDatabaseFile);
        }

        private void MultiRead_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExampleDatabaseFile))
                return;

            //build connection string
            cb.Clear(); //clear any existing settings.
            cb.Uri = ExampleDatabaseFile;
            cb.SchemaName = "db";
            
            
            using (SqlDatabaseConnection cnn = new SqlDatabaseConnection(cb.ConnectionString))
            {
                cnn.Open();
                
                Parallel.For(0, Environment.ProcessorCount, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i => {

                    try
                    {
                        using (SqlDatabaseCommand command = new SqlDatabaseCommand())
                        {
                            command.Connection = cnn;
                            command.CommandText = "SELECT ProductId, ProductName FROM Products ORDER BY ProductId LIMIT 10 OFFSET " + (10 * i) + ";";
                            SqlDatabaseDataReader rd = command.ExecuteReader();
                            while (rd.Read())
                            {
                                Debug.Write(Thread.CurrentThread.ManagedThreadId + "\t");
                                for (int c = 0; c < rd.VisibleFieldCount; c++)
                                {
                                    Debug.Write(rd.GetValue(c) + "\t");
                                }
                                Debug.WriteLine("");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                });
            }
               
        }

        private void ParallelRead_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExampleDatabaseFile))
                return;

            //build connection
            cb.Clear(); //clear any previous settings
            cb.Uri = ExampleDatabaseFile;
            cb.MultipleActiveResultSets = true;
            cb.ExtendedResultSets = false;
            cb.SchemaName = "db";


            using (SqlDatabaseConnection cnn = new SqlDatabaseConnection(cb.ConnectionString))
            {
                cnn.Open();

                Parallel.For(0, Environment.ProcessorCount, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i => {

                    try
                    {
                        using (SqlDatabaseCommand command = new SqlDatabaseCommand())
                        {
                            command.Connection = cnn;
                            command.CommandText = "SELECT ProductId, ProductName FROM Products ORDER BY ProductId LIMIT 10 OFFSET " + (10 * i) + ";";
                            SQLDatabaseResultSet[] cmdrs = command.ExecuteReader(true);
                            if ((cmdrs != null) && (cmdrs.Length > 0))
                            {
                                foreach(SQLDatabaseResultSet rs in cmdrs)
                                {
                                    Debug.WriteLine("RowCount {0}", rs.RowCount);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                });
            }
        }

        private void ParallelInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExampleDatabaseFile))
                return;

            string[] Files = Directory.GetFiles(Path.Combine(Directory.GetParent(Path.GetDirectoryName(Application.ExecutablePath)).Parent.FullName, "csv"), "*.csv");
            

            using (SqlDatabaseConnection cnn = new SqlDatabaseConnection("schemaname=db;uri=file://@memory;"))
            {
                cnn.Open();

                using (SqlDatabaseCommand cmd = new SqlDatabaseCommand(cnn))
                {                   
                    cmd.CommandText = "CREATE TABLE Transactions (StreetAddress Text, City Text, Zip Text, State Text, Beds Integer, Baths Integer";
                    cmd.CommandText += ", SQFT Text, PropertyType Text, SaleDate Text, Price Real, Latitude Text, Longitude Text);";
                    cmd.ExecuteNonQuery();
                }
                              
                
                Parallel.For(0, Files.Length, i =>
                {
                    string[] FileLines = File.ReadAllLines(Files[i]);
                    using (SqlDatabaseCommand cmd = new SqlDatabaseCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = "INSERT INTO Transactions VALUES (@StreetAddress, @City, @Zip, @State, @Beds, @Baths, @SQFT, @PropertyType, @SaleDate, @Price, @Latitude, @Longitude); ";

                        //Add Query Parameters if they don't exists.
                        if (!cmd.Parameters.Contains("@StreetAddress"))
                            cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@StreetAddress" });
                        if (!cmd.Parameters.Contains("@City"))
                            cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@City" });
                        if (!cmd.Parameters.Contains("@Zip"))
                            cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@Zip" });
                        if (!cmd.Parameters.Contains("@State"))
                            cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@State" });
                        if (!cmd.Parameters.Contains("@Beds"))
                            cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@Beds" });
                        if (!cmd.Parameters.Contains("@Baths"))
                            cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@Baths" });
                        if (!cmd.Parameters.Contains("@SQFT"))
                            cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@SQFT" });
                        if (!cmd.Parameters.Contains("@PropertyType"))
                            cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@PropertyType" });
                        if (!cmd.Parameters.Contains("@SaleDate"))
                            cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@SaleDate" });
                        if (!cmd.Parameters.Contains("@Price"))
                            cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@Price" });
                        if (!cmd.Parameters.Contains("@Latitude"))
                            cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@Latitude" });
                        if (!cmd.Parameters.Contains("@Longitude"))
                            cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@Longitude" });


                        for (int l = 0; l < FileLines.Length; l++)
                        {
                            string[] Values = FileLines[l].Split(','); //split line based on comma

                            cmd.Parameters["@StreetAddress"].Value = Values[0];
                            cmd.Parameters["@City"].Value = Values[1];
                            cmd.Parameters["@Zip"].Value = Values[2];
                            cmd.Parameters["@State"].Value = Values[3];
                            cmd.Parameters["@Beds"].Value = Values[4];
                            cmd.Parameters["@Baths"].Value = Values[5];
                            cmd.Parameters["@SQFT"].Value = Values[6];
                            cmd.Parameters["@PropertyType"].Value = Values[7];
                            cmd.Parameters["@SaleDate"].Value = Values[8];
                            cmd.Parameters["@Price"].Value = Values[9];
                            cmd.Parameters["@Latitude"].Value = Values[10];
                            cmd.Parameters["@Longitude"].Value = Values[11];

                            cmd.ExecuteNonQuery();

                            ////Parameters can be acccessed via index to shorten the code
                            ////Parameters must be created in correct order and their count must match with values from file.
                            ////Comment the above code if you want to test following code.
                            //for (int v = 0; v < Values.Length; v++)
                            //{
                            //    cmd.Parameters[v].Value = Values[v];
                            //}
                            //cmd.ExecuteNonQuery();
                        }
                    }

                    Debug.WriteLine("Finished Thread {0} with total lines {1} from file {2}", Thread.CurrentThread.ManagedThreadId, FileLines.Length, Files[i]);

                });
                using (SqlDatabaseCommand cmd = new SqlDatabaseCommand(cnn))
                {
                    cmd.CommandText = "SELECT Count(*) as [TotalTransactions] FROM Transactions;";
                    Debug.WriteLine("Total Transactions {0}", cmd.ExecuteScalar());
                }
                Debug.WriteLine("Finished All Files");

            }
        }

        private void MarsEnabled_Click(object sender, EventArgs e)
        {
            // MARS (MultipleActiveResultSets) can increase read time since queries can be combined.
            // Very useful for large forms and web pages which require data from multiple tables.
            // Instead of running each query and processing result get all result at once.

            if (string.IsNullOrWhiteSpace(ExampleDatabaseFile))
                return;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            //build connection string
            cb.Clear(); //clear any previous settings
            cb.Uri = ExampleDatabaseFile; //Set the database file
            cb.MultipleActiveResultSets = true; //We need multiple result sets
            cb.ExtendedResultSets = false; //extended result set is false but can be set during command execution.
            cb.SchemaName = "db"; //schema name
            

            using (SqlDatabaseConnection cnn = new SqlDatabaseConnection(cb.ConnectionString))
            {
                cnn.Open();
                
                try
                {
                    using (SqlDatabaseCommand command = new SqlDatabaseCommand())
                    {
                        command.Connection = cnn;

                        //execute two queries against two tables.
                        //command.CommandText = "SELECT ProductId, ProductName FROM Products; SELECT CustomerId, LastName || ' , ' || FirstName FROM Customers LIMIT 10;";

                        // For easy to read above command can also be written as following:
                        command.CommandText = "SELECT ProductId, ProductName FROM Products ; ";
                        command.CommandText += "SELECT CustomerId, LastName || ',' || FirstName FROM Customers LIMIT 10 ; ";

                        SQLDatabaseResultSet[] cmdrs = command.ExecuteReader(false);// parameter bool type is for ExtendedResultSet
                        if ((cmdrs != null) && (cmdrs.Length > 0))
                        {
                            //this loop is just an example how to loop through all rows and columns.
                            for(int r = 0; r < cmdrs[0].RowCount; r++) //loop through each row of result set index zero ( 0 )
                            {                                
                                for(int c = 0; c < cmdrs[0].ColumnCount; c++)
                                {
                                    Debug.WriteLine(cmdrs[0].Rows[r][c].ToString());
                                }                             
                            }

                            //Loading data from products table which is at index 0 : cmdrs[0]
                            for (int r = 0; r < cmdrs[0].RowCount; r++) //loop through each row of result set index zero ( 0 ) which is products table
                            {
                                //cmdrs[0].Rows[r][0] : in Rows[r][0] r = row and [0] is column index.
                                comboBox1.Items.Add(cmdrs[0].Rows[r][0].ToString() + " - " + cmdrs[0].Rows[r][1].ToString());
                            }
                            //Loading data from customers table which is at index 1 cmdrs[1]
                            for (int r = 0; r < cmdrs[1].RowCount; r++) //loop through each row of result set index zero ( 0 ) which is customers table
                            {
                                //cmdrs[0].Rows[r][0] : Rows[r][0] r = row and [0] is column index.
                                comboBox2.Items.Add(cmdrs[1].Rows[r][0].ToString() + " - " + cmdrs[1].Rows[r][1].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                //combobox1 will close when combobox2 is opened.
                comboBox1.Focus();
                comboBox1.DroppedDown = true;

                //combobox2 open will close combobox1 by behaviour.
                comboBox2.Focus();
                comboBox2.DroppedDown = true;
            }
        }

        private void ExtendedResults_Click(object sender, EventArgs e)
        {
            // Extended result set returns more information about query.
            // Processing time is in milliseconds.

            if (string.IsNullOrWhiteSpace(ExampleDatabaseFile))
                return;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            //build connection
            cb.Clear(); //clear any previous settings
            cb.Uri = ExampleDatabaseFile;
            cb.MultipleActiveResultSets = true;
            cb.ExtendedResultSets = true;
            cb.SchemaName = "db";


            using (SqlDatabaseConnection cnn = new SqlDatabaseConnection(cb.ConnectionString))
            {
                cnn.Open();

                try
                {
                    using (SqlDatabaseCommand command = new SqlDatabaseCommand())
                    {
                        command.Connection = cnn;

                        ////execute two queries against two tables.
                        ////query can have parameters they are not declared here since code is commented.
                        //command.CommandText = "UPDATE Suppliers SET CompanyName = CompanyName Where SupplierId = 1;SELECT ProductId, ProductName FROM Products; SELECT CustomerId, LastName || ' , ' || FirstName FROM Customers LIMIT 10;";

                        // For easy to read above command can also be written as following:
                        command.CommandText = "UPDATE Suppliers SET CompanyName = CompanyName Where SupplierId = 1 ; "; //First Query will be at index 0
                        command.CommandText += "SELECT ProductId [Product Id], ProductName FROM db.Products LIMIT 10 OFFSET @Limit ; ";  //Second Query will be at index 1
                        command.CommandText += "SELECT CustomerId, LastName || ',' || FirstName FROM Customers LIMIT @Limit ; "; //Third Query will be at index 2

                        command.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@Limit", Value = 10 });

                        SQLDatabaseResultSet[] cmdrs = command.ExecuteReader(true);// parameter bool type is for ExtendedResultSet
                        if ((cmdrs != null) && (cmdrs.Length > 0))
                        {
                            foreach(SQLDatabaseResultSet rs in cmdrs)
                            {
                                Console.WriteLine("---------------------------------\n" + rs.SQLText);
                                Debug.WriteLine("Execution time in Milliseconds: {0} ", rs.ProcessingTime);
                                Debug.WriteLine("Rows Affected: {0}" , rs.RowsAffected); //RowsAffected is non zero for update or delete only.

                                if (string.IsNullOrWhiteSpace(rs.ErrorMessage))
                                    Debug.WriteLine("No error");
                                else
                                    Debug.WriteLine(rs.ErrorMessage);

                                //All the schemas in the query
                                foreach (object schema in rs.Schemas)
                                    Debug.WriteLine("Schema Name: {0} ", schema);

                                //All the tables in the query
                                foreach (object table in rs.Tables)
                                    Debug.WriteLine("Table Name: {0} ", table);

                                //parameters if any 
                                foreach (object Parameter in rs.Parameters)
                                    Debug.WriteLine("Parameter Name: {0} ", Parameter);


                                //data type for returned column, datatype is what is defined during create table statement.
                                foreach(string datatype in rs.DataTypes)
                                {
                                    Console.Write(datatype + "\t");
                                }
                                Debug.WriteLine(""); //add empty line to make it easy to read

                                //Column names or aliases
                                foreach (string ColumnName in rs.Columns)
                                {
                                    Console.Write(ColumnName + "\t");
                                }
                                Debug.WriteLine("");//add empty line to make it easy to read

                                //all columns and rows.
                                foreach (object[] row in rs.Rows)
                                {
                                    foreach (object column in row)
                                    {
                                        Debug.Write(column + "\t"); // \t will add tab
                                    }
                                    Debug.WriteLine(""); //break line for each new row.
                                }
                            }
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private void ParallelInsertFile_Click(object sender, EventArgs e)
        {

            DialogResult dlgresult = MessageBox.Show("This example will copy file names from MyDocuments folder, continue ?","Important Question", MessageBoxButtons.YesNo);

            if (dlgresult.ToString() == "No")
                return;

            string[] files = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "*.*");
            
            string dbfilepath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "files.db");
            if (File.Exists(dbfilepath))
                File.Delete(dbfilepath);

            using (SqlDatabaseConnection cnn = new SqlDatabaseConnection("schemaname=db;uri=file://" + dbfilepath + ";"))
            {
                
                cnn.Open();

                using (SqlDatabaseCommand cmd = new SqlDatabaseCommand(cnn))
                {
                    cmd.CommandText = "CREATE TABLE FileNames (Id Integer primary key autoincrement, InsertDateTime Text, ThreadId Integer, FileName Text); ";
                    cmd.ExecuteNonQuery();
                }
                SqlDatabaseTransaction trans = cnn.BeginTransaction();
                                
                try
                {
                    Parallel.ForEach(files, (currentFile) =>
                    {
                        using (SqlDatabaseCommand cmd = new SqlDatabaseCommand(cnn))
                        {
                            cmd.Transaction = trans;
                            cmd.CommandText = "INSERT INTO FileNames VALUES (null, GetDate(), @ThreadId, @FileName); ";
                            cmd.Parameters.Add("@ThreadId", Thread.CurrentThread.ManagedThreadId);
                            cmd.Parameters.Add("@FileName", currentFile);
                            cmd.ExecuteNonQuery();                            
                        }
                    });
                }                    
                catch
                {
                    trans.Rollback();
                }
                
                trans.Commit();
                //Now try reading..
                using (SqlDatabaseCommand cmd = new SqlDatabaseCommand(cnn))
                {
                    cmd.CommandText = "SELECT * FROM FileNames LIMIT 100; ";
                    SqlDatabaseDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int c = 0; c < dr.VisibleFieldCount; c++)
                        {
                            Debug.Write(dr.GetValue(c) + "\t");
                        }
                        Debug.WriteLine("");
                    }
                }
                
            }

            if (File.Exists(dbfilepath))
                File.Delete(dbfilepath);
        }

        private void SavePoint_Click(object sender, EventArgs e)
        {
            using (SqlDatabaseConnection cnn = new SqlDatabaseConnection("schemaname=db;uri=file://@memory;"))
            {
                cnn.Open();
                SqlDatabaseTransaction trans = cnn.BeginTransaction();
                using (SqlDatabaseCommand cmd = new SqlDatabaseCommand(cnn))
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = "CREATE TABLE SavePointExample (id Integer); ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO SavePointExample VALUES (1); ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SAVEPOINT a; ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO SavePointExample VALUES (2); ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SAVEPOINT b; ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO SavePointExample VALUES (3); ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SAVEPOINT c; ";
                    cmd.ExecuteNonQuery();

                    //should return 1, 2, 3 since no rollback or released has occured.
                    cmd.CommandText = "SELECT * FROM SavePointExample; ";
                    SqlDatabaseDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int c = 0; c < dr.VisibleFieldCount; c++)
                        {
                            Debug.Write(dr.GetValue(c) + "\t");
                        }
                        Debug.WriteLine("");
                    }

                    //rollback save point to b without committing transaction. The value 3 and savepoint c will be gone.
                    cmd.CommandText = "ROLLBACK TO b"; //b 
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT * FROM SavePointExample; ";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int c = 0; c < dr.VisibleFieldCount; c++)
                        {
                            Debug.Write(dr.GetValue(c) + "\t");
                        }
                        Debug.WriteLine(""); // line break.
                    }

                    //if we uncomment and release c it wil produce logical error as savepoint c does not exists due to rollback to b.
                    //cmd.CommandText = "RELEASE c"; //c 
                    //cmd.ExecuteNonQuery();

                    cmd.CommandText = "RELEASE b;"; //release b means commit the deffered transaction.
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT * FROM SavePointExample; ";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int c = 0; c < dr.VisibleFieldCount; c++)
                        {
                            Debug.Write(dr.GetValue(c) + "\t");
                        }
                        Debug.WriteLine(""); // line break.
                    }


                    //We can still rollback entire transaction
                    //trans.Rollback();

                    //commit an entire transaction
                    trans.Commit();

                    //If we rollback transaction above regardless of release savepoint (i.e. saving)
                    //following will produce an error that SavePointExample table not found.
                    cmd.CommandText = "SELECT * FROM SavePointExample; ";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int c = 0; c < dr.VisibleFieldCount; c++)
                        {
                            Debug.Write(dr.GetValue(c) + "\t");
                        }
                        Debug.WriteLine(""); // line break.
                    }

                }


            }
        }

        private void MixedLanguages_Click(object sender, EventArgs e)
        {
            using (SqlDatabaseConnection cnn = new SqlDatabaseConnection("schemaname=db;uri=file://@memory;"))
            {
                cnn.Open();
                SqlDatabaseTransaction trans = cnn.BeginTransaction();
                using (SqlDatabaseCommand cmd = new SqlDatabaseCommand(cnn))
                {
                    cmd.CommandText = "CREATE TABLE Languages (Id Integer Primary Key AutoIncrement, LanguageName Text, LangText Text);";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO Languages VALUES (null, @Language, @LangText);";
                    cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@Language" });
                    cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@LangText" });

                    cmd.Parameters["@Language"].Value = "English";
                    cmd.Parameters["@LangText"].Value = "Hello World";
                    cmd.ExecuteNonQuery();

                    //Languages written right to left must use parameters intead of string concatenation of sql text.
                    cmd.Parameters["@Language"].Value = "Urdu";
                    cmd.Parameters["@LangText"].Value = "ہیلو ورلڈ";
                    cmd.ExecuteNonQuery();

                    cmd.Parameters["@Language"].Value = "Arabic";
                    cmd.Parameters["@LangText"].Value = "مرحبا بالعالم";
                    cmd.ExecuteNonQuery();

                    cmd.Parameters["@Language"].Value = "Chinese Traditional";
                    cmd.Parameters["@LangText"].Value = "你好，世界";
                    cmd.ExecuteNonQuery();

                    cmd.Parameters["@Language"].Value = "Japanese";
                    cmd.Parameters["@LangText"].Value = "こんにちは世界";
                    cmd.ExecuteNonQuery();

                    cmd.Parameters["@Language"].Value = "Russian";
                    cmd.Parameters["@LangText"].Value = "Привет мир";
                    cmd.ExecuteNonQuery();

                    cmd.Parameters["@Language"].Value = "Hindi";
                    cmd.Parameters["@LangText"].Value = "नमस्ते दुनिया";
                    cmd.ExecuteNonQuery();


                    cmd.CommandText = "SELECT * FROM Languages; ";
                    SqlDatabaseDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int c = 0; c < dr.VisibleFieldCount; c++)
                        {
                            Debug.Write(dr.GetValue(c) + "\t");
                        }
                        Debug.WriteLine("");
                    }

                    Debug.WriteLine("---- Search -----");
                    //Urdu and Arabic should return when searching like ر which is R character in english.
                    cmd.CommandText = "SELECT * FROM Languages WHERE LangText LIKE @LikeSearch;"; //note no single quotes around @LikeSearch parameter LIKE '%w%'
                    cmd.Parameters.Add(new SqlDatabaseParameter { ParameterName = "@LikeSearch", Value = "%ر%" });
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int c = 0; c < dr.VisibleFieldCount; c++)
                        {
                            Debug.Write(dr.GetValue(c) + "\t");
                        }
                        Debug.WriteLine("");
                    }

                    Debug.WriteLine("---- Search With OR operator -----");

                    //Now it should return English, Urdu, Arabic and Russian due to OR operator
                    cmd.CommandText = "SELECT * FROM Languages WHERE (LangText LIKE '%W%') OR (LangText LIKE @LikeSearch) OR (LangText = @LangText);"; //note no single quotes around @LikeSearch parameter LIKE '%w%'

                    //Parameters can be cleared using : cmd.Parameters.Clear(); //however we are reusing existing parameter names.
                    cmd.Parameters["@LikeSearch"].Value = "%ر%" ; //since parameter @LikeSearch already exist assign new value.
                    cmd.Parameters["@LangText"].Value = "Привет мир"; //parameter @LangText already exist in this Command object.
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        for (int c = 0; c < dr.VisibleFieldCount; c++)
                        {
                            Debug.Write(dr.GetValue(c) + "\t");
                        }
                        Debug.WriteLine("");
                    }

                }
            }

        }
    }
}
