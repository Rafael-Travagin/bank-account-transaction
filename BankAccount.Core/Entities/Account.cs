using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccount.Core.Entities.Fabric;
using BankAccount.Core.Enum;
using BankAccount.Core.ValueObjects;

namespace BankAccount.Core.Entities;

public class Account : Entity
{
    public Bank Bank { get; private set; } = null!;
    public AccountName AccountName { get; private set; } =null!;
    public Document Document { get; private set; } =null!;
    private List<Transaction> _transactions = [];
    public IReadOnlyCollection<Transaction>? Transactions { get => _transactions.AsReadOnly(); } 

    public Account(Bank bank, AccountName accountName, Document document)
    {
        Bank = bank;
        AccountName = accountName;
        Document = document;
    }

    protected Account(){}

    public decimal Balance(){
        decimal debits = 0;
        decimal credits = 0;
        try { debits = Convert.ToDecimal(Transactions?.Where(x => x.Type == TypeTransaction.Debit).Sum(x => x.Amount.Value)); } catch {}        
        try {credits = Convert.ToDecimal(Transactions?.Where(x => x.Type == TypeTransaction.Credit).Sum(x => x.Amount.Value));} catch{}        
        return credits - debits;
    }

    public void Debit(decimal amountTransaction) =>
        CreateTransaction(amountTransaction, TypeTransaction.Debit);

    public void Credit(decimal amountTransaction) =>
        CreateTransaction(amountTransaction, TypeTransaction.Credit);

    private void CreateTransaction(Decimal amountTransaction, TypeTransaction typeTransaction) =>
        _transactions.Add(TransactionFabric.CreateTransaction(amountTransaction, typeTransaction, this.Id));
    
    public IReadOnlyCollection<Transaction>? NewTransactions { get => _transactions.Where(t => t.Status == null).ToList().AsReadOnly(); } 

}