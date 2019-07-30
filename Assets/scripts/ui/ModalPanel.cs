using UnityEngine;

namespace ui
{
    public class ModalPanel:MonoBehaviour
    {
        public void Show()
        {
            Visual.instance.transparentModalWindow.SetActive(true);
        }

        public void Hide()
        {
            Visual.instance.transparentModalWindow.SetActive(false);
        }

        
    }
}