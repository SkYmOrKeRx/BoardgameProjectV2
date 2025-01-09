using BoardgameProjectV2.Modelo;
using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace BoardgameProjectV2.Menus;

delegate List<Boardgame> BoardgameQuery();
delegate List<Boardgame> BoardgameQueryString(string input);

internal class MenuCheckBoardgameDatabase : Menu
{
    private string menuName = "***CHECK BOARDGAME DATABASE MENU***";

    public bool _isON = false;

    private Dictionary<int, BoardgameQuery> boardgameQueriesSorting = new Dictionary<int, BoardgameQuery>()
    {
        { 1, new BoardgameQuery(BoardgameQueries.GetBoardgamesAscendingName) },
        { 2, new BoardgameQuery(BoardgameQueries.GetBoardgamesAscendingLaunchDate)},
        { 3, new BoardgameQuery(BoardgameQueries.GetBoardgamesAscendingPrice)},
        { 4, new BoardgameQuery(BoardgameQueries.GetBoardgamesAscendingRank)},
        { 5, new BoardgameQuery(BoardgameQueries.GetBoardgamesAscendingScores)}
    };

    private Dictionary<int, BoardgameQueryString> boardgameQueriesFiltering = new Dictionary<int, BoardgameQueryString>()
    {
        {1, new BoardgameQueryString(BoardgameQueries.GetBoardgamesAscendingFilterName) },
        {2, new BoardgameQueryString(BoardgameQueries.GetBoardgamesAscendingFilterLaunchDate) },
        {3, new BoardgameQueryString(BoardgameQueries.GetBoardgamesAscendingFilterPrice) },
    };

    //private Dictionary<ConsoleKey, Action> menuKeys = new Dictionary<ConsoleKey, Action>()
    //{
    //    {ConsoleKey.Escape, () => menuOptions[9].ShowMenu()},
    //    {ConsoleKey.F1, () => MenuGetBoardgamesQueryList()},
    //};


