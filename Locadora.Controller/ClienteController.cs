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

            SqlCommand command = new SqlCommand(Cliente.INSERTCLIENTE, connection);

            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Email", cliente.Email);
            command.Parameters.AddWithValue("@Telefone", cliente.Telefone ?? (object)DBNull.Value);

            var clienteID = Convert.ToInt32(command.ExecuteScalar());
            cliente.setClienteID(clienteID);

            connection.Close();
        }
    }
}
