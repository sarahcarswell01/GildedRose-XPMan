using System.Collections.Generic;

namespace GildedRose
{
	class GildedRose
	{
		IList<Item> Items;
		public GildedRose(IList<Item> Items) 
		{
			this.Items = Items;
		}

    const string concertTickets = "Backstage passes to a TAFKAL80ETC concert";
    const string cheese = "Aged Brie";
    const string legendaryItem = "Sulfuras, Hand of Ragnaros";
    const int MAXQUALITY = 50;
    const int MINQUALITY = 0;

		public void UpdateQuality()
		{
			foreach (var item in Items)
			{
				if (item.Name != cheese && item.Name != concertTickets)
				{
					if (item.Quality > MINQUALITY)
					{
            DecrementNonLegendaryItem(item);
					}
				}
				else
				{
          UpdateConcertTicketQuality(item);
				}
				
				if (item.Name != legendaryItem)
				{
					item.SellIn--;
				}
				
				if (item.SellIn < MINQUALITY)
				{
					if (item.Name != cheese)
					{
						if (item.Name != concertTickets)
						{
							if (item.Quality > MINQUALITY)
							{
                DecrementNonLegendaryItem(item);
							}
						}
						else
						{
							item.Quality = MINQUALITY;
						}
					}
					else
					{
            Increment(item);
					}
				}
			}
		}
		
    private void UpdateConcertTicketQuality(Item item)
    {
      if (item.Quality < MAXQUALITY)
				{
					item.Quality++;

          if (item.Name == concertTickets)
					{
						if (item.SellIn < 11)
						{
              Increment(item);
						}
							
						if (item.SellIn < 6)
						{
              Increment(item);
						}
					}
				}
    }

    private void Increment(Item item)
    {
      if (item.Quality < MAXQUALITY)
			{
				item.Quality++; 
			}
    }

    private void DecrementNonLegendaryItem(Item item)
    {
      if (item.Name != legendaryItem)
			{
        item.Quality--;
			}
    }

	}
	
	public class Item
	{
		public string Name { get; set; }
		
		public int SellIn { get; set; }
		
		public int Quality { get; set; }
	}
	
}
