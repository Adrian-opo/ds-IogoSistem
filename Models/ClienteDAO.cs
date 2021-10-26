using IogoSistem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IogoSistem.Models
{
    class ClienteDAO
    {
        private static Conexao conn = new Conexao();
        public void Insert(Cliente t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO cliente (nome_cli ) " +
                    "VALUES (@nome)";

                query.Parameters.AddWithValue("@nome", t.Nome_Cliente);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Erro ao salvar o cliente. Verifique e tente novamente.");

                

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Update(Cliente t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE cliente SET nome_cli= @nome ";

                query.Parameters.AddWithValue("@nome_cli", t.Nome_Cliente);

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Erro ao atualizar o cliente. Verifique e tente novamente.");

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
