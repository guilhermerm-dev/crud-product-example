using System.Collections.Generic;
using crud_product_domain.Entities;

namespace crud_product_domain.Repositories
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void DeleteProduct(int code);
        void EditProduct(int code, string name, string description, decimal price, int quantity);
        IEnumerable<Product> GetAllProducts();
        Product GetProductByCode(int code);
        bool IsProductAlreadyExists(int code);
    }
}
