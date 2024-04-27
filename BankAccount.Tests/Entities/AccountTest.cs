using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccount.Core.Entities;
using BankAccount.Core.Entities.Fabric;
using BankAccount.Core.ValueObjects;
using Xunit;

namespace BankAccount.Tests.Entities;

public class AccountTest
{    

    [Fact]
    public void CriarAccount()
    {
        var bank = new Bank("BB");
        var accountName = new AccountName("222");
        var document = new Document("123456");        
        var account = new Account(bank: bank, accountName: accountName, document: document);   
        Assert.Equal("123456", account.Document.Value);
    }

    [Fact]
    public void CreditarConta(){
        var bank = new Bank("BB");
        var accountName = new AccountName("222");
        var document = new Document("123456");      
        var account = new Account(bank: bank, accountName: accountName, document: document);
        account.Credit(10000M);
        account.Credit(2500.10M);
        Assert.Equal(12500.10M, account.Balance());
    }

    [Fact]
    public void DebitarConta(){
        var bank = new Bank("BB");
        var accountName = new AccountName("222");
        var document = new Document("123456");        
        var account = new Account(bank: bank, accountName: accountName, document: document);   
        account.Debit(1000.50M);
        account.Debit(505M);        
        Assert.Equal(-1505.50M, account.Balance());
    }


}