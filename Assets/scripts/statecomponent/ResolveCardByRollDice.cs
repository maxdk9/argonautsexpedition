
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

public class ResolveCardByDiceRoll :StateComponent,UnityEngine.EventSystems.IPointerDownHandler
    {
        
        public void OnPointerDown(PointerEventData eventData)
        {

           // OneCardManager c=this.GetComponent<OneCardManager>();
            Debug.Log("ResolveCardByDiceRoll ");
            OneCardManager c = this.GetComponent<OneCardManager>();
            Game.instance.DiceEncounterNumber = c.cardAsset.cardnumber;
            new GoToNextGamePhase(GamePhase.Battle).AddToQueue();
            
            // GameManager.instance.StartCoroutine(this.Draw3Cards());   
        }

       
        
        
    }
