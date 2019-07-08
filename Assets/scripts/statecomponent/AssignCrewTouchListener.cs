
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

public class AssignCrewTouchListener :tempTouchComponent,UnityEngine.EventSystems.IPointerDownHandler
    {
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OneCardManager c=this.GetComponent<OneCardManager>();
            if (c != CrewAssigner.instance.Target)
            {
                CrewAssigner.instance.Hide();
                CrewAssigner.instance.Show(c);
                
            }
            else
            {
                if (CrewAssigner.instance.gameObject.active)
                {
                    CrewAssigner.instance.Hide();
                }
                else
                {
            
                    CrewAssigner.instance.Show(c);    
                }    
            }
            
                  
        }

       
        
        
    }
