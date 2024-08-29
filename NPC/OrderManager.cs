using NPC.calculators.discount.enums;
using NPC.calculators.discount;
using NPC.models;
using NPC.calculators.total;
namespace NPC
{
    public class OrderManager
    {

        private readonly DiscountCalculatorFacotry _discountCalculatorFactory;

        public OrderManager(DiscountConfig discountConfig)
        {
            _discountCalculatorFactory = new DiscountCalculatorFacotry(discountConfig);
        }


        //Metodo che gestisce l'ordine di esecuzioni degli sconti e contiene alcune logiche di alto livello  (es. se è già stato applicato uno sconto non ne applico un altro)
        public decimal ProcessOrder(OrderInfo order)
        {
            Console.WriteLine("Calculator starting...");

            var discounts = new List<decimal>();

            //Sconto per i possessori di carta fedeltà
            Console.WriteLine("Getting fidelity card discount...");
            var fidelityCardDiscountCalculator = _discountCalculatorFactory.GetDiscountCalculator(DiscountType.FidelityCard);
            var fidelityCardDiscount = fidelityCardDiscountCalculator.CalculateDiscount(order);
            Console.WriteLine($"Fidelity card discount: {fidelityCardDiscount}");
            if (fidelityCardDiscount > 0)
            {
                discounts.Add(fidelityCardDiscount);
            }

            //Sconto per i soggetti con disabilità
            Console.WriteLine("Getting disability discount...");
            var disabilityDiscountCalculator = _discountCalculatorFactory.GetDiscountCalculator(DiscountType.Disability);
            var disabilityDiscount = disabilityDiscountCalculator.CalculateDiscount(order);
            Console.WriteLine($"Disability discount: {disabilityDiscount}");
            if (disabilityDiscount > 0)
            {
                discounts.Add(disabilityDiscount);
            }

            //Sconto per i gruppi
            Console.WriteLine("Getting group discount...");
            var groupDiscountCalcolator = _discountCalculatorFactory.GetDiscountCalculator(DiscountType.GroupSize);
            var groupDiscount = groupDiscountCalcolator.CalculateDiscount(order);
            Console.WriteLine($"Group discount: {groupDiscount}");
            if (groupDiscount > 0)
            {
                discounts.Add(groupDiscount);
            }

            //Se non è stato applicato lo sconto di gruppo, applico lo sconto per i bambini
            if (groupDiscount == 0)
            {
                Console.WriteLine("Getting child discount...");
                var childDiscountCalcolator = _discountCalculatorFactory.GetDiscountCalculator(DiscountType.Child);
                var childDiscount = childDiscountCalcolator.CalculateDiscount(order);
                Console.WriteLine($"Child discount: {childDiscount}");
                if (childDiscount > 0)
                {
                    discounts.Add(childDiscount);
                }
            }
            else
            {
                Console.WriteLine("Already got the group discount. Skipping child discount....");
            }

            //Sconto per gli anziani
            Console.WriteLine("Getting senior citizen discount...");
            var seniorCitizenDiscountCalcolator = _discountCalculatorFactory.GetDiscountCalculator(DiscountType.SeniorCitizen);
            var seniorCitizenDiscount = seniorCitizenDiscountCalcolator.CalculateDiscount(order);
            Console.WriteLine($"Senior citizen discount: {seniorCitizenDiscount}");
            if (seniorCitizenDiscount > 0)
            {
                discounts.Add(seniorCitizenDiscount);
            }

            var notYetDiscounted = discounts.Count == 0;

            //Se non è stato applicato nessuno sconto, cerco di applicare lo sconto in base all'orario dell'ordine
            if (notYetDiscounted)
            {
                //Sconto per ordini effettuati entro un certo orario
                Console.WriteLine("Getting early order discount...");
                var earlyOrderDiscountCalculator = _discountCalculatorFactory.GetDiscountCalculator(DiscountType.EarlyOrder);
                var earlyOrderDiscount = earlyOrderDiscountCalculator.CalculateDiscount(order);
                Console.WriteLine($"Early order discount: {earlyOrderDiscount}");
                if (earlyOrderDiscount > 0)
                {
                    discounts.Add(earlyOrderDiscount);
                }
                //Se l'ordine non è stato effettuato entro un certo orario, cerco di applicare lo sconto del fine settimana
                else
                {
                    Console.WriteLine("Getting weekend discount...");
                    var weekendDiscountCalcolator = _discountCalculatorFactory.GetDiscountCalculator(DiscountType.Weekend);
                    var weekendDiscount = weekendDiscountCalcolator.CalculateDiscount(order);
                    Console.WriteLine($"Weekend discount: {weekendDiscount}");
                    if (weekendDiscount > 0)
                    {
                        discounts.Add(weekendDiscount);
                    }
                }
            }
            else
            {
                Console.WriteLine("Already discounted. Skipping order time discount....");
            }

            Console.WriteLine($"Total discounts: {string.Join("+", discounts)}");

            var orderCalculator = new TotalCalculator();

            Console.WriteLine("Getting total...");
            //Applico tutti gli sconti
            var total = orderCalculator.CalculateTotal(order.FullPrice, discounts);
            Console.WriteLine($"Total: {total}");

            return total;
        }
    }
}
