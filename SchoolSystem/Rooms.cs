using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
{                                                                                               //Start of Application
    public partial class Rooms : Form                                                           // Name of class
    {                                                                                           //start of class
        //creates an instance of the class MainWindow
        MainWindow mainWindowForm = new MainWindow();

        //Declares a variable
        int rowIndex = 0;

        //Creates a variable
        string queryViewRoom = "SELECT * FROM Room";

        //Creates a variable
        string roomDbTable = "Room";

        //Creates a variable
        string roomDataTablePk = "room_Pk";

        //The below method initialises the objects/componets of the class
        public Rooms()
        {
            InitializeComponent();
        }


        /*
         this following event closes this class and opens the main window class
         */
        private void buttonBackToMainWindow_Click(object sender, EventArgs e)
        {
            this.Close();
            mainWindowForm.Show();
        }

        //The below method is used to show the data of the rooms
        void showDataRoom()                                                                      //Name of method
        {                                                                                        //Start of methos
            //Exception handler
            try
            {
                //populates the data to the objects
                textBoxRoomId.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][0].ToString();
                textBoxDesignation.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][1].ToString();
                textBoxRoomType.Text = mainWindowForm.myDataSet.Tables[0].Rows[rowIndex][2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of Exception Handler
        }                                                                                       //End of method

        /*
         * the following event allows the user to view the rooms, by pulling this imformatin from the DB and show it by
         * calling the showDataRoom method
         */

        private void buttonViewRooms_Click(object sender, EventArgs e)
        {                                                                                       //Start of event
            //Handles exceptions errors
            try
            {
                //Call methods of another Class
                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewRoom, roomDbTable, roomDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                //Calls the method 
                showDataRoom();
            }
            catch (Exception ex)
            {
                //Shows the exception message
                MessageBox.Show(ex.Message);
            } //End of Exception handler


            //Shows the buttons
            buttonDelete.Show();
            buttonUpdate.Show();
            buttonSearch.Show();
            buttonFirst.Show();
            buttonPrevious.Show();
            buttonNext.Show();
            buttonLast.Show();
        }                                                                                         //End of event

        /*
         * the below event allows the user to add rooms using methods of the class (mainWindow)
         */

        private void buttonAddRoom_Click(object sender, EventArgs e)
        {                                                                                         //Start of event
            //Declares a Variable
            string queryAddRoom;

            //Sql query to insert the data into the DB
            queryAddRoom = "INSERT INTO Room (roomID,designation,type) VALUES ('" + textBoxRoomId.Text +
            "','" + textBoxDesignation.Text + "','" + textBoxRoomType.Text + "')";
            
            //exception handler
            try
            {
                //calls method of another class
                mainWindowForm.addRecord(queryAddRoom);
            }
            catch   (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of Exception handler
        }                                                                                       //End of event

        /*
         * the following event allows the user to update the rooms using the method updateRecords of the class
         * (mainWindowForm), and further shows the rooms once update is complete.
         */

        private void buttonUpdate_Click(object sender, EventArgs e)
        {                                                                                       //Start of event
            //Declares a variable and assigns an sql query to it
            string sqlUpdateRoom = "UPDATE Room SET designation='" + textBoxDesignation.Text + "', type='" + textBoxRoomType.Text + "' WHERE roomID=" + textBoxRoomId.Text;

            //Exception handler
            try
            {
                //Calls methods
                mainWindowForm.updateRecord(sqlUpdateRoom);

                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewRoom, roomDbTable, roomDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                showDataRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of exception handler
        }                                                                                       //End of event

        /*
         * the following event allows the user to delete a record (room) using methods of the class mainWindowForm
         */
        private void buttonDelete_Click(object sender, EventArgs e)
        {                                                                                       //Start of event
            //Declares a variable and assigns a value to it
            string sqlDeleteRoom = "DELETE from Room WHERE roomID=" + textBoxRoomId.Text;

            //Exception handler
            try
            {
                //calls method of the class mainWindowForm
                mainWindowForm.deleteRecord(sqlDeleteRoom);

                mainWindowForm.connectToDataBase();
                mainWindowForm.loadData(queryViewRoom, roomDbTable, roomDataTablePk);
                mainWindowForm.disconnectFromDataBase();

                showDataRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } //End of Exception handler
        }                                                                                       //End of event

        /*
         * the following event allows the user to search for an specific record in the database
         */

        private void buttonSearch_Click(object sender, EventArgs e)
        {                                                                                       //Start of event
            //Exception handler
            try
            {
                //creates an interaction box and for the user to insert the room ID and saves the number in the variable n
                int n = Convert.ToInt32(Interaction.InputBox("Enter room ID :", "Search", "0", 100, 100));
                
                //Finds the record in the dataset and shows it
                DataRow myDataRow;
                myDataRow = mainWindowForm.myDataSet.Tables[0].Rows.Find(n);
                if (myDataRow != null)
                {
                    rowIndex = mainWindowForm.myDataSet.Tables[0].Rows.IndexOf(myDataRow);

                    textBoxRoomId.Text = myDataRow[0].ToString();
                    textBoxDesignation.Text = myDataRow[1].ToString();
                    textBoxRoomType.Text = myDataRow[2].ToString();
                }
                //Displays a message in case the record is not found
                else
                    MessageBox.Show("Record Not Found");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a valid ID number \n" + "Error Message: " + ex.Message);
            } //End of exception
        }                                                                                        //End of event

        //Envent clears fields
        private void buttonClearFields_Click(object sender, EventArgs e)
        {
            textBoxRoomId.Clear();
            textBoxDesignation.Clear();
            textBoxRoomType.Clear();
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
        {                                                                                      //Start of event                                                                   
            if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
            {
                rowIndex = 0;
                showDataRoom();
                MessageBox.Show("First Record");
            }
            else
                MessageBox.Show("No records");
        }                                                                                      //End of event

        private void buttonPrevious_Click(object sender, EventArgs e)
        {                                                                                      //Start of event
            if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
            {
                if (rowIndex > 0)
                {
                    rowIndex--;
                    showDataRoom();
                }
                else
                    MessageBox.Show("First Record");
            }
            else
                MessageBox.Show("no records");
        }                                                                                     //End of Event

        private void buttonNext_Click(object sender, EventArgs e)
        {                                                                                     //Start of event
            if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
            {
                if (rowIndex < mainWindowForm.myDataSet.Tables[0].Rows.Count - 1)
                {
                    rowIndex++;
                    showDataRoom();
                }
                else
                    MessageBox.Show("Last Record");
            }
            else
                MessageBox.Show("No records");
        }                                                                                    //End of event

        private void buttonLast_Click(object sender, EventArgs e)
        {                                                                                    //Start of event
            if (mainWindowForm.myDataSet.Tables[0].Rows.Count > 0)
            {
                rowIndex = mainWindowForm.myDataSet.Tables[0].Rows.Count - 1;
                showDataRoom();
                MessageBox.Show("Last Record");
            }
            else
                MessageBox.Show("No records");
        }                                                                                    //End of event
         /*
          * the below event hides some controls of the class
          */
        private void Rooms_Load(object sender, EventArgs e)
        {                                                                                   //Start of event                                                                
            //Hides controls
            buttonDelete.Hide();
            buttonUpdate.Hide();
            buttonSearch.Hide();

            buttonFirst.Hide();
            buttonPrevious.Hide();
            buttonNext.Hide();
            buttonLast.Hide();
        }                                                                                   //End of event
    }                                                                                       //End of class
}                                                                                           //End of application
