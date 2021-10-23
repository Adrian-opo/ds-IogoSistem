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
    /// Lógica interna para Ajuda.xaml
    /// </summary>
    public partial class Ajuda : Window
    {
        public Ajuda()
        {
            InitializeComponent();
        }

        private void BtnManual(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", "https://1drv.ms/w/s!AnSJkZzABmWdgbE6VM6K3l6YuUwrtg?e=hYAgTF");
        }

        private void AssistenciaRemota_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", "https://meet.google.com/sne-jubo-skb");

        }

        private void EnviarEmail_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", "https://mail.google.com/mail/u/0/#inbox");
        }
    }
}
