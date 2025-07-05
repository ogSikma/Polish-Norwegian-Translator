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
using System.Reflection.Emit;

namespace Slownik_z_MDI.Views
{

    public partial class Quiz : UserControl
    {
        public Quiz()
        {
            InitializeComponent();
        }
        public static int wylosowaneID;
        public static int seriaPoprawnych;

        public void Losowanie()
        {
            Random random = new Random();
            wylosowaneID = random.Next(33);
            TextBlock1.Text = "Słowo to: '" + Chosen_Word_Informations.Assign_Informations_About_Word(wylosowaneID) + "'";
        }

        private void RozpocznijQuiz_Click(object sender, RoutedEventArgs e)
        {
            Losowanie();
        }

        private static string odpowiedzUzytkownika = "";
        private static string kwerendaOdpowiedzi;
        private void Odpowiedz_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sikma\source\repos\Slownik_z_MDI\Slownik_z_MDI\_data\norweski.mdf;Integrated Security=True");
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sikma\source\repos\Slownik_z_MDI\Slownik_z_MDI\_data\norweski.mdf;Integrated Security=True";
            conn.Open();

            try
            {
                odpowiedzUzytkownika = TextBox1.Text;
            }
            catch (ArgumentNullException ex)
            {
                MessageBoxResult key = MessageBox.Show("Błąd", "Coś poszło nie tak przy wpisywaniu słowa.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            kwerendaOdpowiedzi = "SELECT ID FROM tbl_Details WHERE polski='" + odpowiedzUzytkownika + "'"; //wybierz ID dla wybranego w TextBox słowa po polsku
            SqlCommand cmd2 = new SqlCommand(kwerendaOdpowiedzi, conn);
            SqlDataReader reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {
                if (wylosowaneID.ToString() == reader2["ID"].ToString())
                {
                    while (wylosowaneID.ToString() == reader2["ID"].ToString())
                    {
                        seriaPoprawnych++;
                        Message_Content.Display_Correct_Message();
                        Losowanie();
                    }
                }
                else if (wylosowaneID.ToString() != reader2["ID"].ToString())
                {
                    seriaPoprawnych = 0;
                    Message_Content.Display_Incorrect_Message();
                    Losowanie();
                }
            }
            reader2.Close();
        }
    }


    public static class Message_Content
    {
        public static void Display_Correct_Message()
        {
            MessageBoxResult key = MessageBox.Show("Prawidłowo przetłumaczyłeś słowo Twoja seria wynosi " + Quiz.seriaPoprawnych, "Gratulacje!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void Display_Incorrect_Message()
        {
            MessageBoxResult key = MessageBox.Show("Niestety, błędne tłumaczenie", "Spróbuj ponownie", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }


    public class Chosen_Word_Informations
    {
        public static string Assign_Informations_About_Word(int wylosowaneID)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sikma\source\repos\Slownik_z_MDI\Slownik_z_MDI\_data\norweski.mdf;Integrated Security=True");
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sikma\source\repos\Slownik_z_MDI\Slownik_z_MDI\_data\norweski.mdf;Integrated Security=True";
            conn.Open();

            string wylosowaneSlowo_polski="";
            string wylosowaneSlowo_norweski="";
            string wylosowaneSlowo_ID="";
            string wylosowaneSlowo_pismo="";
            string kwerenda;
            kwerenda = "SELECT norweski, polski, pismo, ID FROM tbl_Details WHERE ID=" + wylosowaneID + "";                  
            SqlCommand cmd1 = new SqlCommand(kwerenda, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                wylosowaneSlowo_norweski = reader1["norweski"].ToString();
                wylosowaneSlowo_polski = reader1["polski"].ToString();
                wylosowaneSlowo_ID = reader1["ID"].ToString();
                wylosowaneSlowo_pismo = reader1["pismo"].ToString();
            }

            reader1.Close();
            conn.Close();
            return wylosowaneSlowo_norweski;
        }
    }
}
