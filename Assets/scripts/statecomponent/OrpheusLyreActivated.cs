
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using command;
    using DG.Tweening;
    using GameActors;
    using JetBrains.Annotations;
    using Model;
    using tools;
    using UnityEngine;
   using UnityEngine.EventSystems;

public class OrpheusLyreActivated:MonoBehaviour 
{

    private void Awake()
    {
   
    }


    private void OnDestroy()
    {

    }

   
    

    public void Activate()
    {
        CardListChooser.instance.FillByCards(Game.instance.winningPile);
        CardListChooser.instance.Show();
        CardListChooser.instance.AddComponentToCards<OrpheusLyreActivatedTarget>();
    }


    public class OrpheusLyreActivatedTarget : MonoBehaviour,UnityEngine.EventSystems.IPointerDownHandler
    {
        private OneCardManager cm;

        private void Awake()
        {
            cm = GetComponent<OneCardManager>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
                Debug.Log("OrpheusLyreActivatedTarget");
        }
    }
    
    
}
