using Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameActors
{
    public class CardActor :MonoBehaviour
    {
        public CardManager.Card card;
        public Image cardbackground;
        public Image cardimage;
        
        
        public Image deadlinessImage;
        public Image difficultyImage;
        public Image treasureTypeImage;
        
        public TextMeshProUGUI nameLabel;
        public TextMeshProUGUI deadlinessLabel;
        public TextMeshProUGUI difficultyLabel;
        public TextMeshProUGUI descriptionLabel;
        




    }
}