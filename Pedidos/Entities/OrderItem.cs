using System.Globalization;

namespace Pedidos.Entities
{
    internal class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double SubTotal()
        {
            return Price * Quantity; 
        }

        public override string ToString()
        {
            return $"{Product.Name.ToUpper()}, ${Price.ToString("F2", CultureInfo.InvariantCulture)}, Quantidade: {Quantity}, SubTotal: {SubTotal().ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
