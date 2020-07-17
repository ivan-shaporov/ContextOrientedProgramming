using System;
using System.Linq;

namespace ContextOrientedProgramming
{
    partial class Program
    {
        static readonly string[][] customerBd = new[]
        {
            new[] { "1234-1234-1234-1234", "Ivan", "Petrov", "1000.0" },
            new[] { "4321-4321-4321-4321", "Petr", "Ivanov", "2000.0" },
        };

        static void LookupCustomer(Context _)
        {
            var customer = customerBd.FirstOrDefault(c => c[0] == _.Get<string>("CardNumber"));

            if (customer == null)
            {
                return;
            }

            _.Set("FirstName", customer[1]);
            _.Set("LastName", customer[2]);
            _.Set("Balance", decimal.Parse(customer[3]));
        }

        static void DecreaseCustomerBalance(Context _)
        {
            var customer = customerBd.FirstOrDefault(c => c[0] == _.Get<string>("CardNumber"));

            if (customer == null)
            {
                return;
            }

            var newValue = decimal.Parse(customer[3]) - _.Get<decimal>("WithdrawalValue");
            customer[3] = newValue.ToString();
        }

        static void PrintCustomerInfo(Context _)
        {
            Console.WriteLine($"{_.Get<string>("FirstName")} {_.Get<string>("LastName")}, balance: {_.Get<decimal>("Balance")}");
        }
    }
}
