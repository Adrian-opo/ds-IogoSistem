using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IogoSistem.Models
{
    class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Ativo { get; set; }
        public Funcionario Funcionario { get; set; }

        private static Usuario _instance;
        public Usuario() { }

        public static Usuario GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Usuario();
            }
            return _instance;
        }
        public static bool Login(string usuario, string senha)
        {
            var user = new UsuarioDAO().GetByUsuario(usuario,senha);

            if (user != null)
                return true;
            
            
            return false;
        }

    }
   
}
