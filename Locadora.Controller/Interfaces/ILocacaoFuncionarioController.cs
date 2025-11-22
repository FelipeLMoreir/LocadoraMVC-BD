using Locadora.Models;

namespace Locadora.Controller.Interfaces
{
    public interface ILocacaoFuncionarioController
    {
        void AdicionarLocacaoFuncionario(LocacaoFuncionario relacionamento);
        void RemoverLocacaoFuncionario(int locacaoFuncionarioId);
        List<LocacaoFuncionario> ListarFuncionariosDaLocacao(Guid locacaoId);
        List<LocacaoFuncionario> ListarLocacoesDoFuncionario(int funcionarioId);
    }
}
