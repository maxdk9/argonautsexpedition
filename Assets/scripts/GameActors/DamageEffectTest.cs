using UnityEngine;

namespace GameActors
{
    public class DamageEffectTest: MonoBehaviour
    {
        public static DamageEffectTest instance;
        public  GameObject DamageEffectPrefab;

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                DamageEffect.CreateDamageEffect(new Vector3(0,0,0),2);
            }
        }
    }
}