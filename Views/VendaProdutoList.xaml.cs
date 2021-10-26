using IogoSistem.Models;
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

namespace IogoSistem.Views
{
    /// <summary>
    /// Interação lógica para VendaProdutoList.xam
    /// </summary>
    public partial class VendaProdutoList : Window
    {
        private List<Produto> _produtoList = new List<Produto>();
        public List<Produto> ProdutosSelecionados { get; private set; }
        public VendaProdutoList()
        {
            InitializeComponent();
            Loaded += VendaProdutoList_Loaded;
        }

        private void VendaProdutoList_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            try
            {
                _produtoList = new ProdutoDAO().List();
                dataGrid.ItemsSource = _produtoList;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            var itens = dataGrid.Items;
            ProdutosSelecionados.Clear();
            foreach(Produto produto in itens)
            {
                if (produto.IsSelected)
                {
                    ProdutosSelecionados.Add(produto);
                }

            }

            if (ProdutosSelecionados.Count == 0)
                MessageBox.Show("Nnenhum Produto Foi Selecionado!", "", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();

        }

        private void BtnBuscarProduto_Click(object sender, RoutedEventArgs e)
        {
            var text = BuscarProduto.Text;
            var filteredList = _produtoList.Where(i => i.Nome.ToLower().Contains(text));
            dataGrid.ItemsSource = filteredList;
        }
    }
}
