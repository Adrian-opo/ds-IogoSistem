using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IogoSistem.Models
{
    class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public string ProdutoFornecido { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Complemento { get; set; }
        public Endereco Lagradouro { get; set; }
        public Endereco Numero { get; set; }
        public Endereco Bairro { get; set; }
        public Endereco Cidade { get; set; }
        public Endereco UF { get; set; }
        public Endereco CEP { get; set; }

    }
}
