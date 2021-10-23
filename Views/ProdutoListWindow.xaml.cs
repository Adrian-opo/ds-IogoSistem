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
using IogoSistem.Models;

namespace IogoSistem.Views
{
    /// <summary>
    /// Lógica interna para ProdutoListWindow.xaml
    /// </summary>
    public partial class ProdutoListWindow : Window
        
    {
        private List<Produto> _produto = new List<Produto>();
        public ProdutoListWindow()
        {
            InitializeComponent();
            Loaded += ProdutoListWindow_Loaded;
        }

        private void ProdutoListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {

                _produto = new ProdutoDAO().List();

                dataGridConsultarProd.ItemsSource = _produto;



              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            var window = new UsuarioFormWindow();
            window.ShowDialog();
            LoadDataGrid();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var userselected = dataGridConsultarProd.SelectedItem as Produto;

            var window = new ProdutoFormWindow(userselected.Id);
            window.ShowDialog();
            LoadDataGrid();

        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void BtnEX_Click(object sender, RoutedEventArgs e)
        {
            var userselected = dataGridConsultarProd.SelectedItem as Produto;
            var result = MessageBox.Show($"Deseja remover o produto {userselected.Nome}?", "Confirmação de exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ProdutoDAO();
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

        private void Btnbusca_Click(object sender, RoutedEventArgs e)
        {
            var text = txtbusca.Text;

            var filterlist = _produto.Where(i => i.Nome.ToLower().Contains(text));
            dataGridConsultarProd.ItemsSource = filterlist;
        }
    }
}
