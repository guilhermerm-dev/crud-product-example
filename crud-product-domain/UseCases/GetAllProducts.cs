using System.Collections.Generic;
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

        public IEnumerable<Product> Execute()
        {
            return _productRepository.GetAllProducts();
        }
    }
}
