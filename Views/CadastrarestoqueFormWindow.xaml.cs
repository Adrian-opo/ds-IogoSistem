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
using System.Windows.Shapes;

namespace IogoSistem.Views
{
    /// <summary>
    /// Lógica interna para CadastrarestoqueFormWindow.xaml
    /// </summary>
    public partial class CadastrarestoqueFormWindow : Window
    {

        private List<Produto> _produto = new List<Produto>();
       

        private Produto _pdt;
        private int _id;
        public CadastrarestoqueFormWindow()
        {
            InitializeComponent();
            Loaded += CadastrarestoqueFormWindow_Loaded;
        }

        private void CadastrarestoqueFormWindow_Loaded(object sender, RoutedEventArgs e)
        {

            _pdt = new Produto();
            if (_id > 0)
                fillForm();
            LoadDataGrid();
        }

       

        private void LoadDataGrid()
        {
            try
            {

                _produto = new ProdutoDAO().List();

                dataGridCadatrarestoque.ItemsSource = _produto;





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
            var userselected = dataGridCadatrarestoque.SelectedItem as Fornecedor;

            var window = new FornecedorFormWindow(userselected.Id);
            window.ShowDialog();
            LoadDataGrid();

        }

        private void BtnEX_Click(object sender, RoutedEventArgs e)
        {
          
        }
        private void SaveData()
        {
            try
            {
                var dao = new CadastrarEstoqueDAO();
                var text = "Atualizado";

                if (_pdt.Id == 0)
                {
                    text = "cadastrado";
                    dao.Insert(_pdt);
                    CloseFormVerify();
                }
                else
                    dao.Update(_pdt);



                MessageBox.Show($"O produto foi {text}", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "não executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void CloseFormVerify()
        {
            var result = MessageBox.Show("Deseja continuar?", "continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
                this.Close();
            else
                ClearInputs();
        }
        private void ClearInputs()
        {

            TBquantidade.Text = "";
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            _pdt.Estoque = int.Parse(TBquantidade.Text);

            SaveData();
        }
       
        


        private void fillForm()
        {
            try
            {
                var dao = new CadastrarEstoqueDAO();
           


                TBquantidade.Text = _pdt.Estoque.ToString();
              





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dataGridConsultarProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void produtos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Pquantidade_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Btnbusca_Click(object sender, RoutedEventArgs e)
        {
            var text = txtbusca.Text;

            var filterlist = _produto.Where(i => i.Nome.ToLower().Contains(text));
            dataGridCadatrarestoque.ItemsSource = filterlist;

            try
            {
                var dao = new CadastrarEstoqueDAO();



                TBquantidade.Text = _pdt.Estoque.ToString();






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }




        }
    }
    }

