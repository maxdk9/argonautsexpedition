using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CrewItem:MonoBehaviour,IPointerDownHandler
{
    public int crewNumber;
    private Image image;

    private void Awake()
    {
        image = this.GetComponent<Image>();
        
    }


    public void SetImageColor(Color color)
    {
        image.color = color;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CrewAssigner.instance.Target.cardAsset.crewNumber = crewNumber;
        
        CrewAssigner.crewDeployed.Invoke();
    }
}
