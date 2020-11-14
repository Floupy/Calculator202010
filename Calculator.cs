﻿using System;
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
    public partial class Calculator : Form
    {
        string operation;
        bool operationActive = false;
        bool allowPeriod = true;

        public Calculator()
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
            if (allowPeriod)
            {
                Display.Text += ".";
                allowPeriod = false;
            }           
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            string s = Display.Text;
            
            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
                if (s.EndsWith("."))
                {
                    s = s.Substring(0, s.Length - 1);
                }
            }
            else
            {
                s = "0";
            }

            Display.Text = s;
            CheckPeriod();
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(Display.Text);
            number *= -1; //number = number * -1
            Display.Text = Convert.ToString(number);
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            try
            {
                string[] numberStrings = Display.Text.Split(Convert.ToChar(operation));
                double[] numbers = new double[2];
                double result = 0;

                numbers[0] = Convert.ToDouble(numberStrings[0]);
                numbers[1] = Convert.ToDouble(numberStrings[1]);

                if (operation == "+")
                {
                    result = numbers[0] + numbers[1];
                }
                else if (operation == "-")
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

                Display.Text = Convert.ToString(result);
                operationActive = false;
            }
            catch
            {
                
            }
        }

        private void CheckPeriod()
        {
            if (Display.Text.Contains("."))
            {
                allowPeriod = false;
            }
            else
            {
                allowPeriod = true;
            }
        }


        private void buttonOperation_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            
            if (!operationActive)
            {
                operation = button.Text;
                Display.Text += operation;
                operationActive = true;
                allowPeriod = true;
            }
        }

        private void buttonMode_Click(object sender, EventArgs e)
        {
            if(buttonMode.Text == "Sim")
            {
                buttonMode.Text = "Sci";
                this.Width = 440;
                buttonBackspace.Left = 370;
                Display.Width = 350;
            }
            else
            {
                buttonMode.Text = "Sim";
                this.Width = 285;
                buttonBackspace.Left = 230;
                Display.Width = 210;
            }            
        }
    }
}
