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
    /// Lógica interna para ConsultarUsuario.xaml
    /// </summary>
    public partial class ConsultarUsuario : Window
    {

        public ConsultarUsuario()
        {
            InitializeComponent();
        }
        private object Editar;
        public new object ShowDialog()
        {
            base.ShowDialog();
            return Editar;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Editar = null;
            this.Close();

        }


        private void Agenda_Loaded(object sender, RoutedEventArgs e)
        {

            //banco de dados
            // List<Util> ConsultarUsuariopor = new List<Util>();

            // for (int i = 1; i <= 24; i++)
            //{
            //List<Util> Consultarusuariopor = new List<Util>();

            //{

            //Nome = "x",
            //Email = "x"
            //

        }


        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ConsultarUsuario exclui = new ConsultarUsuario();
            exclui.ShowDialog();
            MessageBox.Show("Excluído com sucesso!");
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Editar_Usuario editarusuario = new Editar_Usuario();
            editarusuario.ShowDialog();
        }

        private void Comboboxconsultarusuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
    