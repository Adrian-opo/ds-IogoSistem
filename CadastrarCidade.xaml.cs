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
    /// Lógica interna para CadastrarCidade.xaml
    /// </summary>
    public partial class CadastrarCidade : Window
    {
        private List<string> paises;
        private List<string> estados;
        private List<string> cidades;
        private List<string> ufs;


        public CadastrarCidade()
        {
            InitializeComponent();
            Loaded += CadastrarCidade_Loaded;


        }

        private void CadastrarCidade_Loaded(object sender, RoutedEventArgs e)
        {
            paises = new List<string>();
            estados = new List<string>();
            cidades = new List<string>();
            ufs = new List<string>();


            paises.Add("");
            paises.Add("");
            paises.Add("");
            paises.Add("");

            comboboxpais.ItemsSource = paises;

            estados.Add("");
            estados.Add("");
            estados.Add("");
            estados.Add("");

            comboboxestado.ItemsSource = estados;

            cidades.Add("");
            cidades.Add("");
            cidades.Add("");
            cidades.Add("");

           // comboboxcidade.ItemsSource = cidades;

            ufs.Add("");
            ufs.Add("");
            ufs.Add("");
            ufs.Add("");

            //comboboxcidade.ItemsSource = ufs;


        }

        private void recebe_cidade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btn_cancelar(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cancelado com sucesso!");
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
                 EditarCidade editarcidade = new EditarCidade();
                 editarcidade.ShowDialog();
            
        }

        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {
            ExcluirCidade excluircidade = new ExcluirCidade();
           excluircidade.ShowDialog();


            MessageBox.Show("Excluído com sucesso!");
        }

        private void BtnSalvarcidade_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Salvo com sucesso!");
        }

        private void Btnpesquisar(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Essa função ainda não está disponível");
        }

       
    }
}
