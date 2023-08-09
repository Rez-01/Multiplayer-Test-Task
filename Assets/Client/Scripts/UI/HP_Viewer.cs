using UnityEngine;
using UnityEngine.UI;

public class HP_Viewer : MonoBehaviour
{
    private Slider _slider;

    private void OnEnable()
    {
        PlayerHP.SetMaxHP += SetMaxValue;
        PlayerHP.OnHPChange += ChangeSlider;
    }

    private void OnDisable()
    {
        PlayerHP.SetMaxHP -= SetMaxValue;
        PlayerHP.OnHPChange -= ChangeSlider;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void SetMaxValue(int maxValue)
    {
        _slider.maxValue = maxValue;
        ChangeSlider(maxValue);
    }

    private void ChangeSlider(int value)
    {
        _slider.value = value;
    }
}
