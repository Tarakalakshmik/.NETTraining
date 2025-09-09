using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Repositories
{
    interface ITransactionRepository
    {
        string AddPayee(Payee payee);
        (Payee payee, string message) GetPayee(int id);
        (List<Transaction_Details> transactions, string message) GetStatement(int accountNumber, DateTime fromDate, DateTime toDate);

        (Transaction_Details txnDetails, string message) MakeTransaction(Transaction_Details transaction);

    }
}
