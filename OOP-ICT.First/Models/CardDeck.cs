namespace OOP_ICT.Models
{
    public class CardDeck
    {
        private List<Card> _cards;

        public CardDeck()
        {
            _cards = new List<Card>();
        }

        public List<Card> GenerateCardDeck()
        {
            List<Card> deck = new List<Card>();
            var suits = Enum.GetNames(typeof(Suits));
            var ranks = Enum.GetNames(typeof(Ranks));
            foreach (string suitName in suits)
            {
                foreach (string rankName in ranks)
                {
                    deck.Add(new Card(suitName, rankName, false));
                }
            }

            return deck;
        }
    }
}