using System.Collections.Generic;
using System.Threading.Tasks;
using crud_product_domain.Entities;
using crud_product_domain.Repositories;

namespace crud_product_domain.UseCases
{
    public class GetAllProducts
    {
        private readonly IProductRepository _productRepository;

        public GetAllProducts(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Execute()
        {
            return await _productRepository.GetAllProducts();
        }
    }
}
