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
    

    public static void MakeMementoCurrentGame()
    {
     

    }

    public static void InitializeGameFromMemento()
    {
    }

    

    


    public static void Save(string prefix)
    {
        MakeMementoCurrentGame();
        string gameString = UnityEngine.JsonUtility.ToJson(instance);
        PlayerPrefs.SetString(prefix + gameStringConstant, gameString);
        PlayerPrefs.Save();
    }
               

    public static void Load(string prefix)
    {
        string gameString = PlayerPrefs.GetString(prefix + gameStringConstant);
        instance = UnityEngine.JsonUtility.FromJson<SaveLoadHelper>(gameString);
        InitializeGameFromMemento();
    }


    public static void LoadFixedSave(string tutorialString)
    {
        
        instance = UnityEngine.JsonUtility.FromJson<SaveLoadHelper>(tutorialString);
        InitializeGameFromMemento();
    }
}