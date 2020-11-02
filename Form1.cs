using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator202010
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NumericButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
        }

        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                Display.Text += ".";
            }            
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            Display.Text = Display.Text.Remove(Display.Text.Length - 1);

            if(Display.Text.EndsWith("."))
            {
                Display.Text = Display.Text.Remove(Display.Text.Length - 1);
            }

            if (Display.Text.Length == 0)
            {
                Display.Text = "0";
            }
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(Display.Text);
            number *= -1;
            Display.Text = Convert.ToString(number);
        }
    }
}
