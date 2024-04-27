using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccount.Core.Entities;
using BankAccount.Core.UseCases.Shared.Contract;
using BankAccount.Core.ValueObjects;
using MediatR;

namespace BankAccount.Core.UseCases.CreateAccount
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IRepository _repository;
        
        public Handler(IRepository repository) => _repository = repository;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            try{
                if (!request.IsValid()) return new Response("Account Err ...", 400);

                var bank = new Bank(request.Bank);
                var acountName = new AccountName(request.AccountName);
                var document = new Document(request.Document);
                var account = new Account(bank, acountName, document);
                await _repository.SaveAccountAsync(account, cancellationToken);
                return  new Response("Account created successfully", 201);
            }
            catch (Exception ex){
                return  new Response(ex.Message, 500);
            }
            
        }
    }
}