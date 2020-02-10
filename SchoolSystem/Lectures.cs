using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Title: School System
   Date: 15-November-2017
   Author: S185432
*/

namespace SchoolSystem                                                                          //Name of the application
{                                                                                               //Start of application
    public partial class Lectures: Form                                                         //Name of class
    {
        //Creates an instance of the class MainWindow
        MainWindow mainWindowForm = new MainWindow();

        //Declares a variable
        int rowIndex = 0;

        //Creates a variable
        string queryViewResources = "SELECT * FROM Lectures";

        //Creates a variable
        string resourceDbTable = "Lectures";

        //Creates a variable
        string resourceDataTablePk = "lecture_Pk";

        //Delcares Variables and assigns 0 to them
        public int numberOfStudents = 0;
        public int numberOfChairs = 0;

        //The below method initialises the objects/componets of the class
        public Lectures()
        {
            InitializeComponent();
        }

        //This Event allows the user to go back to the main window
        private void buttonBackToMain_Click(object sender, EventArgs e)
        {                                                                                          //Start of event
            this.Close();
            mainWindowForm.Show();
        }                                                                                          //End of event

        /*
         * The below method retrieves the rooms from the database
         * */

        private void getRoomsFromDB()                                                              //Name of method
        {                                                                                          //Start of method
            //Declares a variable and assigns an sql statement to it
            string sqlGetRoom = "SELECT type FROM Room";
            //Exception handler
            try
            {
                /*creates an intance of a data Adapter and passes two parameters (an sql query to pull the information 
                 * and the connection string)
                 * */
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlGetRoom, mainWindowForm.connection);

                //Creates an instance of a data table
                DataTable dataTable = new DataTable();

                //fills the data table with the information on the data adapter
                dataAdapter.Fill(dataTable);

                //assigns the source of information for the combobox
                comboBoxRoom.DataSource = dataTable;

                //Identifies the column of the data base to get information from
                comboBoxRoom.DisplayMember = "type";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading courses, Reason: " + ex.Message);
            } //End of exception handler
        }                                                                                           //End of method
        /*
         * The below method retrieves the courses from the database
         * */
        private void pullCourseFromDB()
        {                                                                                           //Start of method
            //Declares a variable and assigns the sql statement to it
            string sqlGetCourses = "SELECT courseName FROM Courses";
            
            //Exception handler
            try
            {
                /*creates an intance of a data Adapter and passes two parameters (an sql query to pull the information 
                 * and the connection string)
                 * */
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlGetCourses, mainWindowForm.connection);
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
            } //End of Exception
        }                                                                                           //End of method                                                                         

        private void getNumberOfRecords(string queryNumberOfRecordsParameter, string identifierParameter)
        {                                                                                           //Start of method
            //Exception handler
            try
            {
                /*creates an intance of a data Adapter and passes two parameters (an sql query to pull the information 
                * and the connection string)
                * */
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(queryNumberOfRecordsParameter, mainWindowForm.connection);
                //Creates an instance of a data table
                DataTable dataTable = new DataTable();

                //fills the data table with the information on the data adapter
                dataAdapter.Fill(dataTable);

                //switch conditons. "A" counts students and "B" deals with resources (chair)
                switch (identifierParameter)
                {                                                                                   //Start of Switch condition
                    case "A":
                        {
                            numberOfStudents = dataTable.Rows.Count;
                            labelStudentsOnCourse.Text = numberOfStudents.ToString();
                            break;
                        }
                    case "B":
                        {
                            numberOfChairs = dataTable.Rows.Count;
                            labelNumberOfChairs.Text = numberOfChairs.ToString();
                            break;
                        }
                    default:
                        MessageBox.Show("Could not get the number of students or chairs ");
                        break;
                }                                                                                   //End of Switch condition
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //end of exception handling
        }                                                                                           //End of method

        /*
         * The below event calls retrives the rooms and courses from the DB. And additionally hides some of the controls
         * */

        private void Lectures_Load(object sender, EventArgs e)
        {
            //Exception handler
            try
            {
                //Calls methods of another class
                mainWindowForm.connectToDataBase();
                getRoomsFromDB();
                mainWindowForm.disconnectFromDataBase();

                mainWindowForm.connectToDataBase();
                pullCourseFromDB();
                mainWindowForm.disconnectFromDataBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handling

            //Clears objects
            comboBoxRoom.Text = "";
            comboBoxCourse.Text = "";

            //Hides controls
            buttonDeleteLecture.Hide();
            buttonUpdateLecture.Hide();
            buttonSearchLecture.Hide();

            buttonFirst.Hide();
            buttonNext.Hide();
            buttonPrevious.Hide();
            buttonLast.Hide();

        }                                                                                           //End of event

        //The below method is used to show the lectures
        private void showLectureData()
        {                                                                                          //Start of method
            //Exception handler
            try
            {
                //Populates data to appropriate elements of the class
                textBoxLectureId.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][0].ToString();
                textBoxLectureName.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][1].ToString();
                textBoxNumberOfStudents.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][2].ToString();
                comboBoxCourse.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][3].ToString();
                comboBoxRoom.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][4].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handling
        }                                                                                        //End of method

        /*
        * the following event allows the user to view the lectures, by pulling this imformatin from the DB and show it by
        * calling the showLectureData method
        */
        private void buttonViewLectures_Click(object sender, EventArgs e)
        {                                                                                       //Start of event
            //Exception handler
            try
            {
                //Calls methods
                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewResources, resourceDbTable, resourceDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                showLectureData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of Exception handling

            //Shows buttons
            buttonDeleteLecture.Show();
            buttonUpdateLecture.Show();
            buttonSearchLecture.Show();

            buttonFirst.Show();
            buttonNext.Show();
            buttonPrevious.Show();
            buttonLast.Show();
        }                                                                                         //End of event

        /***********************************************************************************************************************
        * *********************************************************************************************************************
        * *********************************************************************************************************************
        * 
        * The following events navegate the dataset and show the first, previous, next or last record when the respective *****
          button is clicked (event is triggered).
        *
        * *********************************************************************************************************************
        * *********************************************************************************************************************
        * */

        private void buttonFirst_Click(object sender, EventArgs e)
        {                                                                                         //Start of event
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    rowIndex = 0;
                    showLectureData();
                    MessageBox.Show("First Record");
                }
                else
                    MessageBox.Show("No records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been Loaded ", ex.Message);
            }
        }                                                                                        //End of event

        private void buttonPrevious_Click(object sender, EventArgs e)
        {                                                                                        //Start of event
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    if (rowIndex > 0)
                    {
                        rowIndex--;
                        showLectureData();
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
        }                                                                                       //End of event

        private void buttonNext_Click(object sender, EventArgs e)
        {                                                                                       //start of event
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    if (rowIndex < mainWindowForm.myDataSet.Tables[0].Rows.Count - 1)
                    {
                        rowIndex++;
                        showLectureData();
                    }
                    else
                        MessageBox.Show("Last Record");
                }
                else
                    MessageBox.Show("No records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been loaded ", ex.Message);
            }
        }                                                                                       //End of event

        private void buttonLast_Click(object sender, EventArgs e)
        {                                                                                       //Start of event
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    rowIndex = mainWindowForm.myDataSet.Tables[0].Rows.Count - 1;
                    showLectureData();
                    MessageBox.Show("Last Record");
                }
                else
                    MessageBox.Show("No records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been loaded ", ex.Message);
            }
        }                                                                                       //End of event

        //Event clear all fields
        private void buttonClearFields_Click(object sender, EventArgs e)
        {                                                                                      //Start of event
            //Clearing all the fields

            textBoxLectureId.Clear();
            textBoxLectureName.Clear();
            textBoxNumberOfStudents.Clear();
            comboBoxCourse.Text = "";
            comboBoxRoom.Text = "";
            
        }                                                                                    //End of event

        /*
         * the following event allows the user to search for an specific record in the database
         */

        private void buttonSearchLecture_Click(object sender, EventArgs e)
        {                                                                                    //Start of event
            //Exception handler
            try
            {
                //creates an interaction box and for the user to insert the room ID and saves the number in the variable n
                int n = Convert.ToInt32(Interaction.InputBox("Please enter the lecture ID:", "Search", "0", 100, 100));

                //Finds the record in the dataset and shows it
                DataRow myDataRow;
                myDataRow = mainWindowForm.myDataSet.Tables[0].Rows.Find(n);
                if (myDataRow != null)
                {
                    rowIndex = mainWindowForm.myDataSet.Tables[0].Rows.IndexOf(myDataRow);

                    textBoxLectureId.Text = myDataRow[0].ToString();
                    textBoxLectureName.Text = myDataRow[1].ToString();
                    textBoxNumberOfStudents.Text = myDataRow[2].ToString();
                    comboBoxCourse.Text = myDataRow[3].ToString();
                    comboBoxRoom.Text = myDataRow[4].ToString();
                    
                }
                //Displays a message in case the record is not found
                else
                    MessageBox.Show("Record Not Found");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a valid ID number \n" + "Error Message: " + ex.Message);
            } //End of exception handling
        }                                                                                       //End of event

        /*
         * the following event allows the user to delete a record (lecture) using methods of the class mainWindowForm
         */

        private void buttonDeleteLecture_Click(object sender, EventArgs e)
        {                                                                                      //Start of event

            //Declares a variable and assign the sql statement to it
            string sqlDeleteLecture = "DELETE from Lectures WHERE lectureID=" + textBoxLectureId.Text;

            //Exception handler
            try
            {
                //calls methods of the class mainWindowForm
                mainWindowForm.deleteRecord(sqlDeleteLecture);

                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewResources, resourceDbTable, resourceDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                showLectureData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handling
        }                                                                                        //End of event

        /*
         * the following event allows the user to update the lectures using the method updateRecords of the class
         * (mainWindowForm), and further shows the lectures once update is complete.
         */

        private void buttonUpdateLecture_Click(object sender, EventArgs e)
        {                                                                                       //Start of event

            //Declares a variable and assigns an sql statement to it
            string sqlUpdateLecture = "UPDATE Lectures SET lecture='" + textBoxLectureName.Text + "', numberOfStudents='" + textBoxNumberOfStudents.Text + "', course='" + comboBoxCourse.Text + "', room='" + comboBoxRoom.Text + "' WHERE lectureID=" + textBoxLectureId.Text;

            //Exception handler
            try
            {
                //Calls methods of the class mainWindowForm
                mainWindowForm.updateRecord(sqlUpdateLecture);

                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewResources, resourceDbTable, resourceDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                showLectureData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception
        }                                                                                        //End of event

/********************************************************************************************************************************
*********************************************************************************************************************************
**     The below event handles the addition of lectures. Firstly it retrieves the number of students on the selected course  ****
**     and the number of chairs in the selected room. Additionally, it checks whether the number of chairs are sufficient    ****
**     for the students by comparing the two values. If there are sufficient chairs/resources it proceeds in adding the      ****
*      lecture otherwise it displays a message to the user advising the addition of resources or selection of a different room **
*********************************************************************************************************************************
*********************************************************************************************************************************
*/


        private void buttonAddLecture_Click(object sender, EventArgs e)
        {                                                                                             //Start of event
            //Declares a variable and assigns a value to it
            string selectedCourse = comboBoxCourse.Text ;

            //Declares a variable and assigns a value to it
            string selectedRoom = comboBoxRoom.Text ;

            //Declares a variable
            string identifier;

            //Declares a variable and assigns a value to it
            string queryNumberOfStudents = "SELECT studentName FROM Students WHERE course='" + selectedCourse + "';";

            string resourceName = "Chair";

            //Declares a variable and assigns a value to it
            string queryNumberOfChairs = "SELECT resourceID FROM Resources WHERE resourceName='" + resourceName + "';";

            identifier = "A";
            try
            {
                /* calls methods fromm the class mainWindowForm to connect and disconect from the data base abd class a local
                 * method (getNumberOfRecord, which sends the parameters sql statement and the identifier)
                */
                mainWindowForm.connectToDataBase();
                getNumberOfRecords(queryNumberOfStudents, identifier);
                mainWindowForm.disconnectFromDataBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                /* calls methods fromm the class mainWindowForm to connect and disconect from the data base abd class a local
                 * method (getNumberOfRecord, which sends the parameters sql statement and the identifier)
                */
                identifier = "B";
                mainWindowForm.connectToDataBase();
                getNumberOfRecords(queryNumberOfChairs, identifier);
                mainWindowForm.disconnectFromDataBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Adds the lecture if the chairs are enough for the students
            if (numberOfChairs >= numberOfStudents)
            {
                //Declares a Variable
                string queryAddLecture;

                //Sql query to insert the data into the DB
                queryAddLecture = "INSERT INTO Lectures (lectureID,lecture,numberOfStudents,course,room) VALUES ('" + textBoxLectureId.Text +
                "','" + textBoxLectureName.Text + "','" + textBoxNumberOfStudents.Text + "','" + comboBoxCourse.Text + "','" + comboBoxRoom.Text + "')";
                try
                {
                    //Calls the method addRecord from the class mainWindowForm
                    mainWindowForm.addRecord(queryAddLecture);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //Displays a message for the user if the chair are not enought
            else
                MessageBox.Show("The number of the students on the course is greater than the number of chairs in the room, " +
            "please add more chairs to the room through the resource form.");
        }                                                                                       //End of event AddLecture
    }                                                                                           //End of class
}                                                                                               //End of programme
