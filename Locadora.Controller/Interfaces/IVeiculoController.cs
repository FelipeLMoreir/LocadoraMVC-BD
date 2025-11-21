using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    public interface IVeiculoController
    {
        public void AdicionarVeiculo(Veiculos veiculo);
        public List<Veiculos> ListarTodosVeiculos();
        public Veiculos BuscarVeiculoPlaca(string placa);
        public void AtualizarStatusVeiculo(string statusVeiculo);
        public void DeletarVeiculo(int idVeiculo);  
    }
}
