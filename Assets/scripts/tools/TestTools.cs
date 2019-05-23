using Model;
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
                
                
                
                c = CardManager.Instance().shuffledList[i];
                
                GameObject cardprefab = OneCardManager.GetCardPrefab(c);
                GameObject cardObject =
                    GameObject.Instantiate(cardprefab, testGroup, false);
                OneCardManager cardManager = cardObject.GetComponent<OneCardManager>();
                cardManager.cardAsset = c;
                cardManager.ReadCardFromAsset();
            }
               
                
                
        }
    }
}