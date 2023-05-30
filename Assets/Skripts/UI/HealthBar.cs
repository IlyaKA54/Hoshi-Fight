using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private HealthContainer _healthContainer;

    private void Start()
    {
        _slider.maxValue = _healthContainer.Health;
        _slider.value = _healthContainer.Health;
    }
    private void Update()
    {
        _slider.value = _healthContainer.Health;
    }
}
