using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private Slider _experienceBar;

    private void Start()
    {
        _experienceBar = GetComponent<Slider>();
    }

    public void ChangeCurrentValue(int currentValue)
    {
        _experienceBar.value = currentValue;
    }

    public void ChangeMaxValue(int maxValue)
    {
        _experienceBar.maxValue = maxValue;
    }
}