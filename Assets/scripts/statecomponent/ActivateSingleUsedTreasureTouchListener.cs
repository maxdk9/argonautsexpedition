
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

        bool customActivation = false;
        
        if (oneCardManager.cardAsset.effecttype == Effect.EffectType.AegisOfZeus_IgnoreDeadliness_single&&GameLogic.CanUseEffect(oneCardManager.cardAsset.effecttype))
        {
            AegisOfZeusActivated component = oneCardManager.gameObject.GetComponent<AegisOfZeusActivated>();
            if (!component.enabled)
            {
                component.Activate();
            }

            customActivation = true;
        };
        
        if (oneCardManager.cardAsset.effecttype == Effect.EffectType.HelmOfHades_MoveMonsterToDiscardPile_single&&GameLogic.CanUseEffect(oneCardManager.cardAsset.effecttype))
        {
            HelmOfHadesActivated component = oneCardManager.gameObject.GetComponent<HelmOfHadesActivated>();
            if (!component.enabled)
            {
                component.Activate();
            }

            customActivation = true;
        };
        
        
        if(!customActivation)
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

            if (cm.cardAsset.effecttype == Effect.EffectType.AegisOfZeus_IgnoreDeadliness_single)
            {
                cm.gameObject.AddComponent<AegisOfZeusActivated>().enabled = false;
            }
            
            if (cm.cardAsset.effecttype == Effect.EffectType.HelmOfHades_MoveMonsterToDiscardPile_single)
            {
                cm.gameObject.AddComponent<HelmOfHadesActivated>().enabled = false;
            }
            
        }
    }
    
    }
