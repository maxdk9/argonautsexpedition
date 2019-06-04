using System.Collections.Generic;
using DG.Tweening;
using Model;
using screen;
using UnityEngine;

namespace tools
{
    public class TestTools
    {
        public static void TestCardList()
        {
            
            Transform testGroup=GameObject.Find("testCardGroup1").GetComponent<Transform>();
                
            
            CardManager.Instance().Init();
            CardManager.Instance().Shuffle();
            CardManager.Card c=null;
            
            for (int i = 0; i < 3; i++)
            {
                
                
                
                /*c = CardManager.Instance().shuffledList[i];
                
                GameObject cardprefab = OneCardManager.GetCardPrefab(c);
                GameObject cardObject =
                    GameObject.Instantiate(cardprefab, testGroup, false);
                OneCardManager cardManager = cardObject.GetComponent<OneCardManager>();
                cardManager.cardAsset = c;
                cardManager.ReadCardFromAsset();*/
            }
               
                
                
        }

        public static void TestCardMove()
        {
            CardManager.Instance().Init();
            CardManager.Instance().Shuffle();

            float duration = 1f;

            CardManager.Card c;

            //for (int i = 0; i < CardManager.Instance().shuffledList.Count; i++)
            for (int i = 0; i < 2; i++)
            {
                
                GameObject cardPoint = Visual.instance.CardPointOutside;
                c = CardManager.Instance().shuffledList[i];
                
                GameObject cardObject = OneCardManager.CreateOneCardManager(c, cardPoint);
                
                MoveCardToAnotherParent(cardObject,Visual.instance.CardDeckFrame.transform);
                
                
            }
        }


        public static void TestFillDeck()
        {
            CardManager.Instance().Init();
            CardManager.Instance().Shuffle();

            float duration = .5f;

            CardManager.Card c;

            Sequence s = DOTween.Sequence();
            
            
            
            List<GameObject> shuffledCards=new List<GameObject>();
            //for (int i = 0; i < CardManager.Instance().shuffledList.Count; i++)
            for (int i = 0; i < 5; i++)
            {
                
                GameObject cardPoint = Visual.instance.CardPointOutside;
                c = CardManager.Instance().shuffledList[i];
                
                GameObject cardObject = OneCardManager.CreateOneCardManager(c, cardPoint);

                SetCanvasOrderInObject(cardObject, i);
                
                
                shuffledCards.Add(cardObject);
                
                s.Append(cardObject.transform.DOMove(Visual.instance.CardDeckFrame.transform.position, duration)).SetEase(Ease.Flash);
                s.Join(cardObject.transform.DORotate(new Vector3(0f, 179f, 0f), duration));
                
                
                
                
            }
            s.onComplete = () =>
            {
                foreach (GameObject go in shuffledCards)
                {
                    go.transform.SetParent(Visual.instance.CardDeckFrame.transform);    
                }
                
            };

            s.Play();
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
            float duration = .5f;
            

            cardObject.transform.SetParent(null);
            Sequence s = DOTween.Sequence();
            
            
            s.Append(cardObject.transform.DOMove(partyStack.position, duration));
            s.Join(cardObject.transform.DORotate(new Vector3(0f, 179f, 0f), duration));
            s.Play();
            s.onComplete = () => { cardObject.transform.SetParent(partyStack); };


        }
        
    }
    
    
    
    
}