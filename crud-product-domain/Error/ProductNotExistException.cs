using System;
namespace crud_product_domain.Error
{
    public class ProductNotExistException : Exception
    {
        public ProductNotExistException(string message) : base(message)
        {
        }
    }
}
