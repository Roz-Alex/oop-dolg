using OOP_ICT.Fifth.Base;
using OOP_ICT.Fifth.BeforePlaying;
using OOP_ICT.Fourth.Models;
using OOP_ICT.Second.Person;
using Spectre.Console;

namespace OOP_ICT.Fifth.BeforePlaying;

public class Join
{
    public void JoinGame()
    {
        Poker poker = new Poker(Start.BasicEntities.GetCasinoAccount());
        Start.Games.Add(poker);
        AddBasicGamers(poker);
        
        AnsiConsole.MarkupLine("[green]You joined the room:[/]");
        PrintListOfPlayers(poker);
        
        AnsiConsole.MarkupLine("[red]You must enter your name[/]");
        AnsiConsole.WriteLine();
        var playerName = AnsiConsole.Prompt(new TextPrompt<string>("[red]Enter your name:[/]").PromptStyle("red"));
        Gamer gamer = new Gamer(playerName);
        
        poker.Enter(gamer);

        AddCurrency addCurrencyClass = new AddCurrency();
        addCurrencyClass.AddCurrencyToGamer();
    }
    
    private void AddBasicGamers(Poker poker)
    {
        foreach (var gamer in BasicPlayers.BasicGamers)
        {
            poker.Enter(gamer);
        }
    }
    
    public static void PrintListOfPlayers(Poker poker)
    {
        foreach (var gamer in poker.GetGamers())
        {
            AnsiConsole.MarkupLine($"[yellow]{gamer.Name}[/]");
        }
    }
}