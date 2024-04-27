using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using BankAccount.Core.Enum;
using MediatR;

namespace BankAccount.Core.UseCases.CreateTransaction;

public class Request: IRequest<Response>
{
    public decimal Amount { get; set; } = 0;
    public string Type { get; set; } = "Debit";
    public string AccountId { get; set; } = null!;
    public bool IsValid() => true;
}