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
    /// Interação lógica para FornecedorFormWindow.xam
    /// </summary>
    public partial class FornecedorFormWindow : Window
    {
        private int _id;
        private Fornecedor _fornecedor;

        public FornecedorFormWindow()
        {
            InitializeComponent();
            Loaded += FornecedorFormWindow_Loaded;
        }

        public FornecedorFormWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += FornecedorFormWindow_Loaded;
        }

        private void FornecedorFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _fornecedor = new Fornecedor();
            if (_id > 0)
                fillForm();
        }
    }
}
