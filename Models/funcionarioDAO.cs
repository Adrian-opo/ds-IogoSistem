using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IogoSistem.Interfaces;
using IogoSistem.Database;
using MySql.Data.MySqlClient;
using IogoSistem.Helpers;
using System.Data;

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
                query.CommandText = "DELETE FROM funcionario WHERE id_funcionario = @id";

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
                query.CommandText = "SELECT * FROM Funcionario LEFT JOIN Endereco ON id_endereco_fk = id_endereco WHERE id_funcionario = @id";                 //LEFT JOIN endereco ON id_endereco_fk = id_endereco


                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("nenhum registro foi encontrado!");


                var funcionario = new Funcionario();

                while (reader.Read())
                {
                    funcionario.Id = reader.GetInt32("id_funcionario");
                    funcionario.Nome = reader.GetString("nome_fun");
                    funcionario.CPF = reader.GetString("cpf_fun");
                    funcionario.Email = reader.GetString("email_fun");
                    funcionario.Telefone = reader.GetString("telefone_fun");
                    // funcionario.Endereco = DAOHelper.GetString(reader, "id_endereço_fk");
                    funcionario.DataNascimento = reader.GetDateTime("dataNasciemto_fun");
                    funcionario.RG = reader.GetString("rg_fun");
                    funcionario.PCD = reader.GetBoolean("deficiencia_fun");
                    funcionario.NumeroCarteira = reader.GetString("numeroCarteira_fun");
                    funcionario.Salario = reader.GetString("tipoSalario_fun");
                    funcionario.DataAdimissao = reader.GetDateTime("dataAdimissão_fun");
                    funcionario.SetorTrabalho = reader.GetString("setor_fun");
                    funcionario.CargaHoraria = reader.GetString("cargaHorario_fun");
                    if (!DAOHelper.IsNull(reader, "id_endereco_fk"))
                        funcionario.Endereco = new Endereco()
                        {

                            Numero = reader.GetInt32("numero_end"),
                            Lagradouro = reader.GetString("rua_end"),
                            Bairro = reader.GetString("bairro_end"),
                            Cidade = reader.GetString("cidade_end"),
                            UF = reader.GetString("uf_end"),
                            CEP = reader.GetString("cep_end"),
                            Pais = reader.GetString("pais_end"),
                        };


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
                query.CommandText = "cadastrarFuncionario";
                query.CommandType = CommandType.StoredProcedure;


                // query.CommandText = "INSERT INTO funcionario (nome_fun, cpf_fun, email_fun, telefone_fun, id_endereço_fk, dataNasciemto_fun, rg_fun, deficiencia_fun, numeroCarteira_fun, tipoSalario_fun, dataAdimissão_fun, setor_fun, cargaHorario_fun)  " +
                // "VALUES (@nome, @cpf, @email, @celular, @endereco, @datanasc, @rg, @PCD, @numerocarteira, @salario, @dataadmissao, @setortrabalho, @cargahoraria)";

                //query.CommandText = "CALL cadastrarFuncionario (@nome, @celular, @cpf, @rg, @email, @salario, @numerocarteira, @setortrabalho, @PCD, @dataadmissao, @datanasc, @cargahoraria, @numero)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@tipoSalario", t.Salario);
                query.Parameters.AddWithValue("@numerocarteira", t.NumeroCarteira);
                query.Parameters.AddWithValue("@setor", t.SetorTrabalho);
                query.Parameters.AddWithValue("@deficiencia", t.PCD);
                query.Parameters.AddWithValue("@dataAdimissão", t.DataAdimissao?.ToString("yyyy-mm-dd"));
                query.Parameters.AddWithValue("@dataNascimento", t.DataNascimento?.ToString("yyyy-mm-dd"));
                query.Parameters.AddWithValue("@cargaHoraria", t.CargaHoraria);
                query.Parameters.AddWithValue("@numero", t.Endereco.Numero);
                query.Parameters.AddWithValue("@rua", t.Endereco.Lagradouro);
                query.Parameters.AddWithValue("@bairro", t.Endereco.Bairro);
                query.Parameters.AddWithValue("@cidade", t.Endereco.Cidade);
                query.Parameters.AddWithValue("@cep", t.Endereco.CEP);
                query.Parameters.AddWithValue("@uf", t.Endereco.UF);
                query.Parameters.AddWithValue("@pais", t.Endereco.Pais);




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
                query.CommandText = "Select * FROM funcionario"; //id_funcionario, nome_fun, cpf_fun, email_fun, telefone_fun, dataNasciemto_fun, rg_fun, deficiencia_fun, numeroCarteira_fun, tipoSalario_fun, dataAdimissão_fun, setor_fun, cargaHorario_fun,

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionario()
                    {

                        Id = reader.GetInt32("id_funcionario"),
                        Nome = reader.GetString("nome_fun"),
                        CPF = reader.GetString("cpf_fun"),
                        Email = reader.GetString("email_fun"),
                        Telefone = reader.GetString("telefone_fun"),
                        //Endereco = DAOHelper.GetString(reader, "id_endereço_fk"),
                        DataNascimento = reader.GetDateTime("dataNasciemto_fun"),
                        RG = reader.GetString("rg_fun"),
                        PCD = reader.GetBoolean("deficiencia_fun"),
                        NumeroCarteira = reader.GetString("numeroCarteira_fun"),
                        Salario = reader.GetString("tipoSalario_fun"),
                        DataAdimissao = reader.GetDateTime("dataAdimissão_fun"),
                        SetorTrabalho = reader.GetString("setor_fun"),
                        CargaHoraria = reader.GetString("cargaHorario_fun"),
                        Endereco = new Endereco()
                        {

                            Numero = reader.GetInt32("numero_end"),
                            Lagradouro = reader.GetString("rua_end"),
                            Bairro = reader.GetString("bairro_end"),
                            Cidade = reader.GetString("cidade_end"),
                            UF = reader.GetString("uf_end"),
                            CEP = reader.GetString("cep_end"),
                            Pais = reader.GetString("pais_end"),
                        }






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
                query.CommandText = "UPDATE funcionario SET (nome_fun=@nome, cpf_fun=@cpf, email_fun=@email, telefone_fun=@celular, dataNasciemto_fun=@datanasc, rg_fun=@rg, estado_end=@estado, deficiencia_fun=@PCD, " +
                    "numeroCarteira_fun=@numerocarteira, tipoSalario_fun=@salario, dataAdimissão_fun=@dataadmissao, setor_fun=@setortrabalho," +
                    " cargaHorario_fun=@cargahoraria, numero_end=@numero, rua_end=@rua, bairro_end=@bairro, cidade_end=@cidade, cep_end=@cep, uf_end=@uf, pais_end=@pais)  " +
                    "WHERE  id_funcionario=@id";


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
                query.Parameters.AddWithValue("@numero", t.Endereco.Numero);
                query.Parameters.AddWithValue("@rua", t.Endereco.Lagradouro);
                query.Parameters.AddWithValue("@bairro", t.Endereco.Bairro);
                query.Parameters.AddWithValue("@cidade", t.Endereco.Cidade);
                query.Parameters.AddWithValue("@cep", t.Endereco.CEP);
                query.Parameters.AddWithValue("@uf", t.Endereco.UF);
                query.Parameters.AddWithValue("@pais", t.Endereco.Pais);

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
