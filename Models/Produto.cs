using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IogoSistem.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public string Nome { get; set; }
        public string Sabor { get; set; }
        public string Medida { get; set; }
        public double Valor_Produto { get; set; }
        public int Estoque { get; set; }
        private bool _selected = false;

        public bool IsSelected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }


    }
}
