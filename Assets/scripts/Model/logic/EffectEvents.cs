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
                float TimeMovement = .4f;
                float DelayTime = .1f;
                DeckGameControlPanel.instance.Hide();
                Visual.instance.CardDeckFrame.SetActive(true);
                    
                yield return  new WaitForSeconds(EndTurn.SmallAmountOfTime);
                List<OneCardManager> curEnc = Visual.instance.GetCurrentEncounter();
                foreach(OneCardManager cm in curEnc)
                {
                    yield return new WaitForSeconds(EndTurn.SmallAmountOfTime);
                    MoveCardToPoint(cm,Visual.instance.CardPointShuffle,true);                    
                }

                List<OneCardManager> currentDeck = Visual.instance.GetCurrentDeck();
                foreach(OneCardManager cm in currentDeck)
                {
                    yield return new WaitForSeconds(EndTurn.SmallAmountOfTime);
                    MoveCardToPoint(cm,Visual.instance.CardPointShuffle,false);                    
                }
                yield return new WaitForSeconds(TimeMovement  + DelayTime);

                OneCardManager[] shuffledArray =
                    Visual.instance.CardPointShuffle.GetComponentsInChildren<OneCardManager>();
                foreach (OneCardManager cm in shuffledArray)
                {
                    if (cm.isPreview)
                    {
                        continue;
                    }
                    
                    
                }
                
                
                Command.CommandExecutionComplete();
            }
        }
        
        
        public static void MoveCardToPoint(OneCardManager card,GameObject destination,bool rotation)
        {                
            card.transform.SetParent(null);

            Sequence sequence = DOTween.Sequence();
            
            
            sequence.Append(card.transform.DOLocalMove(destination.transform.position, EndTurn.TimeMovement1));
            if (rotation)
            {
                sequence.Insert(0, card.transform.DORotate(new Vector3(0f, 179f, 0f), EndTurn.TimeMovement1*.5f));    
            }
            
            
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