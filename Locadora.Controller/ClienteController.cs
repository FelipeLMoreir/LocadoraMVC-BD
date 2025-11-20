using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller
{
    public class ClienteController
    {
        public void AdicionarCliente(Cliente cliente, Documento documento)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Cliente.INSERTCLIENTE, connection, transaction);

                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@Telefone", cliente.Telefone ?? (object)DBNull.Value);

                    var clienteID = Convert.ToInt32(command.ExecuteScalar());

                    cliente.setClienteID(clienteID);

                    var documentoController = new DocumentoController();

                    documento.setClienteID(clienteID);

                    documentoController.AdicionarDocumento(documento, connection, transaction);

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar cliente: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar cliente: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Cliente> ListarTodosClientes()
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Cliente.SELECTALLCLIENTES, connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Cliente> listaClientes = new List<Cliente>();

                while (reader.Read())
                {
                    var cliente = new Cliente(reader["Nome"].ToString(),
                                              reader["Email"].ToString(),
                                              reader["Telefone"] != DBNull.Value ?
                                              reader["Telefone"].ToString() : null
                                              );
                    //cliente.setClienteID(Convert.ToInt32(reader["ClienteID"]));

                    var documento = new Documento(
                        reader["TipoDocumento"].ToString(),
                        reader["Numero"].ToString(),
                        DateOnly.FromDateTime(reader.GetDateTime(5)),
                        DateOnly.FromDateTime(reader.GetDateTime(6))
                        );

                    cliente.setDocumento(documento);

                    listaClientes.Add(cliente);
                }
                return listaClientes;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao listar clientes: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao listar clientes: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public Cliente BuscaClientePorEmail(string email)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(Cliente.SELECTCLIENTEPOREMAIL, connection);

                command.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var cliente = new Cliente(reader["Nome"].ToString(),
                                              reader["Email"].ToString(),
                                              reader["Telefone"] != DBNull.Value ?
                                              reader["Telefone"].ToString() : null
                                              );
                    cliente.setClienteID(Convert.ToInt32(reader["ClienteID"]));

                    var documento = new Documento(
                        reader["TipoDocumento"].ToString(),
                        reader["Numero"].ToString(),
                        (DateOnly)reader["DataEmissao"],
                        (DateOnly)reader["DataValidade"]
                        );

                    return cliente;
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar cliente por email: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar cliente por email: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void AtualizarTelefoneCliente(string telefone, string email)
        {
            var clienteEncontrado = this.BuscaClientePorEmail(email);

            if (clienteEncontrado is null)
            {
                throw new Exception("Cliente não encontrado para o email informado.");
            }
            clienteEncontrado.setTelefone(telefone);

            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();
            try
            {
                SqlCommand command = new SqlCommand(Cliente.UPDATECLIENTE, connection);
                command.Parameters.AddWithValue("@Telefones", clienteEncontrado.Telefone);
                command.Parameters.AddWithValue("@ClienteID", clienteEncontrado.ClienteID);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao atualizar telefone do cliente: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao atualizar telefone do cliente: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeletarCliente(string email)
        {
            var clienteEncontrado = BuscaClientePorEmail(email);

            if (clienteEncontrado is null)
            {
                throw new Exception("Cliente não encontrado para o email informado.");
            }

            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand(Cliente.DELETECLIENTE, connection);
                command.Parameters.AddWithValue("@ClienteID", clienteEncontrado.ClienteID);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao deletar cliente: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao deletar cliente: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
