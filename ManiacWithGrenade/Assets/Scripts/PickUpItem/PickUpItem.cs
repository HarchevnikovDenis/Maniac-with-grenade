using UnityEngine;

public class PickUpItem : SpawnedObjectBase
{
    [SerializeField] private GrenadeType grenadeType;

    public GrenadeType TypeOfGrenade => grenadeType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() is PlayerController player)
        {
            player.Inventory.AddGrenadeWithType(grenadeType);
            spawner.SpawnWithDelay();
        }
    }
}
