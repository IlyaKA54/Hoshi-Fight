using UnityEngine;

public class MoveState : PlayerState
{
    [SerializeField] private StaminaAccumulator _staminaAccumulator;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedRatio;

    private void OnEnable()
    {
        _playerInput.DirectionChanged += OnDirectionChanged;
        _staminaAccumulator.StartAccumulator();
        Animator.SetBool("Run", true);
    }
    private void OnDisable()
    {
        _playerInput.DirectionChanged -= OnDirectionChanged;
        Animator.SetBool("Run", false);
    }

    private void OnDirectionChanged(Vector3 direction)
    {
        Rigidbody.velocity = new Vector3(direction.x, 0, direction.y) * _speedRatio;
        if (Rigidbody.velocity.magnitude > _maxSpeed)
            Rigidbody.velocity *= _maxSpeed / Rigidbody.velocity.magnitude;

        if (Rigidbody.velocity.magnitude != 0)
            Rigidbody.MoveRotation(Quaternion.LookRotation(Rigidbody.velocity, Vector3.up));
    }

    private void Update()
    {
        
    }
}
