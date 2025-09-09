using Banking.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Banking.Repositories
{
    public class TransactionRepositoryImpl : ITransactionRepository
    {
        private BankingDBEntities1 db = null;
        public TransactionRepositoryImpl()
        {
            db = new BankingDBEntities1();
        }
        public string AddPayee(Payee payee)
        {
            string message = "";
            try
            {
                db.Sp_AddPayee(payee.Beneficiary_Name, payee.From_Account, payee.To_Account, payee.Nickname);
                message = "Payee added successfully";
            }
            catch (SqlException e)
            {
                message = e.Message;
            }
            return message;
        }

        public (Payee payee, string message) GetPayee(int id)
        {
            Payee payee = null;
            String msg = "";
            try
            {
                var result = db.fn_GetPayee(id).FirstOrDefault();
                payee = new Payee()
                {
                    Payee_Id = result.Payee_Id.Value,
                    To_Account = result.Account_Number.Value,
                    Beneficiary_Name = result.Beneficiary_Name,
                    Nickname = result.Nickname
                };
                msg = "Fetched Payee Details Successfully";
            }
            catch (SqlException e)
            {
                msg = e.Message;
            }
            return (payee, msg);
        }

        public (List<Transaction_Details> transactions, string message) GetStatement(int accountNumber, DateTime fromDate, DateTime toDate)
        {
            List<Transaction_Details> txnDetails = new List<Transaction_Details>();
            string msg = "";
            try
            {
                var result = db.fn_GetStatement(accountNumber, fromDate, toDate);
                foreach (var r in result)
                {
                    txnDetails.Add(new Transaction_Details()
                    {
                        Transaction_Id = r.Transaction_Id.Value,
                        From_Account = r.From_Account,
                        To_Account = r.To_Account,
                        Transaction_Mode = r.Transaction_Mode,
                        Transaction_Type = r.Transaction_Type,
                        Amount = r.Amount,
                        Transaction_Date = r.Transaction_Date,
                        Remarks = r.Remarks
                    });
                }
                msg = "Statement generated successfully";
            }
            catch (SqlException e)
            {
                msg = e.Message;
            }
            return (txnDetails, msg);
        }

        public (Transaction_Details txnDetails, string message) MakeTransaction(Transaction_Details transaction)
        {
            Transaction_Details txn = null;
            string msg = "";
            try
            {
                int txnNumber = db.Sp_AddTransaction(transaction.From_Account, transaction.To_Account, transaction.Transaction_Mode, transaction.Transaction_Type, transaction.Amount, transaction.Transaction_Date, transaction.Remarks);
                txn = db.Transaction_Details.Find(txnNumber);
                msg = "Transaction Successful";
            }
            catch (SqlException e)
            {
                msg = e.Message;
            }
            return (txn, msg);
        }
    }
}