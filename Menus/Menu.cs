
namespace BoardgameProjectV2.Menus;

public abstract class Menu
{
    public static readonly Dictionary<int, Menu> menuOptions = new()
    {
        { 1, new MenuAddBoardgame() },
        { 2, new MenuEditBoardgame() },
        { 3, new MenuRateBoardgame() }
    };

    public string welcomeTitle = "░J░M░F░C░'░S░ ░B░O░A░R░D░G░A░M░E░ ░D░A░T░A░B░A░S░E░";
    //int onlyLetters = welcomeTitle.Length;

    public abstract void DisplayTitle();

    public abstract void ShowMenu();

    public void ShowHeader()
    {
        DisplayTitle();
        Console.Clear();

        Console.WriteLine("***************************************************");
        Console.WriteLine(welcomeTitle);
        Console.WriteLine("***************************************************");
    }
 }


