using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccount.Core.Enum;
using BankAccount.Core.ValueObjects;

namespace BankAccount.Core.Entities;

/// <summary>
/// Class <c>Transaction</c> Expresses a transaction in an account.
/// </summary>
public class Transaction : Entity
{
    protected Transaction(){}
    
   /// <summary>
    /// This method fetches data and returns a list of
    /// <typeparamref name="T"/>.
    /// </summary>
    /// <param name="type">Transaction type: debit or credit</param>
    /// <param name="amount">Transaction amount</param>
    /// <param name="accountId">transaction account Id</param>
    public Transaction(TypeTransaction type, Amount amount, Guid accountId)
    {
        Type = type;
        Amount = amount;
        Status = null;
        Date = DateTime.Now.ToUniversalTime();
        AccountId = accountId;
    }

    /// <value>Property <c>X</c> transaction decimal value.</value>
    public Amount Amount { get; private set; } = new(0);
    public TypeTransaction Type { get; private set; } = TypeTransaction.Debit;
    public StatusTransaction? Status { get; private set; } = null;
    public DateTime Date { get; private set; } = DateTime.Now.ToUniversalTime();
    public Guid AccountId { get; private set; }
    public Account? Account{ get; set; } 
}