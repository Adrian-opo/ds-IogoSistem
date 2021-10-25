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


        private void EventoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _evento = new Evento();
            LoadDataGrid();

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
                if (Validate())
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
                    {

                    
                        dao.Update(_evento);
                        MessageBox.Show($"O funcionario foi {text}", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                        ClearInputs();
                        _evento.Id = 0;
              

                    }

                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "não executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private bool Validate()
        {
            var validator = new EventoValidator();
            var result = validator.Validate(_evento);

            if (!result.IsValid)
            {
                string errors = null;
                var count = 1;

                foreach (var faliure in result.Errors)
                {
                    errors += $"{count++} -{faliure.ErrorMessage}\n";
                }
                MessageBox.Show(errors, "validação de dados", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            return result.IsValid;
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

        private void BtnDeleta_Click(object sender, RoutedEventArgs e)
        {
            var eventoselect = dataGridEvento.SelectedItem as Evento;
            var result = MessageBox.Show($"Deseja remover o funcionario {eventoselect.Tipo}?", "Confirmação de exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new EventoDAO();
                    dao.Delete(eventoselect);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exeção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var userselected = dataGridEvento.SelectedItem as Evento;
            _id = userselected.Id;

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

        private void Limpar_campos(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }


}
