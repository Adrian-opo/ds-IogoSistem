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
    /// Lógica interna para Agenda.xaml
    /// </summary>
    public partial class Agenda : Window
    {

        public Agenda()
        {
            InitializeComponent();
            Loaded += Agenda_Loaded;
            
        }

        private void Agenda_Loaded(object sender, RoutedEventArgs e)
        {
            List<Evento> listaAgenda = new List<Evento>();
            List<Evento> listaAgendames = new List<Evento>();

            for(int i=1; i<=24; i++)
            {
                listaAgenda.Add(new Evento()
                {
                    Horas = i+":00",
                    Domingo = "x",
                    Segunda = "X",
                    Terca = "X",
                    Quarta = "X",
                    Quinta = "X",
                    Sexta = "X",
                    Sabado = "X"
                    
                });

                listaAgendames.Add(new Evento()
                {
                    Semana1="abc",
                    Semana2="abc",
                    Semana3="abc",
                    Semana4="abc"
                });

                
            }



            dataGridAgenda.ItemsSource = listaAgenda;
            dataGridAgenda1.ItemsSource = listaAgendames;
                
        }


        private void Btn_Semana(object sender, RoutedEventArgs e)
        {
            Btn_semana.Background = Brushes.White;
            Btn_mes.Background = new SolidColorBrush(Color.FromArgb(255, 0, 169, 255));
            dataGridAgenda.Visibility = Visibility.Visible;
            dataGridAgenda1.Visibility = Visibility.Collapsed;

            
        }

        private void Btn_Mes(object sender, RoutedEventArgs e)
        {

            Btn_mes.Background = Brushes.White;
            Btn_semana.Background = new SolidColorBrush(Color.FromArgb(255, 0, 169, 255));
            dataGridAgenda.Visibility = Visibility.Collapsed;
            dataGridAgenda1.Visibility = Visibility.Visible;
        }
    }
}
