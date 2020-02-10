using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;   //To create an Interaction box
using System.Data.OleDb;
using System.Data.SqlClient;

/* Title: School System
   Date: 15-November-2017
   Author: S185432
*/


namespace SchoolSystem                                                                          //Name of application                                      
{                                                                                               //Start of program 
    public partial class MainWindow : Form                                                      //Name of class
    {                                                                                           //Start of program
        //Creates a variable
        public string sqlGetCourses;

        //creates a variable of type oledbconnection and creates an instance of it
        public OleDbConnection connection = new OleDbConnection();

        //creates a variable of type oledbcommand
        public OleDbCommand myCommand = new OleDbCommand();

        //Creates a variable of type OleDbDataAdapter
        public OleDbDataAdapter myDataApter = new OleDbDataAdapter();

        //Creates a variable of type OleDbDataet
        public DataSet myDataSet = new DataSet();

        //Declares a variable and assigns 0 to it
        int rowIndex = 0;

        //Creates a variable
        string myQuery = "SELECT * FROM Students";

        //Creates a variable
        string myDbTable = "Students";

        //Creates a variable
        string myDataTablePk = "Students_Pk";

        //The below method initialises the objects/componets of the class
        public MainWindow()                                                             
        {
            InitializeComponent();
        }

        // Connects to the Data base
        public void connectToDataBase ()   
        {   
            //the object of the OleDBConection uses the connection string property to get the provider and the data source
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source= schoolSystem.accdb";
            //Exception handler
            try
            {
                //Opens the connection
                connection.Open();    
            }
            //Cathes the exception
            catch (Exception ex)
            {
                //Displays the exception message
                MessageBox.Show("Failed due to " + ex.Message);
            }

        }

