using System.Threading.Tasks;
using crud_product_domain.Entities;
using crud_product_domain.Error;
using crud_product_domain.Repositories;

namespace crud_product_domain.UseCases
{
    public class CreateProduct
    {
        private readonly IProductRepository _productRepository;

        public CreateProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Execute(Product product)
        {
            if (_productRepository.IsProductAlreadyExists(product.Code))
                throw new ProductAlreadyExistsException($"Product with code {product.Code} already exists in data base.");
            await _productRepository.CreateProduct(product);
        }
    }
}
