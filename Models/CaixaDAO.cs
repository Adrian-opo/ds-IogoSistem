using IogoSistem.Database;
using IogoSistem.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IogoSistem.Models;

namespace IogoSistem.Models
{
    class CaixaDAO : IDAO<Caixa>
    {

        private static Conexao conn = new Conexao();

        public CaixaDAO()
        {
            conn = new Conexao();
        }


        public void Delete(Caixa t)
        {
            throw new NotImplementedException();
        }

        public Caixa GetById(int Id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM caixa  WHERE id_caixa=@id";


                query.Parameters.AddWithValue("@id", Id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("nenhum registro foi encontrado");

                Caixa caixa = null;

                while (reader.Read())
                {
                    caixa = new Caixa();
                    caixa.Id = reader.GetInt32("id_caixa");
                    // caixa.DataFechamento_cai = reader.GetString("dataFechamento_cai");
                    // caixa.DataAbertura_cai = reader.GetString("dataAbertura_cai");


                }
                return caixa;
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

        public void Insert(Caixa t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO caixa (dataFechamento_cai, dataAbertura_cai ) " +
                    "VALUES (@DataFechamento, @DataAbertura)";

                query.Parameters.AddWithValue("@DataFechamento", t.DataFechamento_cai.ToString("yyyy-MMM-dd"));
                query.Parameters.AddWithValue("@DataAbertura", t.DataAbertura_cai.ToString("yyyy-MMM-dd"));

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Erro. Verifique e tente novamente.");



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

        public List<Caixa> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Caixa t)
        {
            throw new NotImplementedException();
        }
    }
}
