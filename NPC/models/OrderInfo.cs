namespace NPC.models
{
    //Classe contente le informazioni dell'ordine
    public class OrderInfo
    {
        public decimal FullPrice { get; private set; }
        // Rappresenta se il cliente ha una carta fedeltà
        public bool HasFidelityCard { get; private set; }

        // Rappresenta se il cliente ha una disabilità
        public bool HasDisability { get; private set; }

        // Rappresenta la dimensione del gruppo
        public int GroupSize { get; private set; }

        // Rappresenta la data e l'ora dell'ordine
        public DateTime OrderDateTime { get; private set; }

        // Rappresenta l'età del cliente
        public int CustomerAge { get; private set; }

        public OrderInfo(decimal fullPrice, bool hasFidelityCard, bool hasDisability, int groupSize, DateTime orderDateTime, int customerAge)
        {
            FullPrice = fullPrice;
            HasFidelityCard = hasFidelityCard;
            HasDisability = hasDisability;
            GroupSize = groupSize;
            OrderDateTime = orderDateTime;
            CustomerAge = customerAge;
        }
    }
}
