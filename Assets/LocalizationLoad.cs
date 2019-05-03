using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationLoad : MonoBehaviour {

	public Text FormattedText;

	/// <summary>
	/// Called on app start.
	/// </summary>
	public void Awake()
	{
		LocalizationManager.Read();

		switch (Application.systemLanguage)
		{
			
			case SystemLanguage.Russian:
				LocalizationManager.Language = "Russian";
				break;
			default:
				LocalizationManager.Language = "English";
				break;
		}

		// This way you can insert values to localized strings.
	//	FormattedText.text = LocalizationManager.Localize("Settings.PlayTime", TimeSpan.FromHours(10.5f).TotalHours);

		// This way you can subscribe to localization changed event.
	//	LocalizationManager.LocalizationChanged += () => FormattedText.text = LocalizationManager.Localize("Settings.PlayTime", TimeSpan.FromHours(10.5f).TotalHours);
	}

	/// <summary>
	/// Change localization at runtime
	/// </summary>
	public void SetLocalization(string localization)
	{
		LocalizationManager.Language = localization;
	}

	
}
