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

namespace Slownik_z_MDI.Views
{
    public partial class UsunSlowo : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sikma\source\repos\Slownik_z_MDI\Slownik_z_MDI\_data\norweski.mdf;Integrated Security=True");

        public UsunSlowo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            string usuwaneSlowo = TextBox1.Text;
            string kwerenda = "DELETE FROM tbl_Details WHERE norweski='" + usuwaneSlowo + "'"; //usuń wpisane w textbox słowo z bazy danych
            SqlCommand cmd = new SqlCommand(kwerenda, conn);
            cmd.ExecuteNonQuery();
            MessageBoxResult key = MessageBox.Show("Usunięto", "Prawidłowo usunięto słowo",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "æ";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "ø";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + "å";
        }
    }
}
