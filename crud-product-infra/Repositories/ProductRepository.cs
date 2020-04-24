﻿using System;
using System.Collections.Generic;
using crud_product_domain.Entities;
using crud_product_domain.Repositories;
using crud_product_infra.ConnectionFactory.Abstract;
using crud_product_infra.Enums;
using System.Data;
using Dapper;

namespace crud_product_infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataBase _dataBase = DataBase.PostgreSql;
        private readonly string _connectionString = "User ID=postgres;Password=;Host=localhost;Port=5432;Database=store;Pooling=true;";

        public void CreateProduct(Product product)
        {
            using var connection = DataBaseFactory.DataBase(_dataBase)
                                .CreateDataBaseConnector(_connectionString)
                                .Connect();
            connection.Execute("INSERT INTO store.product VALUES (code, name , description , quantity, price) " +
            "INTO (@code, @name, @description, @quantity, @price)", new
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
            throw new NotImplementedException();
        }

        public void EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using var connection = DataBaseFactory.DataBase(_dataBase)
                                   .CreateDataBaseConnector(_connectionString)
                                   .Connect();
            return connection.Query<Product>("SELECT code, name , description , price, quantity FROM store.product", commandType: CommandType.Text);
        }

        public Product GetProductByCode(int code)
        {
            using var connection = DataBaseFactory.DataBase(_dataBase)
                                   .CreateDataBaseConnector(_connectionString)
                                   .Connect();
            return connection.QueryFirstOrDefault<Product>("SELECT code, name , description , quantity, price FROM store.product WHERE code = @code", new
            {
                code,
            }, commandType: CommandType.Text);
        }
    }
}
