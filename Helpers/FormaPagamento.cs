using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IogoSistem.Helpers
{
    public class FormaPagamento
    {

        public static List<string> List()
        {
            List<string> formaPagamento = new List<string>
            {
                "Dinheiro",
                "Cartão de Crédiro",
                "Cartão de Débito",
                "Cheque á Vista"

            };

            return formaPagamento;
        }
    }
}
