using System.Collections;
using System.Collections.Generic;
using common;
using DG.Tweening;
using screen;
using UnityEngine;

namespace Model.States
{
    public class EndTurn:iState
    {
        
        
        public static float TimeMovement1 = 1.6f;
        public static float SmallAmountOfTime = .05f;
        public static float DelayTime = .3f;
        
        public static EndTurn ourInstance=new EndTurn();
        
        public void Execute(double time)
        {
               
        }

        public void OnEnter()
        {
            Debug.Log("EndTurn");
            ScreenManager.instance.Show(ScreenManager.ScreenType.Deckgame);
            Visual.instance.EffectGroup.SetActive(true);
            new CommandDoCasualties().AddToQueue(); 
            new GoToNextGamePhase(GamePhase.StartNewTurn).AddToQueue();
        }

        public void OnExit()
        {
            
        }

        public class CommandDoCasualties : Command
        {   
            public override void StartCommandExecution()
            {
                GameManager.instance.StartCoroutine(DoCasualtiesCoroutine());
            }

            private IEnumerator DoCasualtiesCoroutine()
            {
                yield return  new WaitForSeconds(.2f);
                
                GameLogicEvents.eventRemoveSingleEffects.Invoke();
                if (Game.instance.Casualties > 0)
                {
                    Vector2 pos = Visual.instance.LossCounter.transform.localPosition;
                    DamageEffect.CreateDamageEffect(pos,Game.instance.Casualties);    
                }
                

                List<OneCardManager> curEnc = Visual.instance.GetCurrentEncounter();
                
                foreach(OneCardManager cm in curEnc)
                {
                    yield return new WaitForSeconds(EndTurn.SmallAmountOfTime);

                    bool isResolved = cm.cardAsset.resolved == ResolvedType.resolved_win;
                    if (isResolved)
                    {
                        VisualTool.DiscardCardToWinningPile(cm);    
                    }
                    else
                    {
                        VisualTool.DiscardCardToDiscardPile(cm);
                    }
                    
                }
                yield return new WaitForSeconds(TimeMovement1  + DelayTime);
                Debug.Log("CommandDoCasualties");
                GameLogicModifyGame.DoCasualties();
                GameLogicEvents.eventUpdateLossCounter.Invoke();
                GameLogicEvents.eventUpdateCrewCounter.Invoke();
                Command.CommandExecutionComplete();
            }
        }
    }
    
   
}