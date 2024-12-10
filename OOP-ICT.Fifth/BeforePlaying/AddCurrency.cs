using OOP_ICT.Fifth.Base;
using OOP_ICT.Fifth.FirstTurn;
using OOP_ICT.Second.Person;
using Spectre.Console;

namespace OOP_ICT.Fifth.BeforePlaying;

public class AddCurrency
{
    private Gamer _mainGamer = Start.Games[0].GetGamers()[Start.Games[0].GetGamers().Count - 1];
    public void AddCurrencyToGamer()
    {
        PrintFirstPhrase();
        var money = AnsiConsole.Prompt(new TextPrompt<int>("[red]Enter money to add to bank acc:[/]").PromptStyle("green"));
        
        if (money > 0)
        {
            Start.BasicEntities.GetBank().CreateBankAccount(_mainGamer);
            Start.BasicEntities.GetBank().TopUpAccount(_mainGamer, money);
        }

        if (money <= 0)
        {
            AnsiConsole.MarkupLine($"[red]Amount of money is negative. Try again[/]");
            AnsiConsole.WriteLine();
            var newMoney = AnsiConsole.Prompt(new TextPrompt<int>("[red]Enter money to add to bank acc:[/]").PromptStyle("green"));

            Start.BasicEntities.GetBank().CreateBankAccount(_mainGamer);
            Start.BasicEntities.GetBank().TopUpAccount(_mainGamer, newMoney);
        }
        
        PrintUpdatedBankBalance();
        var chips = AnsiConsole.Prompt(new TextPrompt<int>("[red]Enter chips to add to casino acc:[/]").PromptStyle("green"));
        if (chips <= _mainGamer.GamerBankAccount.GetBalance())
        {
            Start.BasicEntities.GetCasino().CreateCasinoAccount(_mainGamer);
            Start.BasicEntities.GetCasino().BuyChips(Start.ChipsMoneyExchange, _mainGamer, chips);
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]Not enough balance on your bank acc. Balance is {_mainGamer.GamerBankAccount.GetBalance()} Try again[/]");
            AnsiConsole.WriteLine();
            var newChips = AnsiConsole.Prompt(new TextPrompt<int>("[red]Enter chips to add to casino acc:[/]").PromptStyle("green"));
            Start.BasicEntities.GetCasino().CreateCasinoAccount(_mainGamer);
            Start.BasicEntities.GetCasino().BuyChips(Start.ChipsMoneyExchange, _mainGamer, newChips);
        }
        
        PrintUpdatedCasinoBalance();
        PrintPlayersInfo();

        DealTwoCardsToEachPlayer dealTwoCardsToEachPlayerClass = new DealTwoCardsToEachPlayer();
        dealTwoCardsToEachPlayerClass.DealTwoCards();
    }

    private void PrintFirstPhrase()
    {
        AnsiConsole.MarkupLine($"[red]Before starting you need to top up your acc[/]");
        AnsiConsole.WriteLine();
    }

    private void PrintUpdatedBankBalance()
    {
        AnsiConsole.MarkupLine($"[green]Now your bank acc balance is {_mainGamer.GamerBankAccount.GetBalance()}[/]");
        AnsiConsole.MarkupLine($"[red]Now you need to buy chips[/]");
    }

    private void PrintUpdatedCasinoBalance()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"[green]Now your casino acc balance is {_mainGamer.GamerCasinoAccount.GetBalance()}[/]");
    }

    private void PrintPlayersInfo()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("[green]We're ready to start w these gamers:[/]");
        Join.PrintListOfPlayers(Start.Games[0]);
    }
}
