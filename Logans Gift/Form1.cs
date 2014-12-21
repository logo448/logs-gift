using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Speech.Synthesis;
using System.Media;
using System.IO;
using System.Threading;

namespace Logans_Gift
{
    public partial class Form1 : Form
    {
        // create a global speech synthesizer object
        static SpeechSynthesizer _synth = new SpeechSynthesizer();


        static string user_name;

        static Tuple<string, string> user_nick_names;

        public Form1()
        {
            InitializeComponent();
        }

        

        /// <summary>
        /// function that triggers when the first done button is clicked
        /// The function gets which radio button is checked and then greets them with their snow name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // check to see if the jeff radio button is checkded
            if (radioButton1.Checked == true)
            {
                // set the user name to jeff
                user_name = "jeff";
            }

            // check to see if the susie radiobutton is checkded
            if (radioButton2.Checked == true)
            {
                // sets the user name to susie
                user_name = "susie";
            }

            // checks to see if the maddi radio button is checked
            if (radioButton3.Checked == true)
            {
                // sets the user name to maddie
                user_name = "maddie";
            }

            // create a tuple that holds the user's two nick names
            user_nick_names = get_nick_name(user_name);

            // display the greeting in label 2
            label2.Text = string.Format("Hi, {0}. It's Snow Buddy!", user_nick_names.Item1);

            // update the form so the message get's printed
            this.Update();

            // initialize a variable that will hold the path to the audio greeting resource
            UnmanagedMemoryStream greeting_audio = null;

            // checks who is using the program and which greeting to play
            switch (user_name)
            {
                case "jeff":
                    greeting_audio = Properties.Resources.snow_papa;
                    break;
                case "susie":
                    greeting_audio = Properties.Resources.snow_angel;
                    break;
                case "maddie":
                    greeting_audio = Properties.Resources.snow_monster;
                    break;
            }
            // plays an audio clip
            SoundPlayer player = new SoundPlayer(greeting_audio);
            player.Play();    

            // sleep before controls become visible
            Thread.Sleep(3000);

            // make the what do youw want to label visible
            label3.Visible = true;

            // make the groupbox visible
            groupBox1.Visible = true;
        }

        /// <summary>
        /// function to get the nicknames of either dad, mom, or mad
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Tuple<string, string> get_nick_name(string name)
        {
            // check each name
            switch (name)
            {
                case "jeff":
                    // return a tuple with two nick names
                    return Tuple.Create("Snow Papa", "Jeffamund");

                case "susie":
                    // return a tuple with two nick names
                    return Tuple.Create("Snow Angel", "Momamund");

                case "maddie":
                    // return a tuple with two nick names
                    return Tuple.Create("Snow Monster", "Madamund");
            }
            // Fail safe
            return null;
        }

        /// <summary>
        /// function that accesses a .exe file from resources and then extracts the file into the users temp directory.
        /// </summary>
        /// <param name="exe_bytes"></param>
        /// <param name="exe_name"></param>
        private void create_exe(byte[] exe_bytes, string exe_name)
        {
            // a string that is set to the directory where the .exe will be created
            string exe_to_run = Path.Combine(Path.GetTempPath(), exe_name);

            // creates the .exe from the byte array of the embedded resource .exe
            using (FileStream exe_file = new FileStream(exe_to_run, FileMode.CreateNew))
                exe_file.Write(exe_bytes, 0, exe_bytes.Length);
        }

        /// <summary>
        /// triggers when the application loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // checks to see if the binary clock exe has been extracted
            if (!File.Exists(Path.Combine(Path.GetTempPath(), "binary_clock.exe")))
            {
                // gets a bit array of the binary clock exe resource
                byte[] exe_bytes = Properties.Resources.binaryClock;
                // calls a function that creates the binary_clock.exe
                create_exe(exe_bytes, "binary_clock.exe");
            }

            // checks to see if per_mon has been extracted
            if (!File.Exists(Path.Combine(Path.GetTempPath(), "per_mon.exe")))
            {
                // gets a bit array of the per mon exe resource
                byte[] exe_bytes = Properties.Resources.Per_Mon;
                // calls a function that creates the per_mon.exe
                create_exe(exe_bytes, "per_mon.exe");
            }
        }

        /// <summary>
        /// function that triggers when second done button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            // check to see if the binary clock radio button is checked
            if (radioButton4.Checked)
            {
                // start the binary clock .exe
                System.Diagnostics.Process.Start(Path.Combine(Path.GetTempPath(), "binary_clock.exe"));
            }

            // check to see if the holy balls radio button is checked
            if (radioButton5.Checked)
            {
                // call the holy balls function with the value from the number box as an argument
                holy_balls((int)numericUpDown1.Value);
            }

            // check to see if the perf_mon radio button is checked
            if (radioButton6.Checked)
            {
                // start per_mon.exe
                System.Diagnostics.Process.Start(Path.Combine(Path.GetTempPath(), "per_mon.exe"));
            }

            if (radioButton7.Checked)
            {
                Form2 checker = new Form2();
                checker.Show();
            }

            if (radioButton8.Checked)
            {
                how_today();
            }
        }

        /// <summary>
        /// function that says holy balls x amount of times
        /// </summary>
        /// <param name="iterations"></param>
        private void holy_balls(int iterations)
        {
            // loop x amount of times
            for (int i = 0; i < iterations; i++)
            {
                // increment the speech rate
                _synth.Rate = i;

                // say holly balls
                _synth.Speak("holy balls");
            }
        }

        /// <summary>
        /// triggers when the user closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // play my merry christmas sound clip
            SoundPlayer player = new SoundPlayer(Properties.Resources.merry_christmas);
            player.Play();

            // display a message in a model box
            MessageBox.Show("Have a merry Christmas, and a happy New Year!");           
        }

        private void how_today()
        {
            UnmanagedMemoryStream how_today_audio = null;
            switch (user_name)
            {
                case "jeff":
                    how_today_audio = Properties.Resources.jeff_today;
                    break;
                case "susie":
                    how_today_audio = Properties.Resources.mom_today;
                    break;
                case "maddie":
                    how_today_audio = Properties.Resources.mad_today;
                    break;
            }
            SoundPlayer player = new SoundPlayer(how_today_audio);
            player.Play();
        }
    }
}
