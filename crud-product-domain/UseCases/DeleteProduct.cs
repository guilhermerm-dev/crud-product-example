using System.Threading.Tasks;
using crud_product_domain.Error;
using crud_product_domain.Repositories;

namespace crud_product_domain.UseCases
{
    public class DeleteProduct
    {
        private readonly IProductRepository _productRepository;

        public DeleteProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task Execute(int code)
        {
            if (_productRepository.IsProductAlreadyExists(code))
                return _productRepository.DeleteProduct(code);

            throw new ProductNotExistException($"Product code {code} not exists");
        }
    }
}
