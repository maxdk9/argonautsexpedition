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
        
        foreach (CardManager.Card card in Game.instance.currentEncounter)
        {    
            GameObject cardObject =  OneCardManager.CreateOneCardManager(card, Visual.instance.CurrentEncounter);
        }
        
        yield return new WaitForSeconds(.01f);
        Command.CommandExecutionComplete();
    }
    
}
