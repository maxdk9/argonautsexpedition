using System.Collections.Generic;
using UnityEngine;

namespace screen
{
    public class ScreenManager :MonoBehaviour
    {
        
        public static ScreenManager instance = null; // Экземпляр объекта

	
        void Start () {
            if (instance == null) { 
                instance = this;  
            } else if(instance == this){ 
                Destroy(gameObject); 
            }
            DontDestroyOnLoad(gameObject);
            InitializeManager();
        }
        
        public Canvas MainMenuCanvas;
        public Canvas OptionsCanvas;
        public Canvas CreditsCanvas;
        public Canvas DeckgameCanvas;
        public Canvas RollDiceCanvas;
        public Canvas TestCanvas;
        public Canvas BackgroundCanvas;
        private ScreenType currentType;
        
        
        private void InitializeManager()
        {
            MainMenuCanvas = GameObject.Find("MainMenuCanvas").GetComponent<Canvas>();
            OptionsCanvas = GameObject.Find("OptionsCanvas").GetComponent<Canvas>();
            CreditsCanvas = GameObject.Find("CreditsCanvas").GetComponent<Canvas>();
            DeckgameCanvas = GameObject.Find("DeckgameCanvas").GetComponent<Canvas>();
            RollDiceCanvas = GameObject.Find("RollDiceCanvas").GetComponent<Canvas>();
            BackgroundCanvas = GameObject.Find("BackgroundCanvas").GetComponent<Canvas>();
            TestCanvas = GameObject.Find("TestCanvas").GetComponent<Canvas>();
            
            screens.Add(ScreenType.Deckgame,DeckgameCanvas);  
            screens.Add(ScreenType.Credits,CreditsCanvas);
            screens.Add(ScreenType.Options,OptionsCanvas);  
            screens.Add(ScreenType.Mainmenu,MainMenuCanvas);
            screens.Add(ScreenType.Rolldice,RollDiceCanvas);
            screens.Add(ScreenType.Testscreen,TestCanvas);
            
        }


        private static Dictionary<ScreenType, Canvas> screens=new Dictionary<ScreenType, Canvas>();
        
        public enum  ScreenType
        {
            Deckgame,
            Options,
            Credits,
            Rolldice,
            Mainmenu,
            Testscreen
        }


        public void Show(ScreenType screenType)
        {
            
            foreach (KeyValuePair<ScreenType,Canvas> keyvalue in screens)
            {
                if (keyvalue.Key == screenType)
                {

                    TurnOnCanvas(keyvalue.Value,true);
                    
                    
                    currentType = screenType;
                    
                }
                else
                {
                    TurnOnCanvas(keyvalue.Value,false);
                    
                }   
            }
            currentType = screenType;
            ShowVisualObjects();
      
        }

        private void TurnOnCanvas(Canvas canvas, bool enabled)
        {
            canvas.enabled=enabled;
            canvas.gameObject.SetActive(enabled);
        }


        private void ShowVisualObjects()
        {
            Visual.instance.gameObject.SetActive(currentType==ScreenType.Deckgame);            
        }


        public ScreenType CurrentType()
        {
            return currentType;
        }


        public Canvas GetCurrentMainCanvas()
        {
            foreach (KeyValuePair<ScreenType,Canvas> keyvalue in screens)
            {
                Canvas c = keyvalue.Value;
                if (c.gameObject.active)
                {
                    return c;
                }
            }

            return null;
        }
    }
}