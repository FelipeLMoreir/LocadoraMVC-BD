using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

Cliente cliente = new Cliente("Novo Clientezin", "1novo0email@uol.com");

//Documento documento = new Documento(1, "RG", "123456789", new DateOnly(2015, 5, 1), new DateOnly(2025, 5, 1));

Console.WriteLine(cliente);

var clienteController = new ClienteController();

try
{
    clienteController.AdicionarCliente(cliente);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
var listaDeClientes = clienteController.ListarTodosClientes();

foreach (var clienteDaLista in listaDeClientes)
{
    Console.WriteLine(clienteDaLista);
}