﻿using UnityEngine;
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

    public void ReadCardFromAsset()
    {
      
        // 2) add card name
        NameLabel.text = LocalizationManager.Localize(Const.cardsin+cardAsset.name);
        // 3) add mana cost
        if (DescriptionLabel != null)
        {
            DescriptionLabel.text = LocalizationManager.Localize( Const.carddescr+cardAsset.name);    
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
        
        
        return GameManager.instance.MonsterCardPrefab;
    }
    
    
}
