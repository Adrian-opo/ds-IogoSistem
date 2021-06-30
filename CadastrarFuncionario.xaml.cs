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
        private void recebe_email_LostFocus(object sender, RoutedEventArgs e)
        {
            string email = recebe_email.Text.Trim();

            if (!Util.IsEmail(email))
            {
                e.Handled = true;
                tbemail_error.Visibility = Visibility.Visible;
                TxtBox_RecebeCPF.Margin = new Thickness(45, 7, 0, 0);
            }
            else
            {
                tbemail_error.Visibility = Visibility.Collapsed;
                TxtBox_RecebeCPF.Margin = new Thickness(45, 23, 0, 0);
            }
        }

        private void TxtBox_RecebeCPF_LostFocus(object sender, RoutedEventArgs e)
        {
            string cpf = TxtBox_RecebeCPF.Text;
            cpf = cpf.Replace('_', '0');

            if ((cpf == "___.___.___-__"))
            {
                MessageBox.Show("Digite um CPF valido");
            }
            else
            {
                if (Util.IsCpf(cpf))
                {
                    e.Handled = true;
                    tbcpf_error.Visibility = Visibility.Collapsed;

                }
                else
                {
                    tbcpf_error.Visibility = Visibility.Visible;
                }

            }
        }

        private void BtnAdicionarFoto_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", @"C:\Users");

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
            CadastrarFuncionario editarFunc = new CadastrarFuncionario();
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

        private void btn_editar_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            string email = recebe_email.Text.Trim();
            string cpf = TxtBox_RecebeCPF.Text.Trim();

            if ((recebe_nome.Text == "") || (recebe_DataNasc.Text == "") || (recebe_Função.Text == "") || (recebe_NCarteira.Text == "") || (recebe_SetorTrabalho.Text == "") || (recebe_Endereco.Text == "") || (!Util.IsEmail(email)) || (!Util.IsCpf(cpf)))
            {
                MessageBox.Show("Campo(s) em branco e/ou invalido(s)!");
            }
            else
            {
                MessageBox.Show("Funcionario cadastrado com sucesso");
                recebe_nome.Text = recebe_email.Text = TxtBox_RecebeCPF.Text = recebe_DataNasc.Text = recebe_Endereco.Text = recebe_Função.Text = recebe_NCarteira.Text = recebe_SetorTrabalho.Text;
            }
        }


    }
}
