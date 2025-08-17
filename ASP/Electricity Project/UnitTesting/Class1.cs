using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Electricity_Project;
namespace UnitTesting
{
    public class Class1
    {
        [TestFixture]
      
        [TestFixture]
        public class ElectricityBoardTests
        {
            [TestCase(50, ExpectedResult = 0)]
            [TestCase(250, ExpectedResult = 225)]
            [TestCase(500, ExpectedResult = 1000)]
            [TestCase(650, ExpectedResult = 1625)]
            [TestCase(1300, ExpectedResult = 5800)]
            public double CalculateBill_ShouldReturnCorrectAmount(int units)
            {
                var bill = new ElectricityBill { UnitsConsumed = units };
                var board = new ElectricityBoard();
                board.CalculateBill(bill);
                return bill.BillAmount;
            }
        }


    }
}
