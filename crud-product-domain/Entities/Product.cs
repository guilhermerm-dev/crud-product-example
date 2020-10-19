using Flunt.Validations;
using crud_product_shared.Entities;

namespace crud_product_domain.Entities
{
    public class Product : Entity
    {
        public Product(int code, string name, string description, decimal price, int quantity)
        {
            Code = code;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Product.Name", "Product Name cant be null or empty")
                .IsGreaterThan(Price, 0, "Product.Price", "Product Price cant be lower or equals"));
        }

        public int Code { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }


        public override string ToString()
        {
            return $"Code: {Code} | Name: {Name} | Quantity: {Quantity} | Price: {Price} | Description: {Description}";
        }
    }
}
