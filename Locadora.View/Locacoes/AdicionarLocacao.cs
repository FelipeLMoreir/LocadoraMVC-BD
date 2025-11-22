using Locadora.Controller;
using Locadora.Models;
using System;

namespace Locadora.View.Locacoes
{
    public class AdicionarLocacao
    {
        public void FormAddLocacao(LocacaoController locacaoController)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("======= DADOS DA LOCAÇÃO =======");
                Console.Write("Digite o ID do cliente: ");
                int clienteId = int.Parse(Console.ReadLine());
                Console.Write("Digite o ID do veículo: ");
                int veiculoId = int.Parse(Console.ReadLine());
                Console.Write("Digite o valor da diária: ");
                decimal valorDiaria = decimal.Parse(Console.ReadLine());
                Console.Write("Digite o número de dias de locação: ");
                int dias = int.Parse(Console.ReadLine());

                var locacao = new Locacao(clienteId, veiculoId, valorDiaria, dias);
                locacaoController.AdicionarLocacao(locacao);
                Console.WriteLine("Locação adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
