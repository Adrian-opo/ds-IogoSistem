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
                    caixa.id_caixa = reader.GetInt32("id_caixa");
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

            Console.WriteLine("DataFechamento_cai ->>>>>>>>>>" + t.DataFechamento_cai.ToString());
            Console.WriteLine("DataAbertura_cai ->>>>>>>>>>" + t.DataAbertura_cai.ToString());
            Console.WriteLine("SaldoAnterior_cai ->>>>>>>>>>" + t.SaldoAnterior_cai.ToString());
            Console.WriteLine("ValorDebito_cai ->>>>>>>>>>" + t.ValorDebito_cai.ToString());
            Console.WriteLine("Observacoes_cai ->>>>>>>>>>" + t.Observacoes_cai.ToString());
            Console.WriteLine("Observacoes_cai ->>>>>>>>>>" + t.Observacoes_cai.ToString());
            Console.WriteLine("ValorCredito_cai ->>>>>>>>>>" + t.ValorCredito_cai.ToString());
            Console.WriteLine("Saldo_cai ->>>>>>>>>>" + t.Saldo_cai.ToString());
            try
            {
                var query = conn.Query();

                query.Parameters.AddWithValue("@DataFechamento", t.DataFechamento_cai.ToString());
                query.Parameters.AddWithValue("@DataAbertura", t.DataAbertura_cai.ToString());
                query.Parameters.AddWithValue("@SaldoAnterior", t.SaldoAnterior_cai.ToString());
                query.Parameters.AddWithValue("@ValorDebito", t.ValorDebito_cai.ToString());
                query.Parameters.AddWithValue("@Observacoes", t.Observacoes_cai.ToString());
                query.Parameters.AddWithValue("@ValorCredito", t.ValorCredito_cai.ToString());
                query.Parameters.AddWithValue("@SaldoCaixa", t.Saldo_cai.ToString());
                // query.Parameters.AddWithValue("@Id_usuario_fk", "0");
                query.Parameters.AddWithValue("@ID", "0");
                // query.Parameters.AddWithValue("@ID", t.id_caixa.ToString());
                query.CommandText = "INSERT INTO caixa (dataFechamento_cai, dataAbertura_cai, saldoAnterior_cai, valorDebito_cai, observações_cai, valorCredito_cai, saldo_cai, id_caixa) " +
                    "VALUES (@DataFechamento, @DataAbertura,@SaldoAnterior,@ValorDebito,@Observacoes,@ValorCredito, @SaldoCaixa, @ID)";

                // query.Parameters.AddWithValue("@DataFechamento", t.DataFechamento_cai.ToString("yyyy-MMM-dd"));
                // query.Parameters.AddWithValue("@DataAbertura", t.dataAbertura_cai.ToString("yyyy-MMM-dd"));
                // query.Parameters.AddWithValue("@SaldoAnterior", t.saldoAnterior_cai.ToString());
                //query.Parameters.AddWithValue("@ValorDebito", t.valorDebito_cai.ToString());
                //   query.Parameters.AddWithValue("@Observacoes", t.observações_cai.ToString());
                //  query.Parameters.AddWithValue("@ValorCredito", t.valorCredito_cai.ToString());
                //  query.Parameters.AddWithValue("@SaldoCaixa", t.saldo_cai.ToString());
                //query.Parameters.AddWithValue("@ID", t.id_caixa.ToString());

                // Console.WriteLine("query.ToString() ->>>>>>>>>>" + query.ToString());
                // query.Parameters.AddWithValue("@DataFechamento", "2020-10-20");
                // query.Parameters.AddWithValue("@DataAbertura", "2019-10-20");
                // query.Parameters.AddWithValue("@SaldoAnterior","100,00");
                // query.Parameters.AddWithValue("@ValorDebito", "100,00");
                // query.Parameters.AddWithValue("@Observacoes", "Vazio");
                // query.Parameters.AddWithValue("@ValorCredito", "100,00");
                // query.Parameters.AddWithValue("@SaldoCaixa", "100,00");
                // query.Parameters.AddWithValue("@ID", "0");

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Erro. Verifique e tente novamente.");



            }
            catch (Exception e)
            {
                Console.WriteLine("Erroooou ->>>>>>>>>>" + e);
                // throw e;
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
