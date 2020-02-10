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

namespace SchoolSystem                                                                             //Name of application
{                                                                                                  //Start of application
    public partial class Payments : Form                                                           //Name of class
    {
        //The below method initialises the objects/componets of the class
        public Payments()
        {
            InitializeComponent();
        }

        //Creates an instance of the class MainWindow
        MainWindow mainWindowForm = new MainWindow();

        //Declares a variable
        int rowIndex = 0;

        //Event allows the user to go back to the main class/window
        private void buttonBackToMain_Click(object sender, EventArgs e)
        {                                                                                         //Start of event
            this.Close();
            mainWindowForm.Show();
        }                                                                                         //End of event

        /*
         * the below event handles the searching of an speciific record in the database
         * */

        private void Payments_Load(object sender, EventArgs e)
        {                                                                                        //Start of event

            //Creates a variable
            string queryStudent = "SELECT * FROM Students";

            //Creates a variable
            string studentDbTable = "Students";

            //Creates a variable
            string studentDataTablePk = "student_Pk";

            //Exception handler
            try
            {
                //Calls methods
                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryStudent, studentDbTable, studentDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                findStudent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handler

            //Hides Controls
            buttonFirst.Hide();
            buttonPrevious.Hide();
            buttonNext.Hide();
            buttonLast.Hide();

        }                                                                                        //End of event

        /*
       * the following method allows the user to find a specific student, and show his/her name and course.
       */

        void findStudent ()                                                                      //Method name
        {                                                                                        //Start of method
            
            //Exception handler
            try
            {
                //Creates an interaction box and assigns its value to the variable n
                int n = Convert.ToInt32(Interaction.InputBox("Please enter the student ID:", "Search", "0", 100, 100));

                //Finds the value of n in the dataset
                DataRow myDataRow;
                myDataRow = mainWindowForm.myDataSet.Tables[0].Rows.Find(n);
                if (myDataRow != null)
                {
                    rowIndex = mainWindowForm.myDataSet.Tables[0].Rows.IndexOf(myDataRow);

                    textBoxName.Text = myDataRow[1].ToString();
                    textBoxCourse.Text = myDataRow[4].ToString();
                }
                else
                    MessageBox.Show("Record Not Found");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a valid student number: \n"+ "Error Message: " + ex.Message);
            } //End of event handler
        }                                                                                       //End of method


        //The below method is used to show the Payments
        public void showDataPayment()
        {                                                                                      //Start of method
            //Exception handler
            try
            {
                //populates the data to the objects
                textBoxId.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][0].ToString();
                textBoxAmountPaid.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][1].ToString();
                textBoxName.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][2].ToString();
                textBoxCourse.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][3].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of xception handling
        }                                                                                    //End of Method

        /*
       * the following event allows the user to view payments, by pulling this imformatin from the DB and showing it by
       * calling the showPayment method
       */
        private void buttonViewPayments_Click(object sender, EventArgs e)
        {                                                                                          //Start of event
            //Declares variables and assign values to it
            string queryViewPayment = "SELECT * FROM Payment";
            string paymentDbTable = "Payment";
            string paymentDataTablePk  = "payment_Pk";

            //Handles exceptions errors
            try
            {
                //Call methods of another Class
                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewPayment, paymentDbTable, paymentDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                //Calls the method 
                showDataPayment();
            }
            catch (Exception ex)
            {
                //Shows the exception message
                MessageBox.Show(ex.Message);
            } //End of exception handling
            

            //Hides control
            buttonAddPayment.Hide();

            //Shows controls
            buttonFirst.Show();
            buttonPrevious.Show();
            buttonNext.Show();
            buttonLast.Show();
        }                                                                                       //End of event

        //This event clears all the fields and shows some controls
        private void buttonClearFields_Click(object sender, EventArgs e)
        {                                                                                        //Start of event
            //Clears fields
            textBoxName.Clear();
            textBoxCourse.Clear();
            textBoxAmountPaid.Clear();
            textBoxId.Clear();
            //shows controls
            buttonAddPayment.Show();
        }

        private void buttonAddPayment_Click(object sender, EventArgs e)
        {                                                                                        //Start of event
            //Declares a Variable
            string queryAddPayment;

            //Sql query to insert the data into the DB
            queryAddPayment = "INSERT INTO Payment (paymentID,amount,student,course) VALUES ('" + textBoxId.Text +
            "','" + textBoxAmountPaid.Text + "','" + textBoxName.Text + "','" + textBoxCourse.Text + "')";

            //Exception handler
            try
            {
                //Calls method of the class mainWindowForm
                mainWindowForm.addRecord(queryAddPayment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handling
        }                                                                                        //End of event

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
        {                                                                                        //Start of event
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    rowIndex = 0;
                    showDataPayment();
                    MessageBox.Show("First Record");
                }
                else
                    MessageBox.Show("No records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been Loaded", ex.Message);
            }

        }                                                                                        //End of event

        private void buttonPrevious_Click(object sender, EventArgs e)
        {                                                                                       //Start of event
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    if (rowIndex > 0)
                    {
                        rowIndex--;
                        showDataPayment();
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
        {                                                                                       //Start of event
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    if (rowIndex < mainWindowForm.myDataSet.Tables[0].Rows.Count - 1)
                    {
                        rowIndex++;
                        showDataPayment();
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
        }                                                                                        //End of event

        private void buttonLast_Click(object sender, EventArgs e)
        {                                                                                        //Start of event
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    rowIndex = mainWindowForm.myDataSet.Tables[0].Rows.Count - 1;
                    showDataPayment();
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




    }                                                                                            //End of Class
}                                                                                                //End of application
