using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

/* Title: School System
   Date: 15-November-2017
   Author: S185432
*/

namespace SchoolSystem                                                                          //Name of application
{                                                                                               //Start of application
    public partial class Resources : Form                                                       //Name of class
    {                                                                                           //Start of class
        //Creates an instance of the class MainWindow
        MainWindow mainWindowForm = new MainWindow();

        //Declares a variable
        int rowIndex = 0;

        //Creates a variable
        string queryViewResources = "SELECT * FROM Resources";

        //Creates a variable
        string resourceDbTable = "Resources";

        //Creates a variable
        string resourceDataTablePk = "resources_Pk";

        //The below method initialises the objects/componets of the class
        public Resources()                                                                      //name of method
        {                                                                                       //Start of method
            //calls method
            InitializeComponent();
        }                                                                                       //End of method

        /*
         * The below event is carried when the class is loading and it consists in retriving the rooms from the databse and
         * hide some controls of the class
         * */

        private void Resources_Load(object sender, EventArgs e)
        {                                                                                       //Start of event
            //exception handler
            try
            {
                //calls methods
                mainWindowForm.connectToDataBase();
                getRoomsFromDB();
                mainWindowForm.disconnectFromDataBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handler

            //clears the object
            comboBoxRoom.Text = "";

            //hides controls
            buttonDeleteResource.Hide();
            buttonUpdateResource.Hide();
            buttonSearchResource.Hide();

            buttonFirst.Hide();
            buttonNext.Hide();
            buttonPrevious.Hide();
            buttonLastResource.Hide();

        }                                                                                       //End of event

        //Method retrieves the rooms from the DB

        private void getRoomsFromDB ()                                                          //Name of method
        {                                                                                       //Start of method
            //Declares a variable and assigns an sql query to it
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
            } //End of Exception handler
        }                                                                                        //End of method

        //Method shows the data retrived from the database

