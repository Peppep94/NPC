using NPC.calculators.discount.helpers;
using NPC.models;

namespace NPC.calculators.discount.implementations
{
    internal class GroupSizeDiscountCalcolator : IDiscountCalculator
    {
        private readonly Dictionary<string, decimal> _groupDiscounts;

        public GroupSizeDiscountCalcolator(Dictionary<string, decimal> groupDiscounts)
        {
            _groupDiscounts = groupDiscounts;
        }

        //Calcola lo sconto in base grandezza del gruppo. Per ogni reange di dimensioni di un gruppo è previsto uno sconto diverso.
        //Un range è rappresentato da una stringa con il formato "21-25" dove vengono rappresentati gli estremi. 
        //Nel caso "21-25" il numero dei componenti del gruppo è valido se è nell'intervallo da 21 a 25 con 21 e 25 compresi 
        //Se la stringa contiene solo un numero il numero dei componenti è valido se è maggiore è uguale a quel numero
        public decimal CalculateDiscount(OrderInfo order)
        {
            foreach (var discount in _groupDiscounts)
            {
                if (RangeComparerHelper.IsInRange(order.GroupSize, discount.Key))
                {
                    return discount.Value;
                }
            }

            return 0;
        }
    }
}
