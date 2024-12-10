using OOP_ICT.Fifth.BeforePlaying;
using OOP_ICT.Fifth.Bets;
using OOP_ICT.Fifth.ThirdTurn;
using OOP_ICT.Second.Person;
using Spectre.Console;

namespace OOP_ICT.Fifth.FourthTurn;

public class DealLastCardOnTable
{
    
    public void DealLastCard()
    {
        PrintFirstPhrase();
        Start.Games[0].DealLastTurn(Start.BasicEntities.GetDealer());
        
        AnsiConsole.MarkupLine("[yellow]Here are common cards:[/]");
        foreach (var card in Start.Games[0].GetCommonCards())
        {
            AnsiConsole.MarkupLine($"[yellow]{card.Suit} {card.Rank}[/]");
        }
        
        PrintBetsInfo();
        BetsGetter betsGetterClass = new BetsGetter();
        betsGetterClass.GetBets();

        WinnerDetermination winnerDeterminationClass = new WinnerDetermination();
        winnerDeterminationClass.DetermineWinner();
    }

    private void PrintFirstPhrase()
    {
        AnsiConsole.MarkupLine("[red]Now dealer deals three common cards[/]");
        AnsiConsole.WriteLine();
    }

    private void PrintBetsInfo()
    {
        AnsiConsole.MarkupLine("[green]Now time of bets![/]");
        AnsiConsole.WriteLine();
    }
}