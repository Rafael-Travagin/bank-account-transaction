using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Core.UseCases.CreateTransaction;

public class Response(string message, int status): BankAccount.Core.UseCases.Shared.Response(message,status){}