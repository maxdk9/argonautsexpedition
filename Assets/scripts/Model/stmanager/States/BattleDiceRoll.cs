using screen;
using UnityEngine;
using UnityEngine.Events;

namespace Model.States
{
    public class BattleDiceRoll:iState
    {
        public static BattleDiceRoll ourInstance=new BattleDiceRoll();
        public UnityEvent diceRolledEvent=new UnityEvent();
        
        private GameObject currentDiceEncounterObject;
        private OneCardManager currentDiceEncounterOneCardManager;
        
        
        
        public void Execute(double time)
        {
            
        }

        public void OnEnter()
        {
            ScreenManager.instance.Show(ScreenManager.ScreenType.Rolldice);
            Visual.instance.mainDice.SetActive(true);
            Visual.instance.mainDice.GetComponent<ApplyForceInRandomDirection>().Reset();

            SetCurrentDiceEncounterObject();
            
            RollDiceTouchListener rollDiceTouchListener =
                Visual.instance.RollDiceImage.gameObject.AddComponent<RollDiceTouchListener>();
            rollDiceTouchListener.dice = Visual.instance.mainDice;
            rollDiceTouchListener.RollEnabled = true;

            CardManager.Card opponentCard = currentDiceEncounterOneCardManager.cardAsset;
            diceRolledEvent.RemoveAllListeners();
            diceRolledEvent.AddListener(new UnityAction(delegate{GameLogicModifyGame.CalculateDiceRollResult(currentDiceEncounterOneCardManager.cardAsset); } ));
            
            diceRolledEvent.AddListener(new UnityAction(delegate { ResultPanel.instance.ShowMessage(GameLogic.GetResultMessage()); }));
            
            diceRolledEvent.AddListener(new UnityAction(delegate { RollDiceResultBar.instance.Show(); }));
            diceRolledEvent.AddListener(new UnityAction(delegate { new GoToNextGamePhase(GamePhase.BattleEnd).AddToQueue(); }));
            
            
            
        }

        public void SetCurrentDiceEncounterObject()
        {
            CardManager.Card diceEncounterCard = Visual.instance.GetCurrentEnemyCard();
            currentDiceEncounterObject =  OneCardManager.CreateOneCardManager(diceEncounterCard,Visual.instance.currentDiceEncounter);
            currentDiceEncounterOneCardManager = currentDiceEncounterObject.GetComponent<OneCardManager>();
            
        }

        
        


        public void OnExit()
        {
           
        }
    }
}