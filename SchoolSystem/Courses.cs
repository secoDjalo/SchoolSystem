using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Title: School System
   Date: 15-November-2017
   Author: S185432
*/

namespace SchoolSystem                                                                      //Name of program
{                                                                                           //Start of program
    public partial class Courses : Form                                                     //Name of class
    {                                                                                       //Start of Class
        //Creates an Instance of the class main Window
        MainWindow mainWindowForm = new MainWindow();

        //Declares a variable
        int rowIndex = 0;

        //Creates a variable
        string queryViewCourse = "SELECT * FROM Courses";

        //Creates a variable
        string courseDbTable = "Courses";

        //Creates a variable
        string courseDataTablePk = "courses_Pk";

        //The below method initialises the objects/componets of the class
        public Courses()
        {
            InitializeComponent();
        }

        //This event allows the user to go back to the main window
        private void buttonBackToMainWindow_Click(object sender, EventArgs e)
        {                                                                                       //Start of event
            //Closes this Form
            this.Close();

            //Shows the Main Window Form
            mainWindowForm.Show();

        }                                                                                       //End of event

        //this event hides some controls when the class is loaded
        private void Courses_Load(object sender, EventArgs e)
        {                                                                                       //Start of event
            //Hides controls/buttons
            buttonDelete.Hide();
            buttonSearch.Hide();
            buttonUpdate.Hide();
            buttonFirst.Hide();
            buttonLast.Hide();
            buttonNext.Hide();
            buttonPrevious.Hide();
        }                                                                                      //End of event

