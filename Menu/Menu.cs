
namespace BoardgameProjectV2.Menu;

public class Menu
{
    public static readonly Dictionary<int, Menu> menuOptions = new()
    {
        { 1, new MenuAddBoardgame() },
        { 2, new MenuEditBoardgame() },
        { 3, new MenuRateBoardgame() }
    };


    public static Dictionary<int, object> menuOptions1 = new()
    {
        { 1, new MenuAddBoardgame() },
        { 2, new MenuEditBoardgame() },
        { 3, new MenuRateBoardgame() }
    };

    static string welcomeTitle = "░J░M░F░C░'░S░ ░B░O░A░R░D░G░A░M░E░ ░D░A░T░A░B░A░S░E░";
    //int onlyLetters = welcomeTitle.Length;

    public static void ShowMainMenu()
    {
        Menu newMenu = new Menu();

        while (true) 
        {
            newMenu.DisplayTitle();
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
                    if (menuId == 1) { ((MenuAddBoardgame)menuOptions1[menuId]).ShowMenuInstructions(); }
                    if (menuId == 2) { ((MenuEditBoardgame)menuOptions1[menuId]).ShowMenuInstructions(); }
                    if (menuId == 3) { ((MenuRateBoardgame)menuOptions1[menuId]).ShowMenuInstructions(); }
                    if (menuId == 4) { Console.WriteLine("\nExiting application..."  ); Thread.Sleep(2000); Environment.Exit(0); }
                }
                else
                {
                    newMenu.DisplayTitle();
                    Console.WriteLine($"\n\n... There's no option such as {keyConfirmation.KeyChar.ToString()}! Try again!");
                    Thread.Sleep(2000);
                    newMenu.DisplayTitle();
                } 
            }
            else
            {
                newMenu.DisplayTitle();
                Console.WriteLine("\n\n... You typed something wrong! Try again!");
                Thread.Sleep(2000);
                newMenu.DisplayTitle();
            }
            //newMenu.DisplayTitle();
            //Console.WriteLine($"\n\n...Accessing the selected menu....");
            //Thread.Sleep(1750);

            //This could be replaced by a few lines altering the whole code, by adding an abstract Menu class / IMenu interface
            //like so: if(int.TryParse(keyConfirmation.KeyChar.ToString(), out int menuId ) { selectedMenu.ShowMenuInstructions(); }

            //newMenu.DisplayTitle();
            //switch (keyConfirmation.Key)
            //{
            //    case ConsoleKey.D1 or ConsoleKey.NumPad1:
            //        Console.WriteLine("\n\n...Accessing the 'Add a boardgame menu'....");
            //        Thread.Sleep(3000);
            //        ((MenuAddBoardgame)menuOptions[1]).ShowMenuInstructions();
            //        break;
            //    case ConsoleKey.D2 or ConsoleKey.NumPad2:
            //        Console.WriteLine("\n\n...Accessing the 'Edit a boardgame menu'....");
            //        Thread.Sleep(3000);
            //        ((MenuEditBoardgame)menuOptions[2]).ShowMenuInstructions();
            //        break;
            //    case ConsoleKey.D3 or ConsoleKey.NumPad3:
            //        Console.WriteLine("\n\n...Accessing the 'Rate a boardgame menu'....");
            //        Thread.Sleep(3000);
            //        ((MenuRateBoardgame)menuOptions[3]).ShowMenuInstructions();
            //        break;
            //    case ConsoleKey.D5 or ConsoleKey.NumPad5:
            //        foreach (var menuName in menuOptions)
            //        {
            //            Console.WriteLine($"{menuName}");
            //        }
            //        Console.ReadKey();

            //        break;
            //}
        }
    }

    public virtual void DisplayTitle()
    {
        Console.Clear();

        Console.WriteLine("***************************************************");
        Console.WriteLine(welcomeTitle);
        Console.WriteLine("***************************************************");  
    }
}