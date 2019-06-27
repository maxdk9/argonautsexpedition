using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class GameLogicEvents
    {
        
        


        public static void SubscribeEvents()
        {
        
            
        }
        
        
        
        
        
        public static void CopyGameActorsToCurrentGame()
        {
            
        }



        public static int GetDeployedCrew()
        {
            OneCardManager[] cards = Visual.instance.CurrentEncounter.GetComponentsInChildren<OneCardManager>();

            int deployedCrew = 0;
            foreach (OneCardManager card in cards)
            {
                if (card.PreviewManager == null)
                {
                    continue;
                }
                deployedCrew += card.cardAsset.crewNumber;
            }

            return deployedCrew;
        }
        public static void DeployCrew()
        {
            int deployedCrew = GetDeployedCrew();
            Game.instance.DeployedCrew = deployedCrew;
            Visual.instance.UpdateCrewCounter();
        }

       
        
        
    }
}