
using System.Diagnostics;

namespace BoardgameProjectV2.Modelo;

internal class BoardgameQueriesPrinter
{
    public static void PrintOrderByName(List<Boardgame> boardgames)
    {
        int i = 0;
        int maxString = boardgames.Max(boardgame => boardgame.Name.Length);
        Console.WriteLine("\nORDER BY NAME (ASCENDING)\n");
        Console.WriteLine($"Option -    Name\n");
        foreach (Boardgame boardgame in boardgames) 
        {   
            Console.WriteLine($" {(i + 1),2}    -    {boardgame.Name.PadRight(maxString)} (#{boardgame.Index + 1})");
            i++;
        } 
    }

    public static void PrintOrderByLaunchDate(List<Boardgame> boardgames)
    {
        int i = 0;
        Console.WriteLine("\nORDER BY LAUNCH DATE (ASCENDING)\n");
        Console.WriteLine($"Option -    Name\n");
        foreach (Boardgame boardgame in boardgames)
        {
            Console.WriteLine($" {(i + 1),2}    -    {boardgame.Name} ({boardgame.LaunchDate})");
            i++;
        } 
    }

    public static void PrintOrderByPrice(List<Boardgame> boardgames)
    {
        int maxString = boardgames.Max(boardgame => boardgame.Name.Length);
        int i = 0;
        string whiteSpaces = " ";

        Console.WriteLine("\nORDER BY PRICE (ASCENDING)\n");
        Console.WriteLine($"Option -   {"Name".ToString().PadRight(maxString)}-     Price\n");
        foreach (Boardgame boardgame in boardgames) 
        {
            Console.WriteLine($" {(i + 1),2} -       {boardgames[i].Name.PadRight(maxString)} -     {i + 1} ({boardgames[i].ScoresAverage().ToString("F1")})");
            i++;
        } 
    }
    public static void PrintOrderByRank(List<Boardgame> boardgames) 
    {
        BoardgameManager.RankAllBoardgamesInDB(boardgames);
        int i = 0;
        int maxString = boardgames.Max(boardgame => boardgame.Name.Length);

        Console.WriteLine("ORDER BY RANK (DESCENDING)\n");
        
        Console.WriteLine($"Option -    {"Name".ToString().PadRight(maxString)}-     {"Rank".ToString().PadRight(boardgames.Count)}\n");
        foreach (Boardgame boardgame in boardgames)
        {
            Console.WriteLine($" {(i + 1),2} -       {boardgames[i].Name.PadRight(maxString)} -     {i + 1} ({boardgames[i].ScoresAverage().ToString("F1")})");
            i++;
        }
        
    }

    public static void PrintOrderByMostReviews(List<Boardgame> boardgames)
    {
        int i = 0;
        int maxString = boardgames.Max(boardgame => boardgame.Name.Length);

        
        Console.WriteLine("\nORDER BY MOST REVIEWS (ASCENDING)\n");
        Console.WriteLine($"Option -    {"Name".ToString().PadRight(maxString)}-     {"Reviews"}\n");
        foreach (Boardgame boardgame in boardgames)
        {
            Console.WriteLine($" {(i + 1),2} -       {boardgames[i].Name.PadRight(maxString)} -      {boardgame.Scores.Count}");
            i++;
        }
        
    }

    public static void PrintFilterByName(List<Boardgame> boardgames) 
    {
        Console.WriteLine("\nFILTER BY NAME (ASCENDING)\n");
        if (boardgames.Count <= 0)
        {
            Console.WriteLine("\nNo boardgames have been found with this criteria...");
            return;
        }
        else
        {
            int i = 0;
            foreach (Boardgame boardgame in boardgames)
            {
                Console.WriteLine($"{i + 1} - #{boardgame.Index + 1} {boardgame.Name}");
                i++;
            }
                
        }
    }

    public static void PrintFilterByLaunchDate(List<Boardgame> boardgames)
    {
        Console.WriteLine("\nFILTER BY LAUNCH DATE (ASCENDING)\n");
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
        Console.WriteLine("\nFILTER BY PRICE RANGE (ASCENDING)\n");
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
