using System.Collections.Generic;

namespace NPC.calculators.total
{
    public class TotalCalculator
    {
        public decimal CalculateTotal(decimal fullPrize, IEnumerable<decimal> discounts)
        {
            var discountedPrize = fullPrize;
            foreach (var discount in discounts)
            {
                discountedPrize -= discountedPrize * discount / 100;
            }
            return Math.Max(5, discountedPrize);
        }
    }
}
