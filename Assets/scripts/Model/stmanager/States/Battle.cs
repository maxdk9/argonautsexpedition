using screen;
using UnityEngine;
using UnityEngine.Events;

namespace Model.States
{
    public class Battle:iState
    {
        public static Battle ourInstance=new Battle();
        private GameObject currentDiceEncounterObject;
        public UnityEvent diceRolledEvent=new UnityEvent();
        
        
        
        
        public void Execute(double time)
        {
            
        }

        public void OnEnter()
        {
            ScreenManager.instance.Show(ScreenManager.ScreenType.Rolldice);
            Visual.instance.mainDice.SetActive(true);

            CardManager.Card diceEncounterCard =
                Visual.instance.GetCardByNumberFromCurrentEncounter(Game.instance.DiceEncounterNumber);
            GameObject currentDiceEncounterObject =
                OneCardManager.CreateOneCardManager(diceEncounterCard,Visual.instance.currentDiceEncounter);
            
            RollDiceTouchListener rollDiceTouchListener =
                Visual.instance.RollDiceImage.gameObject.AddComponent<RollDiceTouchListener>();
            rollDiceTouchListener.dice = Visual.instance.mainDice;
            rollDiceTouchListener.RollEnabled = true;
    

            diceRolledEvent.RemoveAllListeners();
          //  diceRolledEvent.AddListener(()=>{ Visual.instance.mainDice.SetActive(false); });
            diceRolledEvent.AddListener(new UnityAction(delegate { GameLogicModifyGame.CalculateDiceRollResult(); }));
            diceRolledEvent.AddListener(new UnityAction(delegate { ResultPanel.instance.ShowMessage(GameLogic.GetResultMessage()); }));
            diceRolledEvent.AddListener(new UnityAction(delegate { ShowDetailedResult(); }));
            diceRolledEvent.AddListener(new UnityAction(delegate { ShowUIAfterDiceRolled(); }));
            
            
        }

        private void ShowDetailedResult()
        {
            
        }

        private void ShowUIAfterDiceRolled()
        {
            
        }


        public void OnExit()
        {
            if (currentDiceEncounterObject != null)
            {
                GameObject.Destroy(currentDiceEncounterObject);
            }
        }
    }
}