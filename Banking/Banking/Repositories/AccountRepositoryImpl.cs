using Banking.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Banking.Repositories
{
    public class AccountRepositoryImpl : IAccountRepository
    {
        private BankingDBEntities1 db = null;
        public AccountRepositoryImpl()
        {
            db = new BankingDBEntities1();
        }
        public string CreateAccount(int service_reference_number, int id)
        {
            string message = "";
            try
            {
                db.Sp_CreateAccount(service_reference_number, id);
                message = "Account created: Approval Successful";
            }
            catch (SqlException e)
            {
                message = e.Message;
            }
            return message;
        }

        public (Account acc, string message) GetAccountDetails(int accountNo)
        {
            Account account = null;
            String msg = "";
            try
            {
                account = db.Accounts.Find(accountNo);
                msg = "Fetched Details Successfully";
            }
            catch (SqlException e)
            {
                msg = e.Message;
            }
            return (account, msg);
        }

        public string RegisterAccount(RegisterAccount account)
        {
            string result = "";
            try
            {
                int? serviceReferenceNumber = db.Sp_Register_Account(account.Title, account.First_Name, account.Middle_Name, account.Last_Name, account.Father_Name, account.Mobile_Number, account.Email_Id, account.Aadhar, account.Gender, account.Date_Of_Birth, account.Residential_Address, account.Permanent_Address, account.Occupation_Type, account.Source_Of_Income, account.Gross_Annual_Income, account.Opt_Debit_Card, account.Opt_Net_Banking).FirstOrDefault();
                result = "Account creation request raised with Service Reference Number: " + serviceReferenceNumber;
            }
            catch (SqlException e)
            {
                result = e.Message;
            }
            return result;
        }
    }
}