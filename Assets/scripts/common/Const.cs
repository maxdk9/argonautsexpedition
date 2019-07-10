using UnityEngine;

namespace common
{
    public class Const
    {
        
        
        
        public static  string carddescr = "legend_";
        public static string cardsin="sin_";

        public static void CalculateSize()
        {
           
            RectTransform monsterRect=GameManager.instance.MonsterCardPrefab.transform.Find("CardBody").GetComponent<RectTransform>();
            OneCardManager.CardWidth = (int)monsterRect.rect.width;
            OneCardManager.CardHeight = (int) monsterRect.rect.height;
            OneCardManager.CardWidthWithoutGlow = OneCardManager.CardWidth - 50;
            OneCardManager.CardHeightWithoutGlow = OneCardManager.CardHeight-50;
            
        }
    }
}