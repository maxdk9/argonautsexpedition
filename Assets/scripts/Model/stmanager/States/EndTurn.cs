using System.Collections;
using System.Collections.Generic;
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
                if (Game.instance.Casualties > 0)
                {
                    Vector2 pos = Visual.instance.LossCounter.transform.localPosition;
                    DamageEffect.CreateDamageEffect(pos,Game.instance.Casualties);    
                }
                

                List<OneCardManager> curEnc = Visual.instance.GetCurrentEncounter();
                
                foreach(OneCardManager cm in curEnc)
                {
                    yield return new WaitForSeconds(EndTurn.SmallAmountOfTime);
                    DiscardCard(cm);
                    
                }
                yield return new WaitForSeconds(TimeMovement1  + DelayTime);
                Debug.Log("CommandDoCasualties");
                GameLogicModifyGame.DoCasualties();
                GameLogicEvents.eventUpdateLossCounter.Invoke();
                GameLogicEvents.eventUpdateCrewCounter.Invoke();
                Command.CommandExecutionComplete();
            }
        }
        
        
        
   
        public static void DiscardCard(OneCardManager card)
        {                
            card.transform.SetParent(null);

            Sequence sequence = DOTween.Sequence();
            sequence.Append(card.transform.DOLocalMove(Visual.instance.CardPointOutside.transform.position, TimeMovement1));
            sequence.Insert(0f, card.transform.DORotate(new Vector3(0f, 179f, 0f), TimeMovement1*.5f));
            sequence.OnComplete(() => { card.transform.SetParent(Visual.instance.CardPointOutside.transform); });
            sequence.Play();
                
        }
        
        
    }
    
   
}