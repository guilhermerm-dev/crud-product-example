using System;
namespace crud_product_domain.Error
{
    public class ProductAlreadyExistsException : Exception
    {
        public ProductAlreadyExistsException(string message) : base(message) { }
    }
}
