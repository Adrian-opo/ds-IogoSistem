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
    /// Lógica interna para Editar_Usuario.xaml
    /// </summary>
    public partial class Editar_Usuario : Window
    {
        public Editar_Usuario()
        {
            InitializeComponent();
        }
        private void Ver(object sender, RoutedEventArgs e)
        {
            string revelasenha = txtsenhauser.Password;
            string voltar = txtrevelar.Text;
            string senhaanrifa = txtsenhauserantiga.Password;
            string voltar2 = txtrevelarantiga.Text;

            if (ver.IsChecked == true)
            {
                txtsenhauser.Visibility = Visibility.Collapsed;
                txtrevelar.Visibility = Visibility.Visible;

                txtrevelar.Text = revelasenha;
            }
            if (ver.IsChecked == false)
            {
                txtsenhauser.Visibility = Visibility.Visible;
                txtrevelar.Visibility = Visibility.Collapsed;

                txtsenhauser.Password = voltar;
            }

            if (verantiga.IsChecked == true)
            {
                txtsenhauserantiga.Visibility = Visibility.Collapsed;
                txtrevelarantiga.Visibility = Visibility.Visible;

                txtrevelarantiga.Text = senhaanrifa;
            }
            if (verantiga.IsChecked == false)
            {
                txtsenhauserantiga.Visibility = Visibility.Visible;
                txtrevelarantiga.Visibility = Visibility.Collapsed;

                txtsenhauserantiga.Password = voltar2;
            }
        }

        private void Btn_Salvar(object sender, RoutedEventArgs e)
        {
            
            string email = txtemail.Text.Trim();
            string cpf = txtcpf.Text.Trim();

            if ((cmbedituser.Text=="") || (txtnameuser.Text == "") || (!Util.IsEmail(email)) || (!Util.IsCpf(cpf)) || (txtsenhauser.Password == "") || (txtsenhauserantiga.Password==""))
            {
                MessageBox.Show("Campo(s) em branco e/ou invalido(s)!");
            }
            else
            {
                MessageBox.Show("Usuário editado com sucesso");
                cmbedituser.Text = txtnameuser.Text = txtemail.Text = txtcpf.Text = txtsenhauser.Password = txtsenhauserantiga.Password= txtrevelar.Text = "";
            }

        }
        private void Btn_Adicionar_foto(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", @"C:\Users");
        }

        private void Btn_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtcpf_lostFocus(object sender, RoutedEventArgs e)
        {
            string cpf = txtcpf.Text;
            cpf = cpf.Replace('_', '0');

            if ((cpf == "___.___.___-__"))
            {
                MessageBox.Show("Digite um CPF valido");
            }
            else
            {
                if (Util.IsCpf(cpf))
                {
                    e.Handled = true;
                    tbcpf_error.Visibility = Visibility.Collapsed;
                    tbnovasenha.Margin = new Thickness(45, 23, 0, 0);

                }
                else
                {
                    tbcpf_error.Visibility = Visibility.Visible;
                    tbnovasenha.Margin = new Thickness(45, 7, 0, 0);
                }

            }
        }
        private void txtemail_lostFocus(object sender, RoutedEventArgs e)
        {



            string email = txtemail.Text.Trim();


            if (!Util.IsEmail(email))
            {
                e.Handled = true;
                tbemail_error.Visibility = Visibility.Visible;
                tbcpf.Margin = new Thickness(45, 7, 0, 0);
            }
            else
            {
                tbemail_error.Visibility = Visibility.Collapsed;
                tbcpf.Margin = new Thickness(45, 23, 0, 0);
            }
        }
    }
}
