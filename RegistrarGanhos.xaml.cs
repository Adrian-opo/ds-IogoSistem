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
using System.Windows.Shapes;

namespace IogoSistem_vs1
{
    /// <summary>
    /// Lógica interna para RegistrarGanhos.xaml
    /// </summary>
    public partial class RegistrarGanhos : Window
    {
        public RegistrarGanhos()
        {
            InitializeComponent();

            registrarganhossimples.IsChecked = true;

            recebe_cliente.Items.Add("Danilo Saiter da Silva");
            recebe_cliente.Items.Add("Adrian Henrique Ferreira");
            recebe_cliente.Items.Add("Felipe Hoffman");
            recebe_cliente.Items.Add("Wester Jesuino Morandi de Oliveira");
            recebe_cliente.Items.Add("Auanny");
            recebe_cliente.Items.Add("Jhéssica");

            recebe_formadepagamento.Items.Add("Dinheiro");
            recebe_formadepagamento.Items.Add("Cartão de Crédito");
            recebe_formadepagamento.Items.Add("Cartão de Débito");
            recebe_formadepagamento.Items.Add("Depósito Bancário");

            recebe_nomedoproduto.Items.Add("Iogurte de Morango");
            recebe_nomedoproduto.Items.Add("Iogurte de Ameixa");
            recebe_nomedoproduto.Items.Add("Iogurte de Abacaxi");
            recebe_nomedoproduto.Items.Add("Iogurte de Maracujá");
        }

        private void dataGridConsultarProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void recebe_numerodeparcelas_KeyDown(object sender, KeyEventArgs e)
        {
            KeyConverter key = new KeyConverter();

            if ((char.IsNumber((string)key.ConvertTo(e.Key, typeof(string)), 0) == false))
            {
                e.Handled = true;
            }
        }

        private void recebe_valor_KeyDown(object sender, KeyEventArgs e)
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

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            

            this.Close();
            
            
        }

    }
}
