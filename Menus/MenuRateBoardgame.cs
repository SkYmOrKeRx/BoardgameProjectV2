
using BoardgameProjectV2.Modelo;

namespace BoardgameProjectV2.Menus;

internal class MenuRateBoardgame: Menu
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
        //update/load all registered boardgames in database
        var registeredBoardgamesInDB = BoardgameManager.LoadAllBoardgames();

        DisplayTitle();
        Console.WriteLine("\n\nAll right! Let's rate a boardgame!!");
        Thread.Sleep(3000);

        DisplayTitle();
        Console.WriteLine("\n\nLoading registered boardgames in database...");

        int i = 0;
        foreach (Boardgame boardgame in registeredBoardgamesInDB)
        {
            Console.WriteLine($"#{i}: {boardgame.Name}");
            i++;
            Thread.Sleep(100);
        }

        menuOptions[3].ShowMenu();
    }
}
