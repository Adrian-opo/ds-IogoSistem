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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IogoSistem.Models;

namespace IogoSistem.Views
{
    /// <summary>
    /// Interação lógica para FornecedorListWindow.xam
    /// </summary>
    public partial class FornecedorListWindow : Window
    {
        public FornecedorListWindow()
        {
            InitializeComponent();
            Loaded += FornecedorListWindow_Loaded;
        }

        private void FornecedorListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new FornecedorDAO();

                dataGridConsultarFornecedor.ItemsSource = dao.List();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            var window = new FornecedorFormWindow();
            window.ShowDialog();
            LoadDataGrid();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var userselected = dataGridConsultarFornecedor.SelectedItem as Usuario;

            var window = new FornecedorFormWindow(userselected.Id);
            window.ShowDialog();
            LoadDataGrid();

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var userselected = dataGridConsultarFornecedor.SelectedItem as Fornecedor;
            var result = MessageBox.Show($"Deseja remover o fornecedor {userselected.Nome}?", "Confirmação de exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new FornecedorDAO();
                    dao.Delete(userselected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exeção", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }






        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Comboboxconsultarusuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
