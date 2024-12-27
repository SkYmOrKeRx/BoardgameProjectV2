namespace BoardgameProjectV2.Modelo;

internal class BoardgameQueriesPrinter
{
    public static void PrintOrderByName(List<Boardgame> boardgames)
    {
        Console.WriteLine("\n\nORDER BY NAME (ASCENDING)\n\n");
        foreach (Boardgame boardgame in boardgames) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name}");
    }

    public static void PrintOrderByLaunchDate(List<Boardgame> boardgames)
    {
        Console.WriteLine("\n\nORDER BY LAUNCH DATE (ASCENDING)\n\n");
        foreach (Boardgame boardgame in boardgames) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name} - {boardgame.LaunchDate}");
    }

    public static void PrintOrderByPrice(List<Boardgame> boardgames)
    {
        Console.WriteLine("\n\nORDER BY PRICE (ASCENDING)\n\n");
        foreach (Boardgame boardgame in boardgames) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name} - ${boardgame.Price}");
    }

    public static void PrintOrderByRank(List<Boardgame> boardgames) 
    {
        Console.WriteLine("\n\nORDER BY RANK (DESCENDING)\n\n");
        BoardgameManager.RankAllBoardgamesInDB(boardgames);
    }

    public static void PrintOrderByMostReviews(List<Boardgame> boardgames)
    {
        Console.WriteLine("\n\nORDER BY MOST REVIEWS (ASCENDING)\n\n");
        foreach (Boardgame boardgame in boardgames) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name} - {boardgame.Scores.Count}");
    }
}
