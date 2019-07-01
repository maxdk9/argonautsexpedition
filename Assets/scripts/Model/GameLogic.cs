namespace Model
{
    public class GameLogic
    {
        public static bool cardIsMonsterOrTreasure(CardManager.Card card)
        {
            return card.type == CardType.monster || card.type == CardType.treasure;
        }
    }
}