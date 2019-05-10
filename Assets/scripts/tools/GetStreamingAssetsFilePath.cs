
using System;
using System.Text;
using UnityEngine;

public class GetStreamingAssetsFilePath
{

    public static String GetPath(String filename)
    {
        string dbPath = "";
        string realPath="";
        if (Application.platform == RuntimePlatform.Android)
        {
            // Android
            string oriPath = System.IO.Path.Combine(Application.streamingAssetsPath, filename);

            // Android only use WWW to read file
            WWW reader = new WWW(oriPath);
            while (!reader.isDone)
            {
            }

            realPath = Application.persistentDataPath + "/db";
            System.IO.File.WriteAllBytes(realPath, reader.bytes);

            dbPath = realPath;
        }
        else
        {
            dbPath =  Application.dataPath+"/StreamingAssets/" + filename;
        }

        return dbPath;
    }
    
}