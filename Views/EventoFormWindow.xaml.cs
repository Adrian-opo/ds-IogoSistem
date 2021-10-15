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
        public EventoFormWindow()
        {
            InitializeComponent();

            Loaded += EventoFormWindow_Loaded;
        }

        private void EventoFormWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn_limpar_Click(object sender, RoutedEventArgs e)
        {

        }
    }


}
