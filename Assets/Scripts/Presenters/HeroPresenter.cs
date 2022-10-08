using Model;
using Views;

namespace Presenters
{
    public class HeroPresenter : IPresenter
    {
        private readonly Hero _model;
        private readonly TargetView _targetView;

        public HeroPresenter(Hero model, TargetView targetView)
        {
            _model = model;
            _targetView = targetView;
        }

        public void Enable()
        {
            _model.GetHealth().Died += OnModelDied;
            _model.RestoredHealth += OnRestoredHealth;
            _model.Raged += OnRaged;
        }

        public void Disable()
        {
            _model.GetHealth().Died -= OnModelDied;
            _model.RestoredHealth -= OnRestoredHealth;
            _model.Raged -= OnRaged;
        }

        private void OnModelDied()
        {
            _targetView.Died();
        }

        private void OnRaged(float speedUp)
        {
            _targetView.Rage(speedUp);
        }

        private void OnRestoredHealth()
        {
            _targetView.RestoreHealth();
        }
    }
}