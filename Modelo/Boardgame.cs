

using static System.Formats.Asn1.AsnWriter;

namespace BoardgameProjectV2.Modelo;


internal class Boardgame
{
    public static int boardgameCount = 0;

    public Boardgame(string name, string description, int launchDate, bool isAvailable, float price, int score)
    {
        Index = boardgameCount++;
        Name = name;
        Description = description;
        LaunchDate = launchDate;
        IsAvailable = isAvailable;
        Price = price;
        Scores = new List<int>{ score };
    }

    public string Name { get; set; }

    public string Description { get; set;}

    public int LaunchDate { get; set; }

    public bool IsAvailable { get; set; }

    public float Price { get; set; }

    public int Score { get; set; }
    
    public int Rank { get; set; } 
    
    public int Index { get; set; }

    public List<int> Scores { get; set; }
        
    public void ShowDetails()
    {                                                        
        Console.WriteLine($"\n\nShowing #{Index+1} {Name} details:");
        Console.WriteLine($"\n\nDescription: {Description}");
        Console.WriteLine($"\nLaunchDate: {LaunchDate}");
        Console.WriteLine($"\nAvailable to purchase?: {(IsAvailable ? "Yes" : "No")}");
        Console.WriteLine($"\nPrice tag: {(Price <= 0 ? "Free" : Price.ToString())}");
        Console.WriteLine($"\nTotal Score: {ScoresAverage():F1}");
        Console.WriteLine($"\nCurrent Rank: {Rank}");
    }
    public double ScoresAverage()
    {
        return Scores.Count > 0 ? Scores.Average() : 0;       
    }
}
