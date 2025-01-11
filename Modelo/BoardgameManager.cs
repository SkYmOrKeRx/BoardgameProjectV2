

namespace BoardgameProjectV2.Modelo;

internal class BoardgameManager
{
    public static Dictionary<int, Boardgame> registeredBoardgames = new();

    //Filling up the database
    static List<Boardgame> boardgamesFiller = BoardgamesMetaData.GetBgs();


    public static List<Boardgame> LoadAllBoardgames()
    {

        List<Boardgame> boardgames = new();

        foreach (Boardgame boardgame in registeredBoardgames.Values) { boardgames.Add(boardgame); }
        return boardgames;
    }

    internal static void AddBoardgameToDB(Boardgame newBoardgame)
    {
        registeredBoardgames.Add(newBoardgame.Index, newBoardgame);
    }

    public static void FillDatabaseWithBoardgames()
    {
        foreach (Boardgame boardgame in boardgamesFiller)
        {
            registeredBoardgames.Add(boardgame.Index, boardgame);
        }
    }

    public static void ListAllBoardgamesInDB()
    {
        Console.WriteLine("\n");
        int currentPage = 0;
        int lastPage = 0;
        foreach (Boardgame boardgame in registeredBoardgames.Values)
        {
            Console.WriteLine($"{boardgame.Index+1}: {boardgame.Name} - {boardgame.ScoresAverage().ToString("F1")}");
            Thread.Sleep(30);
        }
        Console.WriteLine($"\nPage {currentPage}/{lastPage}");
    }

    public static void RankAllBoardgamesInDB(List<Boardgame> boardgames)
    {

        Console.WriteLine("\n");
        for (int i = 0; i < boardgames.Count; i++)
        {
            BoardgameManager.registeredBoardgames[i].Rank = i + 1;            
        }  
    }
}

