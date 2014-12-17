using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logans_Gift
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// function that happens every time a keys is entered into the text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // checks to see if the return key was hit
            if (e.KeyChar == '\r')
            {
                string user_name = get_text();
            }
        }

        /// <summary>
        /// function that happens every time the done button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string user_name = get_text();
        }

        private string get_text()
        {
            // sets the value of the textbox text to a variable
            string textbox1_text = textBox1.Text;

            // make all leters lowercase
            textbox1_text = textbox1_text.ToLower();

            // debug
            label2.Text = textbox1_text;

            // return the text from the textbox
            return textbox1_text;
        }
    }
}
