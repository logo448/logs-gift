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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// function that triggers when the check button is pressed
        /// The function purpose is to auto check and uncheck checkboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // check if both checkboxes in the busch league box are checkded
            if (checkedListBox1.GetItemChecked(0) && checkedListBox1.GetItemChecked(1))
            {
                // check the not busch league box
                checkBox1.Checked = true;
            }
            // makes sure the busch league box unchecks itself if it isn't true
            else
            {
                checkBox1.Checked = false;
            }

            // checks to see if the 2nd or 3rd box is checked and the 1st box
            if ((checkedListBox2.GetItemChecked(1) || checkedListBox2.GetItemChecked(2))
                && checkedListBox2.GetItemChecked(0))
            {
                // checks the value checkbox
                checkBox2.Checked = true;
            }
            // makes sure the value box unchecks itself if it isn't true
            else
            {
                checkBox2.Checked = false;
            }

            // checks to see that the first two checkboxes are checked but the last three aren't 
            if (checkedListBox3.GetItemChecked(0) && checkedListBox3.GetItemChecked(1) 
                && !checkedListBox3.GetItemChecked(2) && !checkedListBox3.GetItemChecked(3)
                && !checkedListBox3.GetItemChecked(4))
            {
                // checks the simplicity checkbox
                checkBox3.Checked = true;
            }
            // makes sure the simplicity box unchecks itself if it isn't true
            else
            {
                checkBox3.Checked = false;
            }

            // checks to see if all three major checkboxes are checked
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                // checks the good to go checkbox
                checkBox4.Checked = true;
            }
            // makes sure the good to go box unchecks itself if it isn't true
            else
            {
                checkBox4.Checked = false;
            }
        }
    }
}
