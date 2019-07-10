using System.Collections;
using System.Collections.Generic;
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
        }

        SameDistanceChildren distance=Visual.instance.CurrentEncounter.GetComponent<SameDistanceChildren>();
        
        foreach (CardManager.Card card in Game.instance.currentEncounter)
        {
            int index = Game.instance.currentEncounter.IndexOf(card);
            GameObject slot = distance.slots[index];
            GameObject cardObject =  OneCardManager.CreateOneCardManager(card, slot);
        }
        
        yield return new WaitForSeconds(.01f);
        Command.CommandExecutionComplete();
    }
    
}
