using BoardgameProjectV2.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BoardgameProjectV2.Menus;

delegate List<Boardgame> BoardgameQuery();

internal class MenuCheckBoardgameDatabase: Menu
{
    private string menuName = "***CHECK BOARDGAME DATABASE MENU***";

    private Dictionary<int, BoardgameQuery> boardgameQueries = new Dictionary<int, BoardgameQuery>()
    {
        { 1, new BoardgameQuery(BoardgameQueries.GetBoardgamesAscendingName) },
        { 2, new BoardgameQuery(BoardgameQueries.GetBoardgamesAscendingLaunchDate)},
        { 3, new BoardgameQuery(BoardgameQueries.GetBoardgamesAscendingPrice)},
        { 4, new BoardgameQuery(BoardgameQueries.GetBoardgamesAscendingRank)},
        { 5, new BoardgameQuery(BoardgameQueries.GetBoardgamesAscendingScores)}   
    };
   

    public override void ShowMenu()
    {
        if (MenuConfirmation.MenuSelectedConfirmation(this)) CheckBoardgameDatabase();
    }

    public override void DisplayTitle()
    {
        Console.Clear();

        Console.WriteLine("***************************************************");
        Console.WriteLine(welcomeTitle);
        Console.WriteLine("***************************************************");
        Console.WriteLine(menuName);

    }

    public void CheckBoardgameDatabase()
    {
        List<Boardgame> registeredBoardgames = BoardgameManager.LoadAllBoardgames();
        string userInput;
        int newBoardgameNumber = 0;

        DisplayTitle();
        Console.WriteLine("\n\nAll right! Let's check the boardgame database!!");
        Thread.Sleep(3000);

        DisplayTitle();
        Console.WriteLine("\n\nLoading registered boardgames in database...");

        if (registeredBoardgames.Count <= 0)
        {
            DisplayTitle();
            Console.WriteLine("\n\nNo boardgames have been found in the database ;(");
            Thread.Sleep(3000);
            DisplayTitle();
            Console.WriteLine("\n\nHeading back to the main menu...");
            Thread.Sleep(3000); 
        }
        else
        {
            while (true)
            {
                DisplayTitle();
                BoardgameManager.ListAllBoardgamesInDB();

                Console.Write("\n\nSelect the number corresponding to the boardgame to check it out or 'F1' for more options:");
                userInput = Console.ReadLine()!;

                if (int.TryParse(userInput, out newBoardgameNumber))
                {
                    if ((newBoardgameNumber < 1) || (newBoardgameNumber > registeredBoardgames.Count))
                    {
                        DisplayTitle();
                        Console.WriteLine($"\n\n... {userInput} is not a valid option! Try again");
                        Thread.Sleep(1750);
                    }
                    else break;
                }
                else if (userInput.Equals(" "))
                {
                    MenuGetBoardgamesQueryList();
                } 
                else
                {
                    DisplayTitle();
                    Console.WriteLine($"\n\n... You must select a valid option! Try again");
                    Thread.Sleep(1750);
                }
            }

            DisplayTitle();
            registeredBoardgames[newBoardgameNumber-1].ShowDetails();


        }
        Console.WriteLine("\n\nPress any key to get back to the previous menu");
        Console.ReadKey();
    }

    private void MenuGetBoardgamesQueryList()
    {
        while (true) 
        {
            DisplayTitle();
            Console.WriteLine("\n\nChoose a query type:");
            Console.WriteLine("\n1-Order");
            Console.WriteLine("2-Filter");
            var userInput = Console.ReadLine()!;
            if (int.TryParse(userInput, out int selectedOption))
            {
                if ((selectedOption != 1) && (selectedOption != 2))
                {
                    DisplayTitle();
                    Console.WriteLine($"\n\n... {userInput} is not a valid option! Try again");
                    Thread.Sleep(1750);
                }
                else 
                {
                    if(selectedOption == 1) OrderQueryMenu();
                    if (selectedOption == 2) FilterQueryMenu();
                }

            }
            else
            {
                DisplayTitle();
                Console.WriteLine($"\n\n... You must select a valid option! Try again");
                Thread.Sleep(1750);
            }
        } 
    }

