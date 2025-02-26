﻿
namespace BoardgameProjectV2.Menus;

public abstract class Menu
{
    public static readonly Dictionary<int, Menu> menuOptions = new()
    {
        { 1, new MenuCheckBoardgameDatabase() },
        { 2, new MenuAddBoardgame() },
        { 3, new MenuEditBoardgame() },
        { 4, new MenuRateBoardgame() },
        { 9, new MenuMain()         }
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


