using UnityEngine;

namespace Views
{
    public class TargetView : View
    {
        [SerializeField] private ShootButton _shootButton;
        
        public void Rage(float speedUp)
        {
            _shootButton.RageOn(speedUp);
        }

        public void RestoreHealth()
        {
            
        }
        
        public override void Died()
        {
            _shootButton.OnHeroDied();
            base.Died();
        }
    }
}