using UnityEngine;

public class CameraFolowing : MonoBehaviour
{
    [SerializeField] private Rigidbody _player;
    [SerializeField] private Vector3 _forwardDirection;
    [SerializeField] private float _speed;
    [SerializeField] private float _angel;
    [SerializeField] private float _distance;
    [SerializeField] private float _maxVectorLenght;

    private HealthContainer _health;

    private Vector3 _nextPosition;

    private void Start()
    {
        float rotationY = Mathf.Rad2Deg * Mathf.Asin(_forwardDirection.x / _forwardDirection.magnitude);
        transform.rotation = Quaternion.Euler(_angel, rotationY, transform.rotation.eulerAngles.z);
    }

    private void FixedUpdate()
    {
        _nextPosition = _player.position + Vector3.ClampMagnitude(_player.velocity, _maxVectorLenght);
        _nextPosition += Vector3.up * Mathf.Cos(Mathf.Deg2Rad * _angel) * _distance;
        _nextPosition += -_forwardDirection * Mathf.Sin(Mathf.Rad2Deg * _angel) * _distance;
        transform.position = Vector3.Lerp(transform.position, _nextPosition, _speed * Time.fixedDeltaTime);
    }
}
