using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Model;
using UnityEngine;

public class PrepareCardResumeGame : Command {
    
    
    public override void StartCommandExecution()
    {
        
        
        GameManager.instance.StartCoroutine(PrepareCardForNewGameCoroutine());
    }

    
    
    
    private IEnumerator PrepareCardForNewGameCoroutine()
    {
        foreach (CardManager.Card card in Game.instance.currentDeck)
        {    
            GameObject cardObject =  OneCardManager.CreateOneCardManager(card, Visual.instance.CardDeckFrame);
            cardObject.transform.DORotate(new Vector3(0f, 179f, 0f), 0);
        }
        
        

        SameDistanceChildren distance=Visual.instance.CurrentEncounter.GetComponent<SameDistanceChildren>();
        
        foreach (CardManager.Card card in Game.instance.currentEncounter)
        {
            int index = Game.instance.currentEncounter.IndexOf(card);
            GameObject slot = distance.slots[index];
            GameObject cardObject =  OneCardManager.CreateOneCardManager(card, slot);
        }
        
        SameDistanceChildren treasureHand=Visual.instance.TreasureHand.GetComponent<SameDistanceChildren>();
        
        foreach (CardManager.Card card in Game.instance.TreasureHand)
        {
            int index = Game.instance.TreasureHand.IndexOf(card);
            GameObject slot = treasureHand.slots[index];
            GameObject cardObject =  OneCardManager.CreateOneCardManager(card, slot);
        }

        foreach (Effect effect in Game.instance.CardEffects)
        {
            GameObject effectActorObject = EffectActor.CreateNewEffectActor(effect);
        }
        
        yield return new WaitForSeconds(.01f);
        GameLogicEvents.eventUpdateCurrentEncounter.Invoke();
        Command.CommandExecutionComplete();
    }
    
}
