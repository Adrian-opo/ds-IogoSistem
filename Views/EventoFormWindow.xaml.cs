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
    /// Lógica interna para EventoFormWindow.xaml
    /// </summary>
    public partial class EventoFormWindow : Window
    {

        private int _id;

        private Evento _evento;
        public EventoFormWindow()
        {
            InitializeComponent();

            Loaded += EventoFormWindow_Loaded;
        }

        public EventoFormWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += EventoFormWindow_Loaded;

        }

        private void EventoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _evento = new Evento();
            LoadDataGrid();
            if (_id > 0)
                fillForm();

        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new EventoDAO();

                dataGridEvento.ItemsSource = dao.List();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void fillForm()
        {
            try
            {
                var dao = new EventoDAO();
                _evento = dao.GetById(_id);

                txt_Tipo.Text = _evento.Tipo;
                txt_observacao.Text = _evento.Descricao;
                dtPickerDataInicio.SelectedDate = _evento.Inicio;
                dtPickerDataFim.SelectedDate = _evento.Fim;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_salvar(object sender, RoutedEventArgs e)
        {
            _evento.Descricao = txt_observacao.Text;
            _evento.Tipo = txt_Tipo.Text;
            if (dtPickerDataInicio.SelectedDate != null)
                _evento.Inicio = (DateTime)dtPickerDataInicio.SelectedDate;
            if (dtPickerDataFim.SelectedDate != null)
                _evento.Fim = (DateTime)dtPickerDataFim.SelectedDate;

            SaveData();
        }
        private void SaveData()
        {
            try
            {
                var dao = new EventoDAO();
                var text = "Atualizado";

                if (_evento.Id == 0)
                {
                    text = "cadastrado";
                    dao.Insert(_evento);
                    CloseFormVerify();
                }
                else
                    dao.Update(_evento);
                    MessageBox.Show($"O funcionario foi {text}", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
               
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
            txt_Tipo.Text = "";
            txt_observacao.Text = "";
            dtPickerDataFim.SelectedDate = null;
            dtPickerDataInicio.SelectedDate = null;
        }

    }


}
