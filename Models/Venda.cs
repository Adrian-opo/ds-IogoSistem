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
        public DateTime? DataVenda { get; set; }
        public string FormaPagamento { get; set; }
        public double ValorTotal { get; set; }
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public List<VendaProduto> Itens { get; set; } = new List<VendaProduto>();

    }
}
