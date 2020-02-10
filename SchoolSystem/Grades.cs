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
namespace SchoolSystem                                                                         //Application name
{                                                                                              //Start of application
    public partial class Grades : Form                                                         //Class name
    {                                                                                          //Start of Class

        //Creates an instance of the class MainWindow
        MainWindow mainWindowForm = new MainWindow();

        //The below method initialises the objects/componets of the class
        public Grades()
        {                                                                                      //Start of method
            InitializeComponent();
        }                                                                                      //End of method

        //The below event takes the user back to the main window
        private void buttonBackToMain_Click(object sender, EventArgs e)
        {                                                                                     //Start of event
            //closes this form
            this.Close();

            //opens the main window class
            mainWindowForm.Show();
        }

        private void Grades_Load(object sender, EventArgs e)
        {

        }                                                                                     //End of event
    }                                                                                         //End of class
}                                                                                             //End of application
