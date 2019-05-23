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

                while (true)
                {
                    int r = UnityEngine.Random.Range(0, CardManager.Instance().shuffledList.Count - 1);
                    c = CardManager.Instance().shuffledList[r];
                    if (c.type == CardType.blessing || c.type == CardType.wrath)
                    {
                        break;
                    }
                    
                }

               
                
                

                
                
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