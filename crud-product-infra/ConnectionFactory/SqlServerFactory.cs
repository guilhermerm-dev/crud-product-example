using crud_product_infra.Abstract;
using crud_product_infra.ConnectionFactory.Abstract;
using crud_product_infra.Connectors;

namespace crud_product_infra.ConnectionFactory
{
    public class SqlServerFactory : DataBaseFactory
    {
        public override DataBaseConnector CreateDataBaseConnector(string connectionString)
        {
            return new SqlServerConnector(connectionString);
        }
    }
}
