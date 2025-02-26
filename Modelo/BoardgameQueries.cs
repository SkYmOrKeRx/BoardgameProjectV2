﻿
namespace BoardgameProjectV2.Modelo;

internal class BoardgameQueries
{
    ///////////////////////// SORT ////////////////

    private static List<Boardgame> newBoardgamesList = BoardgameManager.LoadAllBoardgames();

    public static List<Boardgame> GetBoardgamesAscendingName()
    {
        return newBoardgamesList.OrderBy(boardgame => boardgame.Name).ToList();
        
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
        return newBoardgamesList.OrderByDescending(boardgame => boardgame.ScoresAverage()).ToList();

    }

    internal static List<Boardgame> GetBoardgamesAscendingScores()
    {
        return newBoardgamesList.OrderByDescending(boardgame => boardgame.Scores.Count).ToList();
    }

    ///////////////////////// FILTERS ////////////////

    internal static List<Boardgame> GetBoardgamesAscendingFilterName(string input)
    {       
       return newBoardgamesList.FindAll(boardgame => boardgame.Name.Contains(input,StringComparison.OrdinalIgnoreCase)).ToList();
    }

    internal static List<Boardgame> GetBoardgamesAscendingFilterLaunchDate(string input)
    {
        return newBoardgamesList.FindAll(boardgame => boardgame.LaunchDate.ToString().Contains(input, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    internal static List<Boardgame> GetBoardgamesAscendingFilterPrice(string input)
    {
        return new List<Boardgame>();
        
    }

}
