
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using DG.Tweening;
    using GameActors;
    using UnityEngine;
   using UnityEngine.EventSystems;

public class Draw3CardsTouchListener :StateComponent,UnityEngine.EventSystems.IPointerDownHandler
    {
        
        public void OnPointerDown(PointerEventData eventData)
        {

           // OneCardManager c=this.GetComponent<OneCardManager>();
            
            Debug.Log("Draw3CardsTouchListener ");
            GameManager.instance.StartCoroutine(this.Draw3CardsCoroutine());

            // GameManager.instance.StartCoroutine(this.Draw3Cards());   
        }

        private IEnumerator Draw3CardsCoroutine()
        {
            
            List<OneCardManager> drawlist=new List<OneCardManager>();
            OneCardManager[] deckcards = Visual.instance.CardDeck.GetComponentsInChildren<OneCardManager>();
            
            for (int i = 1; i <=3; i++)
            {
                if (deckcards.Length <i)
                {
                    break;
                }

                OneCardManager card = deckcards[deckcards.Length-(i)];
                drawlist.Add(card);
            }


            float TimeMovement1 = .6f;
            float TimeMovement2 = .4f;
            float SmallAmountOfTime = .05f;
            float DelayTime = .3f;
            
            
            
            
            foreach (OneCardManager card in drawlist)
            {
                    card.transform.SetParent(null);
                    Sequence sequence = DOTween.Sequence();    
                    sequence.Append(card.transform.DOMove(Visual.instance.CardPoint.transform.position, TimeMovement1));
                    sequence.Insert(0f, card.transform.DORotate(Vector3.zero, TimeMovement1));                    
                    sequence.AppendInterval(DelayTime);
                    sequence.Append(card.transform.DOLocalMove(Visual.instance.CurrentEncounter.transform.position, TimeMovement2));
                    sequence.OnComplete(()=>MoveCardToCurrentEncounterGroup(card));
                    
                    sequence.Play();
                    yield return new WaitForSeconds(DelayTime);
            }
            yield return    new WaitForSeconds(TimeMovement1+TimeMovement2+DelayTime);
            Debug.Log("Draw3CardsCoroutine End");
            
        }
        
        private void MoveCardToCurrentEncounterGroup(OneCardManager card)            
        {
            card.transform.SetParent(Visual.instance.CurrentEncounter.transform);
            Debug.Log("Draw3CardsCoroutine card moved "+card.cardAsset.cardnumber.ToString());
        }
        
        
    }
