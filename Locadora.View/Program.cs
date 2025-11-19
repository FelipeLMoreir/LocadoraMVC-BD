using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

Cliente cliente = new Cliente("Novo manzin", "novoemail@uol.com");

//Documento documento = new Documento(1, "RG", "123456789", new DateOnly(2015, 5, 1), new DateOnly(2025, 5, 1));

Console.WriteLine(cliente);

var clienteController = new ClienteController();

clienteController.AdicionarCliente(cliente);

var listaDeClientes = clienteController.ListarTodosClientes();

foreach (var clienteDaLista in listaDeClientes)
{
    Console.WriteLine(clienteDaLista);
}