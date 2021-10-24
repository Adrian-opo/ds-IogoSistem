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
using IogoSistem.Helpers;

namespace IogoSistem.Views
{
    /// <summary>
    /// Interação lógica para FornecedorFormWindow.xam
    /// </summary>
    public partial class FornecedorFormWindow : Window
    {
        private int _id;
        private Fornecedor _fornecedor;

        public FornecedorFormWindow()
        {
            InitializeComponent();
            Loaded += FornecedorFormWindow_Loaded;
        }

        public FornecedorFormWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += FornecedorFormWindow_Loaded;
        }

        private void FornecedorFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _fornecedor = new Fornecedor();

            LoadComboBox();

            if (_id > 0)
                fillForm();
        }

        private void LoadComboBox()
        {
            try
            {
                recebe_uf.ItemsSource = Estado.List();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            _fornecedor.Nome = recebe_nome.Text;
            _fornecedor.RazaoSocial = recebe_razaosocial.Text;
            _fornecedor.CNPJ = recebe_cnpj.Text;

            _fornecedor.CPF = recebe_cpf.Text;
            _fornecedor.RG = recebe_rg.Text;

            _fornecedor.Telefone = recebe_telefone.Text;
            _fornecedor.Celular = recebe_celular.Text;
            _fornecedor.Email = recebe_email.Text;
            _fornecedor.ProdutoFornecido = recebe_produtofornecido.Text;
            _fornecedor.Complemento = recebe_complemento.Text;

            _fornecedor.Endereco = new Endereco();

            _fornecedor.Endereco.Lagradouro = recebe_lagradouro.Text;

            if(int.TryParse(recebe_numero.Text, out int numero))
                _fornecedor.Endereco.Numero = numero;

            if (recebe_uf.SelectedItem != null)
                _fornecedor.Endereco.UF = recebe_uf.SelectedItem as string;

            _fornecedor.Endereco.Bairro = recebe_bairro.Text;
            _fornecedor.Endereco.Cidade = recebe_cidade.Text;
            _fornecedor.Endereco.CEP = recebe_cep.Text;

            SaveData();
           
        }


        private void SaveData()
        {
            try
            {
                var dao = new FornecedorDAO();
                var text = "Atualizado";

                if (_fornecedor.Id == 0)
                {
                    text = "cadastrado";
                    dao.Insert(_fornecedor);
                    CloseFormVerify();
                }
                else
                    dao.Update(_fornecedor);



                MessageBox.Show($"O funcionario foi {text}", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var dao = new FornecedorDAO();
                _fornecedor = dao.GetById(_id);

                recebe_razaosocial.Text = _fornecedor.RazaoSocial;
                recebe_cnpj.Text = _fornecedor.CNPJ;

                recebe_nome.Text = _fornecedor.Nome;
                recebe_cpf.Text = _fornecedor.CPF;
                recebe_rg.Text = _fornecedor.RG;

                recebe_telefone.Text = _fornecedor.Telefone;
                recebe_celular.Text = _fornecedor.Celular;
                recebe_email.Text = _fornecedor.Email;
                recebe_produtofornecido.Text = _fornecedor.ProdutoFornecido;
                recebe_complemento.Text = _fornecedor.Complemento;

                if (_fornecedor.Endereco != null)
                {
                    recebe_lagradouro.Text = _fornecedor.Endereco.Lagradouro;
                    recebe_numero.Text = _fornecedor.Endereco.Numero.ToString();
                    recebe_bairro.Text = _fornecedor.Endereco.Bairro;
                    recebe_cep.Text = _fornecedor.Endereco.CEP;
                    recebe_cidade.Text = _fornecedor.Endereco.Cidade;


                    recebe_uf.SelectedValue = _fornecedor.Endereco.UF;
                }


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
            recebe_razaosocial.Text = "";
            recebe_cnpj.Text = "";

            recebe_nome.Text = "";
            recebe_cpf.Text = "";
            recebe_rg.Text = "";

            recebe_telefone.Text = "";
            recebe_celular.Text = "";
            recebe_email.Text = "";
            recebe_produtofornecido.Text = "";
            recebe_complemento.Text = "";
        }

        private void recebe_numero_KeyDown(object sender, KeyEventArgs e)
        {
            KeyConverter key = new KeyConverter();

            if ((char.IsNumber((string)key.ConvertTo(e.Key, typeof(string)), 0) == false))
            {
                e.Handled = true;
            }
        }
    }
}