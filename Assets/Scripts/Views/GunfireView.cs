using Spawner;
using UnityEngine;

namespace Views
{
    public class GunfireView : View, ISpawnable
    {
        public void TurnOff()
        {
            gameObject.SetActive(false);
        }

        public void TurnOn()
        {
            gameObject.SetActive(true);
        }
    }
}