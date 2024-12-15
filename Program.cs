using BoardgameProjectV2.Menus;
using BoardgameProjectV2.Modelo;

//Filling up the database
BoardgameManager.FillDatabaseWithBoardgames();


// Starting program
MenuMain menuMain = new MenuMain(); 
menuMain.ShowMenu();


                                                            