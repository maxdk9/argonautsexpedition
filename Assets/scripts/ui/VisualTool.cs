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
    
    
}