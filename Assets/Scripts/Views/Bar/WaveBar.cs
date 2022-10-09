using UnityEngine;
using UnityEngine.UI;

public class WaveBar : Bar
{
    [SerializeField] private Image _colorOfHealthBar;
    [SerializeField] private Color _lowColor;
    [SerializeField] private Color _highColor;

    private const float StartValueOfSlider = 0;

    public override void SetStartValueOfSlider()
    {
        Slider.value = StartValueOfSlider;
        _colorOfHealthBar.color = _highColor;
    }

    protected override void ChangeColor()
    {
        
    }
}
