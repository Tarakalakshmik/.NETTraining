using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Accounts
    {

        public int acc_no;
        public string name;
        public string acc_type;
        public char trac_tp;
        public Double amount;
        public Double balance;

        public Accounts(int acc_no, string name, string acc_type, double bal)
        {
            this.acc_no = acc_no;
            this.name = name;
            this.acc_type = acc_type;
            balance = bal;


        }
        public void credit(double balance, double amount)
        {
            balance = amount + balance;
        }
        public void debit(double balance, double amount)
        {
            balance = balance - amount;
        }
        public void show_data()
        {
            Console.WriteLine($"Account number is {acc_no}");
            Console.WriteLine($"Name is {name}");
            Console.WriteLine($"Account type is {acc_type}");
            Console.WriteLine($"Transcation type  {trac_tp}");
            Console.WriteLine($"Balance is {balance}");
        }
    }
        class Question1 
        {
            static void Main(string[] args)
            {
                Accounts b = new Accounts(123,"abc","Savings",1000);
            
                Console.WriteLine("Enter transaction type as D(deposit) or W(withdrawal");
                
                  b.trac_tp = Convert.ToChar(Console.ReadLine());

                //b.amount = Convert.ToDouble(Console.ReadLine());
                
                if(b.trac_tp=='D')
                {
                    Console.WriteLine("Enter amount");
                    b.credit(b.balance,Convert.ToDouble(Console.ReadLine()));
                    b.show_data();
                }
               
                if(b.trac_tp=='W')
                {
                    Console.WriteLine("Enter amount");
                    b.debit(b.balance,Convert.ToDouble(Console.ReadLine()));
                    b.show_data();
                }
               
                Console.Read();

            }
        }
    }


