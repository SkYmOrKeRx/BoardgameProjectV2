
namespace BoardgameProjectV2.Menus;                              


public class MenuConfirmation: Menu
{
    public static bool MenuSelectedConfirmation(Menu selectedMenu)
    {

        while (true)
        {
            selectedMenu.DisplayTitle();
            Console.WriteLine($"\nEntering {GetMenuName(selectedMenu)}");
            Console.WriteLine("\nPlease confirm by pressing 'Enter' key or leave with the'Esc' key\");");
            var keyConfirmation = Console.ReadKey(true);

            if (keyConfirmation.Key == ConsoleKey.Escape)
            {
                selectedMenu.DisplayTitle();
                Console.WriteLine("\n\n... Leaving this menu in 2 seconds...");
                Thread.Sleep(2000);
                return false;
            }
            else if (keyConfirmation.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else
            {
                selectedMenu.DisplayTitle();
                Console.WriteLine("\n... You typed something wrong! Try again!...");
                Thread.Sleep(2000);
            }
        }
    }

    private static string GetMenuName(Menu selectedMenu)
    {
        if (selectedMenu is MenuAddBoardgame)
        {
            return "***ADD A BOARDGAME MENU***";
        }
        if (selectedMenu is MenuEditBoardgame)
        {
            return "***EDIT A BOARDGAME MENU ***";
        }
        if (selectedMenu is MenuRateBoardgame)
        {
            return "***RATE A BOARDGAME MENU***";
        }
        else return "********CRITICAL ERROR**********";
    }

    public override void ShowMenu()
    {
        throw new NotImplementedException();
    }

    public override void DisplayTitle()
    {
        throw new NotImplementedException();
    }
}
