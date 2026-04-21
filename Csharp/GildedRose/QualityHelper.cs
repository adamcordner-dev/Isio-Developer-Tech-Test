namespace GildedRoseKata
{
    public static class QualityHelper
    {
        private const int MaxQuality = 40;
        private const int MinQuality = 0;

        public static void IncreaseQuality(Item item, int amount)
        {
            item.Quality += amount;

            if (item.Quality > MaxQuality)
            { 
                item.Quality = MaxQuality;
            }
        }

        public static void DecreaseQuality(Item item, int amount)
        {
            item.Quality -= amount;

            if (item.Quality < MinQuality)
            {
                item.Quality = MinQuality;
            }
        }
    }
}
