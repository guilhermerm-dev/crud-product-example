using System;
using crud_product_infra.Abstract;
using crud_product_infra.Enums;

namespace crud_product_infra.ConnectionFactory.Abstract
{
    public abstract class DataBaseFactory
    {
        public abstract DataBaseConnector CreateDataBaseConnector(string connectionString);

        public static DataBaseFactory DataBase(DataBase database)
        {
            switch (database)
            {
                case Enums.DataBase.PostgreSql:
                    return new PostgreFactory();
                default:
                    throw new ApplicationException("Database its not recognized");
            }
        }

    }
}
