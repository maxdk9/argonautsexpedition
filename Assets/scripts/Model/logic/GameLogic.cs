using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Resources;
using Assets.SimpleLocalization;
using Model.States;
using UnityEditor;
using UnityEngine;

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
                res = Math.Max(7, res - 1);
            }
            

            return res;
        }

        private static int GetMonsterDifficultyModifier(CardManager.Card card)
        {
            
                int res=0;
                if(HaveEffectByType(Effect.EffectType.Mirrored_Shield)){
                    return 0;
                }
                if(card.name.Equals("skeleton")||card.name.Equals("harpy")){
                    int monsternumber=GetMonsterNumberInEncounter(card)-1;
                    if (monsternumber >= 2)
                    {
                        res = monsternumber - 1;
                    }
                }
                res = Math.Max(0, res);
                return res;
            
        }

        private static int GetMonsterNumberInEncounter(CardManager.Card card)
        {
            int res = 0;
            List<OneCardManager> currentEncounter = Visual.instance.GetCurrentEncounter();
            foreach (OneCardManager enc in currentEncounter)
            {
                
                
                if (enc.cardAsset.name.Equals(card.name))
                {
                    res++;
                }
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

        public static int GetModifiedDiceResult(CardManager.Card card, int diceresult)
        {
            int res;
            int powerup=GetPowerUp(card);
            
            res=Math.Min(diceresult+powerup,6);
            return res;
        }



        public static int GetPowerUp(CardManager.Card card)
        {
            int result = 0;
            if(card.type==CardType.monster&&HaveEffectByType(Effect.EffectType.SwordOfPeleus_MonsterRolls_p1_cont))
            {
                result+=1;
            }
            if(card.type==CardType.treasure&&HaveEffectByType(Effect.EffectType.Argo_TreasureRolls_p1_cont))
            {
                result+=1;
            }	
            if(card.type==CardType.treasure&&HaveEffectByType(Effect.EffectType.Defeat_ColchianDragon_single)){
                result+=2;
            }

            return result;
        }
        
        
        public static string GetResultMessage()
        {
            if (GameLogic.CurrentChallengeWin())
            {
                return LocalizationManager.Localize("victory");
            }
            else
            {

                return LocalizationManager.Localize("defeat");

            }
        }

        public static bool CurrentChallengeWin()
        {

            CardManager.Card currentEncounter = Visual.instance.GetCardByNumberFromCurrentEncounter();

            int playerResult = currentEncounter.crewNumber + Game.instance.DiceEncounterNumber + GameLogic.GetPowerUp(currentEncounter);
            int monsterResult = GameLogic.GetCurrentDifficulty(currentEncounter);
            return playerResult >= monsterResult;


        }
    }

}