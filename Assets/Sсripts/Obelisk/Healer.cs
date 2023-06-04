using UnityEngine;
using UnityEngine.Events;

public class Healer : MonoBehaviour
{
    [SerializeField] private float _healValue;

    public event UnityAction<float> PlayerDetected;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out IHealable player))
        {
            PlayerDetected?.Invoke(_healValue);
        }
    }
}
