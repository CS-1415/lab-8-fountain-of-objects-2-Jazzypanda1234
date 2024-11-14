using System.Security.Cryptography.X509Certificates;
using Lab08;

FountainRoom fountainRoom = new FountainRoom(0, 0);
// Pit pit1 = new Pit(-5, -5);
// Pit pit2 = new Pit(-5, -5);
// Pit pit3 = new Pit(-5, -5);
// Pit pit4 = new Pit(-5, -5);
// Maelstrom maelstrom1 = new Maelstrom(-5, -5);
// Maelstrom maelstrom2 = new Maelstrom(-5, -5);
// Amarok amarok1 = new Amarok(-5, -5);
// Amarok amarok2 = new Amarok(-5, -5);
// Amarok amarok3 = new Amarok(-5, -5);
string sizeInput = getValidSizeInput();
Room[,] Maze = populateMaze(sizeInput);
Monster[,] monsters = populateMonsters(sizeInput);

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
Player player = new Player(0, 0, 5);
while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("You are in the room at  (Column=" + player.x + " Row=" + player.y + " Arrows=" + player.arrows + " ).");
    Maze[player.x, player.y].Information(fountainOn);

    if (monsters[player.x, player.y] != null)
    {
        if (monsters[player.x, player.y].x == player.x && monsters[player.x, player.y].y == player.y)
            monsters[player.x, player.y].Information(player, Maze);
    }


    // if (maelstrom1.x == player.x && maelstrom1.y == player.y)
    //     maelstrom1.Information(player, Maze);
    // if (maelstrom2.x == player.x && maelstrom2.y == player.y)
    //     maelstrom2.Information(player, Maze);

    // if (amarok1.x == player.x && amarok1.y == player.y)
    //     amarok1.Information(player, Maze);
    // if (amarok2.x == player.x && amarok2.y == player.y)
    //     amarok2.Information(player, Maze);
    // if (amarok3.x == player.x && amarok3.y == player.y)
    //     amarok3.Information(player, Maze);

    checkForPits();
    checkForMaelstrom();
    checkForAmarock();

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("What do you want to do?");

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
        // case "shoot north":
        //     player.shootNorth(ref maelstrom1, ref maelstrom2, ref amarok1, ref amarok2, ref amarok3);
        //     break;
        // case "shoot south":
        //     player.shootSouth(ref maelstrom1, ref maelstrom2, ref amarok1, ref amarok2, ref amarok3);
        //     break;
        // case "shoot east":
        //     player.shootEast(ref maelstrom1, ref maelstrom2, ref amarok1, ref amarok2, ref amarok3);
        //     break;
        // case "shoot west":
        //     player.shootWest(ref maelstrom1, ref maelstrom2, ref amarok1, ref amarok2, ref amarok3);
        //     break;
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
        default:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Invalid input. Try again.");
            break;
    }
}

void checkForPits()
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    // if ((player.y - 1 == pit1.y || player.y == pit1.y || player.y + 1 == pit1.y) && (player.x - 1 == pit1.x || player.x == pit1.x || player.x + 1 == pit1.x) ||
    // (player.y - 1 == pit2.y || player.y == pit2.y || player.y + 1 == pit2.y) && (player.x - 1 == pit2.x || player.x == pit2.x || player.x + 1 == pit2.x) ||
    // (player.y - 1 == pit3.y || player.y == pit3.y || player.y + 1 == pit3.y) && (player.x - 1 == pit3.x || player.x == pit3.x || player.x + 1 == pit3.x) ||
    // (player.y - 1 == pit4.y || player.y == pit4.y || player.y + 1 == pit4.y) && (player.x - 1 == pit4.x || player.x == pit4.x || player.x + 1 == pit4.x))
    // {
    //     Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
    // }
}
void checkForMaelstrom()
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    // if ((player.y - 1 == maelstrom1.y || player.y == maelstrom1.y || player.y + 1 == maelstrom1.y) && (player.x - 1 == maelstrom1.x || player.x == maelstrom1.x || player.x + 1 == maelstrom1.x) ||
    // (player.y - 1 == maelstrom2.y || player.y == maelstrom2.y || player.y + 1 == maelstrom2.y) && (player.x - 1 == maelstrom2.x || player.x == maelstrom2.x || player.x + 1 == maelstrom2.x))
    // {
    //     Console.WriteLine("You can hear the growling and groaning of a maelstrom nearby.");
    // }
}
void checkForAmarock()
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    // if ((player.y - 1 == amarok1.y || player.y == amarok1.y || player.y + 1 == amarok1.y) && (player.x - 1 == amarok1.x || player.x == amarok1.x || player.x + 1 == amarok1.x) ||
    // (player.y - 1 == amarok2.y || player.y == amarok2.y || player.y + 1 == amarok2.y) && (player.x - 1 == amarok2.x || player.x == amarok2.x || player.x + 1 == amarok2.x) ||
    // (player.y - 1 == amarok3.y || player.y == amarok3.y || player.y + 1 == amarok3.y) && (player.x - 1 == amarok3.x || player.x == amarok3.x || player.x + 1 == amarok3.x))
    // {
    //     Console.WriteLine("You can smell the rotten stench of an amarok in a nearby room.");
    // }
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
            Maze[0, 2] = new FountainRoom(0, 2);
            // Maze[2, 3] = new Pit(2, 3);
            // maelstrom1 = new Maelstrom(1, 1);
            // fountainRoom = new FountainRoom(0, 2);
            // amarok1 = new Amarok(1, 2);
            // pit1 = new Pit(2, 3);
            break;
        case "medium":
            Maze[0, 4] = new FountainRoom(0, 4);
            // Maze[2, 4] = new Pit(2, 4);
            // Maze[3, 5] = new Pit(3, 5);
            // maelstrom1 = new Maelstrom(1, 1);
            // fountainRoom = new FountainRoom(0, 4);
            // amarok1 = new Amarok(1, 2);
            // amarok2 = new Amarok(4, 0);
            // pit1 = new Pit(2, 4);
            // pit2 = new Pit(3, 5);
            break;
        case "large":
            Maze[0, 6] = new FountainRoom(0, 6);
            // Maze[2, 4] = new Pit(2, 4);
            // Maze[3, 7] = new Pit(3, 7);
            // Maze[0, 3] = new Pit(0, 3);
            // Maze[6, 2] = new Pit(6, 2);
            // maelstrom1 = new Maelstrom(1, 1);
            // maelstrom2 = new Maelstrom(1, 6);
            // fountainRoom = new FountainRoom(0, 6);
            // amarok1 = new Amarok(1, 2);
            // amarok2 = new Amarok(4, 0);
            // amarok3 = new Amarok(5, 6);
            // pit1 = new Pit(2, 4);
            // pit2 = new Pit(3, 7);
            // pit3 = new Pit(0, 3);
            // pit4 = new Pit(6, 2);
            break;
        default:
            break;
    }
    return Maze;
}

Monster[,] populateMonsters(string size)
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

    Monster[,] monsters = new Monster[height, width];
    Random AmarokChance = new Random();
    Random MaelstromChance = new Random();
    Random GoonerChance = new Random();
    for (int y = 1; y < height; y++)
        for (int x = 1; x < width; x++)
        {
            if (GoonerChance.Next(8) == 0)
            {
                monsters[y, x] = new Gooner(x, y);
            }
            else if (MaelstromChance.Next(8) == 0)
            {
                monsters[y, x] = new Maelstrom(x, y);
            }
            else if (AmarokChance.Next(8) == 0)
            {
                monsters[y, x] = new Amarok(x, y);
            }
        }
    return monsters;
}
