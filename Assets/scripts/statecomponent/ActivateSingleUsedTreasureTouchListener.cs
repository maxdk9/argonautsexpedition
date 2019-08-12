
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using command;
    using DG.Tweening;
    using GameActors;
    using JetBrains.Annotations;
    using Model;
    using ui;
    using UnityEngine;
   using UnityEngine.EventSystems;

public class ActivateSingleUsedTreasureTouchListener:MonoBehaviour,UnityEngine.EventSystems.IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        OneCardManager oneCardManager = this.GetComponent<OneCardManager>();

        if (oneCardManager.cardAsset.effecttype == Effect.EffectType.AegisOfZeus_IgnoreDeadliness_single&&GameLogic.CanUseEffect(oneCardManager.cardAsset.effecttype))
        {
            oneCardManager.gameObject.AddComponent<AegisOfZeusActivated>();

            

        }
        else
        {
            DialogActivateSingleUsedTreasure.instance.activatedCard = oneCardManager;
            DialogActivateSingleUsedTreasure.instance.Show(eventData.position);    
        }
        
        
    }

    public static void AddComponentToCurrentHand()
    {
        List<OneCardManager> trCM = Visual.instance.GetCurrentTreasures();

        foreach (OneCardManager cm in trCM)
        {
            if (cm.cardAsset.useType == UseType.continuous)
            {
                continue;
            }
            if (cm.gameObject.GetComponent<ActivateSingleUsedTreasureTouchListener>() == null)
            {
                cm.gameObject.AddComponent<ActivateSingleUsedTreasureTouchListener>();
            }
        }
    }
    
    }
