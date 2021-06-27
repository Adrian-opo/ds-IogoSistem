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
    /// Interaction logic for RegistrarDespesas.xaml
    /// </summary>
    public partial class RegistrarDespesas : Window
    {
        public RegistrarDespesas()
        {
            InitializeComponent();
        }

        private void Agenda_Loaded(object sender, RoutedEventArgs e)
        {
            CbxRecebe_categoria.SelectedIndex = 1;
            List<Util> ListaRegistrarDespesas = new List<Util>();

            for (int i = 1; i <= 24; i++)
            {
                ListaRegistrarDespesas.Add(new Util()
                {
                    Codigo = "X",
                    

                });
            }
            
        }

        private void dataGridRegistrarDespesas_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridRegistrarDespesas_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void dataGridRegistrarDespesas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_Resetar_Click(object sender, RoutedEventArgs e)
        {

            RegistrarGanhos registrarganhos = new RegistrarGanhos();
            registrarganhos.Close();
            Menu menu = new Menu();
            menu.ShowDialog();

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            RegistrarDespesas registrardespesas = new RegistrarDespesas();
            registrardespesas.Close();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void btnAdd_Categoria_Click(object sender, RoutedEventArgs e)
        {

            RegistrarDespesas1 editar = new RegistrarDespesas1();
            editar.ShowDialog();
        }

        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
