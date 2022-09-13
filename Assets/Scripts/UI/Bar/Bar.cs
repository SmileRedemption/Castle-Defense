using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    protected const float StartValueOfSlider = 1f;

    protected abstract void ChangeColor();

    public void OnValueChanged(float minValue, float maxValue)
    {
       Slider.value =  minValue / maxValue;
       ChangeColor();
    }
}
