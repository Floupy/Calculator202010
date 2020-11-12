using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator202010
{
    public partial class Form1 : Form
    {
        private string operation = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void NumericButton_Click(object sender, EventArgs e)
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

        private void buttonSign_Click(object sender, EventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(Display.Text);
                number *= -1;
                Display.Text = Convert.ToString(number);
            }
            catch { }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!Display.Text.Contains("+"))
            {
                operation = "+";
                Display.Text += "+";
            }
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            double result;

            try
            {
                string[] numberTexts = Display.Text.Split('+');
                result = Convert.ToDouble(numberTexts[0]) +
                         Convert.ToDouble(numberTexts[1]);
                Display.Text = Convert.ToString(result);
            }
            catch { }
        }
    }
}
