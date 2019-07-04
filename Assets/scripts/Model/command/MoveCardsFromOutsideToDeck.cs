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

            OneCardManager[] cards = Visual.instance.CardPointOutside.GetComponentsInChildren<OneCardManager>();
            foreach (OneCardManager cardmanager in cards)
            {
                GameObject cardObject = cardmanager.gameObject;
                int cardindex = Array.IndexOf(cards, cardmanager);
                SetCanvasOrderInObject(cardObject, cardindex);
                MoveCardToAnotherParent(cardObject,Visual.instance.CardDeckFrame.transform);
                yield return new WaitForSeconds(SmallAmountOfTime);
            }
            
            yield return new WaitForSeconds(TimeMovement);
            Debug.Log("End MoveCardsOutsideFromDeckCoroutine");
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


        public static void MoveCardToAnotherParent ( GameObject cardObject, Transform partyStack)
        {   
            cardObject.transform.SetParent(null);
            cardObject.transform.DOMove(partyStack.position, TimeMovement);
            
            cardObject.transform.DORotate(new Vector3(0f, 179f, 0f), TimeMovement).onComplete= () =>
            {
                cardObject.transform.SetParent(partyStack);
                Debug.Log("MoveCardToAnotherParent "+cardObject.GetInstanceID());    
            };
        }
        
        
        public static void SimpleMoveCardToAnotherParent ( GameObject cardObject, Transform partyStack)
        {   
            cardObject.transform.SetParent(null);
            cardObject.transform.DOMove(partyStack.position, 0).onComplete= () =>
            {
                cardObject.transform.SetParent(partyStack);    
            };
        }
        
        
    }
}