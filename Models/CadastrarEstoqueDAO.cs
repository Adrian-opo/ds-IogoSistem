using IogoSistem.Database;
using IogoSistem.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IogoSistem.Models
{
    class CadastrarEstoqueDAO : IDAO<Produto>
    {

        private static Conexao conn;

        public CadastrarEstoqueDAO()
        {
            conn = new Conexao();
        }
        public void Delete(Produto t)
        {
            throw new NotImplementedException();
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

                Produto produto = null;

                while (reader.Read())
                {
                    produto = new Produto();
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
                     
                        Estoque = reader.GetInt32("estoque_prod"),
                      


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
                query.CommandText = "UPDATE produto SET estoque_prod=@estoque WHERE id_produto=@id";


               
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

