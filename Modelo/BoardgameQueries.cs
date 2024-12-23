using System.Collections.Generic;
using System.Linq;


namespace BoardgameProjectV2.Modelo;

internal class BoardgameQueries
{
    private static List<Boardgame> newBoardgamesList = BoardgameManager.LoadAllBoardgames();

    public static List<Boardgame> GetBoardgamesAscendingName()
    {
        return newBoardgamesList.OrderBy(boardgame => boardgame.Name).ToList();
    }

    public static List<Boardgame> GetBoardgamesDescendingName() 
    {
         return newBoardgamesList.OrderByDescending(boardgame => boardgame.Name).ToList(); 
    }

    internal static List<Boardgame> GetBoardgamesAscendingLaunchDate()
    {
        return newBoardgamesList.OrderBy(boardgame => boardgame.LaunchDate).ToList();
    }

    internal static List<Boardgame> GetBoardgamesAscendingPrice()
    {
        return newBoardgamesList.OrderBy(boardgame => boardgame.Price).ToList();
    }

    internal static List<Boardgame> GetBoardgamesAscendingRank()
    {
        return newBoardgamesList.OrderBy(boardgame => boardgame.Rank).ToList();
    }

    internal static List<Boardgame> GetBoardgamesAscendingScores()
    {
        return newBoardgamesList.OrderBy(boardgame => boardgame.Scores.Count).ToList();
    }
}
