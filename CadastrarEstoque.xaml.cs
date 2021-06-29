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
    /// Lógica interna para CadastrarEstoque.xaml
    /// </summary>
    public partial class CadastrarEstoque : Window
    {
        public CadastrarEstoque()
        {
            InitializeComponent();


            produtos.Items.Add("Iogurte de Morango");
            produtos.Items.Add("Iogurte de Ameixa");
            produtos.Items.Add("Iogurte de Abacaxi");
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
