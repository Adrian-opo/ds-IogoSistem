using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IogoSistem.Models
{
    class Caixa
    {


        public DateTime DataFechamento_cai { get; set; }

        public DateTime DataAbertura_cai { get; set; }

        public string SaldoAnterior_cai { get; set; }

        public string ValorDebito_cai { get; set; }

        public string Observacoes_cai { get; set; }

        public string ValorCredito_cai { get; set; }

        public double Saldo_cai { get; set; }

        public Caixa caixa { get; set; }

        public int Id { get; internal set; }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }



    }
}