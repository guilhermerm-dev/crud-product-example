using System.Collections.Generic;
using System.Threading.Tasks;
using crud_product_domain.Entities;

namespace crud_product_domain.Repositories
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task DeleteProduct(int code);
        void EditProduct(int code, string name, string description, decimal price, int quantity);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductByCode(int code);
        bool IsProductAlreadyExists(int code);
    }
}
