
namespace BoardgameProjectV2.Menus;                              


public class MenuConfirmation: Menu
{
    public static void MenuSelectedConfirmation(Menu selectedMenu)
    {
        selectedMenu.DisplayTitle(); 
        Console.WriteLine($"{GetMenuName(selectedMenu)}");
        Console.WriteLine("\nBefore continue, make sure you want to access this menu.");
        Console.WriteLine("\nPlease confirm by pressing 'Enter' key or leave with the'Esc' key\");");
        var keyConfirmation = Console.ReadKey(true);
        if (keyConfirmation.Key == ConsoleKey.Escape)
        {
            selectedMenu.DisplayTitle();
            Console.WriteLine("\n\n... Leaving this menu in 2 seconds...");
            Thread.Sleep(2000);
            ShowMainMenu();
        }
        else if (keyConfirmation.Key == ConsoleKey.Enter)
        {
            selectedMenu.DisplayTitle();
            //Console.WriteLine("\n.. Redirecting you to the selected menu ...");
            //Thread.Sleep(2000);
            //MenuAddBoardgame menuAddBoardgame = new();
            //menuAddBoardgame.AddBoardgame();
        }
        else
        {
            selectedMenu.DisplayTitle();
            Console.WriteLine("\n... You typed something wrong! Leaving this menu in 2 seconds...");
            Thread.Sleep(2000);
                ShowMainMenu();
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

        //switch (selectedMenu.GetType())
        //{
        //    case Type t when t.GetType == MenuAddBoardgame :
        //        return "Add a boardgame Menu";
        //    case 2:
        //        return "Edit a boardgame Menu";
        //    case 3:
        //        return "Rate a boardgame Menu";
        //    default:
        //        return "Something wrong is happening!!";
        //}
        
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
