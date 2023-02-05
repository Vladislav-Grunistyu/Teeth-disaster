using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] _enemyToSpawn = new GameObject[4];

    private float _maxPeriod = 20;
    private float _minPeriod = 10;
    private float _timeUntilNextSpawn;

    private void Start()
    {
        _timeUntilNextSpawn = Random.Range(_minPeriod, _maxPeriod);
        for (int i = 60; i < 600; i += 60)
        {
            StartCoroutine(ComplexityStage(i));
        }
    }

    private void Update()
    {
        _timeUntilNextSpawn -= Time.deltaTime;
        if (_timeUntilNextSpawn <= 0)
        {
            _timeUntilNextSpawn = _maxPeriod;
            SpawnRandomEnemy();
        }
    }

    IEnumerator ComplexityStage(float time)
    {
        yield return new WaitForSeconds(time);
        _minPeriod--;
        _maxPeriod--;
        _timeUntilNextSpawn = Random.Range(_minPeriod, _maxPeriod);
    }

    private void SpawnRandomEnemy()
    {
        Instantiate(_enemyToSpawn[Random.Range(0,_enemyToSpawn.Length)],transform.position, Quaternion.identity);
    }
}
