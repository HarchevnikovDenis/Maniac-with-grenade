using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickUpItemSpawner : SpawnerBase
{
    [SerializeField] private List<PickUpItem> grenadePrefabs;

    private List<PickUpItem> spawnedPool = new List<PickUpItem>();
    private PickUpItem spawnedGrenade;

    protected override float timeToNextSpawn => GameManager.Instance.TimeBetweenSpawnGrenade;

    private void Start()
    {
        SpawnRandomGrenade();
    }

    public override void SpawnWithDelay()
    {
        spawnedGrenade.gameObject.SetActive(false);
        spawnedPool.Add(spawnedGrenade);
        StartCoroutine(SpawnItemWithDelay());
    }

    protected override IEnumerator SpawnItemWithDelay()
    {
        yield return new WaitForSeconds(timeToNextSpawn);

        SpawnRandomGrenade();
    }

    private void SpawnRandomGrenade()
    {
        GrenadeType randomType = (GrenadeType)Random.Range(0, Enum.GetValues(typeof(GrenadeType)).Length);

        if (spawnedPool.Find(t => t.TypeOfGrenade.Equals(randomType)))
        {
            // Get From List
            int index = spawnedPool.FindIndex(t => t.TypeOfGrenade.Equals(randomType));
            spawnedGrenade = spawnedPool[index];
            spawnedGrenade.gameObject.SetActive(true);
        }
        else
        {
            // Instantiate
            int index = grenadePrefabs.FindIndex(t => t.TypeOfGrenade.Equals(randomType));
            spawnedGrenade = Instantiate(grenadePrefabs[index], transform);
            spawnedGrenade.InitSpanwer(this);
        }
    }
}
