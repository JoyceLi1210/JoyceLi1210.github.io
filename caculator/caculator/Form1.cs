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
            if(result.Text == "0" or operation_pressed){
            }
        }

        private void Zero_Click(object sender, EventArgs e)
        {

        }

        private void Dot_Click(object sender, EventArgs e)
        {

        }

        private void Operation_Click(object sender, EventArgs e)
        {

        }

        private void Clear_click(object sender, EventArgs e)
        {

        }

        private void Enter_Click(object sender, EventArgs e)
        {
   
            switch (operaion)
            {
                case '+':
                    result.Text = "" + (op1 + op2);
                    break;
                case '-':
                    result.Text = "" + (op1 - op2);
                    break;
                case '*':
                    result.Text = "" + (op1 * op2);
                    break;
                case '/':
                    result.Text = "" + (op1 / op2);
                    break;

            }
        }
    }
}
