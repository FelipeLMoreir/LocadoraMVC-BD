namespace Locadora.Models
{
    public class Veiculos
    {
        public readonly static string INSERTVEICULO = @"INSERT INTO tblVeiculos (CategoriaID, Placa, Marca, 
                                                        Modelo, Ano, StatusVeiculo)
                                                        VALUES (@CategoriaID, @Placa, @Marca, @Modelo, 
                                                        @Ano, @StatusVeiculo)";

        public readonly static string SELECTALLVEICULOS = @"SELECT CategoriaID, 
                                                            Placa, Marca, Modelo, Ano, StatusVeiculo
                                                            FROM tblVeiculos";

        public readonly static string SELECTVEICULOBYPLACA = @"SELECT VeiculoID, CategoriaID, 
                                                               Placa, Marca, Modelo, Ano, StatusVeiculo
                                                               FROM tblVeiculos
                                                               WHERE Placa = @Placa";

        public readonly static string UPDATESTATUSVEICULO = @"UPDATE tblVeiculos 
                                                              SET StatusVeiculo = @StatusVeiculo
                                                              WHERE VeiculoID = @VeiculoID";

        public readonly static string DELETEVEICULO = @"DELETE FROM tblVeiculos
                                                        WHERE VeiculoID = @VeiculoID";
        public int VeiculoID { get; private set; }
        public int CategoriaID { get; private set; }
        public string? NomeCategoria { get; private set; }
        public string Placa { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string StatusVeiculo { get; private set; }
        public Veiculos(int categoriaID, string placa, string marca, string modelo, 
            int ano, string statusVeiculo)
        {
            CategoriaID = categoriaID;
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            StatusVeiculo = statusVeiculo;
        }
        public void setVeiculoID(int veiculoID)
        {
            VeiculoID = veiculoID;
        }
        public void setStatusVeiculo(string statusVeiculo)
        {
            StatusVeiculo = statusVeiculo;
        }
        public void setNomeCategoria(string nomeCategoria)
        {
            NomeCategoria = nomeCategoria;
        }
        public override string? ToString()
        {
            return $"Placa: {Placa}\nMarca: {Marca}" +
                $"\nModelo: {Modelo}\nAno: {Ano}\nStatus do Veículo: {StatusVeiculo}\n" +
                $"Nome da Categoria: {NomeCategoria}";
        }
    }
}
