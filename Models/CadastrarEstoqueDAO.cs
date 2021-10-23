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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }

       
    }

