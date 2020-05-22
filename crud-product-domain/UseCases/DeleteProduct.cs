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

        public void Execute(int code)
        {
            _productRepository.DeleteProduct(code);
        }
    }
}
