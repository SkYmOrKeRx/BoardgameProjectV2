

namespace BoardgameProjectV2.Menus;

internal class MenuMain : Menu
{

    private string menuName = "***MAIN MENU***";

    public override void ShowMenu()
    {
        while (true)
        {
            DisplayTitle();
            Console.WriteLine("\nWelcome to the world's best Boardgame database!");
            Console.WriteLine("\nPlease select an option:" +
                "\n\n1-Check boardgame database" +
                "\n2-Add a new boardgame to the database" +
                "\n3-Edit an registered board game and their details" +
                "\n4-Rate a boardgame" +
                "\n4-Leave the application");

            ConsoleKeyInfo keyConfirmation = Console.ReadKey(true);

            if (int.TryParse(keyConfirmation.KeyChar.ToString(), out int menuId))
            {
                if (menuId == 4) 
                { 
                    Console.WriteLine("\nExiting application...");
                    Thread.Sleep(2000); 
                    Environment.Exit(0);
                }
                else if (menuId < 0 || menuId > 4)
                {
                    DisplayTitle();
                    Console.WriteLine($"\n\n... There's no option such as '{keyConfirmation.KeyChar.ToString()}'! Try again!");
                    Thread.Sleep(2000);
                    DisplayTitle();
                }
                else
                {
                    menuOptions[menuId].ShowMenu();
                }
            }
            else
            {
                DisplayTitle();
                Console.WriteLine("\n\n... You typed something wrong! Try again!");
                Thread.Sleep(2000);
                DisplayTitle();
            }
        }
    }

    public override void DisplayTitle()
    {
        Console.Clear();

        Console.WriteLine("***************************************************");
        Console.WriteLine(welcomeTitle);
        Console.WriteLine("***************************************************");
        Console.WriteLine(menuName);

    }
}
