using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Model.States;
using screen;
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

            if (effectType == Effect.EffectType.Cornucopia_Recover2Crew_single)
            {
                GameLogicEvents.eventRestoreCrew.Invoke(effectType);
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
                float TimeMovement2 = .2f;
                float DelayTime = .1f;
                float SmallAmountOfTime = .01f;
                DeckGameControlPanel.instance.Hide();
                Visual.instance.CardDeckFrame.SetActive(true);
                    
                yield return  new WaitForSeconds(SmallAmountOfTime);
                List<OneCardManager> curEnc = Visual.instance.GetCurrentEncounter();
                foreach(OneCardManager cm in curEnc)
                {
                    yield return new WaitForSeconds(SmallAmountOfTime);
                    MoveCardToPoint(cm,Visual.instance.CardPointShuffle,TimeMovement,true);                    
                }

                List<OneCardManager> currentDeck = Visual.instance.GetCurrentDeck();
                foreach(OneCardManager cm in currentDeck)
                {
                    yield return new WaitForSeconds(SmallAmountOfTime);
                    MoveCardToPoint(cm,Visual.instance.CardPointShuffle,TimeMovement,false);                    
                }
                yield return new WaitForSeconds(TimeMovement  + DelayTime);

                OneCardManager[] shuffledArray =
                    Visual.instance.CardPointShuffle.GetComponentsInChildren<OneCardManager>();
                int shuffledSize = shuffledArray.Length;
                foreach (OneCardManager cm in shuffledArray)
                {
                    if (cm.isPreview)
                    {
                        continue;
                    }

                    int newIndex = UnityEngine.Random.Range(0, shuffledSize);
                    cm.transform.SetSiblingIndex(newIndex);
                }
                
                foreach (OneCardManager cm in shuffledArray)
                {
                    yield return new WaitForSeconds(SmallAmountOfTime);
                    MoveCardToPoint(cm,Visual.instance.CardDeckFrame,TimeMovement2,false);
                }
                
                
                
                
                Command.CommandExecutionComplete();
            }
        }
        
        
        public static void MoveCardToPoint(OneCardManager card,GameObject destination,float timemovement,bool rotation)
        {                
            card.transform.SetParent(null);

            Sequence sequence = DOTween.Sequence();
            
            
            sequence.Append(card.transform.DOLocalMove(destination.transform.position, timemovement));
            if (rotation)
            {
                sequence.Insert(0, card.transform.DORotate(new Vector3(0f, 179f, 0f), timemovement*.6f));    
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


        public static void ShowRestoreCrew()
        {
            GameObject healCrewEffect = GameObject.Instantiate(Visual.instance.particleHealCrew,
                ScreenManager.instance.DeckgameCanvas.transform);
            healCrewEffect.transform.position = Visual.instance.CrewCounter.transform.position-new Vector3(0,10,0);
        }
    }
    
}