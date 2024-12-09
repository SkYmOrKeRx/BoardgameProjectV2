
using BoardgameProjectV2.Handlers;
using BoardgameProjectV2.Modelo;

namespace BoardgameProjectV2.Menu;

internal class MenuAddBoardgame : Menu
{

    private string? _name;
    private string?  _description;
    private int _launchDate;
    private bool _isAvailable;
    private float _price;
    private int _score;

    public void ShowMenuInstructions()
    {
        //MenuAddBoardgame thisMenu = new MenuAddBoardgame();
        MenuConfirmation.MenuSelectedConfirmation(this);
        AddBoardgame();
                                                        
    }

    public void AddBoardgame()
    {
        List<string> strings = new List<string>();

        DisplayTitle();
        Console.WriteLine("\n\nAll right! Let's register a new boardgame!!");
        Thread.Sleep(3000);

        for (int i = 0; i < 6; i++)
        {
            DisplayTitle();
            switch (i)
            {
                case 0:
                    Console.Write($"\nField {i + 1}: Boardgame name: ");
                    _name = Console.ReadLine()!;
                    DisplayTitle();
                    Console.WriteLine($"\n\n({i + 1}) {_name} was succesfully registered!");
                    Thread.Sleep(2000);
                    break;

                case 1:
                    Console.Write($"\nField {i + 1}: Boardgame Description: ");
                    _description = Console.ReadLine()!;
                    DisplayTitle();
                    Console.WriteLine($"\n\n({i + 1})  The following description was succesfully registered: {_description}");
                    Thread.Sleep(3500);
                    break;

                case 2:
                    _launchDate = HandleLaunchDate.HandleUserInput(i);
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

        newBoardgame.ShowDetails();
        Console.WriteLine("\n\n\n\nPress any key to get back to the main menu!");
        Console.ReadKey();

        ShowMainMenu();
    }

    public override void DisplayTitle()
    {
        base.DisplayTitle();
        Console.WriteLine("***ADD A BOARDGAME MENU***");
    }

}



