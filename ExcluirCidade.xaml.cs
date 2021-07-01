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
    /// Lógica interna para ExcluirCidade.xaml
    /// </summary>
    public partial class ExcluirCidade : Window
    {
        public ExcluirCidade()
        {
            InitializeComponent();
        }

        private void Btn_excluir(object sender, RoutedEventArgs e)
        {
            if ((comboboxcidades.Text == ""))
            {
                MessageBox.Show("Campo(s) em branco e/ou invalido(s)!");
            }
            else
            {
                MessageBox.Show("Cidade excluido com sucesso!");
                comboboxcidades.Text = revelarexcluir.Text = "";
            }

            MessageBox.Show("Excluído com sucesso!");
        }

        private void Btn_cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
