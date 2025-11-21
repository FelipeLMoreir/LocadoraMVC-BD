namespace Locadora.Models
{
    public class Categoria
    {
        public readonly static string INSERTCATEGORIA =
            "EXEC sp_INSERIRCATEGORIA @Nome, @Descricao, @Diaria";
        public readonly static string SELECTALLCATEGORIAS =
            "SELECT * FROM tblCategorias;";
        public readonly static string UPDATECATEGORIA =
            "UPDATE tblCategorias " +
            "SET Descricao = @Descricao, " +
            "Diaria = @Diaria " +
            "WHERE CategoriaID = @CategoriaID;";
        public readonly static string SELECTCATEGORIAPORID =
            "SELECT Nome, Descricao, Diaria FROM tblCategorias" +
            " WHERE CategoriaID = @CategoriaID;";
        public readonly static string SELECTNOMECATEGORIAPORID =
            "SELECT Nome FROM tblCategorias" +
            " WHERE CategoriaID = @CategoriaID;";
        public readonly static string DELETECATEGORIA =
            "DELETE FROM tblCategorias " +
            "WHERE CategoriaID = @CategoriaID;";
        public int CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Diaria { get; private set; }

        public Categoria(string nome, decimal diaria)
        {
            Nome = nome;
            Diaria = diaria;
        }
        public Categoria(string nome, string? descricao, decimal diaria) : this(nome, diaria)
        {
            Nome = nome;
            Descricao = descricao;
            Diaria = diaria;
        }

        public void setCategoriaId(int categoriaId)
        {
            CategoriaId = categoriaId;
        }
        public void setDescricao(string descricao)
        {
            Descricao = descricao;
        }
        public void setDiaria(decimal diaria)
        {
            Diaria = diaria;
        }
        public override string? ToString()
        {
            return $"Nome: {Nome}\nDescrição: {Descricao}\nDiária: {Diaria:F2}\n";
        }
    }
}
