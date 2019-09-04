using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace command
{
    public class MoveCardsFromOutsideToDeck:Command
    {
        
        
        public static float TimeMovement = .4f;
        public static float SmallAmountOfTime = .05f;
        
        public override void StartCommandExecution()
        {
            GameManager.instance.StartCoroutine(MoveCardsOutsideFromDeckCoroutine());
        }

        private IEnumerator MoveCardsOutsideFromDeckCoroutine()
        {
            yield return new WaitForSeconds(.01f);
            Visual.instance.CardDeckFrame.gameObject.SetActive(true);
            
            OneCardManager[] cards = Visual.instance.CardPointOutside.GetComponentsInChildren<OneCardManager>();
            foreach (OneCardManager cardmanager in cards)
            {
                GameObject cardObject = cardmanager.gameObject;
               // int cardindex = Array.IndexOf(cards, cardmanager);
                //SetCanvasOrderInObject(cardObject, cardindex);
                
                
                VisualTool.MoveCardToAnotherParentNoSequence(cardObject,Visual.instance.CardDeckFrame.transform,TimeMovement);
                yield return new WaitForSeconds(SmallAmountOfTime);
            }            
            yield return new WaitForSeconds(TimeMovement+SmallAmountOfTime);
            Command.CommandExecutionComplete();
        }
        
        
        private static void SetCanvasOrderInObject(GameObject gameObject, int i)
        {
            Canvas[] canvases = gameObject.GetComponentsInChildren<Canvas>();
            foreach (Canvas canvas in canvases)
            {
                canvas.sortingOrder = i;
            }
        }
    }
}