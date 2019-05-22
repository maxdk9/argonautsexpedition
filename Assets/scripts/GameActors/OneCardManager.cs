using UnityEngine;
using System.Collections;
using Assets.SimpleLocalization;
using common;
using Model;
using TMPro;
using UnityEngine.UI;

// holds the refs to all the Text, Images on the card
public class OneCardManager : MonoBehaviour {

    public CardManager.Card cardAsset;
    public OneCardManager PreviewManager;
    [Header("Text Component References")]
    public TextMeshProUGUI NameLabel;
    public TextMeshProUGUI DifficultyLabel;
    public TextMeshProUGUI DeadlinessLabel;
    public TextMeshProUGUI DescriptionLabel;
    
    [Header ("GameObject References")]
    public GameObject DifficultyImage;
    public GameObject DeadlinessImage;
    [Header("Image References")]
    public Image CardBackground;
    public Image CardImage;
    public Image CardFrame;
    
    public Image CardFaceGlowImage;
    public Image CardBackGlowImage;

    void Awake()
    {
        if (cardAsset != null)
            ReadCardFromAsset();
    }

    private bool canBePlayedNow = false;
    public bool CanBePlayedNow
    {
        get
        {
            return canBePlayedNow;
        }

        set
        {
            canBePlayedNow = value;

           // CardFaceGlowImage.enabled = value;
        }
    }

    public void ReadCardFromAsset()
    {
      
        // 2) add card name
        NameLabel.text = cardAsset.name;
        // 3) add mana cost
        DescriptionLabel.text = LocalizationManager.Localize(cardAsset.name + Const.carddescr);
        DeadlinessLabel.text = cardAsset.deadliness[cardAsset.level].ToString();
        DifficultyLabel.text = cardAsset.difficulty[cardAsset.level].ToString();
        
        string frontpath = "cards/" + cardAsset.name;
        
        CardImage.sprite= Resources.Load<Sprite>(frontpath);
        
      

        if (PreviewManager != null)
        {
            // this is a card and not a preview
            // Preview GameObject will have OneCardManager as well, but PreviewManager should be null there
            PreviewManager.cardAsset = cardAsset;
            PreviewManager.ReadCardFromAsset();
        }
    }
}
