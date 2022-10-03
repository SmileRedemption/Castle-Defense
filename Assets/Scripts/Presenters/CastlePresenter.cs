using Model;
using Views;

namespace Presenters
{
    public class CastlePresenter : IPresenter
    {
        private readonly Castle _castle;
        private readonly CastleView _castleView;

        public CastlePresenter(Castle castle, CastleView castleView)
        {
            _castle = castle;
            _castleView = castleView;
        }

        public void Enable()
        {
            _castle.GetHealth().Died += OnModelDied;
        }

        public void Disable()
        {
            _castle.GetHealth().Died -= OnModelDied;
        }

        public void OnModelDied()
        {
        }
    }
}