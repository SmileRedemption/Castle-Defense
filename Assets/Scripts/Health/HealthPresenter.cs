
public class HealthPresenter
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
        _healthModel.Relieved += OnHealthRelieved;
    }
    
    public void Disable()
    {
        _healthModel.HealthChanged -= OnHealthChanged;
        _healthModel.Relieved -= OnHealthRelieved;
    }

    private void OnHealthRelieved() =>
        _healthView.SetStartValueOfSlider();
    
    private void OnHealthChanged(float currentHealth, float maxHealth) =>
        _healthView.OnValueChanged(currentHealth, maxHealth);
}