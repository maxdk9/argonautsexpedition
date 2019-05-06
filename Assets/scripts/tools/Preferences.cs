using UnityEngine;

namespace tools
{
    public class Preferences
    {
        public static string sfxPref = "sfx_preference";
        public static string soundPref = "sound_preference";
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

        private void SavePreferences()
        {
            PlayerPrefs.SetInt(sfxPref,sfxVolume);
            PlayerPrefs.SetInt(soundPref,soundVolume);
            PlayerPrefs.Save();
        }

        public void LoadPreferences()
        {
            sfxVolume=PlayerPrefs.GetInt(sfxPref);
            soundVolume = PlayerPrefs.GetInt(soundPref);
        }

        private int soundVolume;
        public int SoundVolume
        {
            get { return soundVolume; }
            set
            {
                soundVolume = value;
                SavePreferences();
            }
        }

        





    }
}