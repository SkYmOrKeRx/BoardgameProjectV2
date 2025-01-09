
namespace BoardgameProjectV2.Modelo;

internal class BoardgameQueriesPrinter
{
    public static void PrintOrderByName(List<Boardgame> boardgames)
    {
        Console.WriteLine("ORDER BY NAME (ASCENDING)\n");
        foreach (Boardgame boardgame in boardgames) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name}");
    }

    public static void PrintOrderByLaunchDate(List<Boardgame> boardgames)
    {
        Console.WriteLine("ORDER BY LAUNCH DATE (ASCENDING)\n");
        foreach (Boardgame boardgame in boardgames) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name} - {boardgame.LaunchDate}");
    }

    public static void PrintOrderByPrice(List<Boardgame> boardgames)
    {
        Console.WriteLine("ORDER BY PRICE (ASCENDING)\n");
        foreach (Boardgame boardgame in boardgames) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name} - ${boardgame.Price}");
    }

    public static void PrintOrderByRank(List<Boardgame> boardgames) 
    {
        Console.WriteLine("ORDER BY RANK (DESCENDING)\n");
        BoardgameManager.RankAllBoardgamesInDB(boardgames);
    }

    public static void PrintOrderByMostReviews(List<Boardgame> boardgames)
    {
        Console.WriteLine("ORDER BY MOST REVIEWS (ASCENDING)\n");
        foreach (Boardgame boardgame in boardgames) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name} - {boardgame.Scores.Count}");
    }

    public static void PrintFilterByName(List<Boardgame> boardgames) 
    {
        Console.WriteLine("FILTER BY NAME (ASCENDING)\n");
        if (boardgames.Count <= 0) 
        {
            Console.WriteLine("\nNo boardgames have been found with this criteria...");
            return;
        }
        else foreach (Boardgame boardgame in boardgames) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name}");
    }

    public static void PrintFilterByLaunchDate(List<Boardgame> boardgames)
    {
        Console.WriteLine("FILTER BY LAUNCH DATE (ASCENDING)\n");
        if (boardgames.Count <= 0)
        {
            Console.WriteLine("\nNo boardgames have been found with this criteria...");
            return;
        }
        else 
        {
            Console.WriteLine($"Great! Found {boardgames.Count} ocorrences!!\n");
            foreach (Boardgame boardgame in boardgames) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name} - {boardgame.LaunchDate}");
        }
        
    }

    internal static void PrintFilterByPrice(List<Boardgame> boardgamesOrdered)
    {
        Console.WriteLine("FILTER BY PRICE RANGE (ASCENDING)\n");
        if (boardgamesOrdered.Count <= 0)
        {
            Console.WriteLine("\nNo boardgames have been found with this criteria...");
            return;
        }
        else
        {
            Console.WriteLine($"Great! Found {boardgamesOrdered.Count} ocorrences!!\n");
            foreach (Boardgame boardgame in boardgamesOrdered) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name} - ${boardgame.Price}");
        }
    }
}
