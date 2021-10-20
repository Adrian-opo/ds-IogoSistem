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
using IogoSistem.Models;

namespace IogoSistem.Views
{
    /// <summary>
    /// Lógica interna para UsuarioFormWindow.xaml
    /// </summary>
    public partial class UsuarioFormWindow : Window
    {
        private int _id;

        private Usuario _usuario;

        public UsuarioFormWindow()
        {
            InitializeComponent();
            Loaded += UsuarioFormWindow_Loaded;
        }

        public UsuarioFormWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += UsuarioFormWindow_Loaded;
        }

        private void UsuarioFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _usuario = new Usuario();
            if (_id > 0)
                fillForm();
            
        }

        private void Btn_Salvar(object sender, RoutedEventArgs e)
        {
            if (ver.IsChecked == true)
            {
                _usuario.Nome = txtname.Text;
                _usuario.CPF = txtcpf.Text;
                _usuario.Email = txtemail.Text;
                _usuario.Senha = txtrevelar.Text;

                SaveData();
            }
            else
            {
                _usuario.Nome = txtname.Text;
                _usuario.CPF = txtcpf.Text;
                _usuario.Email = txtemail.Text;
                _usuario.Senha = txtsenha.Password;

                SaveData();
            }

        }  

        private void SaveData()
        {
            try
            {
                var dao = new UsuarioDAO();
                var text = "Atualizado";

                if (_usuario.Id == 0)
                {
                    text = "cadastrado";
                    dao.Insert(_usuario);
                    CloseFormVerify();
                }
                else
                { 
                    dao.Update(_usuario);
                    this.Close();
                }



                MessageBox.Show($"O usuario foi {text}", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "não executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void fillForm()
        {
            try
            {
                var dao = new UsuarioDAO();
                _usuario = dao.GetById(_id);

                txtname.Text = _usuario.Nome;
                txtcpf.Text = _usuario.CPF;
                txtemail.Text = _usuario.Email;
                txtsenha.Password = _usuario.Senha;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseFormVerify()
        {
            var result = MessageBox.Show("Deseja continuar?", "continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                this.Close();
            else
                ClearInputs();
        }

        private void ClearInputs()
        {
            txtname.Text = "";
            txtcpf.Text = "";
            txtemail.Text = "";
            txtsenha.Password = "";
            txtrevelar.Text = "";
        }



        private void Visualizar(object sender, RoutedEventArgs e)
        {

            String revelasenha = txtsenha.Password;
            String voltar = txtrevelar.Text;
            if (ver.IsChecked == true)
            {
                txtsenha.Visibility = Visibility.Collapsed;
                txtrevelar.Visibility = Visibility.Visible;

                txtrevelar.Text = revelasenha;
            }
            if (ver.IsChecked == false)
            {
                txtsenha.Visibility = Visibility.Visible;
                txtrevelar.Visibility = Visibility.Collapsed;

                txtsenha.Password = voltar;

            }
        }

        private void Btnadicionar_foto(object sender, RoutedEventArgs e)
        {

            System.Diagnostics.Process.Start("explorer.exe", @"C:\Users");

        }


        private void txtemail_lostFocus(object sender, RoutedEventArgs e)
        {
            string email = txtemail.Text.Trim();
        }

        private void txtcpf_lostFocus(object sender, RoutedEventArgs e)
        {
            string cpf = txtcpf.Text;
            cpf.Replace('_', '0');
            

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();

        }
    }
}
