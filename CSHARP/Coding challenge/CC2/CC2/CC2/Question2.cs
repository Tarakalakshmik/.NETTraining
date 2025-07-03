//2.Create a Class called Products with Productid, Product Name, Price. Accept 10 Products, sort them based on the price, and display the sorted Products



using System;
using System.Linq;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"ProductId: {ProductId}, ProductName: {ProductName}, Price: {Price}";
    }
}

class Question2
{
    static void Main()
    {
        Product[] products = new Product[10];

        // Take input from user
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Enter details for Product {i + 1}:");
            Console.Write("Product Id: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Product Name: ");
            string productName = Console.ReadLine();
            Console.Write("Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            products[i] = new Product
            {
                ProductId = productId,
                ProductName = productName,
                Price = price
            };
        }

        // Sort products by price
        var sortedProducts = products.OrderBy(p => p.Price);

        // Display products using index and value
        int index = 1;
        foreach (var product in sortedProducts)
        {
            Console.WriteLine($"Index: {index}, Product: {product}");
            index++;
        }
    }
}