    public override void ShowMenu()
    {
        if (MenuConfirmation.MenuSelectedConfirmation(this)) 
        if(!_isON)
            {
                DisplayTitle();
                Console.WriteLine("\n\nAll right! Let's check the boardgame database!!");
                Thread.Sleep(3000);
            } 
        CheckBoardgameDatabase();
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
        Dictionary<ConsoleKey, Action> menuKeys = new()
        {
            {ConsoleKey.Escape, () => menuOptions[9].ShowMenu()},
            {ConsoleKey.F1, () => MenuGetBoardgamesQueryList()},
            {ConsoleKey.F7, () => Console.WriteLine("previous page") },
            {ConsoleKey.F8, () => Console.WriteLine("next page") },
            {ConsoleKey.D1, () => Console.WriteLine("Aqui deveria ter event e nao um Action..")},
            {ConsoleKey.NumPad1, () => Console.WriteLine("Você pressionou o número 1.") },
            { ConsoleKey.D2, () => Console.WriteLine("Você pressionou o número 2.") },
            {ConsoleKey.NumPad2, () => Console.WriteLine("You pressed num# 2") },
            { ConsoleKey.D3, () => Console.WriteLine("Você pressionou o número 3.") },
            {ConsoleKey.NumPad3, () => Console.WriteLine("You pressed num# 3") },
            { ConsoleKey.D4, () => Console.WriteLine("Você pressionou o número 4.") },
            {ConsoleKey.NumPad4, () => Console.WriteLine("You pressed num# 4") },
            { ConsoleKey.D5, () => Console.WriteLine("Você pressionou o número 5.") },
            {ConsoleKey.NumPad5, () => Console.WriteLine("You pressed num# 5") },
            { ConsoleKey.D6, () => Console.WriteLine("Você pressionou o número 6.") },
            {ConsoleKey.NumPad6, () => Console.WriteLine("You pressed num# 6") },
            { ConsoleKey.D7, () => Console.WriteLine("Você pressionou o número 7.") },
            {ConsoleKey.NumPad7, () => Console.WriteLine("You pressed num# 7") },
            { ConsoleKey.D8, () => Console.WriteLine("Você pressionou o número 8.") },
            {ConsoleKey.NumPad8, () => Console.WriteLine("You pressed num# 8") },
            { ConsoleKey.D9, () => Console.WriteLine("Você pressionou o número 9.") },
            {ConsoleKey.NumPad9, () => Console.WriteLine("You pressed num# 9") },
        };

  
        List<Boardgame> registeredBoardgames = BoardgameManager.LoadAllBoardgames();

        DisplayTitle();
        Console.WriteLine("\n\nLoading registered boardgames in database...");

        if (BoardgameManager.registeredBoardgames.Count <= 0)
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
            DisplayTitle();
            BoardgameManager.ListAllBoardgamesInDB();

            Console.Write("\n\nSelect the number corresponding to the boardgame to check it out or 'F1' for more options:");

            ConsoleKeyInfo keyInput = Console.ReadKey(true);

            menuKeys.TryGetValue(keyInput.Key, out Action action);                    

            action!();

            DisplayTitle();

            if (char.IsDigit(keyInput.KeyChar))
            {
                registeredBoardgames[(keyInput.KeyChar - '0') - 1].ShowDetails();
            }         

        }
        Console.Write("\n\nPress any key to check again the database or 'Esc' to leave to the main menu...");
        var newInput = Console.ReadKey(false);
        if (newInput.Key != ConsoleKey.Escape) 
        {
            CheckBoardgameDatabase();           
        }
        DisplayTitle();
        Console.WriteLine("\n\n...Going back to the main menu...");
        Thread.Sleep(1750);
    }

    void GetBgData()
    {

    }

    private void MenuGetBoardgamesQueryList()
    {
        while (true)
        {
            DisplayTitle();
            Console.WriteLine("\n\nChoose a query type:");
            Console.WriteLine("\n1-Order");
            Console.WriteLine("2-Filter");

            var keyInput = Console.ReadKey(false);



            //Alterar para keyInfo
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
                    if (selectedOption == 1) OrderQueryMenu();
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
                    if (boardgameQueriesSorting.TryGetValue(selectedOption, out BoardgameQuery? query)) boardgamesOrdered = query();
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
        //Console.WriteLine("\n\n1 - Filter boardgames by availability");
        while (true)
        {
            DisplayTitle();
            Console.WriteLine("\n\n1 - Filter boardgames by name");
            Console.WriteLine("2 - Filter boardgames by launch date");
            Console.WriteLine("3 - Filter boardgames by range of price (ascending)");
            Console.Write("\n\nChoose an option:");
            var userInput = Console.ReadLine()!;
            if (int.TryParse(userInput, out int selectedOption))
            {
                if ((selectedOption < 0) && (selectedOption > 3))
                {
                    DisplayTitle();
                    Console.WriteLine($"\n\n... {userInput} is not a valid option! Try again");
                    Thread.Sleep(1750);
                }
                else
                {
                    if (boardgameQueriesFiltering.TryGetValue(selectedOption, out BoardgameQueryString query)) boardgamesOrdered = query(userInput);                  
                    switch (selectedOption)
                    {
                        case 1:
                            FilterBoardgamesByName(query!);
                            break;
                        case 2:
                            FilterBoardgamesByLaunchDate(query!);                           
                            break;
                        case 3:
                            FilterBoardgamesByPrice();                            
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

    private void FilterBoardgamesByName(BoardgameQueryString query)
    {
        while (true)
        {

            DisplayTitle();
            Console.Write("\n\nAll right, type a boardgame name or part of it: ");
            var userInput = Console.ReadLine()!;

            if (userInput != null)
            {
                DisplayTitle();
                var boardgamesOrdered = query(userInput);
                Console.WriteLine("\n");
                BoardgameQueriesPrinter.PrintFilterByName(boardgamesOrdered);                
                break;
            }
            else
            {
                DisplayTitle();
                Console.WriteLine("\n\nYou must type at least 3 characters! Try again!");
                Thread.Sleep(1750);
            }
        }
    }

    private void FilterBoardgamesByLaunchDate(BoardgameQueryString query)
    {     
        string userInput;

        //Implementar RANGE of launch dates!
        
        while (true)
        {
            DisplayTitle();
            Console.Write("\n\nAll right, type a boardgame a date (4-digit format): ");
            userInput = Console.ReadLine()!;

            if (userInput!.Contains(" ") || string.IsNullOrWhiteSpace(userInput) || userInput.Length != 4 || !int.TryParse(userInput, out int _launchDate) | int.Parse(userInput) < 0)
            {
                DisplayTitle();
                Console.WriteLine("\n\n... The launch date must have 4 digits and valid numbers! Try again!");
                Thread.Sleep(2000);    
            }
            else
            {
                DisplayTitle();
                var boardgamesOrdered = query(userInput);
                Console.WriteLine("\n");
                BoardgameQueriesPrinter.PrintFilterByLaunchDate(boardgamesOrdered);
                break;
                 
            }
        }
        
    }

    private void FilterBoardgamesByPrice()
    {
        while (true)
        {
            DisplayTitle();
            Console.Write("\n\nAll right, type the lowest price filter first: ");
            var userInput = Console.ReadLine()!;

            if (!string.IsNullOrWhiteSpace(userInput) && int.TryParse(userInput, out int numberMin) && numberMin >= 0)
            {
                DisplayTitle();
                Console.Write("\n\nAll right, now the highest filter: ");
                var userInput1 = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(userInput1) && int.TryParse(userInput1, out int numberMax) && numberMax >= 0 && numberMax > numberMin)
                {
                    DisplayTitle();
                    var boardgamesOrdered = BoardgameManager.LoadAllBoardgames().
                    Where(boardgame => boardgame.Price >= numberMin && boardgame.Price <= numberMax).
                    OrderBy(boardgame => boardgame.Price).ToList();

                    Console.WriteLine("\n");
                    BoardgameQueriesPrinter.PrintFilterByPrice(boardgamesOrdered);
                    break;
                }
                else
                {
                    DisplayTitle();
                    Console.WriteLine("\n\nSomething went wrong!! Let's start over...");
                    Thread.Sleep(1750);
                }
            }
            else
            {
                DisplayTitle();
                Console.WriteLine("\n\nYou must type a valid number! Try again!");
                Thread.Sleep(1750);
            }
        }
    }

}


