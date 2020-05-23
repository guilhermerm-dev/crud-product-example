using System.Threading.Tasks;
using crud_product_domain.Entities;
using crud_product_domain.Repositories;

namespace crud_product_domain.UseCases
{
    public class GetProductByCode
    {
        private readonly IProductRepository _productRepository;

        public GetProductByCode(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Execute(int code)
        {
            return await _productRepository.GetProductByCode(code);
        }
    }
}
