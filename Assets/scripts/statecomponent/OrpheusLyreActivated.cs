
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Assets.SimpleLocalization;
    using command;
    using common;
    using DG.Tweening;
    using GameActors;
    using JetBrains.Annotations;
    using Model;
    using Model.States;
    using tools;
    using UnityEngine;
   using UnityEngine.EventSystems;

public class OrpheusLyreActivated:MonoBehaviour
{

    private bool activated;

    public bool Activated
    {
        get { return activated; }
        set { activated = value; }
    }

    public void Deactivate()
    {
        activated = false;
        CardListChooser.instance.Hide();
        VisualTool.SwitchAllControls(true);
    }
    

    public void Activate()
    {
        VisualTool.SwitchAllControls(false);
        GameLogicEvents.eventCardVisual.Invoke(this.GetComponent<OneCardManager>());
        activated = true;
        CardListChooser.instance.FillByCards(Game.instance.winningPile);
        CardListChooser.instance.Show();
        CardListChooser.instance.AddComponentToCards<OrpheusLyreActivatedTarget>();
        MessageManager.Instance.ShowMessage(LocalizationManager.Localize("chooseCardOrpheusLyre"),10);
        
    }


    public class OrpheusLyreActivatedTarget : MonoBehaviour,UnityEngine.EventSystems.IPointerDownHandler
    {
        private OneCardManager cm;

        private void Awake()
        {
            cm = GetComponent<OneCardManager>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
                ActivateOrpheusLyreCommand c=new ActivateOrpheusLyreCommand();
                c.target = cm;
                c.AddToQueue();
        }
    }
    
    
    
    private class  ActivateOrpheusLyreCommand:Command
    {
        public OneCardManager target;
        
        public override void StartCommandExecution()
        {

            GameManager.instance.StartCoroutine(ActivateOrpheusLyreCoroutine());
            
        }

        private IEnumerator ActivateOrpheusLyreCoroutine()
        {
            
            
            
            Visual.instance.disableInput(true);
            float timeMovement = Const.mediumCardTimeMovement;
            OneCardManager orpheusLyreCM =
                Visual.instance.GetOneCardManagerByName(Const.orpheuslyre, Visual.instance.TreasureHand.transform);
            
            VisualTool.MoveCardToAnotherParent(target.gameObject,Visual.instance.CardPointDiscard.transform,timeMovement);
            VisualTool.MoveCardToAnotherParent(orpheusLyreCM.gameObject,Visual.instance.CardPointDiscard.transform,timeMovement);
            yield return Const.mediumCardTimeMovement + EndTurn.SmallAmountOfTime;
            CardListChooser.instance.Hide();
            VisualTool.SwitchAllControls(true);
            Visual.instance.disableInput(false);
            Command.CommandExecutionComplete();
        }
    }
    
    
}
