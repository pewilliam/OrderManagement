using System;
using OrderManagment.Entities;
using OrderManagment.Entities.Enums;

namespace OrderManagment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----Enter client's data----");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("----Enter order data----");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(clientName, clientEmail, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items in this order: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Clear();
                Console.WriteLine("----Enter item #" + i + " data----");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, productPrice, product);

                order.AddItem(orderItem);
            }

            Console.Clear();
            Console.WriteLine("----ORDER SUMMARY----");
            Console.WriteLine(order);
        }
    }
}
