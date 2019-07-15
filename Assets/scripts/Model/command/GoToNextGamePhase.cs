using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;

public class GoToNextGamePhase : Command
{

    private GamePhase newgamephase;


    public GoToNextGamePhase(GamePhase phase)
    {
        this.newgamephase = phase;
    }
    
    
    public override void StartCommandExecution()
    {
        GameManager.instance.StartCoroutine(GoToNextGamePhaseCoroutine());
    }

    
    
    
    private IEnumerator GoToNextGamePhaseCoroutine()
    {
        StateManager.getInstance().MoveNext(newgamephase);
        yield return new WaitForSeconds(.01f);
        Command.CommandExecutionComplete();
    }
    
}
