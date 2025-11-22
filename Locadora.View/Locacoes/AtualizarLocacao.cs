using Locadora.Controller;
using Locadora.Models.Enums;
using System;

namespace Locadora.View.Locacoes
{
    public class AtualizarLocacao
    {
        public void FormAtualizarLocacao(LocacaoController locacaoController)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Informe o ID da locação que deseja atualizar:");
                int idLocacao = int.Parse(Console.ReadLine());
                Console.Write("Nova data de devolução (yyyy-MM-dd): ");
                DateTime dataDevolucao = DateTime.Parse(Console.ReadLine());
                Console.Write("Novo status (Ativa, Concluida, Cancelada): ");
                EStatusLocacao status = Enum.Parse<EStatusLocacao>(Console.ReadLine(), true);

                locacaoController.AtualizarLocacao(idLocacao, dataDevolucao, status);
                Console.WriteLine("Locação atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
