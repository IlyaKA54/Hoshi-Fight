using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _tapPosition;

    public UnityAction<Vector3> DirectionChanged;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _tapPosition = Input.mousePosition;

        if (Input.GetMouseButton(0))
            DirectionChanged?.Invoke(Input.mousePosition - _tapPosition);

    }
}
