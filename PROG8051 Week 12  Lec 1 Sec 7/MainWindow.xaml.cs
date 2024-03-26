using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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

namespace PROG8051_Week_12__Lec_1_Sec_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(@"Data Source=NAMIQ;Initial Catalog=newDB;Integrated Security=True;TrustServerCertificate=true");


        private void Read(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Sec7DB.dbo.Sec7Table1", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;

        }

        private void Create(object sender, RoutedEventArgs e)
        {
            string command = "INSERT INTO Sec7DB.dbo.Sec7Table1(STID, Name, LastName, Age, Gender, TuitionPaid) " +
                "VALUES(125, 'John', 'Smitrh', 28, 'male', 'false')";
            SqlCommand cmd = new SqlCommand(command, con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
            Read(sender, e);
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            string command = "UPDATE Sec7DB.dbo.Sec7Table1 SET Name = 'Ali' WHERE STID = 124";
            SqlCommand cmd = new SqlCommand(command, con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
            Read(sender, e);
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            string command = "DELETE FROM Sec7DB.dbo.Sec7Table1  WHERE STID='124'";
            SqlCommand cmd = new SqlCommand(command, con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
            Read(sender, e);
        }
    }
}
