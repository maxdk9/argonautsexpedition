using System;
using UnityEditor;

namespace Model
{
    public class GameLogic
    {
        public static bool cardIsMonsterOrTreasure(CardManager.Card card)
        {
            return card.type == CardType.monster || card.type == CardType.treasure;
        }

        public static int GetCurrentDifficulty(CardManager.Card card)
        {
            int basic= card.difficulty[card.level];
            int monsterTypeDiff = GetMonsterDifficultyModifier(card);
            
            
            int res=basic+monsterTypeDiff;
            if (HaveEffectByType(Effect.EffectType.CloakOfHeracles_monsterdifficulty_m1_cont))
            {
                res = Math.max(7, res - 1);
            }
            

            return res;
        }

        private static bool HaveEffectByType(Effect.EffectType effectType)
        {
            foreach (Effect effect in Game.instance.CardEffects)
            {
                if (effect.Type == effectType)
                {
                    return true;
                }
            }

            return false;
        }
    }
}