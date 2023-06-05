using UnityEngine;
using UnityEngine.Events;

public class HealthContainer : MonoBehaviour
{
    [SerializeField] private float _health;

    public float Health { get => _health; }

    public event UnityAction<float> HealthChanged;
    public event UnityAction Died;

    private float _startHealth;

    private void Start()
    {

    }
    public void TakeDamage(int value)
    {
        _health -= value;
        if (_health <= 0)
        {
            _health = 0;
            Died?.Invoke();
        }
        HealthChanged?.Invoke(_health);
    }

    public void OnHeal(float _healValue)
    {
        if (_health <= _startHealth)
            return;

        _health += _healValue;
    }

}
