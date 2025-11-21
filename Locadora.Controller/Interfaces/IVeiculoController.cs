using Locadora.Models;

namespace Locadora.Controller.Interfaces
{
    public interface IVeiculoController
    {
        public void AdicionarVeiculo(Veiculos veiculo);
        public List<Veiculos> ListarTodosVeiculos();
        public Veiculos BuscarVeiculoPlaca(string placa);
        public void AtualizarStatusVeiculo(string statusVeiculo, string placa);
        public void DeletarVeiculo(int idVeiculo);  
    }
}
