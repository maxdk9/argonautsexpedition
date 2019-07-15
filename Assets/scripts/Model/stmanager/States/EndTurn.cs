using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using screen;
using UnityEngine;

namespace Model.States
{
    public class EndTurn:iState
    {
        public static EndTurn ourInstance=new EndTurn();
        
        public void Execute(double time)
        {
               
        }

        public void OnEnter()
        {
            Debug.Log("EndTurn");
            ScreenManager.instance.Show(ScreenManager.ScreenType.Deckgame);
            if (Game.instance.Casualties > 0)
            {
                new CommandDoCasualties().StartCommandExecution();
               // new GoToNextGamePhase(GamePhase.StartNewTurn);
            }
        }

        public void OnExit()
        {
            
        }

        public class CommandDoCasualties : Command
        {
            
            float TimeMovement1 = 1.6f;
            
            float SmallAmountOfTime = .05f;
            float DelayTime = .3f;
            
            
            public override void StartCommandExecution()
            {
                GameManager.instance.StartCoroutine(DoCasualtiesCoroutine());
            }

            private IEnumerator DoCasualtiesCoroutine()
            {
                yield return  new WaitForSeconds(.2f);
                Vector2 pos = Visual.instance.LossCounter.transform.localPosition;
                DamageEffect.CreateDamageEffect(pos,Game.instance.Casualties);

                List<OneCardManager> curEnc = Visual.instance.GetCurrentEncounter();
                
                foreach(OneCardManager cm in curEnc)
                {
                    yield return new WaitForSeconds(SmallAmountOfTime);
                    DiscardCardManager(cm);
                    
                }
                yield return new WaitForSeconds(TimeMovement1  + DelayTime);
                
                GameLogicModifyGame.DoCasualties();
                GameLogicEvents.eventUpdateLossCounter.Invoke();
                GameLogicEvents.eventUpdateCrewCounter.Invoke();
                Command.CommandExecutionComplete();
            }

            private void DiscardCardManager(OneCardManager card)
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
}