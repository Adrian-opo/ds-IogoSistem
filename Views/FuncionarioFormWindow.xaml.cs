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
    /// Interaction logic for FuncionarioFormWindow.xaml
    /// </summary>
    public partial class FuncionarioFormWindow : Window
    {

        private int _id;

        private Funcionario _funcionario;

        public FuncionarioFormWindow()
        {
            InitializeComponent();
            Loaded += FuncionarioFormWindow_Loaded;
        }

        public FuncionarioFormWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += FuncionarioFormWindow_Loaded;
        }

        private void FuncionarioFormWindow_Loaded(object sender, RoutedEventArgs e)
        {

            _funcionario = new Funcionario();
            if (_id > 0)
                FillForm();


        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

            _funcionario.Nome = txtNome.Text;
            _funcionario.CPF = TxtBox_RecebeCPF.Text;
            _funcionario.Email = recebe_email.Text;
            _funcionario.Telefone = recebe_telefone.Text;
            _funcionario.Endereco = recebe_Endereco.Text;
            _funcionario.RG = recebe_rg.Text;
            _funcionario.PCD = recebe_PCD.Text;
            _funcionario.NumeroCarteira = recebe_NCarteira.Text;
            _funcionario.Salario = recebe_Tipo_Salario.Text;
            _funcionario.SetorTrabalho = recebe_SetorTrabalho.Text;
            _funcionario.CargaHoraria = recebe_CargaHoraria.Text;

            if (!recebe_DataNasc.Text.Equals(""))
                _funcionario.DataNascimento = Convert.ToDateTime(recebe_DataNasc.Text);


            if (recebe_DataAdim.Text.Equals(""))
                _funcionario.DataAdimissao = Convert.ToDateTime(recebe_DataAdim.Text);


            SaveData();

        }

        private bool validate()
        {
            var validator = new FuncionarioValitador();
            var result = validator.Validate(_funcionario);

            if (!result.IsValid)
            {
                string errors = null;
                var count = 1;

                foreach (var failure in result.Errors)
                {
                    errors += $"{count++} - {failure.ErrorMessage}\n";
                }
                MessageBox.Show(errors, "validação de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return result.IsValid;
        }

        private void SaveData()
        {

            try
            {
                if (validate())
                {
                    var dao = new FuncionarioDAO();
                    var text = "atualizado";

                    if (_funcionario.Id == 0)
                    {
                        dao.Insert(_funcionario);
                        text = "adicionado";
                    }
                    else
                        dao.Update(_funcionario);
                    MessageBox.Show($"O funcionario foi {text} adicionado com sucesso!", "sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseFormVerify();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "não executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }



        private void FillForm()
        {

            try
            {
                var dao = new FuncionarioDAO();
                _funcionario = dao.GetById(_id);

                recebe_id.Text = _funcionario.Id.ToString();
                txtNome.Text = _funcionario.Nome;
                TxtBox_RecebeCPF.Text = _funcionario.CPF;
                recebe_email.Text = _funcionario.Email;
                recebe_telefone.Text = _funcionario.Telefone;
                recebe_Endereco.Text = _funcionario.Endereco;
                recebe_DataNasc.Text = _funcionario.DataAdimissao?.ToString("yyyy-mm-dd");
                recebe_rg.Text = _funcionario.RG;
                recebe_PCD.Text = _funcionario.PCD;
                recebe_NCarteira.Text = _funcionario.NumeroCarteira;
                recebe_Tipo_Salario.Text = _funcionario.Salario;
                recebe_DataAdim.Text = _funcionario.DataAdimissao?.ToString("yyyy-mm-dd");
                recebe_SetorTrabalho.Text = _funcionario.SetorTrabalho;
                recebe_CargaHoraria.Text = _funcionario.CargaHoraria;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseFormVerify()
        {
            if (_funcionario.Id == 0)
            {

                var result = MessageBox.Show("Deseja continuar adicionando funcionario?", "Continuar?", MessageBoxButton.YesNo, MessageBoxImage.Question);


                if (result == MessageBoxResult.No)

                    this.Close();
                else
                    ClearInputs();
            }

            else
                this.Close();
        }

        private void ClearInputs()
        {
            txtNome.Text = "";
            TxtBox_RecebeCPF.Text = "";
            recebe_email.Text = "";
            recebe_telefone.Text = "";
            recebe_Endereco.Text = "";
            recebe_DataNasc.Text = null;
            recebe_rg.Text = "";
            recebe_PCD.Text = "";
            recebe_NCarteira.Text = "";
            recebe_Tipo_Salario.Text = "";
            recebe_DataAdim.Text = "";
            recebe_SetorTrabalho.Text = "";
            recebe_CargaHoraria.Text = "";

            //           recebe_DataAdim.DataContext = "";

        }




    }
}
