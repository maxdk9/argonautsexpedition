using Assets.SimpleLocalization;
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
            Debug.Log("CrewAssignment");
            MessageManager.Instance.ShowMessage(LocalizationManager.Localize("assigncrewmembers"),10);
            OneCardManager[] cards = Visual.instance.CurrentEncounter.GetComponentsInChildren<OneCardManager>();

            foreach (OneCardManager card in cards)
            {
                card.gameObject.AddComponent<AssignCrewTouchListener>();
                HoverPreview preview = card.GetComponent<HoverPreview>();
                preview.ThisPreviewEnabled = false;
            }


        }

        public void OnExit()
        {
            
        }
    }
}