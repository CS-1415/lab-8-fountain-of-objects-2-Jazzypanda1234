namespace Lab08;

public class Monster
{
    public int x;
    public int y;
    public int health;
    public int armorClass;
    public Monster(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public virtual void Information(Player player, Room[,] Maze) { }
}

public class Maelstrom : Monster
{
    public Maelstrom(int x, int y) : base(x, y)
    {
        this.x = x;
        this.y = y;
        health = 12;
        armorClass = 5;
    }
    public override void Information(Player player, Room[,] Maze)
    {
        if (player.y >= 1 && player.y <= Maze.GetLength(1))
            player.MoveNorth();
        if (player.x >= 0 && player.x <= Maze.GetLength(0) - 1)
            player.MoveEast();
        if (player.x >= 0 && player.x <= Maze.GetLength(0) - 1)
            player.MoveEast();

        Console.WriteLine("You have been moved by a maelstrom to column " + player.x + " and row " + player.y);

        if (y >= 0 && y <= Maze.GetLength(0) - 1)
            y++;
        if (x >= 1 && x <= Maze.GetLength(0))
            x--;
        if (x >= 1 && x <= Maze.GetLength(0))
            x--;
    }
}

public class Amarok : Monster
{
    public Amarok(int x, int y) : base(x, y)
    {
        this.x = x;
        this.y = y;
        health = 24;
        armorClass = 13;
    }
    public override void Information(Player player, Room[,] Maze)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You have encountered an Amarok. They leap at you and attack.");
        Environment.Exit(0);
    }
}

public class Gooner : Monster
{
    public Gooner(int x, int y) : base(x, y)
    {
        this.x = x;
        this.y = y;
        health = 20;
        armorClass = 10;
    }
    public override void Information(Player player, Room[,] Maze)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("A Gooner creeps from the shadows and moves to attack.");
        Environment.Exit(0);
    }
}

public class Maze
{
    public int length;
    public int width;
    public Maze(int length, int width)
    {
        this.length = length;
        this.width = width;
    }
}

public class Room
{
    public bool fountainOn;
    public int x;
    public int y;

    public Room(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public virtual void Information(bool fountainOn) { }
}

public class FountainRoom : Room
{
    public FountainRoom(int x, int y) : base(x, y)
    {
        this.x = x;
        this.y = y;
    }
    public override void Information(bool fountainOn)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        if (!fountainOn)
        {
            Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
        }
        else
        {
            Console.WriteLine("You hear the rushing waters from the Fountain of Objects It has been reactivated!");
        }
    }
}

public class Entrance : Room
{
    public Entrance(int x, int y) : base(x, y)
    {
        this.x = x;
        this.y = y;
    }
    public override void Information(bool fountainOn)
    {
        if (!fountainOn)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You see light coming from the cavern entrance.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("The Fountain of objects has been reactivated, and you have escaped with your life! \nYou win!");
            Environment.Exit(0);
        }
    }
}

public class Pit : Room
{
    public Pit(int x, int y) : base(x, y)
    {
        this.x = x;
        this.y = y;
    }
    public override void Information(bool fountainOn)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You have fallen to your death. You lose.");
        Environment.Exit(0);
    }
}

public class Player
{
    public int x;
    public int y;
    public int arrows;
    public Player(int x, int y, int arrows)
    {
        this.x = x;
        this.y = y;
        this.arrows = arrows;
    }

