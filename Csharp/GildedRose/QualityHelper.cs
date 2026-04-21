namespace GildedRoseKata
{
    public static class QualityHelper
    {
        private const int MaximumQuality = 40;
        private const int MinimumQuality = 0;

        public static void IncreaseQuality(Item item, int amount)
        {
            item.Quality += amount;

            if (item.Quality > MaximumQuality)
            { 
                item.Quality = MaximumQuality;
            }
        }

        public static void DecreaseQuality(Item item, int amount)
        {
            item.Quality -= amount;

            if (item.Quality < MinimumQuality)
            {
                item.Quality = MinimumQuality;
            }
        }
    }
}
