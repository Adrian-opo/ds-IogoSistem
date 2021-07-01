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
    /// Lógica interna para EditarObservacoes.xaml
    /// </summary>
    public partial class EditarObservacoes : Window
    {
        public EditarObservacoes()
        {
            InitializeComponent();
        }

        private void Btnexcluirobservações_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Excluído com sucesso!");
        }

        private void BtnSalvarcidade_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Salvo com sucesso!");
        }
    }
}
