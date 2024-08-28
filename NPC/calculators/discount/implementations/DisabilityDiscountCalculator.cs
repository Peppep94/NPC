using NPC.models;

namespace NPC.calculators.discount.implementations
{
    internal class DisabilityDiscountCalculator : IDiscountCalculator
    {
        private readonly decimal _discount;

        public DisabilityDiscountCalculator(decimal discount)
        {
            _discount = discount;
        }

        public decimal CalculateDiscount(OrderInfo input)
        {
            if (input.HasDisability)
            {
                return _discount;
            }
            return 0;
        }
    }
}
