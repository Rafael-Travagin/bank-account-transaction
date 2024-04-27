using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Core.UseCases.Shared;

public abstract class Response(string message, int status = 400)
{
    public string Message { get; set; } = message;
    public int Status { get; set; } = status;    
}