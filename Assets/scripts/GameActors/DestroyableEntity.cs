using UnityEngine;

namespace Model
{
    public class DestroyableEntity:MonoBehaviour
    {
        public void Kill()
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}