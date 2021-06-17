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
            for(int i=1; i<=24; i++)
            {
                listaAgenda.Add(new Evento()
                {
                    Horas = i+":00",
                    Domingo = "X",
                    Segunda = "X",
                    Terca = "X",
                    Quarta = "X",
                    Quinta = "X",
                    Sexta = "X",
                    Sabado = "X"
                    
                });
            }



            //dataGridAgenda.ItemsSource = listaAgenda; 
                
        }

    }
}
