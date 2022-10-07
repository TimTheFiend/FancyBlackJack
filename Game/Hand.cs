using FancyBlackJack.CardDeck;
using FancyBlackJack.Character;

namespace FancyBlackJack.Game
{
    public struct Hand
    {
        private readonly int maxHandValue = 21;
        // Variables related to both dealer and player
        public BasePlayer player { get; private set; }
        List<Card> cards = new List<Card>();
        public bool isActive { get; private set; } = true;

        #region Variables uniquely relevant to Player 
        public int size => cards.Count;

        public int betAmount { get; private set; } = -1;
        public bool isSplit { get; private set; } = false;
        public bool isBust => Value > maxHandValue;


        // true; player can perform any valid action. false; can only stand/hit
        public bool hasPerformedAction { get; private set; } = false;

        #endregion

        /* Calculate total value */
        public int Value {
            get {
                int totalValue = 0;
                int aceCount = 0;

                foreach (Card card in cards) {
                    if (card.Value is CardValue.ACE)
                        aceCount++;
                    totalValue += card.GetValue;
                }

                if (totalValue > maxHandValue && aceCount > 0) {
                    for (int i = 0; i < aceCount; i++) {
                        totalValue -= 10;  // ACE's lowest value
                        if (totalValue < maxHandValue) {
                            break;
                        }
                    }
                }

                return totalValue;
            }
        }
        
        #region Constructors
        public Hand(BasePlayer player) {
            this.player = player;
        }

        public Hand(Player player, int betAmount) : this(player) {
            this.betAmount = betAmount;
        }
        #endregion

        //Adds card to deck
        public void Hit(Card card) {
            if (isActive) {
                cards.Add(card);

                // If hand is bust, disable.
                if (isBust) {
                    isActive = false;
                }
            }
        }

        public void Stand() {
            isActive = false;
        }

        public override string ToString() {
            if (player is Player) {
                return String.Format("Belongs to {0}\n\tWallet: ${1}\n\tBet: ${2}", player, ((Player)player).Wallet, betAmount);
            }
            return "DEALER's hand";
        }
    }
}

