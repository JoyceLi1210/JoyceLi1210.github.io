using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using System.Windows.Forms;
using System.ComponentModel;

using System.Drawing;



namespace CalculatorV2._0
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
          
        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection db = new MySqlConnection();
                db.ConnectionString = "Data Source = localhost ; User Id = root ; Password= ; database = c_shop";
                db.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = db;
                cmd.CommandText = "DELETE FROM hw2 Where id='" + text1.Text.Replace("'", "'") + "'";
                cmd.ExecuteNonQuery();
                db.Close();
                db_show(sender, e);

            }
            catch (Exception ex) {
                System.Windows.MessageBox.Show(ex.Message);
            }           
           
        }

        private void db_show(object sender, RoutedEventArgs e)
        {
            string myConn = "Data Source = localhost ; User Id = root ; Password= ; database = c_shop";
            MySqlConnection con = new MySqlConnection(myConn);

            MySqlCommand cmd = new MySqlCommand("SELECT id,preorder,postorder,ten,bin FROM hw2", con);


            MySqlDataAdapter SelectAdapter = new MySqlDataAdapter();
            SelectAdapter.SelectCommand = cmd;  //定義資料介面卡的操作指令


            con.Open();


            SelectAdapter.SelectCommand.ExecuteNonQuery();
            DataTable MyDataSet = new DataTable("hw2");
            SelectAdapter.Fill(MyDataSet);

            datagrid1.ItemsSource = MyDataSet.DefaultView;
            SelectAdapter.Update(MyDataSet);
            con.Close();
        }
    }
}
