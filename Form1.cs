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
        private bool operationActive = false;

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

        private void ButtonOperation_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (!operationActive)
            {
                operation = button.Text;
                Display.Text += button.Text;
                operationActive = true;
            }
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            double result;

            try
            {
                string[] numberTexts = Display.Text.Split(Convert.ToChar(operation));
                double[] numbers = new double[2];
                
                numbers[0] = Convert.ToDouble(numberTexts[0]);
                numbers[1] = Convert.ToDouble(numberTexts[1]);
                
                if(operation == "+")
                {
                    result = numbers[0] + numbers[1];
                }
                else if(operation == "-")
                {
                    result = numbers[0] - numbers[1];
                }
                else if (operation == "*")
                {
                    result = numbers[0] * numbers[1];
                }
                else if (operation == "/")
                {
                    result = numbers[0] / numbers[1];
                }
                else
                {
                    result = 0;
                }

                Display.Text = Convert.ToString(result);
                operationActive = false;
            }
            catch { }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
            operation = string.Empty;
            operationActive = false;
        }
    }
}
