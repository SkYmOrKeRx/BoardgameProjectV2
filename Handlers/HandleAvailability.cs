
namespace BoardgameProjectV2.Handlers;

internal class HandleAvailability
{
    public static bool HandleBoardgameAvailability(int i)
    {
        Menu.Menu newMenu = new();
        while (true)
        {
            Console.Write($"\nField {i + 1}: Boardgame is available? Type 'Yes' or 'No': ");
            var checkBool = Console.ReadLine()!;
            newMenu.DisplayTitle();
            if (checkBool.Trim().ToLower() == "yes")
            {                                               
                Console.WriteLine($"\n\n({i + 1})  The boardgame was registered as available for purchase!");
                Thread.Sleep(2000);
                return true;
            }
            else if (checkBool.Trim().ToLower() == "no")
            {
                Console.WriteLine($"\n\n({i + 1})  The boardgame was registered as NOT available for purchase!");
                Thread.Sleep(2000);
                return false;
            }
            else
            {
                newMenu.DisplayTitle();
                Console.WriteLine("\n\n... You typed something wrong! Try again!");
                Thread.Sleep(2000);
                newMenu.DisplayTitle();
            }
        }
    }
}
