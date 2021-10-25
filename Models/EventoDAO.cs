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
    class EventoDAO : IDAO<Evento>
    {

        private static Conexao conn;

        public EventoDAO()
        {
            conn = new Conexao();
        }



        public void Delete(Evento t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM EventoUsuario where id_evento_fk=@id; DELETE FROM evento WHERE id_evento=@id";



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

        public Evento GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM evento WHERE id_evento= @id";


                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("nenhum registro foi encontrado");

                var evento = new Evento();

                while (reader.Read())
                {
                    evento.Id = reader.GetInt32("id_evento");
                    evento.Tipo = reader.GetString("tipo_even");
                    evento.Descricao = reader.GetString("descricao_even");
                    evento.Inicio = reader.GetDateTime("inicioEvento");
                    evento.Fim = reader.GetDateTime("fimEvento");

                }
                return evento;
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

        public void Insert(Evento t)
        {
            try
            {
                var query = conn.Query();
                //query.CommandText = "INSERT INTO funcionario " +
                //    "(nome_func, cpf_func, rg_func, datanasc_func, email_func, celular_func, funcao_func, salario_func, cod_sex_fk) " +
                //    "VALUES (@nome, @cpf, @rg, @datanasc, @email, @celular, @funcao, @salario, @sexo)";
                // resenha varchar(200),tipoEvento varchar(50),inicioEvento date, fimEvento date
                query.CommandText = "cadastrarEvento";
                query.CommandType = CommandType.StoredProcedure;

                /*
                 * CREATE DEFINER=`root`@`%` PROCEDURE `inserir_funcionario`(IN nome varchar(200), IN cod_sexo int, IN cpf varchar(20), IN rg varchar(20),
									   IN datanasc date, IN email varchar(200), IN celular varchar(50), IN funcao varchar(50),
                                                     IN salario double)
                 */

                query.Parameters.AddWithValue("@resenha", t.Descricao);
                query.Parameters.AddWithValue("@tipoEvento", t.Tipo);
                query.Parameters.AddWithValue("@inicioEvento", t.Inicio.ToString("yyyy-MM-dd")); 
                query.Parameters.AddWithValue("@fimEvento", t.Fim.ToString("yyyy-MM-dd")); 
                
                //query.Parameters.AddWithValue("@sexo", (t.Sexo != null && t.Sexo.Id > 0 ? t.Sexo.Id.ToString() : null));

                //query.Parameters.AddWithValue("@departmento", DAOHelper.CheckPropertyNull(t.Departamento, "Id"));

                //var result = query.ExecuteNonQuery();

                //if (result == 0)
                //    throw new Exception("O registro não foi inserido. Verifique e tente novamente.");

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

        public List<Evento> List()
        {


            try
            {
                List<Evento> list = new List<Evento>();
                var query = conn.Query();
                query.CommandText = "Select * FROM Evento";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Evento()
                    {
                        Id = reader.GetInt32("id_evento"),
                        Tipo=reader.GetString("tipo_even"),
                        Descricao = reader.GetString("descricao_even"),
                        Inicio = reader.GetDateTime("inicioEvento"),
                        Fim = reader.GetDateTime("fimEvento")

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

        public void Update(Evento t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE evento SET tipo_even=@tipo,inicioEvento=@inicio,fimEvento=@fim,descricao_even=@descricao WHERE id_evento=@id";

                query.Parameters.AddWithValue("@tipo", t.Tipo);
                query.Parameters.AddWithValue("@inicio", t.Inicio);
                query.Parameters.AddWithValue("@fim", t.Fim);
                query.Parameters.AddWithValue("@descricao", t.Descricao);

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
