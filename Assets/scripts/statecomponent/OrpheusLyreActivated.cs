
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

public class OrpheusLyreActivated :tempTouchComponent
{
   private OneCardManager cardManager;

   private bool activated = false;
   public bool isActivated { get; set; }


   

    private void HighlightCardManager()
    {
        cardManager.Highlighted = this.isActivated;

    }

    private void Awake()
    {
        cardManager=this.GetComponent<OneCardManager>();
        activated = false;
    }


    private void OnDestroy()
    {
        cardManager.Highlighted = false;
    }

    public void DeActivate()
    {
        isActivated = false;
        HighlightCardManager();
        
    }
    

    public void Activate()
    {
        isActivated = true;
        HighlightCardManager();
        
    }
}
