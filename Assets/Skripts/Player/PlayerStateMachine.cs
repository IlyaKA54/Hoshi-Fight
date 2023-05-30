using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(HealthContainer))]
public class PlayerStateMachine : MonoBehaviour, IHealable
{
    [SerializeField] private PlayerState _firstState;
    [SerializeField] private GameMenu _gameMenu;

    private Rigidbody _rigidbody;
    private Animator _animator;
    private PlayerState _currentState;
    private HealthContainer _health;

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void OnDied()
    {
        _currentState.enabled = false;
        enabled = false;
        _animator.SetTrigger("IsDie");
        _gameMenu.BackStartMenu(1);

    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _health = GetComponent<HealthContainer>();
    }

    private void Start()
    {
        _currentState = _firstState;
        _currentState.Enter(_rigidbody, _animator);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(PlayerState nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_rigidbody, _animator);
        }
    }

    public void ApplyDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    public void OnHeal(float _healValue)
    {
        _health.OnHeal(_healValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Healer healer))
            healer.PlayerDetected += OnHeal;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Healer healer))
            healer.PlayerDetected -= OnHeal;
    }
}
