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
    /// Lógica interna para CadastrarFornecedor.xaml
    /// </summary>
    public partial class CadastrarFornecedor : Window
    {
        public CadastrarFornecedor()
        {
            InitializeComponent();

            recebe_cidade.Items.Add("Ouro Preto do Oeste");
            recebe_cidade.Items.Add("Rio de Janeiro");
            recebe_cidade.Items.Add("São Paulo");

            recebe_uf.Items.Add("RO");
            recebe_uf.Items.Add("RJ");
            recebe_uf.Items.Add("SP");

            pessoafisica.IsChecked = true;
        }

        private void pessoafisica_Checked(object sender, RoutedEventArgs e)
        {
            pessoafisica.Checked += pessoafisica_Checked;

            if (pessoafisica.IsChecked == true)
            {

                recebe_nomefantasia.Visibility = Visibility.Hidden;
                recebe_razaosocial.Visibility = Visibility.Hidden;
                recebe_cnpj.Visibility = Visibility.Hidden;

                recebe_nome.Visibility = Visibility.Visible;
                recebe_cpf.Visibility = Visibility.Visible;
                recebe_rg.Visibility = Visibility.Visible;
            }
        }

        private void pessoajuridica_Checked(object sender, RoutedEventArgs e)
        {
            pessoajuridica.Checked += pessoajuridica_Checked;

            if (pessoajuridica.IsChecked == true)
            {
                recebe_nome.Visibility = Visibility.Hidden;
                recebe_cpf.Visibility = Visibility.Hidden;
                recebe_rg.Visibility = Visibility.Hidden;

                recebe_nomefantasia.Visibility = Visibility.Visible;
                recebe_razaosocial.Visibility = Visibility.Visible;
                recebe_cnpj.Visibility = Visibility.Visible;
            }
        }

        private void recebe_cpf_LostFocus(object sender, RoutedEventArgs e)
        {
            string cpf = recebe_cpf.Text;
            cpf = cpf.Replace('_', '0');

            if ((cpf == "___.___.___-__"))
            {
                MessageBox.Show("Digite um CPF valido");
            }

            else
            {
                if (Util.IsCpf(cpf))
                {
                    recebe_cpf.Foreground=Brushes.Green;

                }
                else
                {
                    recebe_cpf.Foreground = Brushes.Red;
                }

            }
        }

        private void recebe_cnpj_LostFocus(object sender, RoutedEventArgs e)
        {
            string cnpj = recebe_cnpj.Text;
            cnpj = cnpj.Replace('_', '0');

            if ((cnpj == "__.___.___/____-__"))
            {
                MessageBox.Show("Digite um CPF valido");
            }

            else
            {
                if (Util.IsCnpj(cnpj))
                {
                    recebe_cnpj.Foreground = Brushes.Green;

                }
                else
                {
                    recebe_cnpj.Foreground = Brushes.Red;
                }

            }
        }

        private void recebe_numero_KeyDown(object sender, KeyEventArgs e)
        {
            KeyConverter key = new KeyConverter();

            if ((char.IsNumber((string)key.ConvertTo(e.Key, typeof(string)), 0) == false))
            {
                e.Handled = true;
            }
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {

            CadastrarFornecedor cadastrarfornecedor = new CadastrarFornecedor();
            cadastrarfornecedor.Close();
            Menu menu = new Menu();
            menu.ShowDialog();
        }
    }
}
