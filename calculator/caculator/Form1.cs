using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caculator
{
    public partial class Form1 : Form
    {
        string operation = "";
        double value = 0;
        bool operation_pressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, EventArgs e)
        {
            if(result.Text == "0" || operation_pressed){
                result.Clear();
            }
            Button b = (Button)sender;
            result.Text += b.Text;
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            if (result.Text == "0")
            {
                result.Clear();
            }
            result.Text += "0";
        }

        private void Dot_Click(object sender, EventArgs e)
        {
            if (!result.Text.Contains("."))
            {
                result.Text += ".";
            }
            
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            operation_pressed = true;
            PreResult.Text = result.Text;

            if(result.Text != "")
            {
                value = Double.Parse(result.Text);
            }
        }

        private void Clear_click(object sender, EventArgs e)
        {
            result.Clear();
            result.Text = "0";
        }

        private void Clear_All_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            PreResult.Text = "";
            value = 0;
            result.Clear();
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    result.Text = (value + Double.Parse(result.Text)).ToString();
                    break;

                case "-":
                    result.Text = (value - Double.Parse(result.Text)).ToString();
                    break;

                case "*":
                    result.Text = (value * Double.Parse(result.Text)).ToString();
                    break;

                case "/":
                    result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;

                default:
                    break;

            }
            operation_pressed = false;
            PreResult.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
