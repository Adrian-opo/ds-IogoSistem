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
    /// Lógica interna para ProdutoFormWindow.xaml
    /// </summary>
    public partial class ProdutoFormWindow : Window
    {

        private int _id;

        private Produto _produto;

        public ProdutoFormWindow()
        {
            InitializeComponent();
            Loaded += ProdutoFormWindow_Loaded;
        }

        public ProdutoFormWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += ProdutoFormWindow_Loaded;
        }

        private void ProdutoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _produto = new Produto();
            if (_id > 0)
                fillForm();

        }



        private void SaveData()
        {
            try
            {
                var dao = new ProdutoDAO();
                var text = "Atualizado";

                if (_produto.Id == 0)
                {
                    text = "cadastrado";
                    dao.Insert(_produto);
                    CloseFormVerify();
                }
                else
                    dao.Update(_produto);



                MessageBox.Show($"O produto foi {text}", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var dao = new ProdutoDAO();
                _produto = dao.GetById(_id);

                Nome.Text = _produto.Nome;
                Medida.Text = _produto.Medida;
                Sabor.Text = _produto.Sabor;
                Valor.Text = _produto.Valor_Produto.ToString();
                Descrição.Text = _produto.Descricao;
                Estoque.Text = _produto.Estoque.ToString();
                Id.Text = _produto.Id.ToString();





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
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
            Nome.Text = "";
            Medida.Text = "";
            Sabor.Text = "";
            Valor.Text = "";
            Descrição.Text = "";
        }

        private void Abrir_Pesquisa(object sender, RoutedEventArgs e)
        {
            var window = new ProdutoListWindow();
            window.ShowDialog();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)

        {
            _produto.Descricao = Descrição.Text;
            _produto.Nome = Nome.Text;
            _produto.Medida = Medida.Text;
            _produto.Sabor = Sabor.Text;
            _produto.Valor_Produto = double.Parse(Valor.Text);
            _produto.Estoque = int.Parse(Estoque.Text);

            SaveData();
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
