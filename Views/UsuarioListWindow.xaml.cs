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
    /// Lógica interna para UsuarioListWindow.xaml
    /// </summary>
    public partial class UsuarioListWindow : Window
    {
        private List<Usuario> _userlist = new List<Usuario>();

        public UsuarioListWindow()
        {
            InitializeComponent();
            Loaded += UsuarioListWindow_Loaded;
        }

        private void UsuarioListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {

                _userlist = new UsuarioDAO().List();

                dataGridConsultarusuario.ItemsSource = _userlist;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnNovo_Click(object sender, RoutedEventArgs e)
        {
            var window = new UsuarioFormWindow();
            window.ShowDialog();
            LoadDataGrid();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var userselected = dataGridConsultarusuario.SelectedItem as Usuario;

            var window = new UsuarioFormWindow(userselected.Id);
            window.ShowDialog();
            LoadDataGrid();

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var userselected = dataGridConsultarusuario.SelectedItem as Usuario;
            var result = MessageBox.Show($"Deseja remover o funcionario {userselected.Nome}?", "Confirmação de exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new UsuarioDAO();
                    dao.Delete(userselected);
                    LoadDataGrid();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exeção", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var text = txtSearch.Text;

            var filterlist=_userlist.Where(i => i.Nome.ToLower().Contains(text));
            dataGridConsultarusuario.ItemsSource = filterlist;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
