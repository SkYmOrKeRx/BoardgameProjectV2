
using BoardgameProjectV2.Handlers;
using BoardgameProjectV2.Modelo;
namespace BoardgameProjectV2.Menu;

internal class MenuEditBoardgame: Menu
{
    public void ShowMenuInstructions()
    {
        //MenuEditBoardgame thisMenu = new MenuEditBoardgame();
        MenuConfirmation.MenuSelectedConfirmation(this);
        EditBoardgame();
                                                                            

    }

    public override void DisplayTitle()
    {
        base.DisplayTitle();
        Console.WriteLine("***EDIT A BOARDGAME MENU***");
    }

    public void EditBoardgame()
    {

    }
}
