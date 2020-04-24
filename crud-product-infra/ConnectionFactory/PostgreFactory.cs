using crud_product_infra.Abstract;
using crud_product_infra.Clients;
using crud_product_infra.ConnectionFactory.Abstract;

namespace crud_product_infra.ConnectionFactory
{
    public class PostgreFactory : DataBaseFactory
    {
        public override DataBaseConnector CreateDataBaseConnector(string connectionString)
        {
            return new PostgreSqlConnector(connectionString);
        }
    }
}
