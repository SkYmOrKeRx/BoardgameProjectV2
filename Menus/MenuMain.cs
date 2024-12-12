

namespace BoardgameProjectV2.Menus;

internal class MenuMain : Menu
{

    private string menuName = "***MAIN MENU***";

    public override void ShowMenu()
    {
        while (true)
        {
            DisplayTitle();
            Console.WriteLine("Welcome to the world's best Boardgame database!\n\n");
            Console.WriteLine("Please select an option:" +
                "\n1-Add a new boardgame to the database" +
                "\n2-Edit an registered board game and their details" +
                "\n3-Rate a boardgame" +
                "\n4-Leave the application");

            ConsoleKeyInfo keyConfirmation = Console.ReadKey(true);

            if (int.TryParse(keyConfirmation.KeyChar.ToString(), out int menuId))
            {
                if ((menuId > 0 || menuId < 5))
                {
                    if (menuId == 1) { ((MenuAddBoardgame)menuOptions[menuId]).ShowMenu(); }
                    if (menuId == 2) { ((MenuEditBoardgame)menuOptions[menuId]).ShowMenu(); }
                    if (menuId == 3) { ((MenuRateBoardgame)menuOptions[menuId]).ShowMenu(); }
                    if (menuId == 4) { Console.WriteLine("\nExiting application..."); Thread.Sleep(2000); Environment.Exit(0); }
                }
                else
                {
                    DisplayTitle();
                    Console.WriteLine($"\n\n... There's no option such as {keyConfirmation.KeyChar.ToString()}! Try again!");
                    Thread.Sleep(2000);
                    DisplayTitle();
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
