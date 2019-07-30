using Assets.SimpleLocalization;
using screen;
using UnityEngine;

namespace Model.States
{
    public class CrewAssignment:iState
    {
        public static CrewAssignment ourInstance=new CrewAssignment();
        
        public void Execute(double time)
        {
            
        }

        public void OnEnter()
        {
            ScreenManager.instance.Show(ScreenManager.ScreenType.Deckgame);
            Debug.Log("CrewAssignment");
            DeckGameControlPanel.instance.Show();
            MessageManager.Instance.ShowMessage(LocalizationManager.Localize("assigncrewmembers"),10);
            OneCardManager[] cards = Visual.instance.CurrentEncounter.GetComponentsInChildren<OneCardManager>();
            GameLogicEvents.eventAddSingleUsedTreausreTouchListener.Invoke();
            foreach (OneCardManager card in cards)
            {

                if (!GameLogic.cardIsMonsterOrTreasure(card.cardAsset))
                {
                    continue;
                }
                card.gameObject.AddComponent<AssignCrewTouchListener>();
                HoverPreview preview = card.GetComponent<HoverPreview>();
                if (preview != null)
                {
                    preview.ThisPreviewEnabled = false;    
                }
            }
            GameLogicEvents.eventUpdateCurrentEncounter.Invoke();
            
        }

        public void OnExit()
        {
            
        }

        
    }
}