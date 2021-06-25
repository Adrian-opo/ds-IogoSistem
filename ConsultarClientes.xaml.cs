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
    /// Lógica interna para ConsultarClientes.xaml
    /// </summary>
    public partial class ConsultarClientes : Window
    {
        public ConsultarClientes()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            
        }
    }
}
