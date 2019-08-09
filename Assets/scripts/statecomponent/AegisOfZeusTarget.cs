
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

public class AegisOfZeusTarget :tempTouchComponent,UnityEngine.EventSystems.IPointerDownHandler
{
        private OneCardManager cardManager;
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        private void Start()
        {
            cardManager=this.GetComponent<OneCardManager>();
            enabled = true;
        }

    private void OnEnable()
    {
        cardManager.Highlighted = enabled;
    }
}
