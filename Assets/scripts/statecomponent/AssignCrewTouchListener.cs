
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

public class AssignCrewTouchListener :StateComponent,UnityEngine.EventSystems.IPointerDownHandler
    {
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OneCardManager c=this.GetComponent<OneCardManager>();
            CrewAssigner.instance.Show(c);      
        }

       
        
        
    }
