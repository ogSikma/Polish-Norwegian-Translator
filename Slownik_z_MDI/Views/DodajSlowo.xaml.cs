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
    public partial class DodajSlowo : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sikma\source\repos\Slownik_z_MDI\Slownik_z_MDI\_data\norweski.mdf;Integrated Security=True");

        public DodajSlowo()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            int rodzajPisma = 0;
            if (RadioBokmal.IsChecked == true)
            {
                rodzajPisma = 0;
            }
            else if (RadioNynorsk.IsChecked==true)
            {
                rodzajPisma = 1;
            }

            try     //nie zmieniać instrukcji try-catch! bez niej działa niepoprawnie
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Details(norweski, pismo, polski) VALUES('" + TextBox1.Text + "','"+ rodzajPisma + "','" + TextBox2.Text + "')", conn); //dodanie do bazy danych wprowadzonego słowa wraz ze standardem pisma
                cmd.ExecuteNonQuery();
                MessageBox.Show("Rekordy dodano pomyślnie");
            }
            catch(Exception ex)
            {
                MessageBoxResult key = MessageBox.Show("Sukces", "Prawidłowo dodano słowo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            conn.Close();
        }


        //TODO - wprowadzić przycisk wyświetlający norweską klawiaturę w celu ułatwienia wyboru znaków specjalnych
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text+"æ";
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
