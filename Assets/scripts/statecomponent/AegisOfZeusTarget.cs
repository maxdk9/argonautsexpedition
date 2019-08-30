
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
    using UnityEngine;
   using UnityEngine.EventSystems;

public class AegisOfZeusTarget :tempTouchComponent,UnityEngine.EventSystems.IPointerDownHandler
{
        private OneCardManager cardManager;
        public void OnPointerDown(PointerEventData eventData)
        {
            ActivateAegisOfZeusTarget t=new ActivateAegisOfZeusTarget();
            t.target = cardManager;
            t.AddToQueue();
        }
    
    
    private class  ActivateAegisOfZeusTarget:Command
    {
        public OneCardManager target;
        
        public override void StartCommandExecution()
        {

            GameManager.instance.StartCoroutine(ActivateAegisOfZeusCoroutine());
            
        }

        private IEnumerator ActivateAegisOfZeusCoroutine()
        {
            
            
            
            Visual.instance.disableInput(true);
            float timeMovement = Const.mediumCardTimeMovement;
            AegisOfZeusTarget targetcomponent = target.GetComponent<AegisOfZeusTarget>();

            AegisOfZeusTarget[] targetsarray = GameObject.FindObjectsOfType<AegisOfZeusTarget>();
            foreach (var VARIABLE in targetsarray)
            {
                if (VARIABLE != targetcomponent)
                {
                    GameObject.DestroyImmediate(VARIABLE);
                }
            }
            
            AegisOfZeusActivated[] arractivated = GameObject.FindObjectsOfType<AegisOfZeusActivated>();
            AegisOfZeusActivated activated = arractivated[0];
            OneCardManager aegis = activated.GetComponent<OneCardManager>();
            EndTurn.DiscardCard(aegis,true);

            GameLogicModifyGame.SetIgnoreDeadliness(target.cardAsset);
            GameLogicEvents.eventUpdateCurrentEncounter.Invoke();
            GameLogicEvents.eventUpdateLossCounter.Invoke();

            yield return Const.mediumCardTimeMovement + EndTurn.SmallAmountOfTime;

            VisualTool.SwitchAllControls(true);
            Visual.instance.disableInput(false);
            Command.CommandExecutionComplete();
        }
    }

    private void Awake()
    {
            cardManager=this.GetComponent<OneCardManager>();
            enabled = true;
        }

    private void OnEnable()
    {
        cardManager.Highlighted = enabled;
    }


    private void OnDestroy()
    {
        cardManager.Highlighted = false;
    }

    public static void ActivateTargets()
    {
        
        
        VisualTool.SwitchAllControls(false);
        
            List<OneCardManager> enclist = Visual.instance.GetCurrentEncounter();
            foreach (OneCardManager cm in enclist)
            {
                if (cm.cardAsset.resolved == ResolvedType.resolved_lost && cm.cardAsset.type == CardType.monster)
                {
                    cm.gameObject.AddComponent<AegisOfZeusTarget>();
                }
            }
        
        
        MessageManager.Instance.ShowMessage(LocalizationManager.Localize("choosemonstertoignoredeadliness"),2);
    }

    public static void DeactivateTargets()
    {
        AegisOfZeusTarget[] comparray = GameObject.FindObjectsOfType<AegisOfZeusTarget>();
        foreach (var VARIABLE in comparray)
        {
            GameObject.DestroyImmediate(VARIABLE);            
        }
        VisualTool.SwitchAllControls(true);
        MessageManager.Instance.Hide();
    }
}
