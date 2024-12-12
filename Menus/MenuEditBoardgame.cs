
using BoardgameProjectV2.Handlers;
using BoardgameProjectV2.Modelo;
namespace BoardgameProjectV2.Menus;

internal class MenuEditBoardgame: Menu
{
    public override void ShowMenu()
    {
        //MenuEditBoardgame thisMenu = new MenuEditBoardgame();
        MenuConfirmation.MenuSelectedConfirmation(this);
        EditBoardgame();
    }

    private string menuName = "***EDIT A BOARDGAME MENU***";

    public override void DisplayTitle()
    {
        Console.Clear();

        Console.WriteLine("***************************************************");
        Console.WriteLine(welcomeTitle);
        Console.WriteLine("***************************************************");
        Console.WriteLine(menuName);

    }

    public void EditBoardgame()
    {

    }
}
