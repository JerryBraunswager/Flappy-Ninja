using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private ProjectilePool _projectilePool;
    [SerializeField] private EndGameScreen _endGameScreen;

    private float _delay;
    private WaitForSeconds _sleepTime;
    private List<Enemy> _enemyList = new List<Enemy>();

    private void Start()
    {
        _delay = _startDelay;
        _sleepTime = new WaitForSeconds(_timeToChangeDelay);
        StartCoroutine(SpawnEnemies());
        StartCoroutine(ChangeDelay());
    }
    private void OnEnable()
    {
        _endGameScreen.RestartButtonClicked += RestartGame;
    }

    private void OnDisable()
    {
        _endGameScreen.RestartButtonClicked -= RestartGame;

        foreach (Enemy enemy in _enemyList) 
        { 
            enemy.Died -= DeactivateEnemy;
        }
    }

    private void RestartGame()
    {
        _delay = _startDelay;
    }

    private IEnumerator SpawnEnemies()
    {
        while (enabled) 
        {
            Spawn();
            yield return new WaitForSeconds(_delay);
        }
    }

    private IEnumerator ChangeDelay() 
    {
        while (enabled)
        {
            yield return _sleepTime;
            _delay -= _amountOfChange;
            _delay = Mathf.Clamp(_delay, 0, _startDelay);
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        var enemy = _pool.GetObject();
        enemy.ShootAbility.Init(_projectilePool);
        enemy.Died += DeactivateEnemy;
        _enemyList.Add(enemy);
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private void DeactivateEnemy(Enemy enemy)
    {
        _pool.PutObject(enemy);
        enemy.Died -= DeactivateEnemy;
        _enemyList.Remove(enemy);
    }
}
