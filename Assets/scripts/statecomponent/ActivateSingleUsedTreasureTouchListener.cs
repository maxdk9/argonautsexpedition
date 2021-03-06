
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
            if (!component.isActivated)
            {
                GameLogicEvents.eventCardVisual.Invoke(oneCardManager);
                component.Activate();
            }
            else
            {
                component.DeActivate();
            }

            customActivation = true;
        };
        if (oneCardManager.cardAsset.effecttype == Effect.EffectType.ApolloBow_RollDice6_single&&GameLogic.CanUseEffect(oneCardManager.cardAsset.effecttype))
        {


            ApolloBowActivated component = oneCardManager.gameObject.GetComponent<ApolloBowActivated>();
            if (component.Activated)
            {
                component.Deactivate();
            }
            else
            {
                component.Activate();
            }
            
            customActivation = true;

        }
            
        
        
        if (oneCardManager.cardAsset.effecttype == Effect.EffectType.OrpheusLyre_StopLevelUpMonsterInVictoryPile_single&&GameLogic.CanUseEffect(oneCardManager.cardAsset.effecttype))
        {
            OrpheusLyreActivated component = oneCardManager.gameObject.GetComponent<OrpheusLyreActivated>();
            if (component.Activated)
            {
                component.Deactivate();
            }
            else
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
            if (cm.cardAsset.effecttype == Effect.EffectType.OrpheusLyre_StopLevelUpMonsterInVictoryPile_single)
            {
                cm.gameObject.AddComponent<OrpheusLyreActivated>().enabled = false;
            }
            
            if (cm.cardAsset.effecttype == Effect.EffectType.ApolloBow_RollDice6_single)
            {
                cm.gameObject.AddComponent<ApolloBowActivated>().enabled = false;
            }
            
            
        }
    }
    
    }
