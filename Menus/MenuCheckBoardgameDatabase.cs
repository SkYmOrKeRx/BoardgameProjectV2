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
        //Fix this code
        Dictionary<ConsoleKey, Action> menuKeys = new()
        {
            {ConsoleKey.Escape, () => menuOptions[9].ShowMenu()},
            {ConsoleKey.F1, () => MenuGetBoardgamesQueryList()},
            {ConsoleKey.F7, () => Console.WriteLine("previous page") },
            {ConsoleKey.F8, () => Console.WriteLine("next page") },
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
            while (true)
            {
                DisplayTitle();
                BoardgameManager.ListAllBoardgamesInDB();

                Console.Write("\n\nSelect the number corresponding to the boardgame to check it out or 'F1' for more options:");

                ConsoleKeyInfo keyInput = Console.ReadKey(true);

                DisplayTitle();
                if (menuKeys.TryGetValue(keyInput.Key, out Action action))
                {
                    action!();
                    //break?                
                }
                else if (char.IsDigit(keyInput.KeyChar))
                {
                    registeredBoardgames[(keyInput.KeyChar - '0') - 1].ShowDetails();
                    break;
                }
                else
                {
                    Console.WriteLine($"\n\n... You must select a valid option! Try again");
                    Thread.Sleep(1750);
                }
            }
        }

        Console.Write("\n\nPress any key to check again the database or 'Esc' to leave to the main menu...");
        var newInput = Console.ReadKey(false);
        DisplayTitle();
        if (newInput.Key == ConsoleKey.Escape)
        {
            Console.WriteLine("\n\n...Going back to the main menu...");
            Thread.Sleep(1750);
            menuOptions[9].ShowMenu();
        }           
        Console.WriteLine("\n\n...Checking again the database...");
        Thread.Sleep(1750);
        CheckBoardgameDatabase();

    }

    private void MenuGetBoardgamesQueryList()
    {
        Dictionary<ConsoleKey, Action> menuKeys = new()       
        {
            {ConsoleKey.Escape, () => menuOptions[9].ShowMenu()},
            {ConsoleKey.Backspace, () => CheckBoardgameDatabase()},
            {ConsoleKey.D1, () => OrderQueryMenu()},
            {ConsoleKey.NumPad1, () => OrderQueryMenu()},
            { ConsoleKey.D2, () => FilterQueryMenu() },
            {ConsoleKey.NumPad2, () => FilterQueryMenu() },
        }; 

        while (true)
        {
            DisplayTitle();            
            Console.WriteLine("\n\n1-Order");
            Console.WriteLine("2-Filter");
            Console.WriteLine("\n\nChoose a query type or press 'Esc' to get back to the main menu:");

            ConsoleKeyInfo keyInput = Console.ReadKey(true);

            if(menuKeys.TryGetValue(keyInput.Key, out Action action))
            {
                action!();
            }
            else
            {
                DisplayTitle();
                Console.WriteLine($"\n\n... You must select a valid option! Try again");
                Thread.Sleep(1750);
            }            
        }
    }

    public void OrderQueryMenu()
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
            Console.Write("\n\nChoose an option or press 'Esc' to get back to the main menu:");


            var keyInput = Console.ReadKey(intercept: true);

            if (boardgameQueriesSorting.TryGetValue(keyInput.KeyChar - '0', out BoardgameQuery? query))
            {
                boardgamesOrdered = query();
                DisplayTitle();
                switch (keyInput.KeyChar - '0')
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
            else if (keyInput.Key == ConsoleKey.Escape)
            {
                DisplayTitle();
                Console.WriteLine("\n\n...Going back to the main menu...");
                Thread.Sleep(1750);
                menuOptions[9].ShowMenu();
            }
            else if (keyInput.Key == ConsoleKey.Backspace)
            {
                MenuGetBoardgamesQueryList();
            }
            else
            {
                DisplayTitle();
                Console.WriteLine($"\n\n... You must select a valid option! Try again");
                Thread.Sleep(1750);
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            OrderQueryMenu();
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

            var keyInput = Console.ReadKey(intercept: true);

            if (boardgameQueriesFiltering.TryGetValue(keyInput.KeyChar - '0', out BoardgameQueryString? queryString))
            {
                //boardgamesOrdered = queryString(keyInput.Key.ToString());
                DisplayTitle();
                switch (keyInput.KeyChar - '0')
                {
                    case 1:
                        FilterBoardgamesByName(queryString);
                        break;
                    case 2:
                        FilterBoardgamesByLaunchDate(queryString);                        
                        break;
                    case 3:
                        FilterBoardgamesByPrice(queryString);
                        break;
                    default:
                        break;
                }


                //aqui chamar showDetails
                Console.WriteLine("\n\nPress any key to return...");
                Console.ReadKey();
                FilterQueryMenu();
            }
            else if (keyInput.Key == ConsoleKey.Escape)
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
    }

    private void FilterBoardgamesByName(BoardgameQueryString query)
    {
        string userInput;
        List<Boardgame> boardgamesOrdered = new();

        while (true)
        {
            //implementar tecla Escape para retornar a qualquer momento com tasks e async
            //if (Console.KeyAvailable)
            //{
            //    var key = Console.ReadKey(intercept: true);
            //    if (key.Key == ConsoleKey.Escape)
            //    {
            //        FilterQueryMenu();
            //        break;
            //    }
            //}

            DisplayTitle();
            Console.WriteLine("\n\nFILTER BOARDGAMES BY NAME");
            Console.Write("\n\nAll right, type a boardgame name or part of it: ");
            userInput = Console.ReadLine()!;

            if (!string.IsNullOrEmpty(userInput) && userInput.Length > 2)
            {
                DisplayTitle();
                boardgamesOrdered = query(userInput);
                Console.WriteLine("\n");                
                break;
            }
            else
            {
                DisplayTitle();
                Console.WriteLine("\n\nYou must type at least 3 characters and something valid! Try again...");
                Thread.Sleep(1750);
            }

            //if (boardgamesOrdered.TryGetValue(keyInput.Key, out Action action))
            //{
            //    action!();
            //}

            //if (char.IsDigit(keyInput.KeyChar))
            //{
            //    ???boardgamesOrdered[(keyInput.KeyChar - '0') - 1].ShowDetails();
            //}

            //boardgamesOrdered[int.Parse(userInput)].ShowDetails();
            
        }

        while(true)
        {
            DisplayTitle();
            BoardgameQueriesPrinter.PrintFilterByName(boardgamesOrdered);
            Console.WriteLine("\n\nSelect the number corresponding to the boardgame to check it out or 'Esc' to leave to the main menu...");

            ConsoleKeyInfo keyInput = Console.ReadKey(true);

            if (keyInput.Key == ConsoleKey.Escape)
            {
                menuOptions[9].ShowMenu();
            }
            else if (int.TryParse(keyInput.KeyChar.ToString(), out int digit) && int.Parse(keyInput.KeyChar.ToString()) > 0 &&
                     int.Parse(keyInput.KeyChar.ToString()) <= boardgamesOrdered.Count )
            {                
                DisplayTitle();
                boardgamesOrdered[digit - 1].ShowDetails();
                break;
            }
            else
            {
                DisplayTitle();
                Console.WriteLine($"\n\n... You must select a valid option! Try again");
                Thread.Sleep(1750);
            }          
        }
        Console.Write("\n\nPress 'Enter' to search again or 'Esc' to leave to the main menu...");
        var newInput = Console.ReadKey(false);

        if (newInput.Key == ConsoleKey.Escape)
        {
            DisplayTitle();
            Console.WriteLine("\n\n...Going back to the main menu...");
            Thread.Sleep(1750);
            menuOptions[9].ShowMenu();
        }
        if (newInput.Key == ConsoleKey.Backspace)
        {
            FilterQueryMenu();
            //CheckBoardgameDatabase();
        }
        DisplayTitle();
        Console.WriteLine("\n\n...Let's apply another filter!!");
        Thread.Sleep(1750);
        FilterQueryMenu();        

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
        Console.Write("\n\nPress 'Enter' to search again or 'Esc' to leave to the main menu...");
        var newInput = Console.ReadKey(false);

        if (newInput.Key == ConsoleKey.Escape)
        {
            DisplayTitle();
            Console.WriteLine("\n\n...Going back to the main menu...");
            Thread.Sleep(1750);
            menuOptions[9].ShowMenu();
        }
        if (newInput.Key == ConsoleKey.Backspace)
        {
            FilterQueryMenu();
            //CheckBoardgameDatabase();
        }
        DisplayTitle();
        Console.WriteLine("\n\n...Let's apply another filter!!");
        Thread.Sleep(1750);
        FilterQueryMenu();
        

    }

    private void FilterBoardgamesByPrice(BoardgameQueryString query)
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


