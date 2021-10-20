﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IogoSistem.Models
{
    class Endereco
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Lagradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidadade { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }
    }
}
