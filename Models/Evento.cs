using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IogoSistem.Models
{
    class Evento
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public string Descricao { get; set; }
    }
}
