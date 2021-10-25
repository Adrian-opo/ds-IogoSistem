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

        public override Venda GetById(int id)
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
        }

        public override void Insert(Venda t)
        {
            try
            {
                var clienteId = new ClienteDAO().Insert(t.Cliente);
                var funcionarioId = new FuncionarioDAO().Insert(t.Funcionario);

                var query = conn.Query();
                query.CommandText = "INSERT INTO fornecedor (nome_for, telefone_for, cpf_for, rg_for, email_for, produtoFornecido_for, celular_for, razaoSocial_for, cnpj_for, complemento_for, id_endereco_fk)" +
                    "VALUES (@nome, @telefone, @cpf, @rg, @email, @produtoFornecido, @celular, @razaoSocial, @cnpj, @complemento, @id_endereco)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@produtoFornecido", t.ProdutoFornecido);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@razaoSocial", t.RazaoSocial);
                query.Parameters.AddWithValue("@cnpj", t.CNPJ);
                query.Parameters.AddWithValue("@complemento", t.Complemento);

                query.Parameters.AddWithValue("@id_endereco", enderecoId);



                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente.");

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
        public override List<Fornecedor> List()
        {
            try
            {
                List<Fornecedor> list = new List<Fornecedor>();
                var query = conn.Query();
                query.CommandText = "Select id_fornecedor, nome_for FROM Fornecedor";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Fornecedor()
                    {
                        Id = reader.GetInt32("id_fornecedor"),
                        Nome = reader.GetString("nome_for")
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

        public override void Update(Fornecedor t)
        {
            try
            {
                long enderecoID = t.Endereco.Id;
                var endDAO = new EnderecoDAO();

                if (enderecoID > 0)
                    endDAO.Update(t.Endereco);
                else
                    enderecoID = endDAO.Insert(t.Endereco);

                var query = conn.Query();
                query.CommandText = "UPDATE Fornecedor SET nome_for=@nome ,telefone_for=@telefone ,cpf_for=@cpf ,rg_for=@rg, email_for=@email, produtoFornecido_for=@produtoFornecido, celular_for=@celular, razaoSocial_for=@razaoSocial, cnpj_for=@cnpj, complemento_for=@complemento, id_endereco_fk=@enderecoID WHERE id_fornecedor=@id";

                query.Parameters.AddWithValue("@razaoSocial", t.RazaoSocial);
                query.Parameters.AddWithValue("@cnpj", t.CNPJ);

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);

                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@produtoFornecido", t.ProdutoFornecido);
                query.Parameters.AddWithValue("@Complemento", t.Complemento);

                query.Parameters.AddWithValue("@enderecoId", enderecoID);

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
