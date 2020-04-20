using crud_product_domain.Entities;

namespace crud_product_domain.UseCases
{
    public class GetProductByCode
    {
        public Product Execute(int code)
        {
            return new Product(1, "Produto A", "Produto A", 1, 10);
        }
    }
}
