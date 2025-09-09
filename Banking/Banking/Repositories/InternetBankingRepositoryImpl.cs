using Banking.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Banking.Repositories
{
    public class InternetBankingRepositoryImpl : IInternetBankingRepository
    {
        private BankingDBEntities1 db = null;
        public InternetBankingRepositoryImpl()
        {
            db = new BankingDBEntities1();
        }
        public string ChangeLoginPassword(int accountNumber, string oldPassword, string newPassword)
        {
            string message = "";
            try
            {
                db.Sp_ChangeLoginPassword(accountNumber, oldPassword, newPassword);
                message = "Transaction Password changed successfully";
            }
            catch (SqlException e)
            {
                message = e.Message;
            }
            return message;
        }

        public string ChangeTransactionPassword(int accountNumber, string oldPassword, string newPassword)
        {
            string message = "";
            try
            {
                db.Sp_ChangeTransactionPassword(accountNumber, oldPassword, newPassword);
                message = "Transaction Password changed successfully";
            }
            catch (SqlException e)
            {
                message = e.Message;
            }
            return message;
        }

        public string CreateDebitCard(int accountNumber)
        {
            string message = "";
            try
            {
                db.Sp_CreateDebitCard(accountNumber);
                message = "Debit Card Generated successfully";
            }
            catch (SqlException e)
            {
                message = e.Message;
            }
            return message;
        }

        public string CreateInternetBanking(int accountNumber, string loginPassword, string transactionPassword)
        {
            string message = "";
            try
            {
                db.Sp_CreateInternetBanking(accountNumber, loginPassword, transactionPassword);
                message = "Created Internet Banking successfully";
            }
            catch (SqlException e)
            {
                message = e.Message;
            }
            return message;
        }
    }
}