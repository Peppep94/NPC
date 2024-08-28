namespace NPC.calculators.discount.helpers
{
    //Helper che permette di scomporre le stringhe che rappresentano un intervallo di numeri e di verificare se un numero è compreso in quell'intervallo.
    internal static class RangeComparerHelper
    {
        public static bool IsInRange(int value, string range)
        {
            var groupRange = range.Split('-');
            int minValue = int.Parse(groupRange[0]);
            int maxValue = groupRange.Length > 1 ? int.Parse(groupRange[1]) : int.MaxValue;

            return value >= minValue && value <= maxValue;
        }
    }
}
