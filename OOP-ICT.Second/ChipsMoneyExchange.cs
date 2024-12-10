using OOP_ICT.Second.Accounts;
using OOP_ICT.Second.Person;

namespace OOP_ICT.Second;

public class ChipsMoneyExchange
{
    private List<int> _chipsDenomination;
    
    public ChipsMoneyExchange()
    {
        _chipsDenomination = new List<int>() { 1, 5, 25, 50, 100 };
    }
    
    public void BuyChips(Gamer gamer, int money)
    {
        Dictionary<int, int> chipsToDenomination = new Dictionary<int, int>();
        GamerBankAccount gamerBankAccount = gamer.GamerBankAccount;
        GamerCasinoAccount gamerCasinoAccount = gamer.GamerCasinoAccount;
        
        foreach (int denomination in _chipsDenomination)
        {
            int count = money / denomination;
            chipsToDenomination[denomination] = count;
            money -= count * denomination;
        }

        foreach (var pair in chipsToDenomination)
        {
            int denomination = pair.Key;
            int count = pair.Value;

            int totalAmount = denomination * count;

            if (gamerBankAccount.PossibleBet(totalAmount))
            {
                gamerBankAccount.WithdrawCurrency(totalAmount);
                gamerCasinoAccount.AddCurrency(totalAmount); // saving the summ of chips gamer's got
            }
        }
    }
}