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
    class UsuarioDAO : IDAO<Usuario>
    {
        private static Conexao conn;
        
        public UsuarioDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Usuario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM usuario WHERE id_usuario=@id";

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

        public Usuario GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM usuario WHERE id_usuario= @id";


                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader(); 

                if (!reader.HasRows)
                    throw new Exception("nenhum registro foi encontrado");

                var usuario = new Usuario();

                while (reader.Read())
                {
                    usuario.Id = reader.GetInt32("id_usuario");
                    usuario.Nome = reader.GetString("nomeUsuario");
                    usuario.CPF = reader.GetString("cpf_usu");
                    usuario.Email = reader.GetString("email_usu");
                    usuario.Senha = reader.GetString("senha_usu");

                }
                return usuario;
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

        public void Insert(Usuario t)
        {
            try
            {
                var query = conn.Query();

                query.CommandText = "cadastrarUsuario";
                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.AddWithValue("@nomeUser", t.Nome);
                query.Parameters.AddWithValue("@cpf_user", t.CPF);
                query.Parameters.AddWithValue("@email", t.Senha);
                query.Parameters.AddWithValue("@senha", t.Email);

                
                /*
                var query = conn.Query();
                query.CommandText = "INSERT INTO usuario (nomeUsuario,cpf_usu,senha_usu,email_usu) " +
                    "VALUES (@nome,@cpf,@senha,@email)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@senha", t.Senha);
                query.Parameters.AddWithValue("@email", t.Email);

                var result = query.ExecuteNonQuery();

                if(result == 0)
                    throw new Exception("O registro não foi inserido, troxa");
                  */



                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetName(0).Equals("Alerta"))
                    {
                        throw new Exception(reader.GetString("Alerta"));
                    }
                }
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

        public List<Usuario> List()
        {
            try
            {
                List<Usuario> list = new List<Usuario>();
                var query = conn.Query();
                query.CommandText="Select * FROM Usuario";

                MySqlDataReader reader= query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Usuario()
                    {
                        Id = reader.GetInt32("id_usuario"),
                        Nome =reader.GetString("nomeUsuario"),
                        CPF=reader.GetString("cpf_usu"),
                        Email=reader.GetString("email_usu")
                        
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

        public void Update(Usuario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE Usuario SET nomeUsuario=@nome,cpf_usu=@cpf,senha_usu=@senha,email_usu=@email WHERE id_usuario=@id";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@senha", t.Senha);
                query.Parameters.AddWithValue("@email", t.Email);

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