        private void showResourceData ()                                                        //Name of method
        {                                                                                       //Start of method
            //Exception handler
            try
            {
                //populates data into appropriate objects
                textBoxResourceId.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][0].ToString();
                textBoxResourceName.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][1].ToString();
                textBoxResourcePrice.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][2].ToString();
                comboBoxRoom.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][3].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handler
        }                                                                                       //End of method

        /*
        * the below event allows the user to add resources using methods of the class (mainWindow)
        */

        private void buttonAddResource_Click(object sender, EventArgs e)
        {                                                                                       //Start of event
            //Declares a Variable
            string queryAddResource;

            //Sql query to insert the data into the DB
            queryAddResource = "INSERT INTO Resources (resourceID,resourceName,resourcePrice,room) VALUES ('" + textBoxResourceId.Text +
            "','" + textBoxResourceName.Text + "','" + textBoxResourcePrice.Text + "','" + comboBoxRoom.Text + "')";
            
            //Exception handler
            try
            {
                //Calls method
                mainWindowForm.addRecord(queryAddResource);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of /exception handling
            
        }                                                                                      //End of event

        /*
         * the belopw mwthod closes this class/window and opens the mainWindowClass
         * */

        private void buttonBackToMain_Click(object sender, EventArgs e)
        {                                                                                     //Start od event
            this.Close();
            mainWindowForm.Show();
        }                                                                                     //End of event

        /*
         * the below event handles the searching of an speciific record in the database
         * */

        private void buttonSearchResource_Click(object sender, EventArgs e)
        {                                                                                    //Start of event
            //Exception handler
            try
            {
                //Creates an interaction box and assigns it value to the variable n
                int n = Convert.ToInt32(Interaction.InputBox("Please enter the resource ID:", "Search", "0",100, 100));

                //Finds the value of n in the dataset
                DataRow myDataRow;
                myDataRow = mainWindowForm.myDataSet.Tables[0].Rows.Find(n);
                if (myDataRow != null)
                {
                    rowIndex = mainWindowForm.myDataSet.Tables[0].Rows.IndexOf(myDataRow);

                    textBoxResourceId.Text = myDataRow[0].ToString();
                    textBoxResourceName.Text = myDataRow[1].ToString();
                    textBoxResourcePrice.Text = myDataRow[2].ToString();
                    comboBoxRoom.Text = myDataRow[3].ToString();
                }
                else
                    MessageBox.Show("Record Not Found");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a valid ID number \n" + "Error Message: " + ex.Message);
            } //End of event handler
        }                                                                                     //End of event 

        /*
        * the following event allows the user to update the rosources using the method updateRecords of the class
        * (mainWindowForm), and further shows the rooms once update is complete.
        */

        private void buttonUpdateResource_Click(object sender, EventArgs e)
        {                                                                                    //Start of event
            //Declares a variable and assigns the update sql query to it
            string sqlUpdateResource = "UPDATE Resources SET resourceName='" + textBoxResourceName.Text + "', resourcePrice='" + textBoxResourcePrice.Text + "', room='" + comboBoxRoom.Text + "' WHERE resourceID=" + textBoxResourceId.Text;

            //exception handler
            try
            {
                //Calls methods
                mainWindowForm.updateRecord(sqlUpdateResource);

                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewResources, resourceDbTable, resourceDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                showResourceData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handling
        }                                                                                    //End of event

        /*
         * the following event allows the user to delete a record (resource) using methods of the class mainWindowForm
         */

        private void buttonDeleteResource_Click(object sender, EventArgs e)
        {                                                                                   //Start of event
            //Declares a variable and assigns the delete sql query to it
            string sqlDeleteResource = "DELETE from Resources WHERE resourceID=" + textBoxResourceId.Text;

            //Exception handler
            try
            {
                //Calls methods
                mainWindowForm.deleteRecord(sqlDeleteResource);

                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewResources, resourceDbTable, resourceDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                showResourceData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of methods
        }

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
        {
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    rowIndex = 0;
                    showResourceData();
                    MessageBox.Show("First Record");
                }
                else
                    MessageBox.Show("No records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been Loaded ", ex.Message);
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    if (rowIndex > 0)
                    {
                        rowIndex--;
                        showResourceData();
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
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    if (rowIndex < mainWindowForm.myDataSet.Tables[0].Rows.Count - 1)
                    {
                        rowIndex++;
                        showResourceData();
                    }
                    else
                        MessageBox.Show("Last Record");
                }
                else
                    MessageBox.Show("No records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been loaded " ,ex.Message);
            }
        }

        private void buttonLastResource_Click(object sender, EventArgs e)
        {
            try
            {
                if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
                {
                    rowIndex = mainWindowForm.myDataSet.Tables[0].Rows.Count - 1;
                    showResourceData();
                    MessageBox.Show("Last Record");
                }
                else
                    MessageBox.Show("No records");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No data has been loaded ", ex.Message);
            }
        }

        //End of dataset navegation

        //The below event clears all fields in the class
        private void buttonClearFields_Click(object sender, EventArgs e)
        {                                                                                      //Start of events
            //Clearing all the fields

            textBoxResourceId.Clear();
            textBoxResourceName.Clear();
            textBoxResourcePrice.Clear();
            comboBoxRoom.Text = "";
        }                                                                                     //End of event

        /*
        * the following event allows the user to view the resources, by pulling this imformatin from the DB and show it by
        * calling the showResourceData method
        */

        private void buttonViewResources_Click(object sender, EventArgs e)
        {                                                                                    //Start of method
            //Exception handler
            try
            {
                //Calls methods
                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewResources, resourceDbTable, resourceDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                showResourceData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handler

            //Shows controls
            buttonDeleteResource.Show();
            buttonUpdateResource.Show();
            buttonSearchResource.Show();

            buttonFirst.Show();
            buttonNext.Show();
            buttonPrevious.Show();
            buttonLastResource.Show();
        }                                                                                    //End of event
    }                                                                                        //End of class
}                                                                                            //End of program
