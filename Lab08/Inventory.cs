namespace Lab08;

public class Inventory
{
    public List<Item> items = new List<Item>();
    public Inventory(params Item[] things)
    {
        foreach (var item in things)
        {
            items.Add(item);
        }
    }

    public int CountSwords(Inventory inventory)
    {
        int swordCount = 0;
        for (int i = 0; i < inventory.items.Count(); i++)
        {
            if (inventory.items[i].name == "sword")
            {
                swordCount++;
            }
        }
        return swordCount;
    }
    public int CountPotions(Inventory inventory)
    {
        int potionCount = 0;
        for (int i = 0; i < inventory.items.Count(); i++)
        {
            if (inventory.items[i].name == "potion")
            {
                potionCount++;
            }
        }
        return potionCount;
    }

    public void CheckInventory(Inventory inventory)
    {
        Console.WriteLine("Your inventory:");
        for (int i = 0; i < inventory.items.Count(); i++)
            if (inventory.items[i].name != "fist")
                Console.WriteLine(inventory.items[i].name);
    }
}