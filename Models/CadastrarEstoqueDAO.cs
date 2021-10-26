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
            throw new NotImplementedException();
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
                        
                        Nome = reader.GetString("nome_prod")
                       
                     
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

