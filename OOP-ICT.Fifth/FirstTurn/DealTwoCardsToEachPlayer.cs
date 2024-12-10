using OOP_ICT.Fifth.Base;
using OOP_ICT.Fifth.BeforePlaying;
using OOP_ICT.Second.Person;
using Spectre.Console;

namespace OOP_ICT.Fifth.FirstTurn;

public class DealTwoCardsToEachPlayer
{
    private Gamer _mainGamer = Start.Games[0].GetGamers()[Start.Games[0].GetGamers().Count - 1];
    public void DealTwoCards()
    {
        PrintFirstPhrase();
        Start.Games[0].DealFirstTurn(Start.BasicEntities.GetDealer());
        
        AnsiConsole.MarkupLine("[yellow]Here are your cards:[/]");
        foreach (var card in _mainGamer.GetListOfGamerCards().GetCards())
        {
            AnsiConsole.MarkupLine($"[yellow]{card.Suit} {card.Rank}[/]");
        }
        
        PrintBlindsInfo();
        GetBlindsFirstTurn getBlindsFirstTurnClass = new GetBlindsFirstTurn();
        getBlindsFirstTurnClass.GetBlinds();
    }

    private void PrintFirstPhrase()
    {
        AnsiConsole.MarkupLine("[red]Now dealer deals two cards to each gamer[/]");
        AnsiConsole.WriteLine();
    }

    private void PrintBlindsInfo()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("[red]Now time of blinds![/]");
    }
}