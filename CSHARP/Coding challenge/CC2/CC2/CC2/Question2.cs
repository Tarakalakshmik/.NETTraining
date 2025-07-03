//2.Create a Class called Products with Productid, Product Name, Price. Accept 10 Products, sort them based on the price, and display the sorted Products



//using System;
//using System.Linq;

//public class Product
//{
//    public int ProductId { get; set; }
//    public string ProductName { get; set; }
//    public decimal Price { get; set; }

//    public override string ToString()
//    {
//        return $"ProductId: {ProductId}, ProductName: {ProductName}, Price: {Price}";
//    }
//}

//class Question2
//{
//    static void Main()
//    {
//        Product[] products = new Product[10];


//        for (int i = 0; i < 10; i++)
//        {
//            Console.WriteLine($"Enter details for Product {i + 1}:");
//            Console.Write("Product Id: ");
//            int productId = Convert.ToInt32(Console.ReadLine());
//            Console.Write("Product Name: ");
//            string productName = Console.ReadLine();
//            Console.Write("Price: ");
//            decimal price = Convert.ToDecimal(Console.ReadLine());
//            products[i] = new Product
//            {
//                ProductId = productId,
//                ProductName = productName,
//                Price = price
//            };
//        }

//        var sortedProducts = products.OrderBy(p => p.Price);
//        int index = 1;
//        foreach (var product in sortedProducts)
//        {
//            Console.WriteLine($"Index: {index}, Product: {product}");
//            index++;
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC2
{
    class Products
    {
        static int[] Productid = new int[10];
        static string[] ProductName = new string[10];
        static double[] Price = new double[10];
        public static void GetDetails()
        {

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter Product{i + 1} Id : ");
                Productid[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Enter Product {i + 1} Name:");
                ProductName[i] = Console.ReadLine();
                Console.WriteLine($"Enter Product {i + 1} Price :");
                Price[i] = Convert.ToDouble(Console.ReadLine());
            }
        }
        public static void SortPrices()
        {
            Array.Sort(Price);
            Console.WriteLine("Prices of 10 Products after sorting:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ID: {Productid[i]}, Name: {ProductName[i]}, Price: {Price[i]}");
            }
        }
    }
    class Question2
    {
        public static void Main()
        {
            Products.GetDetails();
            Products.SortPrices();
            Console.Read();
        }
    }
}