        //Disconnects from the Data Base
        public void disconnectFromDataBase ()
        {
            //Exception handler
            try
            {
                //Closes the connection
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Load Event of this class
        private void MainWindow_Load(object sender, EventArgs e)
        {                                                                               //Start os load event
            //HIdes the Group Box Students
            groupBoxStudents.Hide();

            //Exception handler
            try
            {
                //class methods
                connectToDataBase();
                pullCourseFromDB();
                disconnectFromDataBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Clears combobox
            comboBoxCourse.Text = "";

            //Hides objects
            buttonFirst.Hide();
            buttonPrevious.Hide();
            buttonNext.Hide();
            buttonLast.Hide();

            buttonDelete.Hide();
            buttonUpdate.Hide();
            buttonSearch.Hide();

        }                                                                                 //End os load event

        /*The below method is used to pull information from the database. It should be noted that,
        the same was made public so that other classes can have acces to it.
        */

        public void loadData(string myQueryParameter, string myDbTableParameter, string myDataTablePkParameter)
        {                                                                                 //Start of method

            //Exception handler
            try
            {
                //Creates a data adapter and passes parameters to it, which are used to retrieve data form the database.
                myDataApter = new OleDbDataAdapter(myQueryParameter, connection);

                //creates a dataset object which will be used to store the data.
                myDataSet = new DataSet();

                //fills the dataset
                myDataApter.Fill(myDataSet, myDbTableParameter);

/*    creates a primary key in the data table, the reason for this is because one of the features in this application, is to
 *    allow the user to search for an specific record, and since some tables in the database do not have a primary key there is
 *    a need in defining one here.
                */

                myDataSet.Tables[0].Constraints.Add(myDataTablePkParameter, myDataSet.Tables[0].Columns[0], true);

            }                                                                           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }                                                                                   //End of method

        //The below method is used to show the data from the dataset

        void showData()                                                                     //name of method
        {                                                                                   //Start of method
            //Exception handler
            try
            {
                //assigns values to objects
                textBoxIdNumber.Text = myDataSet.Tables[0].Rows[rowIndex][0].ToString();
                textBoxName.Text = myDataSet.Tables[0].Rows[rowIndex][1].ToString();
                textBoxDOB.Text = myDataSet.Tables[0].Rows[rowIndex][2].ToString();
                textBoxAddress.Text = myDataSet.Tables[0].Rows[rowIndex][3].ToString();
                comboBoxCourse.Text = myDataSet.Tables[0].Rows[rowIndex][4].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }                                                                                   //End of method
 
        //The below event loads the data of the students from the database

        private void buttonLoadData_Click(object sender, EventArgs e)
        {                                                                                   //Start of event
            //Exception handler
            try
            {
                //Calls methods
                connectToDataBase();
                loadData(myQuery, myDbTable, myDataTablePk);
                disconnectFromDataBase();

                //Class the below method
                showData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Shows controls
            buttonFirst.Show();
            buttonPrevious.Show();
            buttonNext.Show();
            buttonLast.Show();

            buttonDelete.Show();
            buttonUpdate.Show();
            buttonSearch.Show();
        }                                                                                    //End of event

        /*      The aim of the below method is to go to the first record in the dataset. 
         *      So if the the current position is greater then 0, it sets it back to 0.
         *      And if it does not find anything in the dataset, it displays a message
         *      
         * IT SHOULD BE NOTED THAT THE SAME CONCEPT IS USED IN OTHER CLASSES AND SINCE THE CONCEPT IS EXPLAINED HERE IN DETAIL,
                 *  THE OTHER CLASSES WILL NOT ADRESS THE ISSUE AGAIN.
         */

        void firstRecord ()                                                                 //Creates a method
        {                                                                                   //Start of method
            //Exception handler
            try
            {
                //sets the index to position 0 (first record of the table) when the method is called
                if (myDataSet.Tables[0].Rows.Count > 0)
                {
                    rowIndex = 0;
                    MessageBox.Show("First Record");
                }
                else
                    MessageBox.Show("No records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been Loaded", ex.Message);
            }
        }                                                                                   //End of method

        //the below event shows the first record in the table

        private void buttonFirst_Click(object sender, EventArgs e)
        {                                                                                  //Start of event
            //Class methods
            firstRecord();
            showData();
        }                                                                                  //End of event

        /*      The aim of the below method is to go to the previous record in the dataset. 
         *      So if the the current position is greater then 0, it reduces the index number by one or inother words it 
         *      dicrements the position.
         *      And if it does not find anything in the dataset, it displays a message
         *      
         *  IT SHOULD BE NOTED THAT THE SAME CONCEPT IS USED IN OTHER CLASSES AND SINCE THE CONCEPT IS EXPLAINED HERE IN DETAIL,
         *  THE OTHER CLASSES WILL NOT ADRESS THE ISSUE AGAIN.
         */

        void previousRecord ()
        {                                                                                 //Start of method
            //Exception handler
            try
            {
                if (myDataSet.Tables[0].Rows.Count > 0)
                {
                    if (rowIndex > 0)
                    {
                        rowIndex--;
                    }
                    else
                        MessageBox.Show("First Record");
                }
                else
                    MessageBox.Show("no records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been loaded ", ex.Message);
            }
        }                                                                                     //End of method

        //the below event shows the previous record in the table

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            //Calls methods
            previousRecord();
            showData();
        }

        /*      The aim of the below method is to go to the next record in the dataset. 
        *     This is achieved by incrementing the position of the index.
         *     
        *  IT SHOULD BE NOTED THAT THE SAME CONCEPT IS USED IN OTHER CLASSES AND SINCE THE CONCEPT IS EXPLAINED HERE IN DETAIL,
         *  THE OTHER CLASSES WILL NOT ADRESS THE ISSUE AGAIN.
        */

        void nextRecord ()
        {                                                                                   //Start of method
            //Exception handler
            try
            {
                if (myDataSet.Tables[0].Rows.Count > 0)
                {
                    if (rowIndex < myDataSet.Tables[0].Rows.Count - 1)
                    {
                        rowIndex++;
                        
                    }
                    else
                        MessageBox.Show("Last Record");
                }
                else
                    MessageBox.Show("No records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been Loaded", ex.Message);
            }
        }                                                                                   //End of method

        //the below event shows the next record in the table
        private void buttonNext_Click(object sender, EventArgs e)
        {
            //Calls method
            nextRecord();
            showData();
        }

        /*      The aim of the below method is to go to the last record in the dataset. 
        *     This is achieved by counting the number of records in the table and substract one position to it, for, 
         *     the first position is 0 and not 1. after having the correct number of positions, then the last position is shown.
         *     
         *  IT SHOULD BE NOTED THAT THE SAME CONCEPT IS USED IN OTHER CLASSES AND SINCE THE CONCEPT IS EXPLAINED HERE IN DETAIL,
         *  THE OTHER CLASSES WILL NOT ADRESS THE ISSUE AGAIN.
        */

        void lastRecord ()                                                                         
        {                                                                                   //Start of method
            //Exception handler
            try
            {
                if (myDataSet.Tables[0].Rows.Count > 0)
                {
                    rowIndex = myDataSet.Tables[0].Rows.Count - 1;
                    MessageBox.Show("Last Record");
                }
                else
                    MessageBox.Show("No records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been loaded", ex.Message);
            }
        }                                                                                   //End of method

        //the below event shows the last record in the table
        private void buttonLast_Click(object sender, EventArgs e)
        {
            //Calls methods
            lastRecord();
            showData();
        }

        //This event clear all the fields
        private void buttonClearFields_Click(object sender, EventArgs e)
        {                                                                                  //Start of event
            //clearing controls
            textBoxIdNumber.Clear();
            textBoxName.Clear();
            textBoxDOB.Clear();
            textBoxAddress.Clear();
            comboBoxCourse.Text = "";
        }                                                                                  //End of method

        /*
         * the below event handles the searching of an speciific record in the database
         * */

        private void buttonSearch_Click(object sender, EventArgs e)
        {                                                                                 //Start of event
            //Exception handler
            try
            {
                //Creates an interaction box and assigns it value to the variable n
                int n = Convert.ToInt32(Interaction.InputBox("Enter student ID:", "Search", "0", 100, 100));
                
                //Finds the value of n in the dataset
                DataRow myDataRow;
                myDataRow = myDataSet.Tables[0].Rows.Find(n);
                if (myDataRow != null)
                {
                    rowIndex = myDataSet.Tables[0].Rows.IndexOf(myDataRow);

                    textBoxIdNumber.Text = myDataRow[0].ToString();
                    textBoxName.Text = myDataRow[1].ToString();
                    textBoxDOB.Text = myDataRow[2].ToString();
                    textBoxAddress.Text = myDataRow[3].ToString();
                    comboBoxCourse.Text = myDataRow[4].ToString();
                }
                else
                    MessageBox.Show("Record Not Found");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a valid ID number \n" + "Error Message: "+ ex.Message);
            }//End of Error handling
        }                                                                                    //End of event                 

        /*
         * the below method deals with the expiration of records in the database, note that the method is public to allow its
         * use in another classes.
         * It creates an instance of the object OleDbCommand and provides parameters to it (the sql query and the connection)
         *Following that os the execution of that command which is done by connecting to the DB first as connection are always 
         *closed after use for securty reasons.
         * */

        public void deleteRecord (string deleteQueryParameter)
        {                                                                                    //Start of method deleteRecord
            //Exception handler
            try
            {
                myCommand = new OleDbCommand(deleteQueryParameter, connection);
                connection.Open();
                int n = myCommand.ExecuteNonQuery();
                connection.Close();
                if (n > 0)
                {
                    MessageBox.Show("Record Deleted");
                }
                else
                    MessageBox.Show("Delete failed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }                                                                                  //End of method deleteRecord

        /*
         * the below event deals with the expiration of records by calling the delete method and further re-loads the data
         * */

        private void buttonDelete_Click(object sender, EventArgs e)
        {                                                                                   //Start of event
            //defines a variable
            string sqlDeleteStudent = "DELETE from Students WHERE studentID=" + textBoxIdNumber.Text;
            
            //Calls a method
            deleteRecord (sqlDeleteStudent);

            //Exception handler
            try
            {
                //Calls methods
                connection.Open();
                loadData(myQuery, myDbTable, myDataTablePk);
                connection.Close();
                showData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }                                                                                 //End of event

        /*
         * the below method updates records in the database, note that the method is public to allow its
         * use in another classes.
         * It creates an instance of the object OleDbCommand and provides parameters to it (the sql query and the connection)
         *Following that os the execution of that command which is done firtly by connecting to the DB as connection are always 
         *closed after use for securty reasons.
         * */


        public void updateRecord(string updateQueryParamete)
        {                                                                                  //Start of method
            //Exception handler
            try
            {
                myCommand = new OleDbCommand(updateQueryParamete, connection);
                connection.Open();
                int n = myCommand.ExecuteNonQuery();
                connection.Close();
                if (n > 0)
                {
                    MessageBox.Show("Record Updated");
                }
                else
                    MessageBox.Show("Update Failed");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of Exception handler
        }                                                                                   //End of method

        /*
         * the below event deals with the update of records by calling the update method and further re-loads the data
         * */

        private void buttonUpdate_Click(object sender, EventArgs e)
        {                                                                                   //Start of event
            //Declares a variable and assigns a value to it
            string sqlUpdateStudent = "UPDATE Students SET studentName='" + textBoxName.Text + "', dateOfBirth='" + textBoxDOB.Text + "', address='" + textBoxAddress.Text + "', course='" + comboBoxCourse.Text + "' WHERE studentID=" + textBoxIdNumber.Text;

            //Exception handler
            try
            {
                //Calls methods
                updateRecord(sqlUpdateStudent);

                connection.Open();
                loadData(myQuery, myDbTable, myDataTablePk);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //end Exception
            

        }                                                                                   //End ofevent

        /*
         * the below method adds records in the database, note that the method is public to allow its
         * use in another classes.
         * It creates an instance of the object OleDbCommand and provides parameters to it (the sql query and the connection)
         *Following that os the execution of that command which is done firtly by connecting to the DB as connection are always 
         *closed after use for securty reasons.
         * */
        public void addRecord(string addQueryParameter)
        {                                                                                  //Start of method
            //Exception handler
            try
            {
                myCommand = new OleDbCommand(addQueryParameter, connection);
                connectToDataBase();

                int n = myCommand.ExecuteNonQuery();
                disconnectFromDataBase();

                if (n > 0)
                {
                    MessageBox.Show("Record added successfully");
                }
                else
                    MessageBox.Show("Record was not Added");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handler
        }                                                                                    //End of method

        /*
         * the below event deals with the adition of records by calling the addRecord method.
         * */

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {                                                                                   //Start of event

            //Declares a Variable
            string queryAddStudent;

            //Sql query to insert the data into the DB
            queryAddStudent = "INSERT INTO Students (studentID,studentName,dateOfBirth,address,course) VALUES ('" + textBoxIdNumber.Text +
            "','" + textBoxName.Text + "','" + textBoxDOB.Text + "','" + textBoxAddress.Text + "','" + comboBoxCourse.Text + "')";
            
            //Exception handler
            try
            {
                //Calls method
                addRecord(queryAddStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handler
            
        }                                                                                   //End of event

        //The below method retrieves the courses from the database
        private void pullCourseFromDB ()
        {                                                                                  //Start of method
            //Declares a variable and assigns value to it
            string sqlGetCourses = "SELECT courseName FROM Courses";
            
            //Exception handler
            try
            {
                /*creates an intance of a data Adapter and passes two parameters (an sql query to pull the information 
                 * and the connection string)
                 * */
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlGetCourses, connection);
                //Creates an instance of a data table
                DataTable dataTable = new DataTable();

                //fills the data table with the information on the data adapter
                dataAdapter.Fill(dataTable);

                //assigns the source of information for the combobox
                comboBoxCourse.DataSource = dataTable;

                //Identifies the column of the data base to get information from
                comboBoxCourse.DisplayMember = "courseName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading courses, Reason: " + ex.Message);
            } //End of exception handler
        }

        //The following events deal with the menus and effects.

        private void labelMenuRooms_MouseHover(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuRooms.ForeColor = Color.Green;
        }

        private void labelMenuRooms_MouseLeave(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuRooms.ForeColor = Color.Black;
        }

        private void labelMenuCourses_MouseHover(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuCourses.ForeColor = Color.Green;
        }

        private void labelMenuCourses_MouseLeave(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuCourses.ForeColor = Color.Black;
        }

        private void labelMenuLectures_MouseHover(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuLectures.ForeColor = Color.Green;
        }

        private void labelMenuLectures_MouseLeave(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuLectures.ForeColor = Color.Black;
        }

        private void labelMenuGrades_MouseHover(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuGrades.ForeColor = Color.Green;
        }

        private void labelMenuGrades_MouseLeave(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuGrades.ForeColor = Color.Black;
        }

        private void labelMenuPayments_MouseHover(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuPayments.ForeColor = Color.Green;
        }

        private void labelMenuPayments_MouseLeave(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuPayments.ForeColor = Color.Black;
        }
        private void labelMenuStudents_MouseHover(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuStudents.ForeColor = Color.Green;    
        }

        private void labelMenuStudents_MouseLeave(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuStudents.ForeColor = Color.Black; 
        }

       

        private void labelMenuResources_MouseHover(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuResources.ForeColor = Color.Green;
        }

        private void labelMenuResources_MouseLeave(object sender, EventArgs e)
        {
            //changes the colour of the label
            labelMenuResources.ForeColor = Color.Black;
        }

        
        private void labelMenuResources_MouseClick(object sender, MouseEventArgs e)
        {
            //Hides this class and shows the class corresponding to the menu by creating an instance of it
            this.Hide();
            Resources formResources = new Resources();
            formResources.Show();
            
        }

        private void labelMenuLectures_MouseClick(object sender, MouseEventArgs e)
        {
            //Hides this class and shows the class corresponding to the menu by creating an instance of it
            this.Hide();
            Lectures lectureForm = new Lectures();
            lectureForm.Show();
        }

        private void labelMenuCourses_MouseClick(object sender, MouseEventArgs e)
        {
            //Hides this class and shows the class corresponding to the menu by creating an instance of it
            this.Hide();
            Courses coursesForm = new Courses();
            coursesForm.Show();
        }

        private void labelMenuGrades_MouseClick(object sender, MouseEventArgs e)
        {
            //Hides this class and shows the class corresponding to the menu by creating an instance of it
            this.Hide();
            Grades gradesForm = new Grades();
            gradesForm.Show();
        }

        private void labelMenuPayments_MouseClick(object sender, MouseEventArgs e)
        {
            //Hides this class and shows the class corresponding to the menu by creating an instance of it
            this.Hide();
            Payments paymentForm = new Payments();
            paymentForm.Show();
           
        }

        private void labelMenuRooms_MouseClick(object sender, MouseEventArgs e)
        {
            //Hides this class and shows the class corresponding to the menu by creating an instance of it
            this.Hide();
            Rooms roomsForm = new Rooms();
            roomsForm.Show();
        }

        private void labelMenuStudents_Click(object sender, EventArgs e)
        {
            //shows the groupbox
            groupBoxStudents.Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Exits the application
            System.Windows.Forms.Application.Exit();
        }
    }                                                                                             //End of class
}                                                                                                 //End of program
