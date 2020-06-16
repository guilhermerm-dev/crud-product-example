using System;
using crud_product_infra.Abstract;

namespace crud_product_infra.ConnectionFactory.Abstract
{
    public abstract class DataBaseFactory
    {
        public abstract DataBaseConnector CreateDataBaseConnector(string connectionString);

        public static DataBaseFactory DataBase(crud_product_shared.Enums.DataBase database) => database switch
        {
            crud_product_shared.Enums.DataBase.PostgreSql => new PostgreFactory(),
            crud_product_shared.Enums.DataBase.SqlServer => new SqlServerFactory(),
            _ => throw new ApplicationException("Database its not recognized"),
        };
    }
}
