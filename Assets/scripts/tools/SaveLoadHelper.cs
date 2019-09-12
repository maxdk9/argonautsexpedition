using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEditor;



[System.Serializable]
public class SaveLoadHelper
{
    private static SaveLoadHelper instance=new SaveLoadHelper();
    public static string defaultPrefixString ="defaultSave";
    private static string gameStringConstant = "game";    
    

 
    

    


    public static void Save(string prefix)
    {
 
        string gameString = UnityEngine.JsonUtility.ToJson(Game.instance);
        Debug.Log(gameString);
        PlayerPrefs.SetString(prefix + gameStringConstant, gameString);
        PlayerPrefs.Save();
    }
               

    public static void Load(string prefix)
    {
        string gameString = PlayerPrefs.GetString(prefix + gameStringConstant);
        UnityEngine.JsonUtility.FromJson<Game>(gameString);
        String currstring = "sdfsdf";

    }


    public static void LoadFixedSave(string tutorialString)
    {
        
        instance = UnityEngine.JsonUtility.FromJson<SaveLoadHelper>(tutorialString);
 
    }
}