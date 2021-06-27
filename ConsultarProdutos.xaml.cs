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
    /// Lógica interna para ConsultarProdutos.xaml
    /// </summary>
    public partial class ConsultarProdutos : Window
    {
        public ConsultarProdutos()
        {
            InitializeComponent();

            Loaded += Agenda_Loaded;
        }
        private void Agenda_Loaded(object sender, RoutedEventArgs e)
        {
            Cmbconsultarpor.SelectedIndex = 1;
            List<Util> ListaConsultarProd = new List<Util>();

            for (int i = 1; i <= 24; i++)
            {
                ListaConsultarProd.Add(new Util()
                {
                    Codigo = "X",
                    Nome = "x",
                    Sabor = "X",
                    Categoria = "X",
                    Peso_Litros = "X",
                    Preco_Custo = "X",
                    Preco_Venda = "X",
                    Qtd_Estoque = "x",
                    Descrição = "X"

                });
            }
            dataGridConsultarProd.ItemsSource = ListaConsultarProd;
        }

        private void dataGridConsultarProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
