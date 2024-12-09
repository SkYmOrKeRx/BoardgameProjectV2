
namespace BoardgameProjectV2.Menu;

internal class MenuRateBoardgame: Menu
{

    public void ShowMenuInstructions()
    {
        MenuConfirmation.MenuSelectedConfirmation(this);
        RateBoardgameMenu();
    }

    public override void DisplayTitle()
    {
        base.DisplayTitle();
        Console.WriteLine("***RATE A BOARDGAME MENU***");
    }


    public void RateBoardgameMenu()
    {
        DisplayTitle();
        Console.WriteLine("\n\nAll right! Let's rate a boardgame!!");
        Thread.Sleep(3000);



        //DisplayTitle();
        //Console.Write("In this menu, a new boardgame will be added to the database.\n" +
        //              "\n7 Fields will be required to be informed before adding it." +
        //              "\n\nPlease confirm by pressing 'Enter' key or leave with the'Esc' key");
        //var keyConfirmation = Console.ReadKey(true);
        //if (keyConfirmation.Key == ConsoleKey.Escape)
        //{
        //    DisplayTitle();
        //    Console.WriteLine("\n\n... Leaving this menu in 2 seconds...");
        //    Thread.Sleep(2000);
        //    ShowMainMenu();
        //}
        //else if (keyConfirmation.Key == ConsoleKey.Enter)
        //{
        //    DisplayTitle();
        //    Console.WriteLine("\nAll right! Let's get started and add some boardgames!");
        //    Thread.Sleep(2000);
        //    AddBoardgame();
        //}
        //else
        //{
        //    DisplayTitle();
        //    Console.WriteLine("\n\n... You typed something wrong!\n Leaving this menu in 2 seconds...");
        //    Thread.Sleep(2000);
        //    ShowMainMenu();
        //}
    }
}
