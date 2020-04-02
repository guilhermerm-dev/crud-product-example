namespace crud_product_domain.Entities
{
    public class Product
    {
        public Product(string name, string description, decimal price, int quantity) : this()
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public Product()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        public override string ToString()
        {
            return $"Name: {Name} | Quantity: {Quantity} | Price: {Price}";
        }
    }
}
