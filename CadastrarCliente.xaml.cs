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
    /// Lógica interna para CadastrarCliente.xaml
    /// </summary>
    public partial class CadastrarCliente : Window
    {
        public CadastrarCliente()
        {
            InitializeComponent();


            combobox_uf.Items.Add("RO");
            combobox_uf.Items.Add("AC");
            combobox_uf.Items.Add("MA");
            combobox_uf.Items.Add("BA");
            combobox_uf.Items.Add("SC");
            combobox_uf.Items.Add("PR");
            combobox_uf.Items.Add("GO");
            combobox_uf.Items.Add("AL");
            combobox_uf.Items.Add("PA");
            combobox_uf.Items.Add("AP");
            combobox_uf.Items.Add("PI");
            combobox_uf.Items.Add("CE");
            combobox_uf.Items.Add("RN");
            combobox_uf.Items.Add("MG");
            combobox_uf.Items.Add("SP");
            combobox_uf.Items.Add("RJ");
            combobox_uf.Items.Add("ES");
            combobox_uf.Items.Add("DF");
            combobox_uf.Items.Add("SE");
            combobox_uf.Items.Add("MT");
            combobox_uf.Items.Add("MS");

        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCliente cadastrarCliente = new CadastrarCliente();
            cadastrarCliente.Close();
            Menu menu = new Menu();
            menu.ShowDialog(); 
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Salvo com sucesso!");
        }

        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Excluído com sucesso!");
        }

        private void btn_novo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
