using Locadora.Controller;
using System;

namespace Locadora.View.Locacoes
{
    public class CancelarLocacao
    {
        public void FormCancelarLocacao(LocacaoController locacaoController)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Informe o ID da locação para cancelar:");
                int idLocacao = int.Parse(Console.ReadLine());

                locacaoController.CancelarLocacao(idLocacao);
                Console.WriteLine("Locação cancelada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
