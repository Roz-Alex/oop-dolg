using OOP_ICT.Models;
using Xunit;
using Xunit.Abstractions;

namespace OOP_ICT.FIrst.Tests
{
    public class TestCardFunctions
    {
        private readonly ITestOutputHelper _output;
        [Fact]
        public void CardTest()
        {
            Card card = new Card("Hearts", "Eight", false);
            Assert.Equal("Hearts", card.Suit);
            Assert.Equal("Eight", card.Rank);
            Assert.False(card.IsVisible);
        }
        public TestCardFunctions(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void DeckOrderTest()
        {
            var deck = new CardDeck();
            List<Card> cardsList = deck.GenerateCardDeck();
    
            Assert.Equal(52, cardsList.Count);
            Assert.Equal(4, cardsList.Select(card => card.Suit).Distinct().Count());
            Assert.Equal(13, cardsList.Select(card => card.Rank).Distinct().Count());
            
            Assert.All(cardsList, card => Assert.NotNull(card.Suit));
            Assert.All(cardsList, card => Assert.NotNull(card.Rank));
        }
        
        [Fact]
        public void ShuffleDeckTest()
        {
            CardDeck cardDeck = new CardDeck();
            List<Card> deck = new List<Card>();
            //var initialDeck = cardDeck.GenerateCardDeck();
            Dealer dealer = new Dealer(deck); 
            var initialDeck = dealer.GetInitialDeck();
            var shuffledDeck = dealer.ShuffleDeck();
            Assert.NotEqual(initialDeck, shuffledDeck);
        }
    }
}

