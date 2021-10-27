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
    /// Lógica interna para CaixaFormWindow.xaml
    /// </summary>
    public partial class CaixaFormWindow : Window
    {

        private int _id;
        private Caixa _caixa;

        public CaixaFormWindow()
        {
            InitializeComponent();
            Loaded += CaixaFormWindow_Loaded;
        }

        public CaixaFormWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += CaixaFormWindow_Loaded;
        }


        private void CaixaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _caixa = new Caixa();
            if (_id > 0)
                fillForm();
        }

        private void fillForm()
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Salvo com sucesso");
        }

        private void txt_Tipo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_numerocaixa(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FillForm()
        {

            try
            {
                var dao = new CaixaDAO();
                _caixa = dao.GetById(_id);

                // recebe_id.Text = _caixa.Id.ToString();            
                //recebe_Datafechamento.Text = _caixa.DataFechamento.ToString("yyyy-mm-dd");             
                //recebe_DataAbertura.Text = _caixa.DataAbertura.ToString("yyyy-mm-dd");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txt_observacoes_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void wpftooldataabertura_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void recebe_id_caixatext(object sender, TextChangedEventArgs e)
        {

        }

        private void textboxsaldoanterior_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textboxsaldoanterior_Copy2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}