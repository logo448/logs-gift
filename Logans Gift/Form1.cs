﻿using System;
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
        #region global set up
        // create a global speech synthesizer object
        static SpeechSynthesizer _synth = new SpeechSynthesizer();

        // create a global variable that holds the name of the current user
        static string user_name;
        #endregion

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
            #region get user name
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
            #endregion

            // create a tuple that holds the user's two nick names
            Tuple<string, string> user_nick_names = get_nick_name(user_name);

            // set the text on the how is ___ today with ____ blank being the current users mund name
            radioButton8.Text = string.Format("How is {0} today?", user_nick_names.Item2);

            #region picturebox
            // initialize a variable to hold the img for the picturebox
            Image img = null;

            // check witch user
            switch (user_name)
            {
                case "jeff":
                    // set the img to me in my flapper hat
                    img = Properties.Resources.me_flapper;
                    break;
                case "susie":
                    // set the img to me in my santa hat
                    img = Properties.Resources.me_santa;
                    break;
                case "maddie":
                    // set the image to me in maddies bear hat
                    img = Properties.Resources.me_bear;
                    break;
            }

            // rotate the picture
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // set the picture box image as img
            pictureBox1.Image = img;

            // set the picturebox size mode to zoom
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            #endregion

            #region greeting
            // display the greeting in label 2
            label2.Text = string.Format("Hi, {0}. It's Snow Buddy!", user_nick_names.Item1);

            // update the form so the message get's printed
            this.Update();

            #region get greeting sound clip
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
            #endregion
            // plays an audio clip
            SoundPlayer player = new SoundPlayer(greeting_audio);
            player.Play();

            #region show the rest of form1
            // sleep before controls become visible
            Thread.Sleep(3000);

            // make the what do youw want to label visible
            label3.Visible = true;

            // make the groupbox visible
            groupBox1.Visible = true;
            #endregion
            #endregion
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
            #region create exe's
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

            // checks to see if auction has been extracted
            if (!File.Exists(Path.Combine(Path.GetTempPath(), "auction_program.exe")))
            {
                // gets a byte array of the auction program.exe resource
                byte[] exe_bytes = Properties.Resources.Auction_Program;
                // calls a function that creates the auction_program.exe
                create_exe(exe_bytes, "auction_program.exe");
            }
            #endregion
        }

        /// <summary>
        /// function that triggers when second done button is clicked
        /// main purpose is to figure out what activity the user had selected
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
                // create and start a holly_balls thread
                Thread Holy_balls = new Thread(() => holy_balls((int)numericUpDown1.Value));
                Holy_balls.Start();
            }

            // check to see if the perf_mon radio button is checked
            if (radioButton6.Checked)
            {
                // start per_mon.exe
                System.Diagnostics.Process.Start(Path.Combine(Path.GetTempPath(), "per_mon.exe"));
            }

            // check if to see if the dad criteria radio button is checked
            if (radioButton7.Checked)
            {
                // start the form designed for 3 criteria checking
                Form2 checker = new Form2();
                checker.Show();
            }

            // check to see if the how is thy today radio button is checked
            if (radioButton8.Checked)
            {
                // call the function to play the audio clip
                how_today();
            }

            // check to see if the auction radiobutton is checked
            if (radioButton9.Checked)
            {
                // start the auction program exe
                System.Diagnostics.Process.Start(Path.Combine(Path.GetTempPath(), "auction_program.exe"));
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
                if (i <= 10)
                {
                    // increment the speech rate
                    _synth.Rate = i;
                }

                // say holly balls
                _synth.Speak("holy balls");
            }
            // close thread when done
            Thread.CurrentThread.Abort();
        }

        /// <summary>
        /// triggers when the user closes the form
        /// main purpose to say merry christmas
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

        /// <summary>
        /// function that plays an audio clip of me asking how the user is
        /// </summary>
        private void how_today()
        {
            // initialize a variable to hold the audio file
            UnmanagedMemoryStream how_today_audio = null;

            // check to see which audio clip to play
            switch (user_name)
            {
                // dad
                case "jeff":
                    // gets the resource of me asking how jeff is
                    how_today_audio = Properties.Resources.jeff_today;
                    break;

                // mom
                case "susie":
                    // gets the resource of me asking how mom is
                    how_today_audio = Properties.Resources.mom_today;
                    break;

                // maddie
                case "maddie":
                    // gets the resource of me asking how maddie is
                    how_today_audio = Properties.Resources.mad_today;
                    break;
            }
            // create a soundplayer with the file selected by the switch statement
            SoundPlayer player = new SoundPlayer(how_today_audio);
            // start the player
            player.Play();
        }
    }
}
