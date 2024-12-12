using BoardgameProjectV2.Menus;

namespace BoardgameProjectV2.Handlers;

internal class HandleLaunchDate
{
    public static int HandleUserInput(int i)
    {
        MenuAddBoardgame newMenuAddBoardgame = new();
        while (true)
        {
            newMenuAddBoardgame.DisplayTitle();
            Console.Write($"\nField {i + 1}: Boardgame Launch date in a 4 digit format: ");
            var checkInput = Console.ReadLine();
                                                                                                                                    
            if (checkInput.Contains(" ") || string.IsNullOrWhiteSpace(checkInput) || checkInput.Length != 4 || !int.TryParse(checkInput, out int _launchDate) | int.Parse(checkInput) < 0 )
            {
                newMenuAddBoardgame.DisplayTitle();
                Console.WriteLine("\n\n... The launch date must have 4 digits and valid numbers! Try again!");
                Thread.Sleep(2000);
            }
            else
            {
                //_launchDate = int.Parse(checkInput);
                Console.WriteLine($"\n\n({i + 1})  The following launch date was succesfully registered: {checkInput}");
                Thread.Sleep(2000);
                return int.Parse(checkInput);
            }
        }
    }
}
