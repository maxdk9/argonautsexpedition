
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

public class ResolveCardByDiceRoll :tempTouchComponent,UnityEngine.EventSystems.IPointerDownHandler
    {
        
        public void OnPointerDown(PointerEventData eventData)
        {
            
            
            

           // OneCardManager c=this.GetComponent<OneCardManager>();
            Debug.Log("ResolveCardByDiceRoll ");
            OneCardManager c = this.GetComponent<OneCardManager>();

            if (c.cardAsset.resolved == ResolvedType.resolved_lost |
                c.cardAsset.resolved == ResolvedType.resolved_win)
            {
                return;
            }

            if (c.cardAsset.type == CardType.wrath)
            {
                return;
            }

            if (c.cardAsset.type == CardType.blessing)
            {
                return;
            }

            Game.instance.CurrentEnemyIndex = c.cardAsset.cardnumber;
            if (c.cardAsset.rollResult > 0)
            {
                new GoToNextGamePhase(GamePhase.BattleEnd).AddToQueue();
            }
            else
            {
                new GoToNextGamePhase(GamePhase.Battle).AddToQueue();
            }
            
            
            // GameManager.instance.StartCoroutine(this.Draw3Cards());   
        }

       
        
        
    }
