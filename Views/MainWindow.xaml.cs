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

        }

        private void Abrir_Usuario(object sender, RoutedEventArgs e)
        {
            var window = new UsuarioFormWindow();
            window.ShowDialog();

        }

        private void Abrir_lista(object sender, RoutedEventArgs e)
        {
            var window = new UsuarioListWindow();
            window.ShowDialog();
        }

        private void Abrir_Evento(object sender, RoutedEventArgs e)
        {
            var window = new EventoFormWindow();
            window.ShowDialog();
        }

        private void produtos(object sender, RoutedEventArgs e)
        {
            var window = new ProdutoFormWindow();
            window.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new FornecedorFormWindow();
            window.ShowDialog();
        }

        private void BtnConsultarFor_Click(object sender, RoutedEventArgs e)
        {
            var window = new FornecedorListWindow();
            window.ShowDialog();
        }

        private void Abrir_Agenda(object sender, RoutedEventArgs e)
        {
            var window = new AgendaWindow();
            window.ShowDialog();

        }
        ///////////////

        private void btn_list_funck_Click(object sender, RoutedEventArgs e)
        {
            var window = new FuncionarioFormWindow();
            window.ShowDialog();
        }

        private void btn_funcionario_Copy_Click(object sender, RoutedEventArgs e)
        {
            var window = new CadastrarestoqueFormWindow();
            window.ShowDialog();
        }
        private void btn_ajuda(object sender, RoutedEventArgs e)
        {
            var window = new Ajuda();
            window.ShowDialog();
        }
        private void Button_Type(string nome)
        {
            Window window;


            switch (nome)
            {
                case "MN_Produto":
                    window = new ProdutoListWindow();
                    window.ShowDialog();
                    break;
                case "MN_Cliente":
                case "MN_HE_Cliente":
                    Process.Start("Calc.exe");

                    break;
                case "MN_Fornecedor":
                    window = new FornecedorListWindow();
                    window.ShowDialog();
                    break;
                case "MN_Funcionario":
                    window = new FuncionarioListWindow();
                    window.ShowDialog();
                    break;
                case "MN_Usuario":
                    window = new UsuarioListWindow();
                    window.ShowDialog();
                    break;
                case "MN_Calculadora":
                    Process.Start("Calc.exe");
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
