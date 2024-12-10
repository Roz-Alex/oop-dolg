namespace OOP_ICT.Models
{
    public class Card
    {
        public string Suit { get; private set; }
        public string Rank { get; private set; }
        public bool IsVisible { get; private set; }

        public Card(string suit, string rank, bool isVisible)
        {
            Suit = suit;
            Rank = rank;
            IsVisible = isVisible;
        }
    }
}