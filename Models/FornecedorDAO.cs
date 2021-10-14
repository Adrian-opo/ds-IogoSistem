using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IogoSistem.Interfaces;
using IogoSistem.Database;
using MySql.Data.MySqlClient;

namespace IogoSistem.Models
{
    class FornecedorDAO : IDAO<Fornecedor>
    {
        private static Conexao conn;

        public FornecedorDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Fornecedor t)
        {
            throw new NotImplementedException();
        }

        public Fornecedor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Fornecedor t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO fornecedor (nome_for ,telefone_for ,cpf_for ,rg_for, email_for, produtoFornecido_for, celular_for, nomeFantasia_for, razãoSocial_for, cnpj_for, complento_for ) " +
                    "VALUES (@nome,@telefone,@cpf,@rg,@email,@produtoFornecido,@celular,@nomeFantasia,@razaoSocial,@cnpj,@complemento)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@produtoFornecido", t.ProdutoFornecido);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@nomeFantasia", t.NomeFantasia);
                query.Parameters.AddWithValue("@razaoSocial", t.RazaoSocial);
                query.Parameters.AddWithValue("@cnpj", t.CNPJ);
                query.Parameters.AddWithValue("@complemento", t.Complemento);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido, troxa");

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Fornecedor> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Fornecedor t)
        {
            throw new NotImplementedException();
        }
    }
}
