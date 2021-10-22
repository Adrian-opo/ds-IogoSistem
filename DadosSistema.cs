using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IogoSistem.Models;
namespace IogoSistem
{
    static class DadosSistema
    {
        private static Usuario _usuario=null;

        public static void SetUser(Usuario user)
        {
            _usuario = user;
        }

        public static Usuario GetUser()
        {
            return _usuario;
        }
    }
}
