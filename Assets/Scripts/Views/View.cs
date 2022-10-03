using UnityEngine;

namespace Views
{
    public abstract class View : MonoBehaviour
    {

        public Vector2 Position => transform.position;

        public void Died()
        {
            Destroy(gameObject);
        }
    }
}