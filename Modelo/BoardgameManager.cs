

namespace BoardgameProjectV2.Modelo;

internal class BoardgameManager
{
    public static Dictionary<int, Boardgame> registeredBoardgames = new();

    //Filling up the database
    static List<Boardgame> boardgamesFiller = new List<Boardgame>
    {
    new Boardgame("Catan", "Jogo de estratégia e comércio.", 1995, true, 45.99f, 9),
    new Boardgame("Ticket to Ride", "Construção de rotas ferroviárias.", 2004, true, 39.99f, 8),
    new Boardgame("Pandemic", "Jogo cooperativo de controle de epidemias.", 2008, true, 42.50f, 9),
    new Boardgame("Carcassonne", "Construção de territórios medievais.", 2000, true, 34.95f, 8),
    new Boardgame("Terra Mystica", "Expansão de territórios e gerenciamento de recursos.", 2012, true, 59.99f, 10)
    };


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
        foreach (Boardgame boardgame in registeredBoardgames.Values)
        {
            Console.WriteLine($"#{boardgame.Index+1}: {boardgame.Name} - {boardgame.ScoresAverage().ToString("F1")}");
            Thread.Sleep(30);
        }
    }
}

