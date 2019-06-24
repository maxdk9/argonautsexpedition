using UnityEngine;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using Assets.SimpleLocalization;
using common;
using Model;
using TMPro;
using UnityEngine.UI;

// holds the refs to all the Text, Images on the card
public class OneCardManager : DestroyableEntity
{


    public static int CardWidth = 360;
    public static int CardHeight = 504;
    
    
    
    public CardManager.Card cardAsset;
    public OneCardManager PreviewManager;
    private bool m_highlighted = false;
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
    public Image UseTypeImage;
    
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

    public bool Highlighted
    {
        get { return m_highlighted; }
        set
        {
            m_highlighted = value;
            if (CardFaceGlowImage != null){
                CardFaceGlowImage.gameObject.SetActive(m_highlighted);
            }
        }
    }

    public void ReadCardFromAsset()
    {
      
        // 2) add card name
        NameLabel.text = LocalizationManager.Localize(Const.cardsin+cardAsset.name);
        // 3) add mana cost
        if (DescriptionLabel != null)
        {

            if (cardAsset.type == CardType.blessing || cardAsset.type == CardType.wrath)
            {
                DescriptionLabel.text = LocalizationManager.Localize( Const.cardsin+cardAsset.type.ToString());
            }
            else
            {
                DescriptionLabel.text = LocalizationManager.Localize( Const.carddescr+cardAsset.name);    
            }
                
        }

        if (DeadlinessLabel != null)
        {
            DeadlinessLabel.text = cardAsset.deadliness[cardAsset.level].ToString();    
        }

        if (DifficultyLabel != null)
        {
            DifficultyLabel.text = cardAsset.difficulty[cardAsset.level].ToString();    
        }

        if (UseTypeImage != null)
        {
            string usetTypePath = "tools/" + cardAsset.useType.ToString();
            UseTypeImage.sprite = Resources.Load<Sprite>(usetTypePath);
        }
        
        if (CardFaceGlowImage != null){
            CardFaceGlowImage.gameObject.SetActive(m_highlighted);
        }
        
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

    public static GameObject GetCardPrefab(CardManager.Card c)
    {
        if (c.type == CardType.monster)
        {
            return GameManager.instance.MonsterCardPrefab;
        }

        if (c.type == CardType.treasure)
        {
            return GameManager.instance.ItemCardPrefab;
            
        }

        if (c.type == CardType.blessing || c.type == CardType.wrath)
        {
            return GameManager.instance.BlessingCardPrefab;
        }
        
        
        return GameManager.instance.MonsterCardPrefab;
    }


    public static GameObject CreateOneCardManager(CardManager.Card c,GameObject point)
    {
        GameObject cardprefab = OneCardManager.GetCardPrefab(c);
        GameObject cardObject = GameObject.Instantiate(cardprefab,point.transform,false);

        //GameObject cardObject = ScriptableObject.Instantiate(cardprefab, point.transform, false);
        cardObject.transform.localScale=Vector3.one;
        cardObject.transform.localPosition=new Vector3(0,0,Visual.instance.transform.position.y);
        //cardObject.transform.localPosition=new Vector3(0,0,0);
        
        //cardObject.transform.SetParent(null);
        cardObject.SetActive(true);
        OneCardManager cardManager = cardObject.GetComponent<OneCardManager>();
        cardManager.cardAsset = c;
        cardManager.ReadCardFromAsset();
        return cardObject;
    }

    private void Update()
    {
        
    }
}
