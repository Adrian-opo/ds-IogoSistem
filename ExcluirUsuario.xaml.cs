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
    /// Lógica interna para Excluir_Usuario.xaml
    /// </summary>
    public partial class Excluir_Usuario : Window
    {
        public Excluir_Usuario()
        {
            InitializeComponent();
        }
        private void verexcluir_Checked(object sender, RoutedEventArgs e)
        {
            String revelasenha = senhauser.Password;
            String voltar = revelarexcluir.Text;
            if (verexcluir.IsChecked == true)
            {
                senhauser.Visibility = Visibility.Collapsed;
                revelarexcluir.Visibility = Visibility.Visible;

                revelarexcluir.Text = revelasenha;
            }
            if (verexcluir.IsChecked == false)
            {
                senhauser.Visibility = Visibility.Visible;
                revelarexcluir.Visibility = Visibility.Collapsed;

                senhauser.Password = voltar;
            }
        }

        private void Btn_excluir(object sender, RoutedEventArgs e)
        {
            if ((Cmbusers.Text == "") || (senhauser.Password == "") )
            {
                MessageBox.Show("Campo(s) em branco e/ou invalido(s)!");
            }
            else
            {
                MessageBox.Show("Usuário excluido com sucesso!");
                Cmbusers.Text = senhauser.Password = revelarexcluir.Text = "";
            }


        }

        private void Btn_cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
