namespace BoardgameProjectV2.Handlers;

internal class HandleScore
{
    public static int HandleBoardgameScore(int i)
    {
        Menu.Menu newMenu = new();
        while (true)
        {
            newMenu.DisplayTitle();
            Console.Write($"\nField {i + 1}: Boardgame score between 0 to 10: ");
            string checkInput = (Console.ReadLine()!);
                                                                                  
            if ((!float.TryParse(checkInput, out float _price) || string.IsNullOrWhiteSpace(checkInput)) || ((int.Parse(checkInput) < 0) || (int.Parse(checkInput) > 10)))
            {
                Console.WriteLine("\n\n... You typed something wrong! Try again!");
                Thread.Sleep(2000);
                newMenu.DisplayTitle();
            }
            else
            {
                Console.WriteLine($"\n\n({i + 1})  The boardgame was registered with a score of {checkInput} points!");
                Thread.Sleep(2000);
                return int.Parse(checkInput);
            }
        }   
    }
}
