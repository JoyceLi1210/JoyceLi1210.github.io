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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


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
        

        private void add_click(object sender, RoutedEventArgs e)
        {
            try
            {
                String con = "Data Source = localhost ; User Id = root ; Password= ; database = c_shop";
                

                MySqlConnection db = new MySqlConnection(con);
                
                db.Open();

                //判斷重複
                String count = "SELECT * FROM hw2 WHERE preorder= "+'\"'+ preorder_print.Text+'\"';
                
                MySqlCommand cmd1 = new MySqlCommand(count, db);
                MySqlDataReader myreader1 = cmd1.ExecuteReader();
                
                //新增資料
                String query = "insert into hw2(preorder,postorder,ten,bin)values('" + preorder_print.Text + "','" + postorder_print.Text + "','" + ten_print.Text + "','" + bin_print.Text + "')";
                MySqlCommand cmd = new MySqlCommand(query, db);
    
                if (preorder_print.Text == "" || postorder_print.Text == "" || ten_print.Text == "" || bin_print.Text == "")
                {
                    MessageBox.Show("資料有誤,未完成計算!");
                }
                
                else if (myreader1.HasRows)
                {
                               
                    MessageBox.Show("資料重複");
                    db.Close();
                }
                else
                {
                    myreader1.Close();                    
                    MySqlDataReader myreader = cmd.ExecuteReader();

                    MessageBox.Show("新增成功");
                    preorder_print.Text = "";
                    postorder_print.Text = "";
                    ten_print.Text = "";
                    bin_print.Text = "";
                    myreader.Close();
                    
                }
            }
            catch(MySql.Data.MySqlClient.MySqlException ex) {
                Console.WriteLine("Error" + ex.Number + ":" + ex.Message);
            }
            
        }

        private void search_click(object sender, RoutedEventArgs e)
        {
            
            Window1 db_search = new Window1();
            db_search.Show();


        }
    }
}
