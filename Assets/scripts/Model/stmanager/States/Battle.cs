using screen;
using UnityEngine;

namespace Model.States
{
    public class Battle:iState
    {
        public static Battle ourInstance=new Battle();
        private GameObject currentDiceEncounterObject;
        
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