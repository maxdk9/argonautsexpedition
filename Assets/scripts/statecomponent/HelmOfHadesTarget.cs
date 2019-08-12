
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

public class HelmOfHadesTarget :tempTouchComponent,UnityEngine.EventSystems.IPointerDownHandler
{
        private OneCardManager cardManager;
        public void OnPointerDown(PointerEventData eventData)
        {
            
            GameManager.instance.RemoveTouchComponentsExceptSelf(cardManager,this);
            ActivateHelmOfHadesTarget t=new ActivateHelmOfHadesTarget();
            t.target = cardManager;
            t.AddToQueue();
        }
    
    
    private class  ActivateHelmOfHadesTarget:Command
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
            HelmOfHadesTarget targetcomponent = target.GetComponent<HelmOfHadesTarget>();

            HelmOfHadesTarget[] targetsarray = GameObject.FindObjectsOfType<HelmOfHadesTarget>();
            foreach (var VARIABLE in targetsarray)
            {
                if (VARIABLE != targetcomponent)
                {
                    GameObject.DestroyImmediate(VARIABLE);
                }
            }
            
            
            

             
            
            HelmOfHadesActivated[] arractivated = GameObject.FindObjectsOfType<HelmOfHadesActivated>();
            HelmOfHadesActivated activated = arractivated[0];
            OneCardManager helmcm= activated.GetComponent<OneCardManager>();
            EndTurn.DiscardCard(helmcm,true);
            
            

            EndTurn.DiscardCard(target,false);
            GameLogicEvents.eventUpdateCurrentEncounter.Invoke();
            GameLogicEvents.eventUpdateLossCounter.Invoke();

            yield return Const.mediumCardTimeMovement + EndTurn.SmallAmountOfTime;

            GameManager.instance.turnButtons(true);
            GameManager.instance.turnTempTouchComponents(true);
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
        GameManager.instance.turnButtons(false);
        GameManager.instance.turnTempTouchComponents(false);
            List<OneCardManager> enclist = Visual.instance.GetCurrentEncounter();
            foreach (OneCardManager cm in enclist)
            {
                if ( cm.cardAsset.type == CardType.monster)
                {
                    cm.gameObject.AddComponent<HelmOfHadesTarget>();
                }
            }
        
        MessageManager.Instance.ShowMessage(LocalizationManager.Localize("choosemonstertoignoredeadliness"),2);
    }

    public static void DeactivateTargets()
    {
        HelmOfHadesTarget[] comparray = GameObject.FindObjectsOfType<HelmOfHadesTarget>();
        foreach (var VARIABLE in comparray)
        {
            GameObject.DestroyImmediate(VARIABLE);            
        }
        GameManager.instance.turnButtons(true);
        GameManager.instance.turnTempTouchComponents(true);
        MessageManager.Instance.Hide();
    }
}
