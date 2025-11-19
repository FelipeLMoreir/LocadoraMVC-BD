using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

Cliente cliente = new Cliente("Felipe", "a@a.com");

Documento documento = new Documento(1, "RG", "123456789", new DateOnly(2015, 5, 1), new DateOnly(2025, 5, 1));

Console.WriteLine(cliente);

var connection = new SqlConnection(ConnectionDB.GetConnectionString());

connection.Open();

SqlCommand command = new SqlCommand(Cliente.INSERTCLIENTE, connection);

command.Parameters.AddWithValue("@Nome", cliente.Nome);
command.Parameters.AddWithValue("@Email", cliente.Email);
command.Parameters.AddWithValue("@Telefone", cliente.Telefone ?? (object)DBNull.Value);//null

cliente.setClienteID(Convert.ToInt32(command.ExecuteScalar()));

//int clienteID = Convert.ToInt32(command.ExecuteScalar());
//cliente.setClienteID(clienteID);

connection.Close();
