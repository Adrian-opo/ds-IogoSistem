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
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM fornecedor WHERE id_fornecedor=@id";

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Não foi removido da sua casa amém");

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

        public Fornecedor GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM fornecedor WHERE id_fornecedor= @id";


                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("nenhum registro foi encontrado");

                var fornecedor = new Fornecedor();

                while (reader.Read())
                {

                    fornecedor.Id =reader.GetInt32("id_fornecedor");

                    fornecedor.RazaoSocial =reader.GetString("razaoSocial_for");
                    fornecedor.CNPJ = reader.GetString("cnpj_for");

                    fornecedor.Nome = reader.GetString("nome_for");
                    fornecedor.CPF = reader.GetString("cpf_for");
                    fornecedor.RG = reader.GetString("rg_for");

                    fornecedor.Telefone = reader.GetString("telefone_for");
                    fornecedor.Celular = reader.GetString("celular_for");
                    fornecedor.Email = reader.GetString("email_for");
                    fornecedor.ProdutoFornecido = reader.GetString("produtofornecido_for");
                    fornecedor.Complemento = reader.GetString("complento_for");

                }
                return fornecedor;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
        }

        public void Insert(Fornecedor t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO fornecedor (nome_for ,telefone_for ,cpf_for ,rg_for, email_for, produtoFornecido_for, celular_for, razaoSocial_for, cnpj_for, complento_for, id_endereco_fk  ) " +
                    "VALUES (@nome,@telefone,@cpf,@rg,@email,@produtoFornecido,@celular,@razaoSocial,@cnpj,@complemento, @id_endereço_fk )";

                

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@produtoFornecido", t.ProdutoFornecido);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@razaoSocial", t.RazaoSocial);
                query.Parameters.AddWithValue("@cnpj", t.CNPJ);
                query.Parameters.AddWithValue("@complemento", t.Complemento);

                query.Parameters.AddWithValue("@id_endereço_fk", t.Lagradouro);
                query.Parameters.AddWithValue("@id_endereço_fk", t.Numero);
                query.Parameters.AddWithValue("@id_endereço_fk", t.Bairro);
                query.Parameters.AddWithValue("@id_endereço_fk", t.Cidade);
                query.Parameters.AddWithValue("@id_endereço_fk", t.UF);
                query.Parameters.AddWithValue("@id_endereço_fk", t.CEP);



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
            try
            {
                List<Fornecedor> list = new List<Fornecedor>();
                var query = conn.Query();
                query.CommandText = "Select * FROM Fornecedor";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Fornecedor()
                    {
                        Id = reader.GetInt32("id_fornecedor"),
                        Nome = reader.GetString("nome_for")
                    });
                }

                return list;
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

        public void Update(Fornecedor t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE Fornecedor SET nome_for=@nome ,telefone_for=@telefone ,cpf_for=@cpf ,rg_for=@rg, email_for=@email, produtoFornecido_for=@produtoFornecido, celular_for=@celular, razaoSocial_for=@razaoSocial, cnpj_for=@cnpj, complento_for=@complemento WHERE id_fornecedor=@id";

                query.Parameters.AddWithValue("@razaoSocial", t.RazaoSocial);
                query.Parameters.AddWithValue("@cnpj", t.CNPJ);

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);

                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@produtoFornecido", t.ProdutoFornecido);
                query.Parameters.AddWithValue("@Complemento", t.Complemento);

                query.Parameters.AddWithValue("@id", t.Id);


                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Atualização nao realizada");

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
    }
}
