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
using Slownik_z_MDI.ViewModels;

namespace Slownik_z_MDI
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DodajSlowo_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new DodajSlowoModel();
        }

        private void UsunSlowo_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new UsunSlowoModel();
        }

        private void WyszukajSlowo_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new WyszukajSlowoModel();
        }

        private void Przetlumacz_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new PrzetlumaczModel();
        }

        private void Quiz_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new QuizModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
