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

namespace Logans_Gift
{
    public partial class Form1 : Form
    {
        // create a global speech synthesizer object
        static SpeechSynthesizer _synth = new SpeechSynthesizer();

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
            // initialize a variable that holds the user's name
            string user_name = "";

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
            Tuple<string, string> user_nick_names = get_nick_name(user_name);

            // display the greeting in label 2
            label2.Text = string.Format("Hi, {0}. It's Snow Buddy!", user_nick_names.Item1);

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

        private void create_exe(byte[] exe_bytes, string exe_name)
        {
            string exe_to_run = Path.Combine(Path.GetTempPath(), exe_name);

            using (FileStream exe_file = new FileStream(exe_to_run, FileMode.CreateNew))
                exe_file.Write(exe_bytes, 0, exe_bytes.Length);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Path.Combine(Path.GetTempPath(), "binary_clock.exe")))
            {
                byte[] exe_bytes = Properties.Resources.binaryClock;
                create_exe(exe_bytes, "binary_clock.exe");
            }           
        }
    }
}
