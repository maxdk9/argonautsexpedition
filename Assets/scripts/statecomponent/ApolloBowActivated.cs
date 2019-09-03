
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

public class ApolloBowActivated:MonoBehaviour
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
        DeactivateTargets();
        
    }
    

    public void Activate()
    {
        VisualTool.SwitchAllControls(false);
        GameLogicEvents.eventCardVisual.Invoke(this.GetComponent<OneCardManager>());
        
        activated = true;
        ActivateTargets();
    }


    
    
    
    public class ApolloBowTarget:MonoBehaviour,IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
               Debug.Log("ApolloBowTargetActivated");
       }

        private void Awake()
        {
            this.GetComponent<OneCardManager>().Highlighted = true;
        }

        private void OnDestroy()
        {
            this.GetComponent<OneCardManager>().Highlighted = false;
        }
    }
    
    private class  CommandActivateApolloBowTarget:Command
    {
        public OneCardManager target;
        
        public override void StartCommandExecution()
        {

            GameManager.instance.StartCoroutine(ActivateApolloBowTargetCoroutine());
            
        }

        private IEnumerator ActivateApolloBowTargetCoroutine()
        {
            
            
            
            Visual.instance.disableInput(true);
            float timeMovement = Const.mediumCardTimeMovement;

            OneCardManager apolloBowCM = Visual.instance.GetOneCardManagerByName(Const.apollobow,Visual.instance.TreasureHand.transform);
            
            GameLogicModifyGame.ApolloBowEffect(target.cardAsset);
            target.ReadCardFromAsset();
            
            VisualTool.MoveCardToAnotherParent(apolloBowCM.gameObject,Visual.instance.CardPointWinning.transform,Const.mediumCardTimeMovement);
            
            yield return timeMovement + EndTurn.SmallAmountOfTime;

            VisualTool.SwitchAllControls(true);
            Visual.instance.disableInput(false);
            Command.CommandExecutionComplete();
        }
    }
    
    
    
    
    
    public static void ActivateTargets()
    {
        
        VisualTool.SwitchAllControls(false);
        
        List<OneCardManager> enclist = Visual.instance.GetCurrentEncounter();
        foreach (OneCardManager cm in enclist)
        {
            if (cm.cardAsset.resolved == ResolvedType.notresolved && (GameLogic.cardIsMonsterOrTreasure(cm.cardAsset)))
            {
                cm.gameObject.AddComponent<ApolloBowTarget>();
            }
        }
        
        MessageManager.Instance.ShowMessage(LocalizationManager.Localize("chooseapollobowtarget"),2);
    }

    public static void DeactivateTargets()
    {
        ApolloBowTarget[] comparray = GameObject.FindObjectsOfType<ApolloBowTarget>();
        foreach (var VARIABLE in comparray)
        {
            GameObject.DestroyImmediate(VARIABLE);            
        }
        VisualTool.SwitchAllControls(true);
        MessageManager.Instance.Hide();
    }
    
    
    
    
}
