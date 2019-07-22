using System;
using Assets.SimpleLocalization;
using Model;
using UnityEngine;
using UnityEngine.EventSystems;


public class Tooltipable:MonoBehaviour,UnityEngine.EventSystems.IPointerDownHandler
{
    public String tooltipKey;
    public static string ttip_typetreasure = "ttip_typetreasure";
    public static string ttip_typesingleuse = "ttip_typesingleuse";
    public static string ttip_typecontinuous = "ttip_typecontinuous";
    
     public void OnPointerDown(PointerEventData eventData)
    {

        if (tooltipKey.Equals(ttip_typetreasure))
        {
            OneCardManager cardManager = this.GetComponentInParent<OneCardManager>();
            
            if (cardManager.cardAsset.useType == UseType.continuous)
            {
                tooltipKey = ttip_typecontinuous;
            }
            else
            {
                tooltipKey = ttip_typesingleuse;
            }
        }
        Tooltip.instance.ShowTooltip(LocalizationManager.Localize(tooltipKey),eventData.position);
    }
}
