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



        private void bttAge_Click(object sender, RoutedEventArgs e)
        {
            Agenda agenda = new Agenda();
            agenda.ShowDialog();
        }
<<<<<<< Updated upstream

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

        private void BtnRegistrarDespesas(object sender, RoutedEventArgs e)
        {

            RegistrarDespesas registrarDespesas = new RegistrarDespesas();
            registrarDespesas.ShowDialog();
        }

        private void registrar_ganhos_Click(object sender, RoutedEventArgs e)
        {
            RegistrarGanhos registrarganhos = new RegistrarGanhos();
            registrarganhos.ShowDialog();
        }

        private void consultar_clientes_Click(object sender, RoutedEventArgs e)
        {
            ConsultarClientes consultarclientes = new ConsultarClientes();
            consultarclientes.ShowDialog();
        }

        private void consultar_fornecedor_Click(object sender, RoutedEventArgs e)
        {
            ConsultarFornecedor consultarFornecedor = new ConsultarFornecedor();
            consultarFornecedor.ShowDialog();
        }

        
=======
>>>>>>> Stashed changes
    }
}
