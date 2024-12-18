
using BoardgameProjectV2.Handlers;
using BoardgameProjectV2.Modelo;
namespace BoardgameProjectV2.Menus;

internal class MenuEditBoardgame: Menu
{
    public override void ShowMenu()
    {
        MenuConfirmation.MenuSelectedConfirmation(this);
        EditBoardgame();
    }

    private string menuName = "***EDIT A BOARDGAME MENU***";

    public override void DisplayTitle()
    {
        Console.Clear();

        Console.WriteLine("***************************************************");
        Console.WriteLine(welcomeTitle);
        Console.WriteLine("***************************************************");
        Console.WriteLine(menuName);

    }

    public void EditBoardgame()
    {
        string userInput;
        int newBoardgameToEditIndex = 0;

        MenuEditBoardgame rateBoardgameMenu = new();
        List<Boardgame> registeredBoardgames = BoardgameManager.LoadAllBoardgames();

        DisplayTitle();
        Console.WriteLine("\n\nAll right! Let's edit a boardgame!!");
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
                Console.Write("\n\nSelect the number corresponding to the boardgame to edit  it: ");
                userInput = Console.ReadLine()!;
                if (int.TryParse(userInput, out newBoardgameToEditIndex))
                {
                    if ((newBoardgameToEditIndex <= 0) || (newBoardgameToEditIndex > BoardgameManager.registeredBoardgames.Count))
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

            DisplayTitle();
            Console.WriteLine($"\n\nYou chose {newBoardgameToEditIndex}-{registeredBoardgames[newBoardgameToEditIndex].Name}");

        }
    }
}
