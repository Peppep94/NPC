using NPC.calculators.discount.helpers;
using NPC.models;

namespace NPC.calculators.discount.implementations
{
    internal class ChildDiscountCalcolator : IDiscountCalculator
    {
        private readonly Dictionary<string, decimal> _childDiscounts;

        public ChildDiscountCalcolator(Dictionary<string, decimal> childDiscounts)
        {
            _childDiscounts = childDiscounts;
        }
        //Calcola lo sconto in base all'età del cliente. Per ogni fascia di età è previsto uno sconto diverso.
        //Una fascia è rappresentata da una stringa con il formato "1-5" dove vengono rappresentati gli estremi. 
        //Nel caso "1-5" l'età è valida se è nell'intervallo da 1 a 5 anni con 1 e 5 compresi 
        //Se la stringa contiene solo un numero , l'età è valida se è maggiore è uguale a quel numero
        public decimal CalculateDiscount(OrderInfo order)
        {
            foreach (var discount in _childDiscounts)
            {
                if (RangeComparerHelper.IsInRange(order.CustomerAge, discount.Key))
                {
                    return discount.Value;
                }
            }

            return 0;
        }
    }
}
