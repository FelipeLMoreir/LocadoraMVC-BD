using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Documento
    {
        public readonly static string INSERTDOCUMENTO =
            "INSERT INTO tblDocumentos (ClienteID, TipoDocumento, Numero, DataEmissao, DataValidade)" +
            "VALUES (@ClienteID, @TipoDocumento, @Numero, @DataEmissao, @DataValidade); ";
        public string DocumentoID { get; private set; }
        public int ClienteID { get; private set; }
        public string TipoDocumento { get; private set; }
        public string Numero { get; private set; }
        public DateOnly DataEmissao { get; private set; }
        public DateOnly DataValidade { get; private set; }

        public Documento(int clienteID, string tipoDocumento, string numero, 
            DateOnly dataEmissao, DateOnly dataValidade)
        {
            ClienteID = clienteID;
            TipoDocumento = tipoDocumento;
            Numero = numero;
            DataEmissao = dataEmissao;
            DataValidade = dataValidade;
        }

        public override string ToString()
        {
            return $"Tipo Documento: {TipoDocumento}\nNúmero: {Numero}" +
                $"\nData de Emissão: {DataEmissao}\nData de Validade: {DataValidade}\n";
        }
    }
}
