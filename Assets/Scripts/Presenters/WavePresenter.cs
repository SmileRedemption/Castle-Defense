using Model;

namespace Presenters
{
    public class WavePresenter : IPresenter
    {
        private readonly Wave _wave;
        private readonly WaveBar _waveBar;

        public WavePresenter(Wave wave, WaveBar waveBar)
        {
            _wave = wave;
            _waveBar = waveBar;
        }

        public void Enable()
        {
            _wave.AllEnemiesSpawned += OnAllEnemiesSpawned;
            _wave.Spawned += OnSpawned;
        }

        public void Disable()
        {
            _wave.AllEnemiesSpawned += OnAllEnemiesSpawned;
            _wave.Spawned -= OnSpawned;
        }
        
        private void OnSpawned(int current, int max)
        {
            _waveBar.OnValueChanged(current, max);
        }
        
        private void OnAllEnemiesSpawned()
        {
            _waveBar.SetStartValueOfSlider();
        }
    }
}