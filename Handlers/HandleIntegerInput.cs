

using BoardgameProjectV2.Menus;
using BoardgameProjectV2.Modelo;

namespace BoardgameProjectV2.Handlers;

internal static class HandleIntegerInput 

{
    public static int HandleIntegerInputs(Menu newMenu, params string[] strings)
    {
        while (true)
        {
            newMenu.DisplayTitle();
            BoardgameManager.ListAllBoardgamesInDB();
            Console.WriteLine(strings[0]);
            string userInput = Console.ReadLine()!;
            if (int.TryParse(userInput, out int newBoardgameIndex))
            {
                if ((newBoardgameIndex <= 0) || (newBoardgameIndex > BoardgameManager.registeredBoardgames.Count))
                {
                    newMenu.DisplayTitle();
                    Console.WriteLine($"\n\n... {userInput} is not a valid option! Try again");
                    Thread.Sleep(1750);
                }
                else return newBoardgameIndex;
            }
            else
            {
                newMenu.DisplayTitle();
                Console.WriteLine($"\n\n... You must select a valid option! Try again");
                Thread.Sleep(1750);
            }
        }
    }      
}
