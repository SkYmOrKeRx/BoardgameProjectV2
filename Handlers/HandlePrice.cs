namespace BoardgameProjectV2.Handlers;

internal class HandlePrice
{
    public static float HandleBoardgamePrice(float i)
    {
        Menu.Menu newMenu = new();
        while (true)
        {
            newMenu.DisplayTitle();
            Console.Write($"\nField {i + 1}: Boardgame selling price: ");
            var checkInput = Console.ReadLine()!;
            if ((!float.TryParse(checkInput, out float _price) || string.IsNullOrWhiteSpace(checkInput)) || checkInput.Contains(" ") || float.Parse(checkInput) < 0)
            {
                newMenu.DisplayTitle();
                Console.WriteLine($"\n\nThe boardgame's price tag must be a natural number! Try again");
                Thread.Sleep(2000);
            }
            else
            {
                newMenu.DisplayTitle();
                Console.WriteLine($"\n\n({i + 1}) The boardgame was registered with a price tag of ${checkInput}");
                Thread.Sleep(2000);
                return float.Parse(checkInput);
            }

        }
    }
}   
