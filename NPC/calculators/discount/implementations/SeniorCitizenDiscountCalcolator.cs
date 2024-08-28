using NPC.models;

namespace NPC.calculators.discount.implementations
{
    internal class SeniorCitizenDiscountCalcolator : IDiscountCalculator
    {

        private readonly SeniorCitizenDiscount _discount;

        public SeniorCitizenDiscountCalcolator(SeniorCitizenDiscount discount)
        {
            _discount = discount;
        }
        public decimal CalculateDiscount(OrderInfo input)
        {
            if (input.CustomerAge > _discount.AgeThreshold)
            {
                return _discount.Percentage;
            }
            return 0;
        }
    }
}
