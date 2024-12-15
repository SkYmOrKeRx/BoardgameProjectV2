
using BoardgameProjectV2.Handlers;
using BoardgameProjectV2.Modelo;

namespace BoardgameProjectV2.Menus;

internal class MenuRateBoardgame : Menu
{

    //List<Boardgame> boardgamesList = new();

    private string menuName = "***RATE A BOARDGAME MENU***";

    public override void ShowMenu()
    {
        if (MenuConfirmation.MenuSelectedConfirmation(this)) RateBoardgameMenu();
        else throw new Exception("Sei la??");
    }

    public override void DisplayTitle()
    {
        Console.Clear();

        Console.WriteLine("***************************************************");
        Console.WriteLine(welcomeTitle);
        Console.WriteLine("***************************************************");
        Console.WriteLine(menuName);

    }


    public void RateBoardgameMenu()
    {

        string userInput;
        int newBoardgameScore = 0;
        int newBoardgameIndex = 0;
        MenuRateBoardgame rateBoardgameMenu = new MenuRateBoardgame();
        List<Boardgame> registeredBoardgames = BoardgameManager.LoadAllBoardgames();


        DisplayTitle();
        Console.WriteLine("\n\nAll right! Let's rate a boardgame!!");
        Thread.Sleep(3000);

        DisplayTitle();
        Console.WriteLine("\n\nLoading registered boardgames in database...");

        if (BoardgameManager.registeredBoardgames.Count <= 0)
        {
            DisplayTitle();
            Console.WriteLine("\n\nNo boardgames have been found in the database ;(");
        }
        else
        {
            while (true)
            {
                DisplayTitle();
                BoardgameManager.ListAllBoardgamesInDB();
                Console.Write("\n\nSelect the number corresponding to the boardgame to rate it: ");
                userInput = Console.ReadLine()!;
                if (int.TryParse(userInput, out int result))
                {
                    if ((result <= 0) || (result > BoardgameManager.registeredBoardgames.Count))
                    {
                        DisplayTitle();
                        Console.WriteLine($"\n\n... {userInput} is not a valid option! Try again");
                        Thread.Sleep(1750);
                    }
                    else break;
                }
                else
                {
                    DisplayTitle();
                    Console.WriteLine($"\n\n... You must select a valid option! Try again");
                    Thread.Sleep(1750);
                }
            }

            newBoardgameIndex = int.Parse(userInput);

            while (true)
            {
                DisplayTitle();
                Console.WriteLine($"\n\nYou chose {newBoardgameIndex}-{registeredBoardgames[newBoardgameIndex].Name}");
                Console.Write($"\n\nPlease rate it from 0 to 10:");
                userInput = Console.ReadLine()!;

                if (int.TryParse(userInput, out newBoardgameScore))
                {
                    if (newBoardgameScore <= 0 || newBoardgameScore > 10)
                    {
                        DisplayTitle();
                        Console.WriteLine($"\n\n... {newBoardgameScore} is not a valid option! Try again");
                        Thread.Sleep(1750);
                    }
                    else break;
                }
                else
                {
                    DisplayTitle();
                    Console.WriteLine($"\n\n... You must select a valid option! Try again");
                    Thread.Sleep(1750);
                }
            }

            Console.WriteLine($"\n\nCongratulations!! You rated {newBoardgameIndex}-{registeredBoardgames[newBoardgameIndex].Name} with a score of {newBoardgameScore} points");

            Console.WriteLine("\n\nPress any key to get back to the main menu!");
            Console.ReadKey();

            menuOptions[9].ShowMenu();  
        }
    }
}
