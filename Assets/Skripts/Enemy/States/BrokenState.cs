using UnityEngine;
using UnityEngine.Events;

public class BrokenState : EnemyState
{
    [SerializeField] private float _disappearTime;

    public event UnityAction<BrokenState> Died;

    private float _lifeTime;

    public void ApplyDamage(Rigidbody rigidbody, float force)
    {
        Animator.SetTrigger("Die");
        Vector3 direction = (transform.position - rigidbody.position);
        direction.y = 0;
        Rigidbody.AddForce(direction.normalized * force, ForceMode.Impulse);
        Died?.Invoke(this);
    }
    private void Update()
    {
        _lifeTime += Time.deltaTime;

        if(_lifeTime >= _disappearTime)
        {
            Destroy(gameObject);
        }
    }
}
