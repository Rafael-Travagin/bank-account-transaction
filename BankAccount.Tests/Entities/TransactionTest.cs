using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using BankAccount.Core.Entities;
using BankAccount.Core.Enum;
using BankAccount.Core.ValueObjects;
using Xunit;

namespace BankAccount.Tests.Entities
{
    public class TransactionTest
    {


        [Fact]
        public void CriarDebito()
        {
            decimal debitAmount = 5000.01M;
            var amount = new Amount(debitAmount);
            var debitTransaction = new BankAccount.Core.Entities.Transaction(TypeTransaction.Debit, amount, new Guid());
            Assert.Equal(TypeTransaction.Debit, debitTransaction.Type);
        }

        [Fact]
        public void CriarCredito()
        {
            decimal creditAmount = 5000.01M;
            var amount = new Amount(creditAmount);
            var creditTransaction = new BankAccount.Core.Entities.Transaction(TypeTransaction.Credit, amount, new Guid());
            Assert.Equal(TypeTransaction.Credit, creditTransaction.Type);
        }

        [Fact]
        public void VerificarValorDebito()
        {
            decimal debitAmount = 5000.01M;
            var amount = new Amount(debitAmount);
            var debitTransaction = new BankAccount.Core.Entities.Transaction(TypeTransaction.Debit, amount,new Guid());
            Assert.Equal(debitAmount, debitTransaction.Amount.Value);
        }
    }
}