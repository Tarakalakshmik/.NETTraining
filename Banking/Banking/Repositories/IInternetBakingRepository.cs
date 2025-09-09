using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Repositories
{
    interface IInternetBankingRepository
    {
        string CreateInternetBanking(int accountNumber, string loginPassword, string transactionPassword);
        string ChangeLoginPassword(int accountNumber, string oldPassword, string newPassword);
        string ChangeTransactionPassword(int accountNumber, string oldPassword, string newPassword);

        string CreateDebitCard(int accountNumber);
    }
}
