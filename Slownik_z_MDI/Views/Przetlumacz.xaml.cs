using System;
using System.Collections.Generic;
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
using System.Security.Cryptography.X509Certificates;

namespace Slownik_z_MDI.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Przetlumacz.xaml
    /// </summary>
    public partial class Przetlumacz : UserControl
    {

        public Przetlumacz()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sikma\source\repos\Slownik_z_MDI\Slownik_z_MDI\_data\norweski.mdf;Integrated Security=True");
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sikma\source\repos\Slownik_z_MDI\Slownik_z_MDI\_data\norweski.mdf;Integrated Security=True";
            conn.Open();

            string tekstPoPolsku = TextBox1.Text;
            string kwerendaTlumaczenie;
            kwerendaTlumaczenie = "SELECT norweski FROM tbl_Details WHERE polski='"+ tekstPoPolsku + "'";
            SqlCommand cmd = new SqlCommand(kwerendaTlumaczenie, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                TextBlock1.Text="Słowo '"+TextBox1.Text+"' przetłumaczone na norweski to: '"+reader["norweski"].ToString()+"'";
            }
            reader.Close();

            conn.Close();

        }
    }
}
