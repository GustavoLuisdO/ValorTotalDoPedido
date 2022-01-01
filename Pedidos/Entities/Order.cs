using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Pedidos.Entities.Enums;

namespace Pedidos.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        // adicionar itens
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        // remover itens
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach(OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Momento do pedido: {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
            sb.AppendLine($"Status do pedido: {Status}");
            sb.AppendLine($"Cliente: {Client}");
            sb.AppendLine("Itens do pedido:");
            foreach(OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine($"Total do pedido: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");
            
            return sb.ToString();
        }
    }
}
