using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IogoSistem.Interfaces;
using IogoSistem.Database;
using MySql.Data.MySqlClient;
using System.Data;
using IogoSistem.Helpers;

namespace IogoSistem.Models
{
    class FornecedorDAO : AbstractDAO<Fornecedor>
    {

        public override void Delete(Fornecedor t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM fornecedor WHERE id_fornecedor=@id";

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O fornecedor não foi removido. Verifique e tente novamente.");

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

        public override Fornecedor GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM fornecedor LEFT JOIN endereco ON id_endereco_fk = id_endereco WHERE id_fornecedor= @id";


                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado.");

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
                    fornecedor.Complemento = reader.GetString("complemento_for");

                    if (!DAOHelper.IsNull(reader, "id_endereco_fk"))
                        fornecedor.Endereco = new Endereco()
                        {
                            Id = reader.GetInt32("id_endereco"),
                            Numero = reader.GetInt32("numero_end"),
                            Lagradouro = reader.GetString("rua_end"),
                            Bairro = reader.GetString("bairro_end"),
                            Cidade = reader.GetString("cidade_end"),
                            UF = reader.GetString("uf_end"),
                            CEP = reader.GetString("cep_end"),
                            Pais = reader.GetString("pais_end")
                        };
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

        public override void Insert(Fornecedor t)
        {
            try
            {
                var enderecoId = new EnderecoDAO().Insert(t.Endereco);

                var query = conn.Query();
                query.CommandText = "INSERT INTO fornecedor (nome_for, telefone_for, cpf_for, rg_for, email_for, produtoFornecido_for, celular_for, razaoSocial_for, cnpj_for, complemento_for, id_endereco_fk)" +
                    "VALUES (@nome, @telefone, @cpf, @rg, @email, @produtoFornecido, @celular, @razaoSocial, @cnpj, @complemento, @id_endereco)";

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

                query.Parameters.AddWithValue("@id_endereco", enderecoId);



                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente.");

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
        public override List<Fornecedor> List()
        {
            try
            {
                List<Fornecedor> list = new List<Fornecedor>();
                var query = conn.Query();
                query.CommandText = "Select id_fornecedor, nome_for FROM Fornecedor";

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

        public override void Update(Fornecedor t)
        {
            try
            {
                long enderecoID = t.Endereco.Id;
                var endDAO = new EnderecoDAO();

                if (enderecoID > 0)
                    endDAO.Update(t.Endereco);
                else
                    enderecoID = endDAO.Insert(t.Endereco);

                var query = conn.Query();
                query.CommandText = "UPDATE Fornecedor SET nome_for=@nome ,telefone_for=@telefone ,cpf_for=@cpf ,rg_for=@rg, email_for=@email, produtoFornecido_for=@produtoFornecido, celular_for=@celular, razaoSocial_for=@razaoSocial, cnpj_for=@cnpj, complemento_for=@complemento, id_endereco_fk=@enderecoID WHERE id_fornecedor=@id";

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

                query.Parameters.AddWithValue("@enderecoId", enderecoID);

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
