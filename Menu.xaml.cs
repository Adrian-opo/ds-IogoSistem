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
using System.Diagnostics;



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

        private void Cadastrarcliente(object sender, RoutedEventArgs e)
        {
            CadastrarCliente cadastrarCliente = new CadastrarCliente();
            cadastrarCliente.ShowDialog();
        }

        private void CadastrarCidade(object sender, RoutedEventArgs e)
        {
            CadastrarCidade cadastrarcidade = new CadastrarCidade();
            cadastrarcidade.ShowDialog();
        }

        private void CadastrarFornecedor(object sender, RoutedEventArgs e)
        {
            CadastrarFornecedor cadastrarfornecedor = new CadastrarFornecedor();
            cadastrarfornecedor.ShowDialog();
        }

        private void CadastrarFuncionario(object sender, RoutedEventArgs e)
        {
            CadastrarFuncionario cadastrarfuncionario = new CadastrarFuncionario();
            cadastrarfuncionario.ShowDialog();
        }

        private void bttCal_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("Calc.exe");
        }

        private void CadastrarUsuario(object sender, RoutedEventArgs e)
        {
            MainWindow cadastrarusuario = new MainWindow();
            cadastrarusuario.ShowDialog();
        }

        private void Cadastrarganhos(object sender, RoutedEventArgs e)
        {

            RegistrarGanhos registrarganhos = new RegistrarGanhos();
            registrarganhos.ShowDialog();
        }

        private void CadastrarProdutos(object sender, RoutedEventArgs e)
        {
            CadastrarProdutos cadastrarprodutos = new CadastrarProdutos();
            cadastrarprodutos.ShowDialog();
        }

        private void CadastrarEventos(object sender, RoutedEventArgs e)
        {
            Evento cadastrareventos = new Evento();
            cadastrareventos.ShowDialog();
        }

        private void bttUsu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow cadastrarusuario = new MainWindow();
            cadastrarusuario.ShowDialog();
        }

        private void bttPro_Click(object sender, RoutedEventArgs e)
        {
            CadastrarProdutos cadastrarprodutos = new CadastrarProdutos();
            cadastrarprodutos.ShowDialog();
        }

        private void bttCai_Click(object sender, RoutedEventArgs e)
        {
            Caixa abrircaixa = new Caixa();
            abrircaixa.ShowDialog();
        }

        private void CadastrarEstoque(object sender, RoutedEventArgs e)
        {
            CadastrarEstoque cadastrarestoque = new CadastrarEstoque();
            cadastrarestoque.ShowDialog();
        }

        private void CadastrarDespesas(object sender, RoutedEventArgs e)
        {
            RegistrarDespesas registrardespesas = new RegistrarDespesas();
            registrardespesas.ShowDialog();
        }

        private void Registrarganhos(object sender, RoutedEventArgs e)
        {
            RegistrarGanhos registrarganhos = new RegistrarGanhos();
            registrarganhos.ShowDialog();
        }

        private void Controlecaixa(object sender, RoutedEventArgs e)
        {
            Caixa abrircaixa = new Caixa();
            abrircaixa.ShowDialog();
        }

        private void AbrirAjudaaoUsuario(object sender, RoutedEventArgs e)
        {
            SuporteUsuario suporteaouser = new SuporteUsuario();
            suporteaouser.ShowDialog();
        }

        private void AbrirConsultCliente(object sender, RoutedEventArgs e)
        {
            ConsultarClientes consultarclientes = new ConsultarClientes();
            consultarclientes.ShowDialog();
        }

        private void AbrirConsultfornecedor(object sender, RoutedEventArgs e)
        {
            ConsultarFornecedor consultarclientes = new ConsultarFornecedor();
            consultarclientes.ShowDialog();
        }



        private void AbrirConsultUsuario(object sender, RoutedEventArgs e)
        {
            ConsultarUsuario consultarusuario = new ConsultarUsuario();
            consultarusuario.ShowDialog();
        }

        private void AbrirConsultProdutos(object sender, RoutedEventArgs e)
        {
            ConsultarProdutos consultarprodutos = new ConsultarProdutos();
            consultarprodutos.ShowDialog();
        }
    }
}
