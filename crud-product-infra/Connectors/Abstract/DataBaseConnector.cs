using System;
using System.Data;

namespace crud_product_infra.Abstract
{
    public abstract class DataBaseConnector : IDisposable
    {
        public DataBaseConnector(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }
        public abstract IDbConnection Connect();
        public abstract void Dispose();
    }
}
