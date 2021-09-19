using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GrenadePool grenadePool;
    [SerializeField] private float timeBetweenSpawnGrenade;
    [SerializeField] private float timeBetweenSpawnEnemy;

    public GrenadePool GrenadePool => grenadePool;
    public float TimeBetweenSpawnGrenade => timeBetweenSpawnGrenade;
    public float TimeBetweenSpawnEnemy => timeBetweenSpawnEnemy;
    public Transform BillboardTarget { get; private set; }

    private void Start()
    {
        Cursor.visible = false;
    }

    public void SetBillboardTarget(Transform target)
    {
        BillboardTarget = target;
    }
}
