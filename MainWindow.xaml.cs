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

namespace IogoSistem
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Visualizar(object sender, RoutedEventArgs e)
        {
            String revelasenha = senhauser.Password;
            if (ver.IsChecked == true)
            {
                senhauser.Visibility = Visibility.Collapsed;
                revelar.Visibility = Visibility.Visible;
                
                revelar.Text = revelasenha;
            }
            if(ver.IsChecked == false)
            {
                senhauser.Visibility = Visibility.Visible;
                revelar.Visibility = Visibility.Collapsed;
            }
        }

        private void Btnadicionar_foto(object sender, RoutedEventArgs e)
        {

            System.Diagnostics.Process.Start("explorer.exe", @"C:\Users");

        }

        

    }
}
