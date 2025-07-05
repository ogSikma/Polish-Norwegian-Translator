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
using Slownik_z_MDI.ViewModels;
using System.CodeDom;
using System.Security.Cryptography.X509Certificates;

namespace Slownik_z_MDI.Views
{
 
    public class WyjatekLiczbaZnakow : ApplicationException
    {
        public WyjatekLiczbaZnakow(string text) : base(text)
        {
            MessageBoxResult key = MessageBox.Show("Należy wpisać słowo. Brakuje liter!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    public partial class WyszukajSlowo : UserControl
    {
        public static int seriaWyszukan=0;
        public WyszukajSlowo()
        {
            InitializeComponent();
           
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sikma\source\repos\Slownik_z_MDI\Slownik_z_MDI\_data\norweski.mdf;Integrated Security=True");
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sikma\source\repos\Slownik_z_MDI\Slownik_z_MDI\_data\norweski.mdf;Integrated Security=True";
            conn.Open();

            try
            {
                string tekstPoNorwesku = TextBox1.Text;
                if (tekstPoNorwesku.Length < 2)
                    throw (new WyjatekLiczbaZnakow("Słowo musi składać się z liter. Nie wpisano słowa"));
                string kwerendaTlumaczenie;
                kwerendaTlumaczenie = "SELECT polski FROM tbl_Details WHERE norweski='" + tekstPoNorwesku + "'";
                SqlCommand cmd = new SqlCommand(kwerendaTlumaczenie, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                Words_Counter.Ammount();
                while (reader.Read())
                {
                    TextBlock1.Text = "Słowo '" + TextBox1.Text + "' przetłumaczone na polski to: '" + reader["polski"].ToString() + "', wyszukano słowo poraz "+ seriaWyszukan;
                }
                reader.Close();
            }
            catch (WyjatekLiczbaZnakow ex)
            {
            }          
            conn.Close();

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
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

    public static class Words_Counter
    {
        public static void Ammount()
        {
            WyszukajSlowo.seriaWyszukan = WyszukajSlowo.seriaWyszukan + 1;
        }
    }
}
