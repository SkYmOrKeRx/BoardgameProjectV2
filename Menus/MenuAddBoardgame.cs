
using BoardgameProjectV2.Handlers;
using BoardgameProjectV2.Modelo;
namespace BoardgameProjectV2.Menus;

internal class MenuAddBoardgame : Menu
{

    private string? _name;
    private string?  _description;
    private int _launchDate;
    private bool _isAvailable;
    private float _price;
    private int _score;

    private string menuName = "***ADD A BOARDGAME MENU***";

    public override void DisplayTitle()
    {
        Console.Clear();

        Console.WriteLine("***************************************************");
        Console.WriteLine(welcomeTitle);
        Console.WriteLine("***************************************************");
        Console.WriteLine(menuName);

    }

    public override void ShowMenu()
    { 
        var menuConfirmation = MenuConfirmation.MenuSelectedConfirmation(this);
        if (menuConfirmation) AddBoardgame();                                                 
    }

    public void AddBoardgame()
    {
        DisplayTitle();
        Console.WriteLine("\n\nAll right! Let's register a new boardgame!!");
        Thread.Sleep(3000);

        for (int i = 0; i < 6; i++)
        {
            DisplayTitle();
            switch (i)
            {
                case 0:
                    _name  = HandleNullInput.HandleBoardgameNullInput(i, _name!);
                    break;

                case 1:
                    _description = HandleNullInput.HandleBoardgameNullInput(i, _name!);
                    break;

                case 2:
                    _launchDate = HandleLaunchDate.HandleLaunchDateInput(i);
                    break;

                case 3:
                    _isAvailable = HandleAvailability.HandleBoardgameAvailability(i);
                    break;

                case 4:
                    _price = HandlePrice.HandleBoardgamePrice(i);
                    break;

                case 5:
                    _score = HandleScore.HandleBoardgameScore(i);
                    break;
            }
        }

        Boardgame newBoardgame = new(_name, _description, _launchDate, _isAvailable, _price, _score);

        DisplayTitle();
        Console.WriteLine($"\n\nCongratulations on registering {newBoardgame.Name} to the database" +
                            "\nCheck it out!");

        BoardgameManager.AddBoardgameToDB(newBoardgame);
        newBoardgame.ShowDetails();
        Console.WriteLine("\n\n\n\nPress any key to get back to the main menu!");
        Console.ReadKey();

        menuOptions[9].ShowMenu();
    }

}



