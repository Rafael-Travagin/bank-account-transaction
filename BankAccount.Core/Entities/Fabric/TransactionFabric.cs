using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccount.Core.Enum;
using BankAccount.Core.ValueObjects;

namespace BankAccount.Core.Entities.Fabric;

public static class TransactionFabric
{
    public static Transaction CreateTransaction(Decimal amountTransaction, TypeTransaction typeTransaction, Guid accountId){
        var amount = new Amount(amountTransaction);
        return new Transaction(typeTransaction, amount, accountId);            
    }        
}