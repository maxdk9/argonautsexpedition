
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

public class Draw3CardsTouchListener :tempTouchComponent,UnityEngine.EventSystems.IPointerDownHandler
    {
        
        public void OnPointerDown(PointerEventData eventData)
        {

           // OneCardManager c=this.GetComponent<OneCardManager>();
            Debug.Log("Draw3CardsTouchListener ");
            new Draw3CardsCommand().AddToQueue();
            new GoToNextGamePhase(GamePhase.CrewAssignment).AddToQueue();

            // GameManager.instance.StartCoroutine(this.Draw3Cards());   
        }

       
        
        
    }
