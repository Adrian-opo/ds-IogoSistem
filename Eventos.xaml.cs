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
    /// Lógica interna para Eventos1.xaml
    /// </summary>
    public partial class Evento : Window
    {
        public Evento()
        {
            InitializeComponent();
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

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
           Evento editarEvento = new Evento();
            editarEvento.ShowDialog();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_limpar_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
