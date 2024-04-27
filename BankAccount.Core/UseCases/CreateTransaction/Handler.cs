using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using BankAccount.Core;
using BankAccount.Core.ValueObjects;
using BankAccount.Core.UseCases.Shared.Contract;
using System.Transactions;
using BankAccount.Core.Enum;

namespace BankAccount.Core.UseCases.CreateTransaction
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IRepository _repository;
        public Handler(IRepository repository) => _repository = repository;

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            try{
                if (!request.IsValid()) return new Response("Error",400 );
                
                var amount = new Amount(request.Amount);
                Console.WriteLine("amount " + amount.Value );

                Guid accountGuidResult;
                bool isGuid = Guid.TryParse(request.AccountId, out accountGuidResult);      
                if (!isGuid) return new Response("Account Id invalid", 500);
                
                // string stringType= request.Type;
                // TypeTransaction enumType = (TypeTransaction)Enum.Parse(typeof(TypeTransaction), stringType);
                TypeTransaction enumType = "debit".Contains(request.Type.ToLower())? TypeTransaction.Debit : TypeTransaction.Credit;
                
                var transaction = new Entities.Transaction(enumType, amount, accountGuidResult);                
                await _repository.SaveTransactionAsync(transaction, cancellationToken);

                return new Response("Transaction created",201);
            }
            catch(Exception ex)
            {
                return new Response(ex.Message,500);
            }

        }
    }
}