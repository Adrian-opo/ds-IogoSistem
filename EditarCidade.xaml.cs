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

namespace IogoSistem_vs1
{
    /// <summary>
    /// Lógica interna para EditarCidade.xaml
    /// </summary>
    public partial class EditarCidade : Window
    {
        private List<string> cidades;
        private List<string> regioes;

        public EditarCidade()
        {
            InitializeComponent();
            Loaded += EditarCidade_Loaded;
        }

        private void EditarCidade_Loaded(object sender, RoutedEventArgs e)
        {
            //banco de dades
            cidades = new List<string>();

            cidades.Add("");
            cidades.Add("");
            cidades.Add("");
            cidades.Add("");

            comboboxcidadeeditada.ItemsSource = cidades;

            regioes = new List<string>();

            regioes.Add("");
            regioes.Add("");
            regioes.Add("");
            regioes.Add("");

           comboboxeditarregiao.ItemsSource = regioes;


        }

        private void Btn_Salvar(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Salvo com sucesso!");
        }

        private void Btn_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
