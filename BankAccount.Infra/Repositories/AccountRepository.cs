using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BankAccount.Core.Entities;
using BankAccount.Core.Enum;
using BankAccount.Core.UseCases.Shared.Contract;
using BankAccount.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Infra.Repositories;

public class AccountRepository: IRepository
{
    private readonly AppDbContext _context;

    public AccountRepository(AppDbContext context) => _context = context;
    public async Task<Account> Get(Guid id, CancellationToken cancellationToken)
    {
        var account =await _context
                            .Accounts
                            .AsNoTracking()
                            .Include( x => x.Transactions)
                            .FirstOrDefaultAsync(a => a.Id == id);
        
        return account??throw new Exception("Não encontrado");
    }

    public async Task<List<Account>> GetAll(CancellationToken cancellationToken)
    {
        var accounts = await _context
                            .Accounts
                            .AsNoTracking()                            
                            .ToListAsync();
        return accounts;
    }

    public async Task SaveTransactionAsync(Transaction transaction, CancellationToken cancellationToken)
    {
        try{
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
        catch(Exception ex){
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task SaveAccountAsync(Account account, CancellationToken cancellationToken)
    {
        try{
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }
        catch(Exception ex){
            throw new Exception(ex.Message, ex);
        }
    }

}