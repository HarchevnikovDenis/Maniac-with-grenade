using UnityEngine;

public abstract class SpawnedObjectBase : MonoBehaviour
{
    protected SpawnerBase spawner;

    public void InitSpanwer(SpawnerBase spawner)
    {
        this.spawner = spawner;
    }
}