    private void OrderQueryMenu()
    {
        List<Boardgame> boardgamesOrdered = new();

        while (true)
        {
            DisplayTitle();
            Console.WriteLine("\n\n1 - Order boardgames by name");
            Console.WriteLine("2 - Order boardgames by launch date");
            Console.WriteLine("3 - Order boardgames by price (ascending)");
            Console.WriteLine("4 - Order boardgames by current rank");
            Console.WriteLine("5 - Order boardgames by most reviews");
            Console.Write("\n\nChoose an option:");
            var userInput = Console.ReadLine()!;
            if (int.TryParse(userInput, out int selectedOption))
            {
                if ((selectedOption < 0) && (selectedOption > 6))
                {
                    DisplayTitle();
                    Console.WriteLine($"\n\n... {userInput} is not a valid option! Try again");
                    Thread.Sleep(1750);
                }
                else
                {
                    DisplayTitle();
                    if(boardgameQueries.TryGetValue(selectedOption, out BoardgameQuery? query)) boardgamesOrdered = query();
                    switch (selectedOption)
                    {
                        case 1:
                            BoardgameQueriesPrinter.PrintOrderByName(boardgamesOrdered);
                            break;
                        case 2:
                            BoardgameQueriesPrinter.PrintOrderByLaunchDate(boardgamesOrdered);
                            break;
                        case 3:
                            BoardgameQueriesPrinter.PrintOrderByPrice(boardgamesOrdered);
                            break;
                        case 4:
                            BoardgameQueriesPrinter.PrintOrderByRank(boardgamesOrdered);
                            break;
                        case 5:
                            BoardgameQueriesPrinter.PrintOrderByMostReviews(boardgamesOrdered);
                            break;
                        default:
                            break;
                    }                                                          
                }
            }
            else
            {
                DisplayTitle();
                Console.WriteLine($"\n\n... You must select a valid option! Try again");
                Thread.Sleep(1750);
            }
           
            Console.WriteLine("\n\nPress any key to get back to the main menu...");
            Console.ReadKey();
            menuOptions[9].ShowMenu();
        }
    }

    private void FilterQueryMenu()
    {
        List<Boardgame> boardgamesOrdered = new();
        Console.WriteLine("\n\n1 - Filter boardgames by availability");
        while (true)
        {
            DisplayTitle();
            Console.WriteLine("\n\n1 - Filter boardgames by name");
            Console.WriteLine("2 - Filter boardgames by launch date");
            Console.WriteLine("3 - Filter boardgames by range of price (ascending)");
            Console.WriteLine("4 - Filter boardgames by range of scores");
            Console.WriteLine("5 - Filter boardgames by description");
            Console.Write("\n\nChoose an option:");
            var userInput = Console.ReadLine()!;
            if (int.TryParse(userInput, out int selectedOption))
            {
                if ((selectedOption < 0) && (selectedOption > 6))
                {
                    DisplayTitle();
                    Console.WriteLine($"\n\n... {userInput} is not a valid option! Try again");
                    Thread.Sleep(1750);
                }
                else
                {
                    DisplayTitle();
                    switch (selectedOption)
                    {
                        case 1:
                            FilterBoardgamesByName();
                            
                            break;
                        case 2:
                            boardgamesOrdered = BoardgameQueries.GetBoardgamesAscendingLaunchDate();
                            foreach (Boardgame boardgame in boardgamesOrdered) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name} - {boardgame.LaunchDate}");
                            break;
                        case 3:
                            boardgamesOrdered = BoardgameQueries.GetBoardgamesAscendingPrice();
                            foreach (Boardgame boardgame in boardgamesOrdered) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name} - ${boardgame.Price}");
                            break;
                        case 4:
                            boardgamesOrdered = BoardgameQueries.GetBoardgamesAscendingRank();
                            BoardgameManager.RankAllBoardgamesInDB(boardgamesOrdered);
                            break;
                        case 5:
                            boardgamesOrdered = BoardgameQueries.GetBoardgamesAscendingScores();
                            foreach (Boardgame boardgame in boardgamesOrdered) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name} - {boardgame.Scores.Count}");
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                DisplayTitle();
                Console.WriteLine($"\n\n... You must select a valid option! Try again");
                Thread.Sleep(1750);
            }

            Console.WriteLine("\n\nPress any key to get back to the main menu...");
            Console.ReadKey();
            menuOptions[9].ShowMenu();
        }
    }


    private void FilterBoardgamesByName()
    {
        List<Boardgame> boardgamesOrdered = new();                              

        DisplayTitle();
        Console.Write("\n\nAll right, type a boardgame name or part of it: ");
        var userInput = Console.ReadLine()!;
        if (userInput != null) 
        {
            boardgamesOrdered = BoardgameQueries.GetBoardgamesAscendingFilterName(userInput);
        }
        foreach (Boardgame boardgame in boardgamesOrdered) Console.WriteLine($"#{boardgame.Index + 1} {boardgame.Name}");
    }

}


