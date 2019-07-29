using System.Collections;
using System.Collections.Generic;
using Model;
using tools;
using UnityEngine;

public class PrepareCardForNewGame : Command {
    
    
    public override void StartCommandExecution()
    {
        GameManager.instance.StartCoroutine(PrepareCardForNewGameCoroutine());
    }

    
    
    
    private IEnumerator PrepareCardForNewGameCoroutine()
    {
        
        TestTools.DeckCorrection();
        new WaitForSeconds(.01f);
        foreach (CardManager.Card card in Game.instance.currentDeck)
        {
            GameObject cardPoint = Visual.instance.CardPointOutside;    
            GameObject cardObject =  OneCardManager.CreateOneCardManager(card, cardPoint);
        }
        yield return new WaitForSeconds(.01f);
        Command.CommandExecutionComplete();
    }
    
    
    
    
}
