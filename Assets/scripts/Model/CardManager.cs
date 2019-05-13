using System;
using System.IO;
using Boo.Lang;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using tools;
using UnityEngine;
using UnityEngine.UI;

namespace Model
{
    public class CardManager
    {




	    [System.Serializable]
        public class Card:ScriptableObject
        {
            public int cardnumber;
            public EffectType effecttype;
            public CardType type;
            public UseType useType;
            public bool reserve;
            public bool wrath;
            public int level;
            public int crewNumber;
            public int rollResult;
            public ResolvedType resolved;
            public bool ignore=false;
            public bool IgnoreDeadliness;
            public bool markApolloBow;
            public bool markOrpheusLyre;
            public String name;
            public int [] difficulty;
            public int [] deadliness;
            
            
            [NonSerialized]
            public Sprite front;
            
		
        
        }

        private static CardManager instance;

        public static CardManager Instance()
        {
            if (instance == null)
            {
                instance=new CardManager();
                
            }

            return instance;
        }


        private System.Collections.Generic.List<Card> m_Dictionary=new System.Collections.Generic.List<Card>(); 

        public void Init()
        {
            LoadDictionary();
        }

        private void LoadDictionary()
        {
            String filename = "cards1.json";
            string filePath = GetStreamingAssetsFilePath.GetPath(filename);

            string dataAsJson="";
            List cardlist = new List();

            if (File.Exists(filePath))
            {
                 dataAsJson = File.ReadAllText(filePath);


                cardlist = JsonConvert.DeserializeObject<List>(dataAsJson,
                    new Newtonsoft.Json.Converters.StringEnumConverter());
            }
            else
            {
                Debug.Log(filename + "No file exist");
            }


            m_Dictionary.Clear();
            foreach (JObject card in cardlist)
            {
                CardManager.Card resultCard = card.ToObject<CardManager.Card>();
                
                
                
                m_Dictionary.Add(resultCard);
            }

            string s = "";

            //CardManager.Card[] cards = JsonHelper.FromJson<CardManager.Card>(dataAsJson);
            //Debug.Log( cards[0]);
        }
    }
}