    public void MoveNorth()
    {
        y--;
    }
    public void MoveSouth()
    {
        y++;
    }
    public void MoveWest()
    {
        x--;
    }
    public void MoveEast()
    {
        x++;
    }

//     public void shootNorth(ref Maelstrom maelstrom1, ref Maelstrom maelstrom2, ref Amarok amarok1, ref Amarok amarok2, ref Amarok amarok3)
//     {
//         if (arrows > 0)
//         {
//             arrows--;
//             if ((maelstrom1.x == x) && (maelstrom1.y == y - 1))
//             {
//                 maelstrom1 = new Maelstrom(-5, -5);
//             }
//             if ((maelstrom2.x == x) && (maelstrom2.y == y - 1))
//             {
//                 maelstrom2 = new Maelstrom(-5, -5);
//             }
//             if ((amarok1.x == x) && (amarok1.y == y - 1))
//             {
//                 amarok1 = new Amarok(-5, -5);
//             }
//             if ((amarok2.x == x) && (amarok2.y == y - 1))
//             {
//                 amarok2 = new Amarok(-5, -5);
//             }
//             if ((amarok3.x == x) && (amarok3.y == y - 1))
//             {
//                 amarok3 = new Amarok(-5, -5);
//             }
//         }
//         else
//             Console.WriteLine("You are out of arrows");
//     }
//     public void shootSouth(ref Maelstrom maelstrom1, ref Maelstrom maelstrom2, ref Amarok amarok1, ref Amarok amarok2, ref Amarok amarok3)
//     {
//         if (arrows > 0)
//         {
//             arrows--;
//             if ((maelstrom1.x == x) && (maelstrom1.y == y + 1))
//             {
//                 maelstrom1 = new Maelstrom(-5, -5);
//             }
//             if ((maelstrom2.x == x) && (maelstrom2.y == y + 1))
//             {
//                 maelstrom2 = new Maelstrom(-5, -5);
//             }
//             if ((amarok1.x == x) && (amarok1.y == y + 1))
//             {
//                 amarok1 = new Amarok(-5, -5);
//             }
//             if ((amarok2.x == x) && (amarok2.y == y + 1))
//             {
//                 amarok2 = new Amarok(-5, -5);
//             }
//             if ((amarok3.x == x) && (amarok3.y == y + 1))
//             {
//                 amarok3 = new Amarok(-5, -5);
//             }
//         }
//         else
//             Console.WriteLine("You are out of arrows");
//     }
//     public void shootWest(ref Maelstrom maelstrom1, ref Maelstrom maelstrom2, ref Amarok amarok1, ref Amarok amarok2, ref Amarok amarok3)
//     {
//         if (arrows > 0)
//         {
//             arrows--;
//             if ((maelstrom1.x == x - 1) && (maelstrom1.y == y))
//             {
//                 maelstrom1 = new Maelstrom(-5, -5);
//             }
//             if ((maelstrom2.x == x - 1) && (maelstrom2.y == y))
//             {
//                 maelstrom2 = new Maelstrom(-5, -5);
//             }
//             if ((amarok1.x == x - 1) && (amarok1.y == y))
//             {
//                 amarok1 = new Amarok(-5, -5);
//             }
//             if ((amarok2.x == x - 1) && (amarok2.y == y))
//             {
//                 amarok2 = new Amarok(-5, -5);
//             }
//             if ((amarok3.x == x - 1) && (amarok3.y == y))
//             {
//                 amarok3 = new Amarok(-5, -5);
//             }
//         }
//         else
//             Console.WriteLine("You are out of arrows");
//     }
//     public void shootEast(ref Maelstrom maelstrom1, ref Maelstrom maelstrom2, ref Amarok amarok1, ref Amarok amarok2, ref Amarok amarok3)
//     {
//         if (arrows > 0)
//         {
//             arrows--;
//             if ((maelstrom1.x == x + 1) && (maelstrom1.y == y))
//             {
//                 maelstrom1 = new Maelstrom(-5, -5);
//             }
//             if ((maelstrom2.x == x + 1) && (maelstrom2.y == y))
//             {
//                 maelstrom2 = new Maelstrom(-5, -5);
//             }
//             if ((amarok1.x == x + 1) && (amarok1.y == y))
//             {
//                 amarok1 = new Amarok(-5, -5);
//             }
//             if ((amarok2.x == x + 1) && (amarok2.y == y))
//             {
//                 amarok2 = new Amarok(-5, -5);
//             }
//             if ((amarok3.x == x + 1) && (amarok3.y == y))
//             {
//                 amarok3 = new Amarok(-5, -5);
//             }
//         }
//         else
//             Console.WriteLine("You are out of arrows");
//     }
}

public class Battle
{
    public int x;
    public int y;
    public Battle(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void TotalBattle()
    {

    }
    public void PlayerTurn()
    {

    }
    public void MonsterTurn()
    {
        
    }
}