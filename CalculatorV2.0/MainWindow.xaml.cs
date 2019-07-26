using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorV2._0
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        bool press = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_click(object sender, RoutedEventArgs e)
        {
            if (press == true)
            {
                preorder_print.Text = "";
                postorder_print.Text = "";
                ten_print.Text = "";
                bin_print.Text = "";
            }
            Button b = (Button)sender;
            formula_print.Text += b.Content;
        }

        private void Zero_click(object sender, RoutedEventArgs e)
        {
            //前有數字能輸入多0
            if (formula_print.Text.Length >= 1)
            {
                Button b = (Button)sender;
                formula_print.Text += b.Content;
            }
        }

        private void Operation_click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            formula_print.Text += " " + b.Content + " ";
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {
            formula_print.Text = formula_print.Text.Substring(0, formula_print.Text.Length - 1);

            preorder_print.Text = "";
            postorder_print.Text = "";
            ten_print.Text = "";
            bin_print.Text = "";
        }

        private void DeleteAll_click(object sender, RoutedEventArgs e)
        {
            formula_print.Text = "";
            preorder_print.Text = "";
            postorder_print.Text = "";
            ten_print.Text = "";
            bin_print.Text = "";
        }

        private void Enter_click(object sender, RoutedEventArgs e)
        {
            press = true;

            //算式拆解
            string[] words = formula_print.Text.Split(' ');
            //放+-*/判斷優先權
            Stack<string> check = new Stack<string>();

            //前序
            int len = words.Length - 1;

            while (len >= 0)
            {
                if (words[len] != "+" && words[len] != "-" && words[len] != "*" && words[len] != "/")
                {
                    preorder_print.Text = " " + words[len] + preorder_print.Text;
                }
                else
                {
                    if (check.Count != 0)
                    {
                        if (words[len] == "*" || words[len] == "/")
                        {
                            check.Push(words[len]);
                        }

                        if (words[len] == "+" || words[len] == "-")
                        {
                            if (check.Peek() == "*" | check.Peek() == "/")
                            {
                                while (check.Count > 0)
                                {
                                    preorder_print.Text = " " + check.Peek() + preorder_print.Text;
                                    check.Pop();
                                }

                                check.Push(words[len]);
                            }
                            else
                            {
                                check.Push(words[len]);
                            }
                        }
                    }
                    else
                    {
                        check.Push(words[len]);
                    }
                }
                len--;
            }
            while (check.Count > 0)
            {
                preorder_print.Text = " " + check.Peek() + preorder_print.Text;
                check.Pop();
            }

            //後序
            len = 0;

            while (len <= words.Length - 1)
            {
                if (words[len] != "+" && words[len] != "-" && words[len] != "*" && words[len] != "/")
                {
                    postorder_print.Text += words[len] + " ";
                }
                else
                {
                    if (check.Count != 0)
                    {
                        if (words[len] == "*" || words[len] == "/")
                        {
                            if (check.Peek() == "*" | check.Peek() == "/")
                            {
                                postorder_print.Text += check.Peek() + " ";
                                check.Pop();
                                check.Push(words[len]);
                            }
                            else
                            {
                                check.Push(words[len]);
                            }
                        }

                        if (words[len] == "+" || words[len] == "-")
                        {

                            while (check.Count > 0)
                            {
                                postorder_print.Text += check.Peek() + " ";
                                check.Pop();
                            }
                            check.Push(words[len]);
                        }
                    }
                    else
                    {
                        check.Push(words[len]);
                    }
                }
                len++;
            }
            while (check.Count > 0)
            {
                postorder_print.Text += check.Peek() + " ";
                check.Pop();
            }

            //十進位
            DataTable dt = new DataTable();
            string ten_result = dt.Compute(formula_print.Text, "false").ToString();

            ten_print.Text = ten_result;

            // 二進位
            bin_print.Text = Convert.ToString(int.Parse(ten_print.Text), 2);
        }
    }
}
