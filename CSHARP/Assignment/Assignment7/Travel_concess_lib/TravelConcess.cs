using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Travel_concess_lib
{
    public class TravelConcess
    {
        public void CalculateConcession(string name, int age, double totalFare)
        {
            if (age <= 5)
            {
                Console.WriteLine($"{name}: Little Champ - Free Ticket");
            }
            else if (age > 60)
            {
                double discountedFare = totalFare - (totalFare * 0.30); // 30% discount
                Console.WriteLine($"{name}: Senior Citizen - Fare after 30% concession: {discountedFare}");
            }
            else
            {
                Console.WriteLine($"{name}: Ticket Booked - Fare: {totalFare}");
            }
        }
    }
}
