using UnityEngine;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using Assets.SimpleLocalization;
using common;
using DG.Tweening;
using Model;
using TMPro;
using UnityEngine.UI;

// holds the refs to all the Text, Images on the card
public class OneCardManager : DestroyableEntity
{


    public static int CardWidth = 360;
    public static int CardWidthWithoutGlow = CardWidth - 25;
    public static int CardHeight = 504;
    public static int CardHeightWithoutGlow = CardHeight-25;
    
    
    
    public CardManager.Card cardAsset;
    public OneCardManager PreviewManager;
    public bool isPreview;
    private bool m_highlighted = false;
    [Header("Text Component References")]
    public TextMeshProUGUI NameLabel;
    public TextMeshProUGUI DifficultyLabel;
    public TextMeshProUGUI DeadlinessLabel;
    public TextMeshProUGUI DescriptionLabel;
    public TextMeshProUGUI CrewLabel;
    
    [Header ("GameObject References")]
    public GameObject DifficultyImage;
    public GameObject DeadlinessImage;
    public GameObject uiDiceObject;
    
    
    [Header("Image References")]
    public Image CardBackground;
    public Image CardImage;
    public Image CardFrame;
    public Image UseTypeImage;
    
    public Image CardFaceGlowImage;
    public Image CardBackGlowImage;
    public Image CrewImage;


    private Sequence diceAnimationSequence;

    
    

  
    void Awake()
    {
        if (cardAsset != null)
        {
            
        }
            //ReadCardFromAsset();
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

        if (CrewLabel != null)
        {
            ShowResolve();
                
            
        }

        if (DeadlinessLabel != null)
        {
            DeadlinessLabel.text = GameLogic.GetDeadliness(cardAsset).ToString();    
        }

        if (DifficultyLabel != null)
        {
            DifficultyLabel.text = GameLogic.GetCurrentDifficulty(cardAsset).ToString();    
            
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
        
      
        SetVisibility();

        if (PreviewManager != null)
        {
            // this is a card and not a preview
            // Preview GameObject will have OneCardManager as well, but PreviewManager should be null there
            PreviewManager.cardAsset = cardAsset;
            PreviewManager.ReadCardFromAsset();
        }
    }

    
    
    
    public void SetVisibility()
    {
        if (uiDiceObject == null)
        {
            return;
        }

        if (cardAsset.resolved == ResolvedType.resolved_win||cardAsset.resolved==ResolvedType.resolved_lost)
        {
            uiDiceObject.SetActive(false);
            return;
        }
        
        uiDiceObject.SetActive(false);
        
        if (Game.instance.CurrentState == GamePhase.BattleView)
        {
            uiDiceObject.SetActive(true);
            CreateDiceAnimationSequence();

        }
        else
        {
            if (diceAnimationSequence != null)
            {
                diceAnimationSequence.Kill();
            }
            
            
        }
        
    }

    private void CreateDiceAnimationSequence()
    {
        if (diceAnimationSequence == null)
        {
            diceAnimationSequence= DOTween.Sequence();
            Vector3 startRotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            diceAnimationSequence.Append(uiDiceObject.transform.DORotate(startRotation,0 ).SetEase(Ease.InOutSine));
            diceAnimationSequence.Append(uiDiceObject.transform.DORotate(new Vector3(10,360,10),1 ).SetEase(Ease.InOutSine));            
            diceAnimationSequence.SetLoops(-1,LoopType.Yoyo);
        }
        diceAnimationSequence.Play();
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

        OneCardManager cardManager = cardObject.GetComponent<OneCardManager>();
        cardObject.tag = "Untagged";
        if (cardManager.PreviewManager != null)
        {
            cardManager.tag = "Untagged";
        }
        //GameObject cardObject = ScriptableObject.Instantiate(cardprefab, point.transform, false);
        cardObject.transform.localScale=Vector3.one;
        cardObject.transform.localPosition=new Vector3(0,0,Visual.instance.transform.position.y);
        //cardObject.transform.localPosition=new Vector3(0,0,0);
        
        //cardObject.transform.SetParent(null);
        cardObject.SetActive(true);
        
        cardManager.cardAsset = c;
        cardManager.ReadCardFromAsset();
        return cardObject;
    }

    private void Update()
    {
        if (cardAsset != null)
        {
            if (cardAsset.needToUpdate)
            {
                ReadCardFromAsset();
                cardAsset.needToUpdate = false;
            }
        }
    }


    public void ShowResolve()
    {
        
        CrewLabel.enabled = false;


        if (CrewImage != null)
        {


            if (cardAsset.resolved == ResolvedType.resolved_win)
            {
                CrewImage.sprite = Visual.instance.ThumbsUp;

            }

            if (cardAsset.resolved == ResolvedType.resolved_lost)
            {
                CrewImage.sprite = Visual.instance.ThumbsDown;
            }
        }

        if (cardAsset.resolved == ResolvedType.notresolved)
        {
            if (cardAsset.crewNumber > 0)
            {
                CrewLabel.enabled = true;
                CrewLabel.text = cardAsset.crewNumber.ToString();
            }
        }      
    }

    public void AnimateResolve()
    {
        if (cardAsset.resolved == ResolvedType.resolved_win||cardAsset.resolved==ResolvedType.resolved_lost)
        {
            if (CrewImage == null)
            {
                return;
            }
            Sequence sequence= DOTween.Sequence();
            
            sequence.Append(CrewImage.transform.DOBlendableMoveBy(new Vector3(0,2), .3f));
            
            sequence.Append(CrewImage.transform.DOBlendableMoveBy(new Vector3(0,-2), .3f));
            sequence.SetLoops(2);
            sequence.Play();
        }
    }
    
    
}
