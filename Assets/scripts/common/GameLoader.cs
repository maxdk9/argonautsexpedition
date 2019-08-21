using screen;
using UnityEngine;

namespace common
{
    public class GameLoader : MonoBehaviour
    {
        public GameManager gameManager;
        public ScreenManager screenManager;
        

        private void Awake()
        {
            if (ScreenManager.instance == null)
            {
                Instantiate(screenManager);
            }
            
            
            if (GameManager.instance == null)
            {
                Instantiate(gameManager);
            }

            
        }
        
        
        
        
    }
    
}