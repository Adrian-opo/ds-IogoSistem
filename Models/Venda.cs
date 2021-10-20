using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IogoSistem.Models
{
    class Venda
    {
        public string Cliente { get; set; }
        public int id_cliente { get; set; }
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public string FormaPagamento { get; set; }
        public int QuantParcelas { get; set; }
        public DateTime DataVencimentoParcela { get; set; }
        public string Produto { get; set; }
        public int id_produto { get; set; }
        public double QuantProduto { get; set; }
        public double Valor { get; set; }

    }
}
