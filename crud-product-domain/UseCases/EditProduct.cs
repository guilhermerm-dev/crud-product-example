using crud_product_domain.Entities;
using crud_product_domain.Repositories;

namespace crud_product_domain.UseCases
{
    public class EditProduct
    {

        private readonly IProductRepository _productRepository;

        public EditProduct(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(Product product)
        {
            _productRepository.EditProduct(product.Code, product.Name, product.Description, product.Price, product.Quantity);
        }
    }
}
