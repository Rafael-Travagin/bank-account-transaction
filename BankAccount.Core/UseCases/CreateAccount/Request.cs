using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace BankAccount.Core.UseCases.CreateAccount;

public class Request : IRequest<Response>
{
    public string Bank { get; set; } = null!;
    public string AccountName { get; set; } =null!;
    public string Document { get; set; } =null!;
    public bool IsValid() => true;
}