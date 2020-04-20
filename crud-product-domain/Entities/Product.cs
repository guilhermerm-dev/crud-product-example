namespace crud_product_domain.Entities
{
    public class Product
    {
        public Product(int code, string name, string description, decimal price, int quantity)
        {
            Code = code;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
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
