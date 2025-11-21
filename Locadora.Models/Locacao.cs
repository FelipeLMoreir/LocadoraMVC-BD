using Locadora.Models.Enums;

namespace Locadora.Models
{
    public class Locacao
    {

        public Guid LocacaoID { get; private set; }
        public int ClienteID { get; private set; }
        public int VeiculoID { get; private set; }
        public DateTime DataLocacao { get; private set; }
        public DateTime DataDevolucaoPrevista { get; private set; }
        public DateTime? DataDevolucaoReal { get; private set; }
        public decimal ValorDiaria { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal Multa { get; private set; }
        public EStatusLocacao Status { get; private set; }

        public Locacao(int clienteID, int veiculoID, decimal valorDiaria, int diasLocacao)
        {
            ClienteID = clienteID;
            VeiculoID = veiculoID;
            DataLocacao = DateTime.Now;
            ValorDiaria = valorDiaria;
            ValorTotal = valorDiaria * diasLocacao;
            DataDevolucaoPrevista = DateTime.Now.AddDays(diasLocacao);
            Status = EStatusLocacao.Ativa;
        }

        public override string? ToString()
        {
            return $"Cliente ID: {ClienteID}\nVeículo ID: {VeiculoID}\nData Locação: {DataLocacao}" +
                $"\nData Devolução Prevista: {DataDevolucaoPrevista}" +
                $"\nData Devolução Real: {DataDevolucaoReal}" +
                $"\nValor Diária: {ValorDiaria}\nValor Total: {ValorTotal}\nMulta: {Multa}\nStatus: {Status}";
        }
    }
}
