using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IogoSistem.Database;

namespace IogoSistem.Models
{
    class EnderecoDAO
    {
        private static Conexao conn = new Conexao();
        public long Insert(Endereco t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO endereco (rua_end, numero_end, bairro_end, cidade_end, uf_end, cep_end, pais_end) " +
                    "VALUES (@rua, @numero, @bairro, @cidade, @uf, @cep, @pais)";

                query.Parameters.AddWithValue("@rua", t.Lagradouro);
                query.Parameters.AddWithValue("@numero", t.Numero);
                query.Parameters.AddWithValue("@bairro", t.Bairro);
                query.Parameters.AddWithValue("@cidade", t.Cidade);
                query.Parameters.AddWithValue("@uf", t.UF);
                query.Parameters.AddWithValue("@cep", t.CEP);
                query.Parameters.AddWithValue("@pais", "-");
                

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Erro ao salvar o endereço. Verifique e tente novamente.");

                return query.LastInsertedId;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Update(Endereco t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE endereco SET rua_end= @rua, numero_end=@numero, bairro_end=@bairro, cidade_end=@cidade, uf_end=@uf, cep_end=@cep, pais_end=@pais ";

                query.Parameters.AddWithValue("@rua", t.Lagradouro);
                query.Parameters.AddWithValue("@numero", t.Numero);
                query.Parameters.AddWithValue("@bairro", t.Bairro);
                query.Parameters.AddWithValue("@cidade", t.Cidade);
                query.Parameters.AddWithValue("@uf", t.UF);
                query.Parameters.AddWithValue("@pais", "-");

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Erro ao atualizar o endereço. Verifique e tente novamente.");

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
