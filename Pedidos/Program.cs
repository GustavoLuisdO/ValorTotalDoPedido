using System;
using System.Globalization;
using Pedidos.Entities;
using Pedidos.Entities.Enums;

namespace Pedidos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dados do Cliente!");

            Console.Write("Nome: ");
            string clientName = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Data de nascimento (dd/mm/aaaa): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Entre com os dados do pedido");

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(clientName, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("Quantos items para este pedido? ");
            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entre com os dados do item #{i}");

                Console.Write("Nome: ");
                string productName = Console.ReadLine();
                Console.Write("Preço: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, price);

                Console.Write("Quantidade: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine("\nResumo do pedido");

            Console.WriteLine(order);

        }
    }
}
