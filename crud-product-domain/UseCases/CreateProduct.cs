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

        public void Execute(Product product)
        {
            if (IsProductAlreadyExists(product.Code))
                throw new ProductAlreadyExistsException($"Product with code {product.Code} already exists in data base.");
            _productRepository.CreateProduct(product);
        }

        private bool IsProductAlreadyExists(int code)
        {
            return _productRepository.IsProductAlreadyExists(code);
        }
    }
}
