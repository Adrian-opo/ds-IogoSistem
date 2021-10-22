using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IogoSistem.Interfaces;
using IogoSistem.Database;
using MySql.Data.MySqlClient;
using IogoSistem.Helpers;

namespace IogoSistem.Models
{
    class FuncionarioDAO : IDAO<Funcionario>
    {
        private static Conexao conn;

        public FuncionarioDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Funcionario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM funcionario WHERE cod_func = @id";

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception(" Registro não foi removido da base de dados, verifique e tente novamente!");
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

        public Funcionario GetById(int id)
        {
            try
            {

                var query = conn.Query();
                query.CommandText = "SELECT * FROM funcionario WHERE id_funcionario = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (reader.HasRows)
                    throw new Exception("nenhum registro foi encontrado!");


                var funcionario = new Funcionario();

                while (reader.Read())
                {
                    funcionario.Id = reader.GetInt32("id_funcionario");
                    funcionario.Nome = DAOHelper.GetString(reader, "nome_fun");
                    funcionario.CPF = DAOHelper.GetString(reader, "cpf_fun");
                    funcionario.Email = DAOHelper.GetString(reader, "email_fun");
                    funcionario.Telefone = DAOHelper.GetString(reader, "telefone_fun");
                    funcionario.Endereco = DAOHelper.GetString(reader, "id_endereço_fk");
                    funcionario.DataNascimento = DAOHelper.GetDateTime(reader, "dataNasciemto_fun");
                    funcionario.RG = DAOHelper.GetString(reader, "rg_fun");
                    funcionario.PCD = DAOHelper.GetString(reader, "deficiencia_fun");
                    funcionario.NumeroCarteira = DAOHelper.GetString(reader, "numeroCarteira_fun");
                    funcionario.Salario = DAOHelper.GetString(reader, "tipoSalario_fun");
                    funcionario.DataAdimissao = DAOHelper.GetDateTime(reader, "dataAdimissão_fun");
                    funcionario.SetorTrabalho = DAOHelper.GetString(reader, "setor_fun");
                    funcionario.CargaHoraria = DAOHelper.GetString(reader, "cargaHorario_fun");
                }

                return funcionario;
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

        public void Insert(Funcionario t)
        {
            try
            {


                var query = conn.Query();
                // query.CommandText = "INSERT INTO funcionario (nome_fun, cpf_fun, email_fun, telefone_fun, id_endereço_fk, dataNasciemto_fun, rg_fun, deficiencia_fun, numeroCarteira_fun, tipoSalario_fun, dataAdimissão_fun, setor_fun, cargaHorario_fun)  " +
                // "VALUES (@nome, @cpf, @email, @celular, @endereco, @datanasc, @rg, @PCD, @numerocarteira, @salario, @dataadmissao, @setortrabalho, @cargahoraria)";

                query.CommandText = "CALL cadastrarFuncionario(@nome, @celular, @cpf, @rg, @email, @salario, @numerocarteira, @setortrabalho, @PCD, @dataadmissao, @datanasc, @cargahoraria, @endereco)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@celular", t.Telefone);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@salario", t.Salario);
                query.Parameters.AddWithValue("@numerocarteira", t.NumeroCarteira);
                query.Parameters.AddWithValue("@setortrabalho", t.SetorTrabalho);
                query.Parameters.AddWithValue("@PCD", t.PCD);
                query.Parameters.AddWithValue("@dataadmissao", t.DataAdimissao?.ToString("yyyy-mm-dd"));
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento?.ToString("yyyy-mm-dd"));
                query.Parameters.AddWithValue("@cargahoraria", t.CargaHoraria);
                query.Parameters.AddWithValue("@endereco", t.Endereco);


                //var result = query.ExecuteNonQuery();

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

        public List<Funcionario> List()
        {
            try
            {
                List<Funcionario> list = new List<Funcionario>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM funcionario";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionario()
                    {

                        Id = reader.GetInt32("id_funcionario"),
                        Nome = DAOHelper.GetString(reader, "nome_fun"),
                        CPF = DAOHelper.GetString(reader, "cpf_fun"),
                        Email = DAOHelper.GetString(reader, "email_fun"),
                        Telefone = DAOHelper.GetString(reader, "telefone_fun"),
                        Endereco = DAOHelper.GetString(reader, "id_endereço_fk"),
                        DataNascimento = DAOHelper.GetDateTime(reader, "dataNasciemto_fun"),
                        RG = DAOHelper.GetString(reader, "rg_fun"),
                        PCD = DAOHelper.GetString(reader, "deficiencia_fun"),
                        NumeroCarteira = DAOHelper.GetString(reader, "numeroCarteira_fun"),
                        Salario = DAOHelper.GetString(reader, "tipoSalario_fun"),
                        DataAdimissao = DAOHelper.GetDateTime(reader, "dataAdimissão_fun"),
                        SetorTrabalho = DAOHelper.GetString(reader, "setor_fun"),
                        CargaHoraria = DAOHelper.GetString(reader, "cargaHorario_fun"),


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

        public void Update(Funcionario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE funcionario SET (nome_fun = @nome, cpf_fun = @cpf, email_fun = @email, telefone_fun = @celular," +
                    " id_endereço_fk = @endereco, dataNasciemto_fun = @datanasc, rg_fun = @rg, deficiencia_fun = @PCD, " +
                    "numeroCarteira_fun = @numerocarteira, tipoSalario_fun = @salario, dataAdimissão_fun = @dataadmissao, setor_fun = @setortrabalho, cargaHorario_fun = @cargahoraria)  " +
                    "WHERE  id_funcionario = @id";


                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@celular", t.Telefone);
                query.Parameters.AddWithValue("@endereco", t.Endereco);
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento?.ToString("yyyy-mm-dd"));
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@PCD", t.PCD);
                query.Parameters.AddWithValue("@numerocarteira", t.NumeroCarteira);
                query.Parameters.AddWithValue("@salario", t.Salario);
                query.Parameters.AddWithValue("@dataadmissao", t.DataAdimissao?.ToString("yyyy-mm-dd"));
                query.Parameters.AddWithValue("@setortrabalho", t.SetorTrabalho);
                query.Parameters.AddWithValue("@cargahoraria", t.CargaHoraria);

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Atualização do registro não foi realizado");
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
    }
}
