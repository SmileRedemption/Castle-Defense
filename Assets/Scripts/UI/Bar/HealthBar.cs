using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Bar
{
    [SerializeField] private Image _colorOfHealthBar;
    [SerializeField] private Color _lowColor;
    [SerializeField] private Color _highColor;

    public void SetStartValueOfSlider()
    {
        Slider.value = StartValueOfSlider;
        _colorOfHealthBar.color = _highColor;
    }

    protected override void ChangeColor() =>
        _colorOfHealthBar.color = Color.Lerp(_lowColor, _highColor, Slider.normalizedValue);
}