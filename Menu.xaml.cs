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
    /// Lógica interna para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnCadastrarUsuario(object sender, RoutedEventArgs e)
        {
            MainWindow abrir = new MainWindow();
            abrir.ShowDialog();
        }

        private void BtnAgenda(object sender, RoutedEventArgs e)
        {
            Agenda agenda = new Agenda();
            agenda.ShowDialog();
        }

        private void BtnCadastrarFornecedor(object sender, RoutedEventArgs e)
        {
            CadastrarFornecedor cadastrarfornecedor = new CadastrarFornecedor();
            cadastrarfornecedor.ShowDialog();
        }

        private void BtnConsultarProduto(object sender, RoutedEventArgs e)
        {
            ConsultarProdutos consultarprod = new ConsultarProdutos();
            consultarprod.ShowDialog();
        }

        private void BtnCadastrarFuncionario(object sender, RoutedEventArgs e)
        {
            CadastrarFuncionario cadastrarFuncionario = new CadastrarFuncionario();
            cadastrarFuncionario.ShowDialog();
        }
    }
}
