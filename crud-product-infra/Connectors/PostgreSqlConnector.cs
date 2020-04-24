using System.Data;
using crud_product_infra.Abstract;
using Npgsql;

namespace crud_product_infra.Clients
{
    public class PostgreSqlConnector : DataBaseConnector
    {
        public PostgreSqlConnector(string connectionString) : base(connectionString)
        {
            ConnectionString = connectionString;
        }

        public override IDbConnection Connect()
        {
            NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public override void Dispose()
        {
            this.Dispose();
        }
    }
}
