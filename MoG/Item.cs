namespace MoG
{
    public class Item
    {
        public Item(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public float Price { get; }
    }
}
