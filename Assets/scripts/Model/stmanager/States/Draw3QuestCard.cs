using System.Linq;
using Assets.SimpleLocalization;
using UnityEngine.UI;

namespace Model.States
{
    public class Draw3QuestCard:iState
    {
        public static Draw3QuestCard ourInstance=new Draw3QuestCard();
        
        public void Execute(double time)
        {
            
            
            
        }

        public void OnEnter()
        {
            Visual.instance.CardDeck.SetActive(true);
            MessageManager.Instance.ShowMessage(LocalizationManager.Localize("draw3questcard"),10);
            Visual.instance.CardDeck.gameObject.AddComponent<Draw3CardsTouchListener>();
        }

        public void OnExit()
        {
            
        }
    }
}