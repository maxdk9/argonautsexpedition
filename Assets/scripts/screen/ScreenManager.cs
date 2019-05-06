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

        private ScreenType currentType;
        
        
        private void InitializeManager()
        {

            MainMenuCanvas = GameObject.Find("MainMenuCanvas").GetComponent<Canvas>();
            OptionsCanvas = GameObject.Find("OptionsCanvas").GetComponent<Canvas>();
            CreditsCanvas = GameObject.Find("CreditsCanvas").GetComponent<Canvas>();
            DeckgameCanvas = GameObject.Find("DeckgameCanvas").GetComponent<Canvas>();
            RollDiceCanvas = GameObject.Find("RollDiceCanvas").GetComponent<Canvas>();
            
            
            screens.Add(ScreenType.Deckgame,DeckgameCanvas);  
            screens.Add(ScreenType.Credits,CreditsCanvas);

            screens.Add(ScreenType.Options,OptionsCanvas);  
            screens.Add(ScreenType.Mainmenu,MainMenuCanvas);
            screens.Add(ScreenType.Rolldice,RollDiceCanvas);
            
        }


        private static Dictionary<ScreenType, Canvas> screens=new Dictionary<ScreenType, Canvas>();
        
        public enum  ScreenType
        {
            Deckgame,
            Options,
            Credits,
            Rolldice,
            Mainmenu
        }


        public void Show(ScreenType screenType)
        {
            foreach (KeyValuePair<ScreenType,Canvas> keyvalue in screens)
            {
                if (keyvalue.Key == screenType)
                {
                    keyvalue.Value.gameObject.SetActive(true);
                    currentType = screenType;
                }
                else
                {
                    keyvalue.Value.gameObject.SetActive(false);
                }
            }
        }



        public ScreenType CurrentType()
        {
            return currentType;
        }
    }
}