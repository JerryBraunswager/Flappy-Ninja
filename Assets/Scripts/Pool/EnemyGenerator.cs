using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _startDelay;
    [SerializeField] private float _timeToChangeDelay;
    [SerializeField] private float _amountOfChange;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private EnemyPool _pool;

    private float _delay;
    private WaitForSeconds _sleepTime;

    private void Start()
    {
        _delay = _startDelay;
        _sleepTime = new WaitForSeconds(_timeToChangeDelay);
        StartCoroutine(SpawnEnemies());
        StartCoroutine(ChangeDelay());
    }

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled) 
        {
            Spawn();
            yield return wait;
        }
    }

    private IEnumerator ChangeDelay() 
    {
        while (enabled)
        {
            yield return _sleepTime;
            _delay -= _amountOfChange;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var enemy = _pool.GetObject();
        enemy.Died += DeactivateEnemy;

        if(enemy.TryGetComponent(out ShootAbility component))
        {
            component.Init(FindAnyObjectByType<ProjectilePool>());
        }

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private void DeactivateEnemy(Enemy enemy)
    {
        _pool.PutObject(enemy);
    }
}
