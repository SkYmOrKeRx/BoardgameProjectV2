﻿using BoardgameProjectV2.Menus;

namespace BoardgameProjectV2.Handlers;

internal class HandleNullInput
{
    public static string HandleBoardgameNullInput(int i)
    {
        MenuAddBoardgame newMenu = new MenuAddBoardgame();
        while (true)
        {
            newMenu.DisplayTitle();

            if (i == 0)
            {
                Console.Write($"\nField {i + 1}: Boardgame name: ");
            }
            if (i == 1)
            {
                Console.Write($"\nField {i + 1}: Boardgame description: ");
            }
                
            var boardgametxt = Console.ReadLine();

            if (!string.IsNullOrEmpty(boardgametxt) && !string.IsNullOrWhiteSpace(boardgametxt))
            {
                if (i == 0)
                {
                    Console.WriteLine($"\n\n({i + 1}) {boardgametxt.Trim()} was succesfully registered!");
                    Thread.Sleep(2000);
                }
                if (i == 1)
                {
                    Console.WriteLine($"\n\n({i + 1}) {boardgametxt.Trim()} was succesfully added to the description!");
                    Thread.Sleep(3500);
                }
                
                return boardgametxt;
            }
            else
            {
                newMenu.DisplayTitle();
                Console.WriteLine("\n\n... You typed something wrong! Try again!");
                Thread.Sleep(2000);
            }
        }
    }
}