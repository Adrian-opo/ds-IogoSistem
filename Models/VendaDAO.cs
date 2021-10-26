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
    class VendaDAO : AbstractDAO<Venda>
    {

        public override void Delete(Venda t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM venda WHERE id_venda=@id";

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("A venda não foi removida. Verifique e tente novamente.");

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

        /*public override Venda GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM venda LEFT JOIN produto ON id_produto_fk = id_produto LEFT JOIN cliente ON id_cliente_fk = id_cliente LEFT JOIN funcionario ON id_funcionario_fk = id_funcionario WHERE id_venda= @id";


                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado.");

                var venda = new Venda();

                while (reader.Read())
                {

                    venda.Id = reader.GetInt32("id_fornecedor");

                    venda.DataVenda = reader.GetDateTime("data_vend");
                    venda.DataVencimentoParcela = reader.GetDateTime("dataVencimentoParcelas_vend");

                    venda.QuantidadeParcelas = reader.GetInt32("quantParcelas_vend");
                    venda.Valor = reader.GetInt32("valor_vend");
                    

                    if (!DAOHelper.IsNull(reader, "id_venda_fk"))
                        venda.Produto = new Produto()
                        {
                            Id = reader.GetInt32("id_produto"),
                            Nome = reader.GetString("nome_prod"),
                            Valor_Produto = reader.GetDouble("rua_end")
                        };

                    if (!DAOHelper.IsNull(reader, "id_cliente_fk"))
                        venda.Cliente = new Cliente()
                        {
                            Id = reader.GetInt32("id_cliente"),
                            Nome_Cliente = reader.GetString("nome_cli")
                        };
                    if (!DAOHelper.IsNull(reader, "id_funcionario_fk"))
                        venda.Funcionario = new Funcionario()
                        {
                            Id = reader.GetInt32("id_funcionario"),
                            Nome = reader.GetString("nome_fun")
                        };
                }
                return venda;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
        }*/

        public override void Insert(Venda t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "cadastrarVenda";
                query.CommandType = CommandType.StoredProcedure;

                //var query = conn.Query();
                //query.CommandText = "CALL cadastrarVenda (@dataVencimentoParcelas, @dataVenda, @funcionario, @cliente, @quantParcelas, @valor)";
                

                
                query.Parameters.AddWithValue("@dataVenda", t.DataVenda?.ToString("yyyy-mm-dd"));
                query.Parameters.AddWithValue("@funcionario", t.Funcionario.Id);
                query.Parameters.AddWithValue("@cliente", t.Cliente.Id);
                query.Parameters.AddWithValue("@formaPagamento", t.FormaPagamento);
                query.Parameters.AddWithValue("@valorTotal", t.ValorTotal);

                

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetName(0).Equals("Alerta"))
                    {
                        throw new Exception(reader.GetString("Alerta"));
                    }
                }

                long vendaId = query.LastInsertedId;

                InsertItens(vendaId, t.Itens);

                //var result = query.ExecuteNonQuery();

                //if (result == 0)
                //throw new Exception("O registro não foi inserido. Verifique e tente novamente.");

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

        private void InsertItens(long vendaId, List<VendaProduto> itens)
        {
            foreach(VendaProduto item in itens)
            {
                var query = conn.Query();
                query.CommandText = "inserirProdutoVenda";
                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.AddWithValue("@quantidade", item.Quantidade);
                query.Parameters.AddWithValue("@venda", item.Venda.Id);
                query.Parameters.AddWithValue("@produto", item.Produto.Id);

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetName(0).Equals("Alerta"))
                    {
                        throw new Exception(reader.GetString("Alerta"));
                    }
                }
            }
        }

        /*public override List<Venda> List()
        {
            try
            {
                List<Venda> list = new List<Venda>();
                var query = conn.Query();
                query.CommandText = "Select valor, cliente, funcionario FROM Venda";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Venda()
                    {
                        Valor = reader.GetInt32("valor")
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
        }*/

        /*public override void Update(Venda t)
        {
            try
            {

                var query = conn.Query();
                query.CommandText = "UPDATE venda SET valor_vend=@valor ,data_vend=@dataVenda ,dataVencimentoParcelas_vend=@dataVencimentoParcelas ,quantParcelas_vend=@quantParcelas, id_funcionario_fk=@funcionario, id_cliente_fk=@cliente WHERE id_venda=@id";


                query.Parameters.AddWithValue("@dataVencimentoParcelas", t.DataVencimentoParcela?.ToString("yyyy-mm-dd"));
                query.Parameters.AddWithValue("@dataVenda", t.DataVenda?.ToString("yyyy-mm-dd"));
                query.Parameters.AddWithValue("@funcionario", t.Funcionario);
                query.Parameters.AddWithValue("@cliente", t.Cliente);
                query.Parameters.AddWithValue("@quantParcelas", t.QuantidadeParcelas);
                query.Parameters.AddWithValue("@valor", t.Valor);


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
        }*/
    }
}
