using NPC.models;

namespace NPC.calculators.discount.implementations
{
    public class FidelityCardDiscountCalculator : IDiscountCalculator
    {
        private readonly decimal _discount;

        public FidelityCardDiscountCalculator(decimal discount)
        {
            _discount = discount;
        }

        public decimal CalculateDiscount(OrderInfo input)
        {
            if (input.HasFidelityCard)
            {
                return _discount;
            }
            return 0;
        }
    }
}
