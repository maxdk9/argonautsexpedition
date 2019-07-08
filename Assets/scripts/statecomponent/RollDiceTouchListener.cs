
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

public class RollDiceTouchListener :tempTouchComponent,UnityEngine.EventSystems.IPointerDownHandler
{
        public GameObject dice;
    private DisplayCurrentDiceValue _displayCurrentDiceValue;
    private ApplyForceInRandomDirection _applyForceInRandomDirection;
    public bool RollEnabled = false;


    public void OnPointerDown(PointerEventData eventData)
        {
            if (dice == null)
            {
                return;
            }

            if (!RollEnabled)
            {
                return;
            }
            
            
            _applyForceInRandomDirection = dice.GetComponent<ApplyForceInRandomDirection>();
            _applyForceInRandomDirection.Roll();
            RollEnabled = false;
        }


        
       
        
        
    }
