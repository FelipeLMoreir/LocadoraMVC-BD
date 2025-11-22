using Locadora.Controller;
using System;

namespace Locadora.View.Locacoes
{
    public class ListarLocacoes
    {
        public void ExibirTodasLocacoes(LocacaoController locacaoController)
        {
            try
            {
                Console.Clear();
                var locacoes = locacaoController.ListarLocacao();
                if (locacoes.Count > 0)
                {
                    foreach (var loc in locacoes)
                    {
                        Console.WriteLine(loc);
                        Console.WriteLine("--------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhuma locação registrada!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
