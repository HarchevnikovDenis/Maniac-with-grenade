using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GrenadeCollision))]
public class Grenade : MonoBehaviour
{
    [SerializeField] private GrenadeType grenadeType;

    public Transform Transform { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public GrenadeType TypeOfGrenade => grenadeType;

    public bool IsPhysic => !Rigidbody.isKinematic && Rigidbody.useGravity;

    private void Awake()
    {
        Transform = gameObject.GetComponent<Transform>();
        Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public void SetPhysicActive(bool isActive)
    {
        if (isActive)
        {
            Rigidbody.isKinematic = false;
            Rigidbody.useGravity = true;
        }
        else
        {
            Rigidbody.isKinematic = true;
            Rigidbody.useGravity = false;
        }
    }

    private void Update()
    {
        if (IsPhysic && Transform.position.y < -10.0f)
        {
            GameManager.Instance.GrenadePool.AddGrenadeToPool(this);
        }
    }
}

public enum GrenadeType
{
    RED,
    GREEN,
    BLUE
}
