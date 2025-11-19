using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller
{
    public class ClienteController
    {
        public void AdicionarCliente(Cliente cliente)
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
                    
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao adicionar cliente: " + ex.Message);
                    transaction.Rollback();
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
                cliente.setClienteID(Convert.ToInt32(reader["ClienteID"]));

                listaClientes.Add(cliente);
            }

            connection.Close();

            return listaClientes;
        }
    }
}
