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

namespace IogoSistem.Views
{
    /// <summary>
    /// Interação lógica para Venda.xam
    /// </summary>
    public partial class Venda : Window
    {
        public Venda()
        {
            InitializeComponent();
        }

        private void recebe_numerodeparcelas_KeyDown(object sender, KeyEventArgs e)
        {
            KeyConverter key = new KeyConverter();

            if ((char.IsNumber((string)key.ConvertTo(e.Key, typeof(string)), 0) == false))
            {
                e.Handled = true;
            }
        }

        private void recebe_quantidade_KeyDown(object sender, KeyEventArgs e)
        {
            KeyConverter key = new KeyConverter();

            if ((char.IsNumber((string)key.ConvertTo(e.Key, typeof(string)), 0) == false))
            {
                e.Handled = true;
            }
        }

        private void registrarganhossimples_Checked(object sender, RoutedEventArgs e)
        {
            registrarganhossimples.Checked += registrarganhossimples_Checked;

            if (registrarganhossimples.IsChecked == true)
            {

                cliente.Visibility = Visibility.Hidden;
                recebe_cliente.Visibility = Visibility.Hidden;
                id_cliente.Visibility = Visibility.Hidden;
                recebe_idcliente.Visibility = Visibility.Hidden;


            }
        }

        private void registrarganhosdetalhados_Checked(object sender, RoutedEventArgs e)
        {
            registrarganhosdetalhados.Checked += registrarganhosdetalhados_Checked;

            if (registrarganhosdetalhados.IsChecked == true)
            {

                cliente.Visibility = Visibility.Visible;
                recebe_cliente.Visibility = Visibility.Visible;
                id_cliente.Visibility = Visibility.Visible;
                recebe_idcliente.Visibility = Visibility.Visible;


            }
        }
    }
}