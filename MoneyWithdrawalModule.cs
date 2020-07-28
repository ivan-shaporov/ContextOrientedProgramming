using System;

namespace ContextOrientedProgramming
{
    partial class Program
    {
        static void ProcessWithdrawal(Context _)
        {
            var cardReaderContext = _.Subset("CardPresent", "CardNumber");
            ReadCard(cardReaderContext);
            PrintCardInfo(cardReaderContext);

            if (!_.Get<bool>("CardPresent"))
            {
                Console.WriteLine("Card not present.");
                return;
            }

            var customerContext = _.Subset("CardNumber", "FirstName", "LastName", "Balance");
            LookupCustomer(customerContext);
            PrintCustomerInfo(customerContext);

            var keypadContext = _.Subset();
            ReadDecimal(keypadContext);
            if (keypadContext.Get<bool>("Canceled"))
            {
                Console.WriteLine("Customer canceled the transaction.");
                return;
            }

            _.Set("WithdrawalValue", keypadContext.Get<decimal>("Result"));

            var withdrawalContext = _.Subset("CardNumber", "WithdrawalValue");

            DecreaseCustomerBalance(withdrawalContext);

            Dispence(withdrawalContext);

            Console.WriteLine("Customer info after withdrawal:");
            LookupCustomer(customerContext);
            PrintCustomerInfo(customerContext);
        }
    }
}
