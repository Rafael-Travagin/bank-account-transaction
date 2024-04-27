using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Core
{
    public static class Configuration
    {
        public static DatabaseConfiguration Database { get; set; } = new();

        public class DatabaseConfiguration
        {
            public string ConnectionString { get; set; } = string.Empty;
        }        
    }
}