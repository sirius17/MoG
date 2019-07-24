using System.Collections.Generic;

namespace MoG
{
    public class PriceList
    {
        private Dictionary<string, Item> _items = new Dictionary<string, Item>();

        public void AddItem(Item item)
        {
            _items[item.Name] = item;
        }

        public float GetUnitPrice(string itemName)
        {
            return _items[itemName].Price;
        }
    }
}
