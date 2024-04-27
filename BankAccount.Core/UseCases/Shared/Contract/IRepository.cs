using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccount.Core.Entities;

namespace BankAccount.Core.UseCases.Shared.Contract
{
    public interface IRepository
    {
        Task<List<Account>> GetAll(CancellationToken cancellationToken);
        Task<Account> Get(Guid id, CancellationToken cancellationToken);
        Task SaveAccountAsync(Account account, CancellationToken cancellationToken);
        Task SaveTransactionAsync(BankAccount.Core.Entities.Transaction transaction, CancellationToken cancellationToken);

    }
}