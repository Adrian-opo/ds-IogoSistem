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
    /// Interaction logic for CadastrarFuncionario.xaml
    /// </summary>
    public partial class CadastrarFuncionario : Window
    {
        public CadastrarFuncionario()
        {
            InitializeComponent();


            recebe_cidade.Items.Add("Ouro Preto do Oeste");
            recebe_cidade.Items.Add("Salvador");
            recebe_cidade.Items.Add("Campinas");

            recebe_uf.Items.Add("RO");
            recebe_uf.Items.Add("BA");
            recebe_uf.Items.Add("SP");

            recebe_sexo.Items.Add("Masculino");
            recebe_sexo.Items.Add("Feminino");

            recebe_Tipo_Salario.Items.Add("Mensal");
            recebe_Tipo_Salario.Items.Add("Anual");
            recebe_Tipo_Salario.Items.Add("Diária");

            recebe_PCD.Items.Add("Sim, Possui Deficiência.");
            recebe_PCD.Items.Add("Não, Possui.");

        }

        private void BtnAdicionarFoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TxtBox_RecebeCPF_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {

          
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            CadastrarFuncionario cadastrarfuncionario = new CadastrarFuncionario();
            cadastrarfuncionario.Close();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void txtemail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            CadastrarFuncionario editarFunc = new CadastrarFuncionario ();
            editarFunc.ShowDialog();
        }

        private void btn_cancelar_Click_1(object sender, RoutedEventArgs e)
        {
            CadastrarFuncionario cadastrarfuncionario = new CadastrarFuncionario();
            cadastrarfuncionario.Close();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void btn_excluir_Click_1(object sender, RoutedEventArgs e)
        {
            ExcluirFuncionario exclui = new ExcluirFuncionario();
            exclui.ShowDialog();
        }

        private void recebe_uf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
