using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                    int monsternumber=GetMonsterNumberInEncounter(card);
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

            CardManager.Card currentEncounter = Visual.instance.GetCurrentEnemyCard();

            int playerResult = currentEncounter.crewNumber + currentEncounter.rollResult + GameLogic.GetPowerUp(currentEncounter);
            int monsterResult = GameLogic.GetCurrentDifficulty(currentEncounter);
            if (currentEncounter.criticalHit)
            {
                return true;
            }
            return playerResult >= monsterResult;


        }

        public static bool CurrentEncounterResolved()
        {
            
            foreach (CardManager.Card card in Game.instance.currentEncounter)
            {

                if (card.type == CardType.wrath || card.type == CardType.blessing)
                {
                    continue;
                }
                if (card.resolved == ResolvedType.notresolved)
                {
                    return false;
                }    
            }

            return true;
        }

        public static int  GetDeadliness(CardManager.Card card)
        {
            if (card.IgnoreDeadliness)
            {
                return 0;
            }
            return  card.deadliness[card.level];
        }

        
        
        public static bool EndDeck()
        {
            List<OneCardManager> currentDeck = Visual.instance.GetCurrentDeck();
            return currentDeck.Count == 0;
        }


        public static bool CanUseEffectInThisPhase(Effect.EffectType effectType)
        {
            GamePhase[] phases = StateManager.dictEnabledPhases[effectType];
            return phases.Contains(Game.instance.CurrentState);
        }
        
        
        
        
        public static bool CanUseEffect(Effect.EffectType effectType)
        {
            bool canUseInPhase = CanUseEffectInThisPhase(effectType);
            if (!canUseInPhase)
            {
                return false;
            }
            if (effectType == Effect.EffectType.AegisOfZeus_IgnoreDeadliness_single)
            {
                if (Game.instance.Casualties == 0)
                {
                    return false;
                }
            }
            
            if (effectType == Effect.EffectType.HelmOfHades_MoveMonsterToDiscardPile_single)
            {
                List<OneCardManager> enclist = Visual.instance.GetCurrentEncounter();
                foreach (var VARIABLE in enclist)
                {
                    if (VARIABLE.cardAsset.type == CardType.monster)
                    {
                        return true;
                    }
                }
                return false;
            }

            if (effectType == Effect.EffectType.OrpheusLyre_StopLevelUpMonsterInVictoryPile_single)
            {
                if (Game.instance.winningPile.Count > 0)
                {
                    return true;
                }

                return false;
            }

            if (effectType == Effect.EffectType.ApolloBow_RollDice6_single)
            {
                List<OneCardManager> encList = Visual.instance.GetCurrentEncounter();
                foreach (var VARIABLE in encList)
                {


                    if (VARIABLE.cardAsset.resolved == ResolvedType.notresolved)
                    {
                        if (VARIABLE.cardAsset.type == CardType.monster || VARIABLE.cardAsset.type == CardType.treasure)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            
            
            return true;
        }
        
        
        
        
        public static int  GetCrewStartingCount(){
            int res=Game.CREWNUMBERSTART;
            
            if(HDReceived(HeroicDeed.hdtype.startingcrew1)){
                res+=1;
            }
            if(HDReceived(HeroicDeed.hdtype.startingcrew2)){
                res+=1;
            }
            if(HDReceived(HeroicDeed.hdtype.startingcrew3)){
                res+=1;
            }
            return res;
        }

        private static bool HDReceived(HeroicDeed.hdtype hdtype)
        {
            foreach (HeroicDeed hd in Game.instance.HeroicDeedList)
            {
                if (hd.Received)
                {
                    return true;
                }   
            }
            return false;
        }


    }

}