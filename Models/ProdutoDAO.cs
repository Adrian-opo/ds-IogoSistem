using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IogoSistem.Interfaces;
using IogoSistem.Database;
using MySql.Data.MySqlClient;
using System.Data;

namespace IogoSistem.Models
{
    class ProdutoDAO : IDAO<Produto>
    {
        private static Conexao conn;

        public ProdutoDAO()
        {
            conn = new Conexao();
        }
        public void Delete(Produto t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM produto WHERE id_produto=@id";

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

        public Produto GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM produto WHERE id_produto= @id";


                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("nenhum registro foi encontrado");

                var produto = new Produto();

                while (reader.Read())
                {
                    produto.Id = reader.GetInt32("id_produto");
                    produto.Nome = reader.GetString("nome_prod");
                    produto.Descricao = reader.GetString("descricao_prod");
                    produto.Estoque = reader.GetInt32("estoque_prod");
                    produto.Sabor = reader.GetString("sabor_prod");
                    produto.Medida = reader.GetString("medida_prod");
                    produto.Valor_Produto = reader.GetDouble("valorVenda_prod");


                }
                return produto;
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

        public void Insert(Produto t)
        {
            try
            {
                var query = conn.Query();
                //query.CommandText = "CALL cadastrarProduto (@descricao,@nome,@sabor,@medida,@valorVenda,@estoque)";
                query.CommandText = "cadastrarProduto";
                query.CommandType = CommandType.StoredProcedure;


                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@sabor", t.Sabor);
                query.Parameters.AddWithValue("@medida", t.Medida);
                query.Parameters.AddWithValue("@valorVenda", t.Valor_Produto);
                query.Parameters.AddWithValue("@estoque", t.Estoque);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido, tu é burro");

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

        public List<Produto> List()
        {
            try
            {
                List<Produto> list = new List<Produto>();
                var query = conn.Query();
                query.CommandText = "Select * FROM Produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Produto()
                    {
                        Id = reader.GetInt32("id_produto"),
                        Nome = reader.GetString("nome_prod"),
                        Descricao = reader.GetString("descricao_prod"),
                        Estoque = reader.GetInt32("estoque_prod"),
                        Sabor = reader.GetString("sabor_prod"),
                        Medida = reader.GetString("medida_prod"),
                        Valor_Produto = reader.GetDouble("valorVenda_prod"),
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

        public void Update(Produto t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE produto SET descricao_prod=@descricao, nome_prod=@nome, sabor_prod=@sabor, medida_prod=@medida, valorVenda_prod=@valor_venda, estoque_prod=@estoque WHERE id_produto=@id";


                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@sabor", t.Sabor);
                query.Parameters.AddWithValue("@medida", t.Medida);
                query.Parameters.AddWithValue("@valor_venda", t.Valor_Produto);
                query.Parameters.AddWithValue("@estoque", t.Estoque);
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







