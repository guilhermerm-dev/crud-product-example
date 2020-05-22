using System.Collections.Generic;
using System.Data;
using crud_product_domain.Entities;
using crud_product_domain.Repositories;
using crud_product_infra.ConnectionFactory.Abstract;
using crud_product_shared;
using Dapper;

namespace crud_product_infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Configuration _configuration;

        public ProductRepository(Configuration configuration)
        {
            _configuration = configuration;
        }

        public void CreateProduct(Product product)
        {
            using var connection = DataBaseFactory.DataBase(_configuration.DataBaseType)
                                .CreateDataBaseConnector(_configuration.ConnectionString)
                                .Connect();
            connection.Execute(@"INSERT INTO store.product (code, name , description , quantity, price) VALUES
            (@code, @name, @description, @quantity, @price)", new
            {
                code = product.Code,
                name = product.Name,
                description = product.Description,
                quantity = product.Quantity,
                price = product.Price
            }, commandType: CommandType.Text);
        }

        public void DeleteProduct(int code)
        {
            using var connection = DataBaseFactory.DataBase(_configuration.DataBaseType)
                                   .CreateDataBaseConnector(_configuration.ConnectionString)
                                   .Connect();
            connection.Execute("UPDATE store.product SET Is_Deleted = false WHERE Code = @code", new { code });
        }

        public void EditProduct(int code, string name, string description, decimal price, int quantity)
        {
            using var connection = DataBaseFactory.DataBase(_configuration.DataBaseType)
                                   .CreateDataBaseConnector(_configuration.ConnectionString)
                                   .Connect();
            connection.Execute("UPDATE store.product SET Name = @name, Description = @description, Price = @price, Quantity = @quantity WHERE Code = @code"
                , new { code, name, price, quantity });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using var connection = DataBaseFactory.DataBase(_configuration.DataBaseType)
                                   .CreateDataBaseConnector(_configuration.ConnectionString)
                                   .Connect();
            return connection.Query<Product>("SELECT code, name , description , price, quantity FROM store.product WHERE Is_Deleted = false", commandType: CommandType.Text);
        }

        public Product GetProductByCode(int code)
        {
            using var connection = DataBaseFactory.DataBase(_configuration.DataBaseType)
                                   .CreateDataBaseConnector(_configuration.ConnectionString)
                                   .Connect();
            return connection.QueryFirstOrDefault<Product>("SELECT code, name , description , quantity, price FROM store.product WHERE code = @code AND Is_Deleted = false", new
            {
                code,
            }, commandType: CommandType.Text);
        }

        public bool IsProductAlreadyExists(int code)
        {
            using var connection = DataBaseFactory.DataBase(_configuration.DataBaseType)
                                   .CreateDataBaseConnector(_configuration.ConnectionString)
                                   .Connect();
            return connection.QueryFirstOrDefault<bool>("SELECT EXISTS(select 1 from store.product where code = @code and is_Deleted = false)", new
            {
                code,
            }, commandType: CommandType.Text);

        }
    }
}
