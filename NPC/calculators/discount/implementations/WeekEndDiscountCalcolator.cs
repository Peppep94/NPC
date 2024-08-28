using NPC.models;

namespace NPC.calculators.discount.implementations
{
    internal class WeekEndDiscountCalcolator : IDiscountCalculator
    {
        private readonly decimal _discount;

        public WeekEndDiscountCalcolator(decimal discount)
        {
            _discount = discount;
        }

        public decimal CalculateDiscount(OrderInfo input)
        {
            var isWeekend = IsWeekend(input.OrderDateTime);

            if (isWeekend)
            {
                return _discount;
            }
            return 0;
        }

        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
