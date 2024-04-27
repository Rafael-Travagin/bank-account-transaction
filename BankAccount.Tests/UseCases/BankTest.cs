using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccount.Core.ValueObjects;
using Xunit;

namespace BankAccount.Tests.UseCases
{
    public class BankTest
    {
        [Fact]
        public void CrearBank()
        {
            var bank = new Bank("Brasil");
            Assert.Equal("Brasil", bank.Name);
        }
    }
}