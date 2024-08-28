using NPC.models;

namespace NPC.calculators.discount.implementations
{
    internal class EarlyOrderDiscountCalcoltor : IDiscountCalculator
    {

        private readonly EarlyOrderDiscount _config;

        public EarlyOrderDiscountCalcoltor(EarlyOrderDiscount config)
        {
            _config = config;
        }

        public decimal CalculateDiscount(OrderInfo input)
        {
            if (input.OrderDateTime.Hour <= _config.LimitHour)
            {
                return _config.Percentage;
            }
            return 0;
        }
    }
}
