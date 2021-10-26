using IogoSistem.Helpers;
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
    /// Interação lógica para Venda.xam
    /// </summary>
    public partial class VendaFormWindow : Window
    {

        private List<VendaProduto> _vendaItensList = new List<VendaProduto>();
        private int _id;
        private Venda _venda = new Venda();

        public VendaFormWindow()
        {
            InitializeComponent();
            Loaded += VendaFormWindow_Loaded;
        }

        public VendaFormWindow(int id)
        {
            

            _id = id;
            InitializeComponent();
            Loaded += VendaFormWindow_Loaded;
        }

        private void VendaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _venda = new Venda();
            //recebe_data.SelectedData = DataVenda.Now;

            LoadComboBoxs();

            if (_id > 0)
                fillForm();
        }

        private void LoadDataGrid()
        {
            _ = UpdateValorTotal();
            dataGridProdutosVenda.ItemsSource = null;
            dataGridProdutosVenda.ItemsSource = _vendaItensList;
        }

        private void LoadComboBoxs()
        {
            try
            {
                recebe_funcionario.ItemsSource = new FuncionarioDAO().List();
                //recebe_cliente.ItemsSource = ClienteDAO().List();
                recebe_formaPagamento.ItemsSource = FormaPagamento.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ComboBox", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (recebe_formaPagamento.SelectedItem != null)
                _venda.FormaPagamento = recebe_formaPagamento.SelectedItem as string;

            if (recebe_data.SelectedDate != null)
                _venda.DataVenda = (DateTime)recebe_data.SelectedDate;

            if (recebe_cliente.SelectedItem != null)
                _venda.Cliente = recebe_cliente.SelectedItem as Cliente;

            if (recebe_funcionario.SelectedItem != null)
                _venda.Funcionario = recebe_funcionario.SelectedItem as Funcionario;

            _venda.ValorTotal = UpdateValorTotal();

            _venda.Itens = _vendaItensList;

            /* if (!recebe_data.Text.Equals(""))
                 _venda.DataVenda = Convert.ToDateTime(recebe_data.Text);

             if (!recebe_quantParcelas.Text.Equals(""))
                 _venda.QuantidadeParcelas = Convert.ToInt32(recebe_quantParcelas.Text);

             if (!recebe_dataVencimento.Text.Equals(""))
                 _venda.DataVencimentoParcela = Convert.ToDateTime(recebe_dataVencimento.Text);

             if (recebe_formaPagamento.SelectedItem != null)
                 _venda.Forma_Pagamento= recebe_formaPagamento.SelectedItem as string;

             _venda.Valor = double.Parse(recebe_valorFinal.Text);

             if (recebe_cliente.SelectedItem != null)
                 _venda.Cliente.Nome_Cliente = recebe_cliente.SelectedItem as string;

             if (recebe_nomeProduto.SelectedItem != null)
                 _venda.Produto.Nome = recebe_nomeProduto.SelectedItem as string;

             if (!recebe_valorProduto.Text.Equals(""))
                 _venda.Produto.Valor_Produto = Convert.ToDouble(recebe_valorProduto.Text);*/

            SaveData();

        }


        private void SaveData()
        {
            try
            {
                var dao = new VendaDAO();
                var text = "atualizada";

                if (_venda.Id == 0)
                {
                    text = "registrada";
                    dao.Insert(_venda);
                    CloseFormVerify();
                }
                else
                    dao.Update(_venda);



                MessageBox.Show($"A venda foi {text}", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "não executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void fillForm()
        {
            try
            {
                var dao = new VendaDAO();
                _venda = dao.GetById(_id);

                /*if (!recebe_data.Text.Equals(""))
                    _venda.DataVenda = Convert.ToDateTime(recebe_data.Text);

                _venda.QuantidadeParcelas = int.Parse(recebe_quantParcelas.Text);

                if (!recebe_dataVencimento.Text.Equals(""))
                    _venda.DataVencimentoParcela = Convert.ToDateTime(recebe_dataVencimento.Text);

                if (recebe_formaPagamento.SelectedItem != null)
                    _venda.Forma_Pagamento = recebe_formaPagamento.SelectedItem as string;

                _venda.Valor = double.Parse(recebe_valorFinal.Text);

                if (recebe_cliente.SelectedItem != null)
                    _venda.Cliente.Nome_Cliente = recebe_cliente.SelectedItem as string;

                if (recebe_nomeProduto.SelectedItem != null)
                    _venda.Produto.Nome = recebe_nomeProduto.SelectedItem as string;

                _venda.Produto.Valor_Produto = double.Parse(recebe_valorProduto.Text);*/


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseFormVerify()
        {
            var result = MessageBox.Show("Deseja continuar?", "continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.No)
                this.Close();
            else
                ClearInputs();
        }

        private void ClearInputs()
        {
            recebe_cliente.Text = "";
            recebe_data.Text = "";

           /* recebe_dataVencimento.Text = "";
            recebe_formaPagamento.Text = "";
            recebe_idganhos.Text = "";

            recebe_nomeProduto.Text = "";
            recebe_quantidade.Text = "";
            recebe_quantParcelas.Text = "";
            recebe_valorFinal.Text = "";*/

            //recebe_valorProduto.Text = "";
        }

        private double UpdateValorTotal()
        {
            double valor = 0.0;

            _vendaItensList.ForEach(item => valor += item.ValorTotal);

            recebe_valorTotal.Text = valor.ToString("C");

            return valor;
        }

        private void AdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            var window = new VendaProdutoList();
            window.ShowDialog();

            var produtosselecionadoslist = window.ProdutosSelecionados;

            var count = 1;

            foreach(Produto produto in produtosselecionadoslist)
            {
                if (!_vendaItensList.Exists(item => item.Produto.Id == produto.Id))
                {
                    _vendaItensList.Add(new VendaProduto()
                    {
                        Id = count,
                        Produto = produto,
                        Quantidade = 1,
                        Valor = produto.Valor_Produto,
                        ValorTotal = produto.Valor_Produto
                    });
                }

                count++;
            }

            
            LoadDataGrid();

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var itemSelected = dataGridProdutosVenda.SelectedItem as VendaProduto;
            _vendaItensList.Remove(itemSelected);
            LoadDataGrid();
        }

        private void dataGridProdutosVenda_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var item = e.Row.Item as VendaProduto;
            var value = (e.EditingElement as TextBox).Text;

            _ = int.TryParse(value, out int quant);

            if (quant > 1)
            {
                item.Quantidade = quant;
                item.ValorTotal = quant * item.Valor;
            }
            LoadDataGrid();
        }
    }
}