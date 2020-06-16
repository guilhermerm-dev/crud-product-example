using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using crud_product_infra.Abstract;

namespace crud_product_infra.Connectors
{
    public class SqlServerConnector : DataBaseConnector
    {
        public SqlServerConnector(string connectionString) : base(connectionString)
        {
            ConnectionString = connectionString;
        }

        public override IDbConnection Connect()
        {
            DbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public override void Dispose()
        {
            this.Dispose();
        }
    }
}
