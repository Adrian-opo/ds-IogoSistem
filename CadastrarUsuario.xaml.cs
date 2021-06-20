using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace IogoSistem_vs1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private void Visualizar(object sender, RoutedEventArgs e)
        {
            
            String revelasenha = senhauser.Password;
            String voltar = revelar.Text;
            if (ver.IsChecked == true)
            {
                senhauser.Visibility = Visibility.Collapsed;
                revelar.Visibility = Visibility.Visible;

                revelar.Text = revelasenha;
            }
            if (ver.IsChecked == false)
            {
                senhauser.Visibility = Visibility.Visible;
                revelar.Visibility = Visibility.Collapsed;

                senhauser.Password = voltar;
            }
        }

        private void Btnadicionar_foto(object sender, RoutedEventArgs e)
        {

            System.Diagnostics.Process.Start("explorer.exe", @"C:\Users");

        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Excluir_Usuario exclui = new Excluir_Usuario();
            exclui.ShowDialog();

        }



        private void Btneditar(object sender, RoutedEventArgs e)
        {
            Editar_Usuario editar = new Editar_Usuario();
            editar.ShowDialog();
        }

        private void Btn_Salvar(object sender, RoutedEventArgs e)
        {
            string email = txtemail.Text.Trim();
            string cpf = txtcpf.Text.Trim();

            if ((nameuser.Text == "") || (!Util.IsEmail(email)) || (!Util.IsCpf(cpf)) || (senhauser.Password == ""))
            {
                MessageBox.Show("Campo(s) em branco e/ou invalido(s)!");
            }
            else
            {
                MessageBox.Show("Usuário cadastrado com sucesso");
                nameuser.Text = txtemail.Text = txtcpf.Text = senhauser.Password = revelar.Text = "";
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
                    tbsenha.Margin = new Thickness(45, 23, 0, 0);

                }
                else
                {
                    tbcpf_error.Visibility = Visibility.Visible;
                    tbsenha.Margin = new Thickness(45, 7, 0, 0);
                }

            }


        }
    }
}
