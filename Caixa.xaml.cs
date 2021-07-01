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
    /// Lógica interna para Caixa.xaml
    /// </summary>
    public partial class Caixa : Window
    {
        public Caixa()
        {
            InitializeComponent();
        }

 

     
        private void Btnrelatorios(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ops! Os relatórios estão indisponíveis no momento.");
        }

        private void Btneditarobservações_Click(object sender, RoutedEventArgs e)
        {

            EditarObservacoes editarobservacoes = new EditarObservacoes();
            editarobservacoes.ShowDialog();
        }

        private void BtnSalvarcidade_Click(object sender, RoutedEventArgs e)
        {
          
            MessageBox.Show("Observações salvas com sucesso!");
        }
    }
}
