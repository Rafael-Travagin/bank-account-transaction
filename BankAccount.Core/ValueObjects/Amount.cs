using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Core.ValueObjects;

public class Amount : ValueObject
{
    protected Amount() {}
    public decimal Value { get;private set; } = 0;

    public Amount(decimal value) => Value = Valid(value);

    private static decimal Valid(decimal value) =>
        value < 0 ? throw new Exception("Valor Tem que ser positivo"): value;

}