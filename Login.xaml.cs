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
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
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
      


      

        private void Btn_Salvar(object sender, RoutedEventArgs e)
        {
            string senha = senhauser.Password;


            if (senha == "1234")
            {
               
                Menu menu = new Menu();
                this.Close();
                menu.ShowDialog();
               

            }
        }
    }




}

