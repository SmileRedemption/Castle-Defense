using Model;
using Views;

namespace Presenters
{
    public class HeroPresenter : IPresenter
    {
        private readonly Transformable _model;
        private readonly TargetView _targetView;
        
        public Transformable Model => _model;


        public HeroPresenter(Transformable model, TargetView targetView)
        {
            _model = model;
            _targetView = targetView;
        }

        public void Enable()
        {
            _model.GetHealth().Died += OnModelDied;
        }

        public void Disable()
        {
            _model.GetHealth().Died -= OnModelDied;
        }

        public void OnModelDied()
        {
            _targetView.Died();
        }
    }
}