using System.Collections;
using UnityEngine;

public class EnemySpawner : SpawnerBase
{
    [SerializeField] private Enemy enemyPrefab;

    private Enemy spawnedEnemy;

    protected override float timeToNextSpawn => GameManager.Instance.TimeBetweenSpawnEnemy;

    private void Start()
    {
        SpawnEnemy();
    }

    public override void SpawnWithDelay()
    {
        spawnedEnemy.gameObject.SetActive(false);
        StartCoroutine(SpawnItemWithDelay());
    }

    protected override IEnumerator SpawnItemWithDelay()
    {
        yield return new WaitForSeconds(timeToNextSpawn);

        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (spawnedEnemy)
        {
            // Enable
            spawnedEnemy.gameObject.SetActive(true);
        }
        else
        {
            // Create
            spawnedEnemy = Instantiate(enemyPrefab, transform);
            spawnedEnemy.InitSpanwer(this);
        }

        spawnedEnemy.RestoreHealth();
    }
}
