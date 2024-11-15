using System.Security.Cryptography.X509Certificates;
using Lab08;

FountainRoom fountainRoom = new FountainRoom(0, 0);
string sizeInput = getValidSizeInput();
Room[,] Maze = populateMaze(sizeInput);
Monster[,] monsters = populateMonsters(sizeInput);
Inventory PlayerInventory = new Inventory(new Fist(), new Potion());

string getValidSizeInput()
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Would you like a small, medium, or large map?");
    string? Input = Console.ReadLine();
    if (Input == "small" || Input == "medium" || Input == "large")
        return Input;
    else
        return getValidSizeInput();
}

bool fountainOn = false;
Player player = new Player(0, 0, PlayerInventory);
while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("You are in the room at  (Column=" + player.x + " Row=" + player.y + " Health=" + player.health + ").");
    Maze[player.x, player.y].Information(fountainOn);

    checkForMonsters();

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("What do you want to do? (move (north,east,south,west), enable fountain, check inventory, drink potion)");

    Console.ForegroundColor = ConsoleColor.Cyan;
    string action = Console.ReadLine();
    switch (action)
    {
        case "move north":
            if (player.y > 0 && player.y <= Maze.GetLength(1) - 1)
                player.MoveNorth();
            break;
        case "move south":
            if (player.y >= 0 && player.y < Maze.GetLength(1) - 1)
                player.MoveSouth();
            break;
        case "move west":
            if (player.x > 0 && player.x <= Maze.GetLength(0) - 1)
                player.MoveWest();
            break;
        case "move east":
            if (player.x >= 0 && player.x < Maze.GetLength(0) - 1)
                player.MoveEast();
            break;
        case "enable fountain":
            if (player.y == fountainRoom.y && player.x == fountainRoom.x)
            {
                fountainOn = true;
                Maze[fountainRoom.x, fountainRoom.y].fountainOn = fountainOn;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You are not in the fountain room");
            }
            break;
        case "check inventory":
            player.inventory.CheckInventory(player.inventory);
            break;
        case "drink potion":
            if (player.inventory.CountPotions(player.inventory) > 0)
            {
                player.health += 5;
                for (int i = 0; i < player.inventory.items.Count(); i++)
                {
                    if (player.inventory.items[i].name == "potion")
                    {
                        player.inventory.items.Remove(player.inventory.items[i]);
                        break;
                    }
                }
                Console.WriteLine("You have gained 5 health. You are now at " + player.health + " health.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You are out of potions.");
            }
            break;
        default:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Invalid input. Try again.");
            break;
    }
    if (monsters[player.x, player.y] != null)
    {
        monsters[player.x, player.y].AttackDialog(player, Maze, monsters);
    }
}

void checkForMonsters()
{
    Console.ForegroundColor = ConsoleColor.DarkRed;

    for (int x = player.x - 1; x <= player.x + 1; x++)
        for (int y = player.y - 1; y <= player.y + 1; y++)
            if (!(x < 0 || y < 0 || x > Maze.GetLength(0) - 1 || y > Maze.GetLength(1) - 1) && monsters[x, y] != null)
            {
                monsters[x, y].Information();
            }
}

Room[,] populateMaze(string size)
{
    int height = 0;
    int width = 0;
    switch (size)
    {
        case "small":
            height = 4;
            width = 4;
            break;
        case "medium":
            height = 6;
            width = 6;
            break;
        case "large":
            height = 8;
            width = 8;
            break;
        default:
            break;
    }

    Room[,] Maze = new Room[height, width];
    for (int y = 0; y < height; y++)
        for (int x = 0; x < width; x++)
            Maze[y, x] = new Room(x, y);

    Maze[0, 0] = new Entrance(0, 0);
    switch (size)
    {
        case "small":
            Maze[1, 2] = new FountainRoom(1, 2);
            fountainRoom = new FountainRoom(1, 2);
            break;
        case "medium":
            Maze[1, 4] = new FountainRoom(1, 4);

            fountainRoom = new FountainRoom(1, 4);
            break;
        case "large":
            Maze[2, 6] = new FountainRoom(2, 6);
            fountainRoom = new FountainRoom(2, 6);
            break;
        default:
            break;
    }
    return Maze;
}

Monster[,] populateMonsters(string size)
{
    Inventory GoonerInventory = new Inventory(new Sword(), new Potion());
    Inventory MaelstromInventory = new Inventory(new Fist(), new Potion());
    Inventory AmarokInventory = new Inventory(new Sword(), new Potion(), new Potion());
    int height = 0;
    int width = 0;
    switch (size)
    {
        case "small":
            height = 4;
            width = 4;
            break;
        case "medium":
            height = 6;
            width = 6;
            break;
        case "large":
            height = 8;
            width = 8;
            break;
        default:
            break;
    }

    Monster[,] monsters = new Monster[height, width];
    Random MonsterChance = new Random();
    for (int y = 1; y < height; y++)
        for (int x = 1; x < width; x++)
        {
            if (MonsterChance.Next(6) == 0)
            {
                monsters[y, x] = new Gooner(x, y, GoonerInventory);
            }
            else if (MonsterChance.Next(6) == 0)
            {
                monsters[y, x] = new Maelstrom(x, y, MaelstromInventory);
            }
            else if (MonsterChance.Next(6) == 0)
            {
                monsters[y, x] = new Amarok(x, y, AmarokInventory);
            }
        }
    return monsters;
}
