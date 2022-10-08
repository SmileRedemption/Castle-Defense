using Model;

namespace Presenters
{
    public class HealthPresenter : IPresenter
    {
        private readonly HealthBar _healthView;
        private readonly Health _healthModel;

        public HealthPresenter(HealthBar healthView, Health healthModel)
        {
            _healthView = healthView;
            _healthModel = healthModel;
        }

        public void Enable()
        {
            _healthModel.HealthChanged += OnHealthChanged;
            _healthModel.Relieved += OnRelieved;
        }

        public void Disable()
        {
            _healthModel.HealthChanged -= OnHealthChanged;
            _healthModel.Relieved -= OnRelieved;
        }

        private void OnHealthChanged(float currentHealth, float maxHealth) =>
            _healthView.OnValueChanged(currentHealth, maxHealth);

        private void OnRelieved() => 
            _healthView.SetStartValueOfSlider();
    }
}