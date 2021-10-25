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
using IogoSistem.Views;
using IogoSistem.Models;

namespace IogoSistem
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Loaded += Login_Loaded;
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            _ = txtUsuario.Focus();
        }



       private void BtnAcessar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = pssBoxSenha.Password.ToString();

            var user = new UsuarioDAO().Login(usuario,senha);

            if (user!=null)
            {
                var ativo = new UsuarioDAO();
                ativo.AtivarUsuario(usuario,senha);
                
                DadosSistema.SetUser(user);

                var main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario e/ou senha incorretos! Tente novamente", "Autorização Negada", MessageBoxButton.OK,MessageBoxImage.Warning);
                _ = txtUsuario.Focus();

            }


        }

        private void Visualizar(object sender, RoutedEventArgs e)
        {
            /*
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
            */

        }


        private void darenter(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Return)
            {
                string usuario = txtUsuario.Text;
                string senha = pssBoxSenha.Password.ToString();

                var user = new UsuarioDAO().Login(usuario, senha);

                if (user != null)
                {

                    DadosSistema.SetUser(user);

                    var main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario e/ou senha incorretos! Tente novamente", "Autorização Negada", MessageBoxButton.OK, MessageBoxImage.Warning);
                    _ = txtUsuario.Focus();

                }


            }
        }
    }
}
