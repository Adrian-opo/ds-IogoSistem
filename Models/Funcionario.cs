using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IogoSistem.Models
{
    class Funcionario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string RG { get; set; }

        public bool PCD { get; set; }

        public string NumeroCarteira { get; set; }

        public string Salario { get; set; }

        public DateTime? DataAdimissao { get; set; }

        public string SetorTrabalho { get; set; }

        public string CargaHoraria { get; set; }

        public Endereco Endereco { get; set; }




    }
}
