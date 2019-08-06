using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Model.States;
using UnityEngine;

namespace Model
{
    public class EffectEvents
    {
        
        
        public static void DoEffect(Effect.EffectType effectType)
        {    
            if (effectType == Effect.EffectType.PansFlute_DiscardTop2Cards_single)
            {
               GameManager.instance.StartCoroutine( PansFluteEffectCoroutine());
            }


            if (effectType == Effect.EffectType.WingedSandals_ReturnAdventureCard_single)
            {
                new CommmandDiscardCurrentEncounter().AddToQueue(); 
                new GoToNextGamePhase(GamePhase.StartNewTurn).AddToQueue();
            }
        }
        


    
        
        public class CommmandDiscardCurrentEncounter : Command
        {   
            
            
            public override void StartCommandExecution()
            {
                GameManager.instance.StartCoroutine(DiscardCoroutine());
            }

            private IEnumerator DiscardCoroutine()
            {
                float TimeMovement = .6f;
                DeckGameControlPanel.instance.Hide();
                Visual.instance.CardDeckFrame.SetActive(true);
                    
                yield return  new WaitForSeconds(EndTurn.SmallAmountOfTime);
                List<OneCardManager> curEnc = Visual.instance.GetCurrentEncounter();
                foreach(OneCardManager cm in curEnc)
                {
                    yield return new WaitForSeconds(EndTurn.SmallAmountOfTime);
                    MoveCardToDeck(cm);                    
                }
                yield return new WaitForSeconds(TimeMovement  + EndTurn.DelayTime);
                Command.CommandExecutionComplete();
            }
        }
        
        
        public static void MoveCardToDeck(OneCardManager card)
        {                
            card.transform.SetParent(null);

            Sequence sequence = DOTween.Sequence();
            GameObject destination =
                Visual.instance.CardDeckFrame;
            
            sequence.Append(card.transform.DOLocalMove(destination.transform.position, EndTurn.TimeMovement1));
            sequence.Insert(0, card.transform.DORotate(new Vector3(0f, 179f, 0f), EndTurn.TimeMovement1*.5f));
            
            sequence.OnComplete(() => { card.transform.SetParent(destination.transform); });
            sequence.Play();
                
        }
        
        
        
        
        

        public static IEnumerator PansFluteEffectCoroutine()
        {
            
            //int numberofdiscard=Math.Min(2,Visual.instance.GetCurrentDeck().Count)
            yield return new WaitForSeconds(.01f);
            List<OneCardManager> decklist = Visual.instance.GetCurrentDeck();
            int discardNumber = Math.Min(2, decklist.Count);
            for (int i = 0; i < discardNumber; i++)
            {
                OneCardManager cm = decklist[decklist.Count - i-1];
                yield return new WaitForSeconds(.1f);
                EndTurn.DiscardCard(cm,false);
            }
            yield return new WaitForSeconds(.5f);


        }


        
    }
    
}