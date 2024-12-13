

namespace BoardgameProjectV2.Modelo;

internal class BoardgameManager
{
    public static Dictionary<int, Boardgame> registeredBoardgames = new();


    public static List<Boardgame> LoadAllBoardgames()
    {
        List<Boardgame> boardgames = new();
        foreach (Boardgame boardgame in registeredBoardgames.Values) 
        {
            boardgames.Add(boardgame);
        }
        return boardgames;
    }

    internal static void AddBoardgameToDB(Boardgame newBoardgame)
    {
        registeredBoardgames.Add(newBoardgame.Index, newBoardgame);
    }
}

