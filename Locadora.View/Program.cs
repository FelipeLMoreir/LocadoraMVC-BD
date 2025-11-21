using Locadora.Controller;
using Locadora.Models;
using Locadora.Models.Enums;

Cliente cliente = new Cliente("Novo ClientezinszzDoc", "217novo0em7ai7lzinDoc@uol.com");

Documento documento = new Documento("RG", "123477777", new DateOnly(2015, 5, 1), new DateOnly(2025, 5, 1));

//Categoria categoria = new Categoria("Categoria Teste Doc", "Descrição da Categoria Teste Doc", (decimal)150.00);

//Console.WriteLine(cliente);

//var clienteController = new ClienteController();
var categoriaController = new CategoriaController();
//var categoria = new Categoria("Esportivo","Descrição da Categoria Teste Doc", 150.00m);
//categoriaController.AdicionarCategoria(categoria);

//categoria = new Categoria("Voador", 250.00m);
//categoriaController.AdicionarCategoria(categoria);

var veiculoController = new VeiculoController();
try
{
    //var veiculo = new Veiculos(2, "XYZ-1111", "Ferrari", "F8 Tributo", 2020, 
    //  EStatusVeiculo.Disponivel.ToString());
    //veiculoController.AdicionarVeiculo(veiculo);
    //var veiculos = veiculoController.ListarTodosVeiculos();

    //foreach (var item in veiculos)
    //{
    //    Console.WriteLine(item);
    //}

    //var veiculo = veiculoController.BuscarVeiculoPlaca("XYZ-7777");
    //veiculoController.DeletarVeiculo(veiculo.VeiculoID);

    Console.WriteLine(veiculoController.BuscarVeiculoPlaca("XYZ-1117"));
    veiculoController.AtualizarStatusVeiculo(EStatusVeiculo.Manutencao.ToString(), "XYZ-1117");
    Console.WriteLine(veiculoController.BuscarVeiculoPlaca("XYZ-1117"));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

//documento.setClienteID(8);
//var documentoController = new DocumentoController();
//documentoController.AdicionarDocumento(documento);

#region insertCliente
//try
//{
//    clienteController.AdicionarCliente(cliente, documento);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion
#region selectCliente
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
#region updateCliente
//try
//{
//    clienteController.AtualizarDocumentoCliente(documento, "217novo0em7ai7lzinDoc@uol.com");
//    Console.WriteLine(clienteController.BuscaClientePorEmail("217novo0em7ai7lzinDoc@uol.com"));
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion
#region deleteCliente
//try
//{
//    clienteController.DeletarClientePorEmail("217novo0em7ai7lzinDoc@uol.com");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion
#region insertCategoria
//try
//{
//    categoriaController.AdicionarCategoria(categoria);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion
#region selectCategoria
//try
//{
//    var listaDeCategorias = categoriaController.ListarTodasCategorias();
//    foreach (var categoriaDaLista in listaDeCategorias)
//    {
//        Console.WriteLine(categoriaDaLista);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion
#region updateCategoria
//try
//{
//    categoriaController.AtualizarCategoria(categoria, "nova desc", (decimal)777.50);
//    Console.WriteLine("Categoria atualizada com sucesso.");

//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion
#region deleteCategoria
//try
//{
//    categoriaController.DeletarCategoria("Categoria Teste Doc");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion
