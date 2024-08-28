using NPC.calculators.discount.enums;
using NPC.calculators.discount.implementations;
using NPC.models;

namespace NPC.calculators.discount
{
    //Facory che si occupa di istanziare le varie classi che si occupano di calcolare lo sconto.
    //Per instanziare una classe che calcola uno sconto, la factory si basa sul tipo di sconto richiesto.
    public class DiscountCalculatorFacotry
    {
        private readonly DiscountConfig _config;
        public DiscountCalculatorFacotry(DiscountConfig config)
        {
            _config = config;
        }
        public IDiscountCalculator GetDiscountCalculator(DiscountType discountType)
        {
            return discountType switch
            {
                DiscountType.FidelityCard => new FidelityCardDiscountCalculator(_config.FidelityCardDiscountPercentage),
                DiscountType.Disability => new DisabilityDiscountCalculator(_config.DisabilityDiscountPercentage),
                DiscountType.GroupSize => new GroupSizeDiscountCalcolator(_config.GroupDiscounts),
                DiscountType.EarlyOrder => new EarlyOrderDiscountCalcoltor(_config.EarlyOrderDiscount),
                DiscountType.Weekend => new WeekEndDiscountCalcolator(_config.WeekendDiscountPercentage),
                DiscountType.SeniorCitizen => new SeniorCitizenDiscountCalcolator(_config.SeniorCitizenDiscount),
                DiscountType.Child => new ChildDiscountCalcolator(_config.ChildDiscounts),
                _ => throw new ArgumentException("Unsupportd discount type", nameof(discountType)),
            };
        }
    }
}
