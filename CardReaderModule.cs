using System;

namespace ContextOrientedProgramming
{
    partial class Program
    {
        static void ReadCard(Context _)
        {
            _.Set("CardPresent", true);
            _.Set("CardNumber", "1234-1234-1234-1234");
        }

        static void PrintCardInfo(Context _)
        {
            if (_.Get<bool>("CardPresent"))
            {
                string cn = _.Get<string>("CardNumber");
                Console.WriteLine($"Card number: {cn}");
            }
        }
    }
}
