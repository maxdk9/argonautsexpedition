using System.Collections;
using System.Collections.Generic;
using System.Linq;
using common;
using DG.Tweening;
using GameActors;
using Model;
using screen;
using UnityEngine;
using UnityEngine.UI;

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


        public static void TestFillDeckOld()
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

        
        public static void TestFillDeck()
        {
            



            ScreenManager.instance.StartCoroutine(FillDeckCoroutine());
            
            
            

            
        }

        private static IEnumerator FillDeckCoroutine()
        {
            CardManager.Instance().Init();
            CardManager.Instance().Shuffle();

            float duration = .5f;

            CardManager.Card c;
            
            
            List<GameObject> shuffledCards=new List<GameObject>();
            //for (int i = 0; i < CardManager.Instance().shuffledList.Count; i++)


            int shuffledCardNumber = 30;

            float smallAmountOfTime = .01f;
            float moveCardDuration = 0.5f;
            for (int i = 0; i < shuffledCardNumber; i++)
            {
                
                GameObject cardPoint = Visual.instance.CardPointOutside;
                c = CardManager.Instance().shuffledList[i];
                GameObject cardObject = OneCardManager.CreateOneCardManager(c, cardPoint);
                SetCanvasOrderInObject(cardObject, i);
                
                MoveCardToAnotherParent(cardObject,Visual.instance.CardDeckFrame.transform);
                //shuffledCards.Add(cardObject);
                
                yield return new WaitForSeconds(smallAmountOfTime);
                
                
            };
            yield return new WaitForSeconds(shuffledCardNumber*smallAmountOfTime+moveCardDuration);
            Debug.Log("End FillDeckCoroutine");
            
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
            float TimeMovement = .5f;
            cardObject.transform.SetParent(null);
            cardObject.transform.DOMove(partyStack.position, TimeMovement);
            
            cardObject.transform.DORotate(new Vector3(0f, 179f, 0f), TimeMovement).onStepComplete=()=>{cardObject.transform.SetParent(partyStack);};


        }



        public static void ShowRollDice()
        {
            ScreenManager.instance.Show(ScreenManager.ScreenType.Rolldice);
        }

        public static void MainTest()
        {
        
        }


       

        private static void MoveCardToUp(string cardname)
        {
            
            CardManager.Card chosenCard = null;
            
            foreach (CardManager.Card card in Game.instance.currentDeck)
            {

                
                if (card.name.Equals(cardname))
                {
                    chosenCard = card;
                    break;
                }
            }

            if (chosenCard != null)
            {
                Game.instance.currentDeck.Remove(chosenCard);
                Game.instance.currentDeck.Insert(Game.instance.currentDeck.Count-1,chosenCard);
            }
            
        }

        public static void DeckCorrection()
        {
            CorrectDeck2_AddItemToHand();   
        }
        
        private static void CorrectDeck1()
        {
            MoveCardToUp("wingedsandals");
        }

        private static void CorrectDeck2_AddItemToHand()
        {

            string cardname = "apollobow";
            CardManager.Card chosenCard = null;
            
            foreach (CardManager.Card card in Game.instance.currentDeck)
            {

                
                if (card.name.Equals(cardname))
                {
                    chosenCard = card;
                    break;
                }
            }
            
            foreach (CardManager.Card card in Game.instance.reserveDeck)
            {

                if (card.name.Equals(cardname))
                {
                    chosenCard = card;
                    break;
                }
            }
            
            

            if (chosenCard != null)
            {
                Game.instance.currentDeck.Remove(chosenCard);
                SameDistanceChildren distance = Visual.instance.TreasureHand.GetComponent<SameDistanceChildren>();
                int emptySlotIndex = distance.GetOccupiedSlotsNumber();
                GameObject treasureslot = distance.slots[emptySlotIndex];
                OneCardManager.CreateOneCardManager(chosenCard, treasureslot);
            }
        }

        public static void GenerateEffects()
        {
            Game.instance.CardEffects.Add(new Effect(Effect.EffectType.Ignore_Charybdis));
            Game.instance.CardEffects.Add(new Effect(Effect.EffectType.Argo_TreasureRolls_p1_cont));
        }


        public static void VisualTest()
        {
            Debug.Log("VisualTest");
            CardListChooserTest();

            // GameManager.instance.listToDestroy.Add(particleHeal);
        }

        private static void CardListChooserTest()
        {
            CardListChooser.instance.FillByCards(Game.instance.winningPile);
            CardListChooser.instance.Show();
        }


       
        

        private void HealVisualTest()
        {
           
            GameObject healCrewEffect = GameObject.Instantiate(Visual.instance.particleHealCrew,
                ScreenManager.instance.DeckgameCanvas.transform);
            healCrewEffect.transform.position = Visual.instance.CrewCounter.transform.position-new Vector3(0,10,0);
        }
        
    }
    
    
    
    
    
    
}