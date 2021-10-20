using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IogoSistem.Interfaces;
using IogoSistem.Database;
using MySql.Data.MySqlClient;

namespace IogoSistem.Models
{/*
    class VendaDAO : IDAO<Venda>
    {
        private static Conexao conn;

        public VendaDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Venda t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM venda WHERE id_venda=@id";

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

        public Venda GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM venda WHERE id_venda= @id";


                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("nenhum registro foi encontrado");

                var venda = new Venda();

                while (reader.Read())
                {
                    venda.Id = reader.GetInt32("id_venda");

                    venda.id_cliente = int.Parse(reader.GetString("id_cliente_fk"));
                    venda.DataVenda = DateTime.Parse(reader.GetString("data_vend"));
                    venda.DataVencimentoParcela = DateTime.Parse(reader.GetString("data_Vencimento_vend"));
                    venda.CNPJ = reader.GetString("cnpj_for");

                    venda.Nome = reader.GetString("nome_for");
                    venda.CPF = reader.GetString("cpf_for");
                    venda.RG = reader.GetString("rg_for");

                    venda.Telefone = reader.GetString("telefone_for");
                    venda.Celular = reader.GetString("celular_for");
                    venda.Email = reader.GetString("email_for");
                    venda.ProdutoFornecido = reader.GetString("produtofornecido_for");
                    venda.Complemento = reader.GetString("complento_for");

                }
                return venda;
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

        public void Insert(Venda t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO fornecedor (nome_for ,telefone_for ,cpf_for ,rg_for, email_for, produtoFornecido_for, celular_for, nomeFantasia_for, razaoSocial_for, cnpj_for, complento_for ) " +
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
        public List<Venda> List()
        {
            try
            {
                List<Venda> list = new List<Venda>();
                var query = conn.Query();
                query.CommandText = "Select * FROM Venda";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Venda()
                    {
                        Id = reader.GetInt32("id_usuario"),
                        Nome = reader.GetString("nome_for"),
                        NomeFantasia = reader.GetString("nomefantasia_for"),
                        CPF = reader.GetString("cpf_for"),
                        CNPJ = reader.GetString("cnpj_for"),
                        Email = reader.GetString("email_for")

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

        public void Update(Venda t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE Venda SET nome_for=@nome ,telefone_for=@telefone ,cpf_for=@cpf ,rg_for=@rg, email_for=@email, produtoFornecido_for=@produtoFornecido, celular_for=@celular, nomeFantasia_for=@nomeFantasia, razaoSocial_for=@razaoSocial, cnpj_for=@cnpj, complento_for=@complemento WHERE id_fornecedor=@id";

                query.Parameters.AddWithValue("@nomeFantasia", t.NomeFantasia);
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
    */
}
