using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Core.ValueObjects;

public class Bank : ValueObject
{
    public string Name { get; private set; } = null!;
    public Bank(string name) => Name = Valid(name);

    private static string Valid( string name ) =>
            String.IsNullOrEmpty(name)?throw new ArgumentNullException("name is invalid"):name;

    protected Bank(){}

}