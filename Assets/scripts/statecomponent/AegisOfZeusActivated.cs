
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
            
            GameManager.instance.turnButtons(true);
            GameManager.instance.turnTempTouchComponents(true);
            List<OneCardManager> enclist = Visual.instance.GetCurrentEncounter();

            AegisOfZeusTarget.DeactivateTargets();

        }

    private void Awake()
    {
        cardManager=this.GetComponent<OneCardManager>();
        enabled = true;
        AegisOfZeusTarget.ActivateTargets();
        
    }


    private void OnDestroy()
    {
        cardManager.Highlighted = false;
    }

    private void OnEnable()
    {
        cardManager.Highlighted = enabled;
    }
}
