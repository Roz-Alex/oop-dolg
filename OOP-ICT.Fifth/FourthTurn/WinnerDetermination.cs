using OOP_ICT.Fifth.BeforePlaying;
using OOP_ICT.Fifth.DBConnection;
using OOP_ICT.Fourth.Evaluators;
using OOP_ICT.Second.Person;
using Spectre.Console;

namespace OOP_ICT.Fifth.FourthTurn;

public class WinnerDetermination
{
    private Gamer _mainGamer = Start.Games[0].GetGamers()[Start.Games[0].GetGamers().Count - 1];
    public void DetermineWinner()
    {
        AnsiConsole.MarkupLine($"[green]Now we are ready to get winner![/]");
        var winner = Start.Games[0].DetermineWinner();
        var converter = new Evaluator();
        ConnectAndInsert connectAndInsertClass = new ConnectAndInsert();

        if (winner.Combination == _mainGamer.Combination)
        {
            AnsiConsole.MarkupLine($"[yellow]It's a tie! both gamers have combination {converter.GetCombinationName(_mainGamer.Combination)}[/]");
            connectAndInsertClass.Insert(winner.Name, Start.Games[0].GetWinning());
            connectAndInsertClass.Insert(_mainGamer.Name, Start.Games[0].GetWinning());
            connectAndInsertClass.SelectAll();
        }
        else
        {   
            var name = converter.GetCombinationName(winner.Combination);
        
            AnsiConsole.MarkupLine($"[green]Our winner is {winner.Name}[/]");
            AnsiConsole.MarkupLine($"[green]Winner's combination is {name}[/]");
            AnsiConsole.MarkupLine($"[red]You have combination {converter.GetCombinationName(_mainGamer.Combination)}[/]");
            connectAndInsertClass.Insert(winner.Name, Start.Games[0].GetWinning());
            connectAndInsertClass.SelectAll();
        }
    }
}