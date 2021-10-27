using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IogoSistem.Models;
using IogoSistem.Views;

namespace IogoSistem.Views
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            var x = DadosSistema.GetUser();
            txtuser.Text=x.Funcionario.Nome.ToString();
            txtDataAtual.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LoadDataGripEventos();


        }
        public void LoadDataGripEventos()
        {
            try
            {
                
                var dao = new EventoDAO();

                dataGridEventos.ItemsSource = dao.List();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Type(string nome)
        {
            Window window;


            switch (nome)
            {
                
                case "MN_Produto":
                case "MN_CA_Produto":
                    window = new ProdutoFormWindow();
                    window.ShowDialog();
                    break;
                case "MN_Estoque":
                case "MN_CA_Estoque":
                    window = new CadastrarestoqueFormWindow();
                    window.ShowDialog();
                    break;
                case "MN_Cliente":
                case "MN_CA_Cliente":
                    //ABRIR TELA CLIENTE
                    break;
                case "MN_Fornecedor":
                case "MN_CA_Fornecedor":
                    window = new FornecedorFormWindow();
                    window.ShowDialog();
                    break;
                case "MN_Funcionario":
                case "MN_CA_Funcionario":
                    window = new FuncionarioFormWindow();
                    window.ShowDialog();
                    break;
                case "MN_Usuario":
                case "MN_CA_Usuario":
                    window = new UsuarioFormWindow();
                    window.ShowDialog();
                    break;
                case "MN_Calculadora":
                    Process.Start("Calc.exe");
                    break;
                case "MN_Eventos":
                    window = new EventoFormWindow();
                    window.ShowDialog();
                    LoadDataGripEventos();
                    break;
                //CONSULTAR
                case "MN_CO_Cliente":
                    //ABRIR TELA CLIENTE
                    break;
                case "MN_CO_Fornecedor":
                    window = new FornecedorListWindow();
                    window.ShowDialog();
                    break;
                case "MN_CO_Funcionario":
                    window = new FuncionarioListWindow();
                    window.ShowDialog();
                    break;
                case "MN_CO_Usuario":
                    window = new UsuarioListWindow();
                    window.ShowDialog();
                    break;
                case "MN_CO_Produto":
                    window = new ProdutoListWindow();
                    window.ShowDialog();
                    break;
                //FINANCEIRO
                case "MN_FI_Ganho":
                case "Btn_Despesas":
                    //ABRIR TELA GANHO
                    break;
                case "MN_FI_Despesa":
                case "Btn_Ganhos":
                    //ABRIR TELA DESPESA
                    break;
                case "MN_FI_Caixa":
                case "Btn_Caixa":
                    window = new CaixaFormWindow();
                    window.ShowDialog();
                    //ABRIR TELA CAIXA
                    break;
                case "MN_AG_AGENDA":
                    window = new AgendaWindow();
                    window.ShowDialog();
                    break;
                case "MN_AJ_AjudaUser":
                    //ABRIR TELA AJUDA AO USUARIO
                    window = new Ajuda();
                    window.ShowDialog();
                    break;

            }
        }

        private void Menu_Button_Click(object sender, RoutedEventArgs e)
        {
        
            string nome;
            if (sender is MenuItem)
            {
                var button = sender as MenuItem;
                nome = button.Name;
                Button_Type(nome);
            }
            else
            {
                var button = sender as Button;
                nome = button.Name;
                Button_Type(nome);

            }


           
        }
    }
}
