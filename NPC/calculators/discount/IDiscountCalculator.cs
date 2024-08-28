using NPC.models;

namespace NPC.calculators.discount
{
    //Interfaccia implementata da tutte le classi che calcolano uno sconto.
    //Ogni classe che calcola uno sconto deve implementare il metodo CalculateDiscount che prende in input le informazioni dell'ordine e restituisce lo sconto calcolato.
    public interface IDiscountCalculator
    {
        decimal CalculateDiscount(OrderInfo input);
    }
}
