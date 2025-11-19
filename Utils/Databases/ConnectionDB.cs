namespace Utils.Databases
{
    public class ConnectionDB
    {
        private static readonly string _connectionString =
            "Data Source=localhost;Initial Catalog=LocadoraDB;User ID=sa;Password=SqlServer@2022;" +
            "TrustServerCertificate=True";

        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
