using System.Collections;
using UnityEngine;

public abstract class SpawnerBase : MonoBehaviour
{
    protected abstract float timeToNextSpawn { get; }

    public abstract void SpawnWithDelay();

    protected abstract IEnumerator SpawnItemWithDelay();
}
