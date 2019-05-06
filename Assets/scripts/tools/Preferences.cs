using System;
using Assets.SimpleLocalization;
using UnityEngine;

namespace tools
{
    public class Preferences
    {
        public static string sfxPref = "sfx_preference";
        public static string musicPref = "music_preference";
        public static string languagePref = "language_preference";
        
        
        private static  Preferences instance;

        public static Preferences GetInstance()
        {
            if (instance == null)
            {
                instance=new Preferences();
            }

            return instance;
        }

        private int sfxVolume;

        public int SfxVolume
        {
            get { return sfxVolume; }
            set
            {
                sfxVolume = value;
                SavePreferences();
            }
        }

        public void SavePreferences()
        {
            PlayerPrefs.SetInt(sfxPref,sfxVolume);
            PlayerPrefs.SetInt(musicPref,musicVolume);
            PlayerPrefs.SetString(languagePref,LocalizationManager.Language);
            PlayerPrefs.Save();
        }

        public void LoadPreferences()
        {
            sfxVolume=PlayerPrefs.GetInt(sfxPref);
            musicVolume = PlayerPrefs.GetInt(musicPref);
            String lang = PlayerPrefs.GetString(languagePref,"");
            if (!lang.Equals(""))
            {
                LocalizationManager.Language = lang;    
            }
            
        }

        private int musicVolume;
        public int MusicVolume
        {
            get { return musicVolume; }
            set
            {
                musicVolume = value;
                SavePreferences();
            }
        }

        





    }
}