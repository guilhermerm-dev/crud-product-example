using System.Collections.Generic;
using crud_product_domain.Entities;

namespace crud_product_domain.Repositories
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void DeleteProduct(int code);
        void EditProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductByCode(int code);
    }
}
