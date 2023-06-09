using UnityEngine;

public class StaminaAccumulator : MonoBehaviour
{
    [SerializeField] private float _accumulationTime;
    [SerializeField] private Ability _ultimateAbility;
    [SerializeField] private Ability _ability;

    private float _staminaValue;
    public void StartAccumulator()
    {
        _staminaValue = 0;
    }

    private void Update()
    {
        _staminaValue += Time.deltaTime;
    }

    public Ability GetAbility()
    {
        if (_staminaValue > _accumulationTime)
            return _ultimateAbility;

        return _ability;
    }
}
