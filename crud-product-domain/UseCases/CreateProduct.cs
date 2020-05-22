using System;
using crud_product_domain.Entities;
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
            if (IsProductAlreadyExists(product.Code)) throw new Exception();
            _productRepository.CreateProduct(product);
        }

        private bool IsProductAlreadyExists(int code)
        {
            return _productRepository.IsProductAlreadyExists(code);
        }
    }
}
