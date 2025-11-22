using Locadora.Controller;
using Locadora.Models;
using Locadora.View.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Locadora.View.VeiculosCategorias.Categorias
{
    public class AtualizarCategoria
    {
        public void AtualizarUmaCategoria(CategoriaController categoriaController)
        {
            try
            {
                Console.Clear();
                if (categoriaController.ListarTodasCategorias().Count == 0)
                {
                    Console.WriteLine("Não há categorias registrados no sistema");
                }
                else
                {
                    new ListarCategorias().ListarTodasCategorias(categoriaController);

                    Console.Write("Digite o nome da categoria que deseja atualizar: ");
                    var nomeCategoria = Console.ReadLine();

                    Console.Write("\nDigite a nova descrição da categoria: ");
                    var descricaoCategoria = Console.ReadLine();

                    Console.Write("\nDigite o novo valor da diária: ");
                    var valorDiaria = decimal.Parse(Console.ReadLine());

                    var categoria = new Categoria(
                        nomeCategoria,
                        descricaoCategoria,
                        valorDiaria
                    );

                    categoriaController.AtualizarCategoria(categoria, descricaoCategoria, valorDiaria);
                    Console.WriteLine("Categoria atualizada com sucesso!");
                    Console.WriteLine(categoriaController.BuscarCategoriaPorId(categoria.CategoriaId));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Helpers.PressionerEnterParaContinuar();
            }
        }
    }
}