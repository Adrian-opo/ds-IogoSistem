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
    class UsuarioDAO : AbstractDAO<Usuario>
    {

        public void AtivarUsuario(string nome, string senha)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "ativarusuario";
                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.AddWithValue("@nome_user", nome);
                query.Parameters.AddWithValue("@senha_user", senha);
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

        public Usuario GetByUsuario(string usuarionome, string senha)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM usuario LEFT JOIN funcionario ON id_funcionario=id_funcionario_fk" +
                    " WHERE nomeUsuario=@usuario AND senha_usu=@senha";

                query.Parameters.AddWithValue("@usuario", usuarionome);
                query.Parameters.AddWithValue("@senha", senha);

                MySqlDataReader reader = query.ExecuteReader();

                Usuario usuario = null;

                while (reader.Read())
                {
                    usuario = Usuario.GetInstance();
                    usuario.Id = reader.GetInt32("id_usuario");
                    usuario.Nome = reader.GetString("nomeUsuario");
                    usuario.Funcionario = new Funcionario() { Id = reader.GetInt32("id_funcionario"), Nome = reader.GetString("nome_fun") };

                }


                return usuario;

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

        public override void Delete(Usuario t)
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

        public override Usuario GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM usuario,funcionario WHERE id_usuario=@id";


                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("nenhum registro foi encontrado");

                Usuario usuario = null;

                while (reader.Read())
                {
                    usuario = Usuario.GetInstance();
                    usuario.Id = reader.GetInt32("id_usuario");
                    usuario.Nome = reader.GetString("nomeUsuario");
                    usuario.CPF = reader.GetString("cpf_usu");
                    usuario.Email = reader.GetString("email_usu");
                    usuario.Senha = reader.GetString("senha_usu");
                    usuario.Funcionario = new Funcionario() { Id = reader.GetInt32("id_funcionario"), Nome = reader.GetString("nome_fun") };

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

        public override List<Usuario> List()
        {
            try
            {
                List<Usuario> list = new List<Usuario>();
                var query = conn.Query();
                query.CommandText = "Select id_usuario,nomeUsuario,cpf_usu,email_usu,Id_funcionario,Nome_fun FROM Usuario,funcionario";

                MySqlDataReader reader = query.ExecuteReader();


                while (reader.Read())
                {
                    list.Add(new Usuario()
                    {
                        Id = reader.GetInt32("id_usuario"),
                        Nome = reader.GetString("nomeUsuario"),
                        CPF = reader.GetString("cpf_usu"),
                        Email = reader.GetString("email_usu"),
                        Funcionario = new Funcionario() { Id = reader.GetInt32("id_funcionario"), Nome = reader.GetString("nome_fun") }

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
        public override void Insert(Usuario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "cadastrarUsuario";
                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.AddWithValue("@nomeUser", t.Nome);
                query.Parameters.AddWithValue("@cpf_user", t.CPF);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@senha", t.Senha);


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

        public override void Update(Usuario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE usuario SET nomeUsuario=@nome, cpf_usu=@cpf, email_usu=@email, senha_usu=@senha  WHERE id_usuario=@id AND (@cpf in(select cpf_fun from Funcionario)) ";


                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@senha", t.Senha);

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
