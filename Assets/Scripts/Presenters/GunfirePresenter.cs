using Model;
using Views;

namespace Presenters
{
    public class GunfirePresenter : IPresenter 
    {
        private readonly Gunfire _gunfire;
        private readonly GunfireView _gunfireView;

        public GunfirePresenter(Gunfire gunfire, GunfireView gunfireView)
        {
            _gunfire = gunfire;
            _gunfireView = gunfireView;
        }

        public void Enable()
        {
            _gunfire.GetHealth().Died += OnModelDied;
        }

        public void Disable()
        {
            _gunfire.GetHealth().Died -= OnModelDied;
        }

        public void OnModelDied()
        {
            
        }
    }
}