using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Core.ValueObjects
{
    public class AccountName : ValueObject
    {
        public string Name { get;private set; } = null!;

        public AccountName(string name) => Name = Valid(name);
        
        private static string Valid( string value ) =>
            String.IsNullOrEmpty(value)?throw new ArgumentNullException("name is invalid"):value;

        protected AccountName(){}
        
    }
}