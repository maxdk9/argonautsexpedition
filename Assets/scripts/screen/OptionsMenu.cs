using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SimpleLocalization;
using screen;
using tools;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

	public  Slider SfxSlider;
	public Slider MusicSlider;
	public Dropdown LanguageDropdown;
	
	private Dictionary<string, SystemLanguage> languagesDictionary=new Dictionary<string, SystemLanguage>();
	
	// Use this for initialization
	void Start ()
	{
		//SetLanaguagesDictionary();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Awake()
	{
		SetLanaguagesDictionary();
	}


	private void SetLanaguagesDictionary()
	{
		languagesDictionary.Clear();
		languagesDictionary.Add(LocalizationManager.Localize("Options.LanguageEnglish"),SystemLanguage.English);
		languagesDictionary.Add(LocalizationManager.Localize("Options.LanguageRussian"),SystemLanguage.Russian);
		
		List<string> keyList = new List<string>(languagesDictionary.Keys);
		LanguageDropdown.options.Clear();
		LanguageDropdown.AddOptions(keyList);		
		
		SfxSlider.value = Preferences.GetInstance().SfxVolume;
		MusicSlider.value = Preferences.GetInstance().MusicVolume;
		
		

	}


	public void OnSfxSliderChanged()
	{
		Preferences.GetInstance().SfxVolume = (int) SfxSlider.value;
	}

	public void OnMusicSliderChanged()
	{
		Preferences.GetInstance().MusicVolume = (int) MusicSlider.value;
	}

	public void OnLanguageDropdownChanged()
	{
		String stringvalue = LanguageDropdown.options[LanguageDropdown.value].text;

		SystemLanguage language;
		if (languagesDictionary.TryGetValue(stringvalue, out language))
		{
			LocalizationManager.Language = language.ToString();
			Preferences.GetInstance().SavePreferences();
		}
	}
	
	
}
