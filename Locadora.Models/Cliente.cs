using System.Xml.Serialization;

namespace Locadora.Models
{
    public class Cliente
    {
        public readonly static string INSERTCLIENTE = 
            "INSERT INTO tblClientes " +
            "VALUES (@Nome, @Email, @Telefone); " +
            "SELECT SCOPE_IDENTITY();";

        public int ClienteID { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string? Telefone { get; private set; } = String.Empty;

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public Cliente(string nome, string email, string? telefone) : this(nome, email)
        {
            Telefone = telefone;
        }

        public void setClienteID(int clienteID)
        {
            ClienteID = clienteID;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\nEmail: {Email}\nTelefone: {Telefone}\n";
        }
    }
}
