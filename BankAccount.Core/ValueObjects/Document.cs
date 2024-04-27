using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Core.ValueObjects
{
    public class Document : ValueObject
    {
        public string Value  { get; private set; } = null!;

        public Document(string name)=> Value = name;

        private static string Valid( string value ) =>
            String.IsNullOrEmpty(value)?throw new ArgumentNullException("cpf is invalid"):value;

        protected Document(){}
    }
}