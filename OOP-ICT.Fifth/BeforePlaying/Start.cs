using OOP_ICT.Fifth.Base;
using OOP_ICT.Fourth.Models;
using OOP_ICT.Models;
using OOP_ICT.Second;
using OOP_ICT.Second.Person;
using Spectre.Console;

namespace OOP_ICT.Fifth.BeforePlaying;

public class Start
{
    public static List<Poker> Games = new List<Poker>();
    public static BasicEntities BasicEntities = new BasicEntities();
    public static int FirstDefaultBet = 10;
    public static ChipsMoneyExchange ChipsMoneyExchange;

    public Start()
    {
        BasicEntities.CreateCasino();
        ChipsMoneyExchange = new ChipsMoneyExchange();
    }
    public void Run()
    {
        AnsiConsole.MarkupLine($"[green]POKER GAME[/]");
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"[cyan]WHAT WOULD YOU LIKE TO DO???[/]");
        AnsiConsole.WriteLine();
        
        var selection = new SelectionPrompt<string>()
            .Title("CHOOSE:")
            .PageSize(5);

        selection.AddChoice("Play");
        selection.AddChoice("Exit");
        var choice = AnsiConsole.Prompt(selection);

        switch (choice)
        {
            case "Play":
                Join joinClass = new Join();
                joinClass.JoinGame();
                break;
            case "Exit":
                AnsiConsole.MarkupLine("[red]Exiting the game. Goodbye![/]");
                Environment.Exit(0);
                break;
        }
    }
}