        //The below method is used to show the data of the courses
        public void showDataCourses()
        {                                                                                      //Start of method
            //Exception handler
            try
            {
                //populates the data to the objects
                textBoxCourseId.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][0].ToString();
                textBoxCourseName.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][1].ToString();
                textBoxDepartment.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][2].ToString();
                textBoxDescription.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][3].ToString();
                textBoxFees.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][4].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of xception handling
        }                                                                                     //End of method

        /*
         * the following event allows the user to view the courses, by pulling this imformatin from the DB and show it by
         * calling the showDataCourses method
         */

        private void buttonViewCourses_Click(object sender, EventArgs e)
        {                                                                                    //Start of event

            //Handles exceptions errors
            try
            {
                //Call methods of another Class
                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewCourse, courseDbTable, courseDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                //Calls the method 
                showDataCourses();
            }
            catch (Exception ex)
            {
                //Shows the exception message
                MessageBox.Show(ex.Message);
            } //End of exception handling
            
            
            //Shows Controls
            buttonDelete.Show();
            buttonSearch.Show();
            buttonUpdate.Show();
            buttonFirst.Show();
            buttonLast.Show();
            buttonNext.Show();
            buttonPrevious.Show();
        }                                                                                       //End of event

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
        {                                                                                          //Start of event
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    rowIndex = 0;
                    showDataCourses();
                    MessageBox.Show("First Record");
                }
                else
                    MessageBox.Show("No records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been Loaded", ex.Message);
            }
        }                                                                                         //End of event

        private void buttonPrevious_Click(object sender, EventArgs e)
        {                                                                                         //Start of event
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    if (rowIndex > 0)
                    {
                        rowIndex--;
                        showDataCourses();
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
        }                                                                                         //End of event

        private void buttonNext_Click(object sender, EventArgs e)
        {                                                                                         //Start of event
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    if (rowIndex < mainWindowForm.myDataSet.Tables[0].Rows.Count - 1)
                    {
                        rowIndex++;
                        showDataCourses();
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
        }                                                                                          //End of event

        private void buttonLast_Click(object sender, EventArgs e)
        {                                                                                          //Start of event
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    rowIndex = mainWindowForm.myDataSet.Tables[0].Rows.Count - 1;
                    showDataCourses();
                    MessageBox.Show("Last Record");
                }
                else
                    MessageBox.Show("No records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been loaded", ex.Message);
            }
        }                                                                                        //End of event

        //This event clears all the fields
        private void buttonClearFields_Click(object sender, EventArgs e)
        {                                                                                        //Start of event
            //Ckears fields
            textBoxCourseId.Clear();
            textBoxCourseName.Clear();
            textBoxDepartment.Clear();
            textBoxDescription.Clear();
            textBoxFees.Clear();
        }                                                                                        //End of events

        /*
         * the following event allows the user to search for an specific record in the database
         */

        private void buttonSearch_Click(object sender, EventArgs e)
        {                                                                                       //Start of event
            //Exception handler
            try
            {
                //creates an interaction box and for the user to insert the room ID and saves the number in the variable n
                int n = Convert.ToInt32(Interaction.InputBox("Please enter the course ID: ", "Search", "0", 100, 100));

                //Finds the record in the dataset and shows it
                DataRow myDataRow;
                myDataRow = mainWindowForm.myDataSet.Tables[0].Rows.Find(n);
                if (myDataRow != null)
                {
                    rowIndex = mainWindowForm.myDataSet.Tables[0].Rows.IndexOf(myDataRow);

                    textBoxCourseId.Text = myDataRow[0].ToString();
                    textBoxCourseName.Text = myDataRow[1].ToString();
                    textBoxDepartment.Text = myDataRow[2].ToString();
                    textBoxDescription.Text = myDataRow[3].ToString();
                    textBoxFees.Text = myDataRow[4].ToString();
                }
                //Displays a message in case the record is not found
                else
                    MessageBox.Show("Record Not Found");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a valid ID number \n" + "Error Message: " + ex.Message);
            }//End of exception handling
        }                                                                                          //End of event

        /*
         * the following event allows the user to delete a record (course) using methods of the class mainWindowForm
         */

        private void buttonDelete_Click(object sender, EventArgs e)
        {                                                                                         //Start of event
            //declares a variable and assigns the delete sql query to it
            string sqlDeleteCourse = "DELETE from Courses WHERE resourceID=" + textBoxCourseId.Text;

            //Exception handler
            try
            {
                //Calls methods of the class mainWindowForm
                mainWindowForm.deleteRecord(sqlDeleteCourse);

                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewCourse, courseDbTable, courseDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                showDataCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handling
        }                                                                                        //End of event

        /*
         * the following event allows the user to update the courses using the method updateRecords of the class
         * (mainWindowForm), and further shows the courses once update is complete.
         */

        private void buttonUpdate_Click(object sender, EventArgs e)
        {                                                                                       //Start of event
            
            //Declares a variable and assign the sql query to it.
            string sqlUpdateCourse = "UPDATE Courses SET courseName='" + textBoxCourseName.Text + "', department='" + textBoxDepartment.Text + "', description='" + textBoxDescription.Text + "', fees='" + textBoxFees.Text + "' WHERE courseID=" + textBoxCourseId.Text;

            //Exception handler
            try
            {
                //Calls methods of the class mainWondowForm
                mainWindowForm.updateRecord(sqlUpdateCourse);

                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewCourse, courseDbTable, courseDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                showDataCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handling
        }                                                                                       //End of event

        /*
         * the below event allows the user to add courses using methods of the class (mainWindow)
         */

        private void buttonAddCourse_Click(object sender, EventArgs e)
        {                                                                                       //Start of event
            //Declares a Variable
            string queryAddCourse;

            //Sql query to insert the data into the DB
            queryAddCourse = "INSERT INTO Courses (courseID,courseName,department,description,fees) VALUES ('" + textBoxCourseId.Text +
            "','" + textBoxCourseName.Text + "','" + textBoxDepartment.Text + "','" + textBoxDescription.Text + "','" + textBoxFees.Text + "')";
            
            //Exception handler
            try
            {
                //Calls method of the class mainWindowForm
                mainWindowForm.addRecord(queryAddCourse);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handling
        }                                                                                       //End of event
    }                                                                                           //End of class
}                                                                                               //End of programme
