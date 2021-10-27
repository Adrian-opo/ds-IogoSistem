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
    /// Interaction logic for FuncionarioListWindow.xaml
    /// </summary>
    public partial class FuncionarioListWindow : Window
    {

        public FuncionarioListWindow()
        {
            InitializeComponent();
            Loaded += FuncionarioListWindow_Loaded;
        }

        private void FuncionarioListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }




        private void LoadDataGrid()
        {
            try
            {
                var dao = new FuncionarioDAO();
                dataGridConsultarfuncionario.ItemsSource = dao.List();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Add_novo_click(object sender, RoutedEventArgs e)
        {
            var window = new FuncionarioFormWindow();
            window.ShowDialog();
            LoadDataGrid();
        }

        private void BtnUpdate_fun_Click(object sender, RoutedEventArgs e)
        {

            var funcionarioselected = dataGridConsultarfuncionario.SelectedItem as Funcionario;

            var window = new FuncionarioFormWindow(funcionarioselected.Id);
            window.ShowDialog();
            LoadDataGrid();


        }

        private void BtnDelete_fun_Click(object sender, RoutedEventArgs e)
        {
            var funcionarioselected = dataGridConsultarfuncionario.SelectedItem as Funcionario;

            var result = MessageBox.Show($"Deseja realmente remover o funcionario `{funcionarioselected.Nome}`?", "confirmação de exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new FuncionarioDAO();
                    dao.Delete(funcionarioselected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void nameuser_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
