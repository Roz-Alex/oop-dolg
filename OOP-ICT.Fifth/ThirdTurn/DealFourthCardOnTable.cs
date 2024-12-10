using OOP_ICT.Fifth.BeforePlaying;
using OOP_ICT.Fifth.Bets;
using OOP_ICT.Fifth.FourthTurn;
using OOP_ICT.Second.Person;
using Spectre.Console;

namespace OOP_ICT.Fifth.ThirdTurn;

public class DealFourthCardOnTable
{
    public void DealFourthCard()
    {
        PrintFirstPhrase();
        Start.Games[0].DealThirdTurn(Start.BasicEntities.GetDealer());
        
        AnsiConsole.MarkupLine("[yellow]Here are common cards:[/]");
        foreach (var card in Start.Games[0].GetCommonCards())
        {
            AnsiConsole.MarkupLine($"[yellow]{card.Suit} {card.Rank}[/]");
        }
        
        PrintBetsInfo();
        BetsGetter betsGetterClass = new BetsGetter();
        betsGetterClass.GetBets();

        DealLastCardOnTable dealLastCardOnTableClass = new DealLastCardOnTable();
        dealLastCardOnTableClass.DealLastCard();
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