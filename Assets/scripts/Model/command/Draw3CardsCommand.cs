using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

namespace command
{
    public class Draw3CardsCommand : Command
    {
        public override void StartCommandExecution()
        {
            GameManager.instance.StartCoroutine(Draw3CardsCoroutine());
        }


        private IEnumerator Draw3CardsCoroutine()
        {
            List<OneCardManager> drawlist = new List<OneCardManager>();
            OneCardManager[] deckcards = Visual.instance.CardDeckFrame.GetComponentsInChildren<OneCardManager>();
            SameDistanceChildren distance = Visual.instance.CurrentEncounter.GetComponent<SameDistanceChildren>();
            int drawCardNumber = 3;
            distance.CurrentEncounterSize = drawCardNumber;


            for (int i = 1; i <= drawCardNumber; i++)
            {
                if (deckcards.Length < i)
                {
                    break;
                }

                OneCardManager card = deckcards[deckcards.Length - (i)];
                drawlist.Add(card);
            }


            float TimeMovement1 = .6f;
            float TimeMovement2 = .4f;
            float SmallAmountOfTime = .05f;
            float DelayTime = .3f;


            foreach (OneCardManager card in drawlist)
            {
                card.transform.SetParent(null);

                Sequence sequence = DOTween.Sequence();
                sequence.Append(card.transform.DOMove(Visual.instance.CardPoint.transform.position, TimeMovement1));
                sequence.Insert(0f, card.transform.DORotate(Vector3.zero, TimeMovement1));
                sequence.AppendInterval(DelayTime);
                int index = drawlist.IndexOf(card);
                GameObject slot = distance.slots[index];

                sequence.Append(card.transform.DOLocalMove(slot.transform.position, TimeMovement2));
                sequence.OnComplete(() => MoveCardToCurrentEncounterGroup(card, slot.transform));

                sequence.Play();
                yield return new WaitForSeconds(DelayTime);
            }

            yield return new WaitForSeconds(TimeMovement1 + TimeMovement2 + DelayTime);
            
            Command.CommandExecutionComplete();
        }

        public void MoveCardToCurrentEncounterGroup([CanBeNull] OneCardManager card, Transform parent)
        {
            card.transform.SetParent(parent);
        }
    }
}