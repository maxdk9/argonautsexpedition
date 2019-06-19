using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DraggingActionsTestReturn : DraggingActionsTest 
{
    private Vector3 savedPos;

    public override void OnStartDrag()
    {
        savedPos = transform.position;
    }

    public override void OnEndDrag()
    {
        transform.DOMove(savedPos, 1f).SetEase(Ease.OutQuint,.5f,.1f);//, 0.5f, 0.1f);   
        Debug.Log("onEndDrag");
    }

    public override void OnDraggingInUpdate(){}

    protected override bool DragSuccessful()
    {
        return true;
    }
}
