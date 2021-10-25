using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IogoSistem.Models
{
    class Venda
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public DateTime DataVencimentoParcela { get; set; }
        public int QuantidadeParcelas { get; set; }
        public double Valor { get; set; }
        public Produto Produto { get; set; }
        public Cliente Cliente { get; set; }

        public Funcionario Funcionario { get; set; }
        
    }
}
