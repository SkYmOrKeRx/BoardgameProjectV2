using BoardgameProjectV2.Handlers;
using BoardgameProjectV2.Modelo;

namespace BoardgameProjectV2.Menus;

internal class MenuRateBoardgame : Menu
{
    string _string1 = "\n\nSelect the number corresponding to the boardgame to rate it: ";

    private string menuName = "***RATE A BOARDGAME MENU***";

    public override void ShowMenu()
    {
        if (MenuConfirmation.MenuSelectedConfirmation(this)) RateBoardgameMenu();
        else throw new Exception("Sei la??");
    }

    public override void DisplayTitle()
    {
        Console.Clear();

        Console.WriteLine("***************************************************");
        Console.WriteLine(welcomeTitle);
        Console.WriteLine("***************************************************");
        Console.WriteLine(menuName);

    }


    public void RateBoardgameMenu()
    {

        string userInput;
        string userInput2;
        int newBoardgameScore = 0;
        int newBoardgameNumber = 0;
        MenuRateBoardgame newMenuRateBoardgame = new();
        List<Boardgame> registeredBoardgames = BoardgameManager.LoadAllBoardgames();

        DisplayTitle();
        Console.WriteLine("\n\nAll right! Let's rate a boardgame!!");
        Thread.Sleep(3000);

        DisplayTitle();
        Console.WriteLine("\n\nLoading registered boardgames in database...");

        if (registeredBoardgames.Count <= 0)
        {
            DisplayTitle();
            Console.WriteLine("\n\nNo boardgames have been found in the database ;(");
        }
        else
        {
            while (true)
            {
                DisplayTitle();
                BoardgameManager.ListAllBoardgamesInDB();
       
                Console.Write("\n\nSelect the number corresponding to the boardgame to rate it: ");
                userInput = Console.ReadLine()!;

                if (int.TryParse(userInput, out newBoardgameNumber))
                {
                    if ((newBoardgameNumber < 1) || (newBoardgameNumber > registeredBoardgames.Count))
                    {
                        DisplayTitle();
                        Console.WriteLine($"\n\n... {userInput} is not a valid option! Try again");
                        Thread.Sleep(1750);
                    }
                    else break;
                }
                else
                {
                    DisplayTitle();
                    Console.WriteLine($"\n\n... You must select a valid option! Try again");
                    Thread.Sleep(1750);
                }
            }

            while (true)
            {
                DisplayTitle();
                Console.WriteLine($"\n\nYou chose {newBoardgameNumber}-{registeredBoardgames[newBoardgameNumber-1].Name}");
                Console.Write($"\n\nPlease rate it from 0 to 10: ");
                userInput2 = Console.ReadLine()!;

                if (int.TryParse(userInput2, out newBoardgameScore))
                {
                    if (newBoardgameScore < 0 || newBoardgameScore > 10)
                    {
                        DisplayTitle();
                        Console.WriteLine($"\n\n... {newBoardgameScore} is not a valid option! Try again");
                        Thread.Sleep(1750);
                    }
                    else break;
                }
                else
                {
                    DisplayTitle();
                    Console.WriteLine($"\n\n... You must select a valid option! Try again");
                    Thread.Sleep(1750);
                }
            }

            Console.WriteLine($"\n\nCongratulations!! You rated {newBoardgameNumber}-{registeredBoardgames[newBoardgameNumber-1].Name} with a score of {newBoardgameScore} points");
            //BoardgameManager.registeredBoardgames[newBoardgameNumber-1].Score = newBoardgameScore;
            Console.WriteLine(BoardgameManager.registeredBoardgames[newBoardgameNumber - 1].Score); 
            //BoardgameManager.registeredBoardgames[newBoardgameNumber-1].Scores.Add(newBoardgameScore);

            Console.WriteLine($"{registeredBoardgames[newBoardgameNumber-1].Name} - Average Score {registeredBoardgames[newBoardgameNumber - 1].ScoresAverage}");

            Console.WriteLine("\n\nPress any key to get back to the main menu!");
            Console.ReadKey();

            menuOptions[9].ShowMenu();  
        }
    }
}
