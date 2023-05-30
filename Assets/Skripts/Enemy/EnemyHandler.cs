using System.Collections;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Spawner _spawner;

    private KillsView _killsView;

    private void Awake()
    {
        _killsView = FindObjectOfType<KillsView>();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            var enemy = _spawner.CreateEnemy();
            enemy.Died += _killsView.OnKillsUpdate;
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

}
