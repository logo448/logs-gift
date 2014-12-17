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

        private Tuple<string, string> check_name(string name)
        {
            switch (name)
            {
                case "jeff":
                    return Tuple.Create("Snow Papa", "Jeffamund");
                case "susie":
                    return Tuple.Create("Snow Angel", "Momamund");
                case "maddie":
                    return Tuple.Create("Snow Monster", "Madamund");
            }
            return null;
        }


    }
}
