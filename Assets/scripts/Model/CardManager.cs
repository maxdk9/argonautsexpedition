using System;
using UnityEngine;

namespace Model
{
    public class CardManager
    {




	    [System.Serializable]
        public class Card
        {
            public int cardnumber;
            private EffectType effecttype;
            private CardType type;
            private UseType useType;
            private bool reserve;
            private bool wrath;
            private int level;
            private int crewNumber;
            private int rollResult;
            private ResolvedType resolved;
            private bool ignore=false;
            private bool IgnoreDeadliness;
            private bool markApolloBow;
            private bool markOrpheusLyre;
            private String name;
            private int [] difficulty;
            private int [] deadliness;
            
            
            [NonSerialized]
                public Sprite front;
                public Sprite back;
                public int[] manaarray=new int[4];
		
            
        }
    }
}