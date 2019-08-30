
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using command;
    using DG.Tweening;
    using GameActors;
    using JetBrains.Annotations;
    using Model;
    using UnityEngine;
   using UnityEngine.EventSystems;

public class AegisOfZeusActivated :tempTouchComponent,UnityEngine.EventSystems.IPointerDownHandler
{
        private OneCardManager cardManager;
        
    
    
        public void OnPointerDown(PointerEventData eventData)
        {


                AegisOfZeusTarget.DeactivateTargets();
                VisualTool.SwitchAllControls(true);
                List<OneCardManager> enclist = Visual.instance.GetCurrentEncounter();
                this.enabled = false;
                HighlightCardManager();
        
        }

    private void HighlightCardManager()
    {
        cardManager.Highlighted = this.enabled;

    }

    private void Awake()
    {
        cardManager=this.GetComponent<OneCardManager>();
        enabled = false;
    }


    private void OnDestroy()
    {
        cardManager.Highlighted = false;
    }

    private void OnEnable()
    {
        HighlightCardManager();
    }

    public void Activate()
    {
        enabled = true;
        HighlightCardManager();
        AegisOfZeusTarget.ActivateTargets();
    }
}
