using System.Linq;
using System;
using System.Collections.Generic;
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
    /// Lógica interna para CaixaListWindow.xaml
    /// </summary>
    public partial class CaixaListWindow : Window
    {
        private List<Caixa> _caixalist = new List<Caixa>();



        public CaixaListWindow()
        {
            InitializeComponent();
            Loaded += CaixaListWindow_Loaded;
        }
        private void CaixaListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }
        private void LoadDataGrid()
        {
            try
            {

                _caixalist = new CaixaDAO().List();

                dataGridconsultarCaixa.ItemsSource = _caixalist;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            var text = wpftooldataaberturac.Text;

            var filterlist = _caixalist.Where(i => i.DataAbertura_cai.ToLower().Contains(text));
            dataGridconsultarCaixa.ItemsSource = filterlist;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
