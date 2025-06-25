using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment3
{
    class Salesdetails
    {
        public int salesNo, productNo, qty;
        public float Price, totalAmount;
        public DateTime dateofSale;
       public Salesdetails() { }

        public Salesdetails(int salesNo, int productNo, float Price, int qty, DateTime dateofSale)
        {
            this.salesNo = salesNo;
            this.productNo = productNo;
            this.Price = Price;
            this.qty = qty;
            this.dateofSale = dateofSale;
        }
        public void Sales(int qty, float Price)
        {
            this.qty = qty;
            this.Price = Price;
            totalAmount = qty * Price;
        }

        public static void ShowData(Salesdetails sale)
        {
            Console.WriteLine($"Sales no: {sale.salesNo}");
            Console.WriteLine($"Product no: {sale.productNo}");
            Console.WriteLine($"Price: {sale.Price}");
            Console.WriteLine($"Quantity: {sale.qty}");
            Console.WriteLine($"Date of Sale: {sale.dateofSale}");
            Console.WriteLine($"Total Amount: {sale.totalAmount}");
        }
    }
    class question3 : Salesdetails
    {
        public static void Main()
        {
            question3 q3 = new question3();
            Console.WriteLine("Enter sales No: ");
            q3.salesNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter product No:");
            q3.productNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price:");
            q3.Price = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Quantity:");
            q3.qty = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Date of Sale:");
            q3.dateofSale = Convert.ToDateTime(Console.ReadLine());
            Salesdetails sale = new Salesdetails(q3.salesNo, q3.productNo, q3.Price, q3.qty, q3.dateofSale);
            sale.Sales(q3.qty, q3.Price);
            Salesdetails.ShowData(sale);
            Console.Read();
        }
    }
}