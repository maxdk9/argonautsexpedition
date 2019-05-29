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

            GameObject cardPoint = GameObject.Find("CardPoint");
            CardManager.Card c = CardManager.Instance().shuffledList[0];
            GameObject cardprefab = OneCardManager.GetCardPrefab(c);
            GameObject cardObject = GameObject.Instantiate(cardprefab,cardPoint.transform,false);
            cardObject.SetActive(true);
            //cardObject.transform.localPosition=Vector3.zero;
            
            
            
            OneCardManager cardManager = cardObject.GetComponent<OneCardManager>();
            cardManager.cardAsset = c;
            cardManager.ReadCardFromAsset();
            
            Sequence s = DOTween.Sequence();
            
           s.Append(cardObject.transform.DOMove(new Vector3(5,0,cardObject.transform.position.z), 2f));
           s.Join(cardObject.transform.DORotate(new Vector3(0f, 179f, 0f), 2f));
            s.Play();
            

        }
        
    }
    
    
    
    
}