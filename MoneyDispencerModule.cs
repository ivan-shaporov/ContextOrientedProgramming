using System;

namespace ContextOrientedProgramming
{
    partial class Program
    {
        static void Dispence(Context _)
        {
            Console.WriteLine($"Here is your ${_.Get<decimal>("WithdrawalValue")}");
        }
    }
}
