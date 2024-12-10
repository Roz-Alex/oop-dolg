using OOP_ICT.Fifth.BeforePlaying;
using OOP_ICT.Second.Person;
using Spectre.Console;

namespace OOP_ICT.Fifth.Bets;

public class BetsGetter
{
    private Gamer _mainGamer = Start.Games[0].GetGamers()[Start.Games[0].GetGamers().Count - 1];
    
    public void GetBets()
    {
        PrintInfoAboutFirstBet();
        PrintActionSuggestion();
        
        var selection = new SelectionPrompt<string>()
            .Title("CHOOSE:")
            .PageSize(5);

        selection.AddChoice("Call");
        selection.AddChoice("Raise");
        selection.AddChoice("Fold");
        var choice = AnsiConsole.Prompt(selection);

        switch (choice)
        {
            case "Call":
                AnsiConsole.MarkupLine($"[green]You called {Start.FirstDefaultBet}[/]");
                Start.Games[0].MakeBet(_mainGamer, Start.FirstDefaultBet);
                AnsiConsole.MarkupLine($"[green]Now your balance is {_mainGamer.GamerCasinoAccount.GetBalance()}[/]");
                break;
            case "Raise":
                var newBet = AnsiConsole.Prompt(new TextPrompt<int>("[red]Enter your bet:[/]").PromptStyle("green"));
                Start.FirstDefaultBet = newBet;
                Start.Games[0].MakeBet(_mainGamer, Start.FirstDefaultBet);
                AnsiConsole.MarkupLine($"[green]You bet {newBet}[/]");
                AnsiConsole.MarkupLine($"[green]Now your balance is {_mainGamer.GamerCasinoAccount.GetBalance()}[/]");
                break;
            case "Exit":
                AnsiConsole.MarkupLine("[red]Exiting the game. Goodbye![/]");
                Environment.Exit(0);
                break;
        }
        
    }

    private void PrintInfoAboutFirstBet()
    {
        AnsiConsole.MarkupLine($"[yellow]First bet has {Start.Games[0].GetGamers()[0].Name}[/]");
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"[green]{Start.Games[0].GetGamers()[0].Name} bet {Start.FirstDefaultBet}[/]");
        AnsiConsole.WriteLine();
    }

    private void PrintActionSuggestion()
    {
        AnsiConsole.MarkupLine("[yellow]Would you like to call bet or raise?[/]");
        AnsiConsole.WriteLine();
    }
}