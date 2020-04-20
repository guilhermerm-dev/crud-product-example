using System.Collections.Generic;
using crud_product_domain.Entities;

namespace crud_product_domain.UseCases
{
    public class GetAllProducts
    {
        public IList<Product> Execute()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(1, "Produto A", "Produto A", 1, 10));
            products.Add(new Product(2, "Produto B", "Produto B", 1, 15));
            products.Add(new Product(3, "Produto C", "Produto C", 1, 20));
            products.Add(new Product(4, "Produto D", "Produto D", 1, 25));
            products.Add(new Product(5, "Produto E", "Produto E", 1, 30));
            return products;
        }
    }
}
