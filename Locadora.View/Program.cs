using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

Cliente cliente = new Cliente("Novo ClientezinszzDoc", "217novo0em7ai7lzinDoc@uol.com");

Documento documento = new Documento("RG", "123477777", new DateOnly(2015, 5, 1), new DateOnly(2025, 5, 1));

//Console.WriteLine(cliente);

var clienteController = new ClienteController();

//documento.setClienteID(8);
//var documentoController = new DocumentoController();
//documentoController.AdicionarDocumento(documento);

#region insert
//try
//{
//    clienteController.AdicionarCliente(cliente, documento);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion
#region select
//try
//{
//    var listaDeClientes = clienteController.ListarTodosClientes();
//    foreach (var clienteDaLista in listaDeClientes)
//    {
//        Console.WriteLine(clienteDaLista);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion
#region update
try
{
    clienteController.AtualizarDocumentoCliente(documento, "217novo0em7ai7lzinDoc@uol.com");
    Console.WriteLine(clienteController.BuscaClientePorEmail("217novo0em7ai7lzinDoc@uol.com"));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
#endregion
#region delete
//try
//{
//    clienteController.DeletarClientePorEmail("217novo0em7ai7lzinDoc@uol.com");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion
