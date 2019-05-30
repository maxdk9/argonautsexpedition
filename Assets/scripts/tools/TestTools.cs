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
                GameObject cardprefab = OneCardManager.GetCardPrefab(c);
                GameObject cardObject = GameObject.Instantiate(cardprefab,cardPoint.transform,false);
                cardObject.transform.localScale=Vector3.one;
                cardObject.transform.localPosition=new Vector3(0,0,Visual.instance.transform.position.y);
                cardObject.transform.SetParent(null);
                cardObject.SetActive(true);
                //cardObject.transform.localPosition=Vector3.zero;
            
            
            
                OneCardManager cardManager = cardObject.GetComponent<OneCardManager>();
                cardManager.cardAsset = c;
                cardManager.ReadCardFromAsset();
            
                MoveCardToAnotherParent(cardObject,Visual.instance.CardDeckFrame.transform);
                
                
            }
        }
        
        
        
        
        
        public static void MoveCardToAnotherParent ( GameObject cardObject, Transform partyStack)
        {
            float duration = 1f;
            

            cardObject.transform.SetParent(null);
            Sequence s = DOTween.Sequence();
            
            
            s.Append(cardObject.transform.DOMove(Visual.instance.CardPoint.transform.position, duration));
            s.Join(cardObject.transform.DORotate(new Vector3(0f, 179f, 0f), duration));
            s.Play();
            s.onComplete = () => { cardObject.transform.SetParent(partyStack); };


        }
        
    }
    
    
    
    
}