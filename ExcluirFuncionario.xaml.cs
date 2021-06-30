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
    /// Interaction logic for ExcluirFuncionario.xaml
    /// </summary>
    public partial class ExcluirFuncionario : Window
    {
        public ExcluirFuncionario()
        {
            InitializeComponent();
        }

        private void CmbNome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_excluir(object sender, RoutedEventArgs e)
        {
            if (CmbNome.Text == "")
            {
                MessageBox.Show("Campo(s) em branco e/ou invalido(s)!");
            }
            else
            {
                MessageBox.Show("Usuário excluido com sucesso!");
                CmbNome.Text = "";
            }
        }
    }
}
