using command;
using common;
using DG.Tweening;
using GameActors;
using screen;
using UnityEngine;
using UnityEngine.UI;


public class VisualTool
{
    public static void SwitchAllControls(bool enable)
    {
        Tooltipable[] tooltipables = ScreenManager.instance.DeckgameCanvas.GetComponentsInChildren<Tooltipable>();
        foreach (var VARIABLE in tooltipables)
        {
            VARIABLE.enabled = enable;
        }

        tempTouchComponent[] tempTouchComponents =
            ScreenManager.instance.DeckgameCanvas.GetComponentsInChildren<tempTouchComponent>();
        foreach (var VARIABLE in tempTouchComponents)
        {
            VARIABLE.enabled = enable;
        }

        Button[] buttons =
            Visual.instance.GetComponentsInChildren<Button>();
        foreach (var VARIABLE in buttons)
        {
            VARIABLE.enabled = enable;
        }
    }


    public static void RemoveChildrensFromTransform(Transform transform)
    {

        while (transform.childCount>0)
        {
            GameObject.DestroyImmediate(transform.GetChild(0).gameObject);
        }
        
    }


    public static void SetAnchorPreset(RectTransform rectTransform)
    {
        rectTransform.anchorMin=new Vector2(.5f,.5f);
        rectTransform.anchorMax=new Vector2(.5f,.5f);
			
        rectTransform.pivot=new Vector2(.5f,.5f);
    }
    
    
    
    
    public static void MoveCardToAnotherParentNoSequence ( GameObject cardObject, Transform partyStack,float duration)
    {   
        cardObject.transform.SetParent(null);
        cardObject.transform.DOMove(partyStack.position, duration);            
        cardObject.transform.DORotate(new Vector3(0f, 179f, 0f), duration).onComplete= () =>
        {
            cardObject.transform.SetParent(partyStack);
                
        };
    }
    
    
    
    public static void MoveCardToAnotherParent ( GameObject card, Transform partyStack,float duration=0f,float delay=0f)
    {

        if (duration == 0f)
        {
            duration = Const.mediumCardTimeMovement;
        }
        card.transform.SetParent(null);
        Sequence sequence = DOTween.Sequence();
        sequence.SetDelay(delay);
        sequence.Append(card.transform.DOLocalMove(Visual.instance.CardPointOutside.transform.position, duration));
        sequence.Insert(delay, card.transform.DORotate(new Vector3(0f, 179f, 0f), duration*.5f));
        sequence.OnComplete(() => { card.transform.SetParent(partyStack); });
        sequence.Play();
    }

    

    public static void SimpleMoveCardToAnotherParent ( GameObject cardObject, Transform partyStack)
    {   
        cardObject.transform.SetParent(null);
        cardObject.transform.DOMove(partyStack.position, 0).onComplete= () =>
        {
            cardObject.transform.SetParent(partyStack);    
        };
    }

    
    
    public static void DiscardCardToDiscardPile(OneCardManager card,float delay=0f)
    {  
       GameObject destination =Visual.instance.CardPointDiscard;
       MoveCardToAnotherParent(card.gameObject,destination.transform,Const.mediumCardTimeMovement,0);    
    }
    
    public static void DiscardCardToWinningPile(OneCardManager card,float delay=0f)
    {   
        GameObject destination =Visual.instance.CardPointWinning ;
        MoveCardToAnotherParent(card.gameObject,destination.transform,Const.mediumCardTimeMovement,0);
    }
    
    
    
}