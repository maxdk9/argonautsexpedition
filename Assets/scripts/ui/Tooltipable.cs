using System;
using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.EventSystems;


public class Tooltipable:MonoBehaviour,UnityEngine.EventSystems.IPointerDownHandler
{
    public String tooltipKey;
    
     public void OnPointerDown(PointerEventData eventData)
    {
        Tooltip.instance.ShowTooltip(LocalizationManager.Localize(tooltipKey));
    }
}
