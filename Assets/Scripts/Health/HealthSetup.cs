using UnityEngine;

[RequireComponent(typeof(IHealthChanger))]
public class HealthSetup : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private Health _model;
    private HealthPresenter _healthPresenter;

    private void Awake()
    {
        _model = GetComponent<IHealthChanger>().GetHealth();
        _healthPresenter = new HealthPresenter(_healthBar, _model);
    }

    private void OnEnable()
    {
        _healthPresenter.Enable();
    }

    private void OnDisable()
    {
        _healthPresenter.Disable();
    }
}