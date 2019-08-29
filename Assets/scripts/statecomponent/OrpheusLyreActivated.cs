
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

    private bool activated;

    public bool Activated
    {
        get { return activated; }
        set { activated = value; }
    }




    public void Deactivate()
    {
        activated = false;
        CardListChooser.instance.Hide();
        VisualTool.SwitchAllControls(true);
    }
    

    public void Activate()
    {
        VisualTool.SwitchAllControls(false);
        activated = true;
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
