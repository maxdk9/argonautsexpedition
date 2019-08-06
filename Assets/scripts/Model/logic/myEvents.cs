using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class myEvents
    {
        public class EffectEvent:UnityEvent<Effect.EffectType>
        {
            public EffectEvent()
            {
                
            }
        }


        public class CardVisualEvent : UnityEvent<OneCardManager>
        {
            
        }

        
        
    }
}