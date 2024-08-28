namespace NPC.models
{
    //Configurazione per tarere i vari tipi di sconto
    //La configurazione è caricata da un file json
    public class DiscountConfig
    {
        public decimal FidelityCardDiscountPercentage { get; set; }
        public decimal DisabilityDiscountPercentage { get; set; }
        public EarlyOrderDiscount EarlyOrderDiscount { get; set; } = null!;
        public decimal WeekendDiscountPercentage { get; set; }
        public SeniorCitizenDiscount SeniorCitizenDiscount { get; set; } = null!;
        public Dictionary<string, decimal> GroupDiscounts { get; set; } = null!;
        public Dictionary<string, decimal> ChildDiscounts { get; set; } = null!;
    }

    public class SeniorCitizenDiscount
    {
        public int AgeThreshold { get; set; }
        public decimal Percentage { get; set; }
    }

    public class EarlyOrderDiscount
    {
        public int LimitHour { get; set; }
        public decimal Percentage { get; set; }
    }
}
