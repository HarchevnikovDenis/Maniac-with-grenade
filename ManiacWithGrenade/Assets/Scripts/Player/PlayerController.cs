using UnityEngine;

[RequireComponent(typeof(MouseLook))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GrenadeShooter grenadeShooter;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float movingSpeed;

    private MouseLook mouseLook;

    private BehaviourType currentBehaviourType;

    private IPlayerBehaviour currentBehaviour;
    private PlayerBehaviourMoving playerBehaviourMoving;
    private PlayerBehaviourShooting playerBehaviourShooting;

    public Transform Transform { get; private set; }
    public Inventory Inventory => inventory;
    public GrenadeShooter GrenadeShooter => grenadeShooter;
    public LayerMask GroundLayer => groundLayer;
    public float MovingSpeed => movingSpeed;

    public Vector3 RaycastDirection
    {
        get
        {
            Vector3 direction;
            if (Transform)
            {
                direction = Transform.forward;
            }
            else
            {
                direction = transform.forward;
            }

            direction.y = 0.0f;
            direction = direction.normalized;
            direction.y = -1.0f;
            return direction;
        }
    }

    public enum BehaviourType
    {
        MOVING,
        SHOOTING
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (Transform)
        {
            Gizmos.DrawLine(Transform.position, Transform.position + RaycastDirection);
        }
        else
        {
            Gizmos.DrawLine(transform.position, transform.position + RaycastDirection);
        }
    }

    private void Awake()
    {
        Transform = gameObject.GetComponent<Transform>();
        mouseLook = gameObject.GetComponent<MouseLook>();

        GameManager.Instance.SetBillboardTarget(Transform);

        // Init behaviour
        playerBehaviourMoving = new PlayerBehaviourMoving(this);
        playerBehaviourShooting = new PlayerBehaviourShooting(this);

        SetDefaultBehaviour();

        // Init Inventory
        inventory.InitInventory();
    }

    private void SetDefaultBehaviour()
    {
        currentBehaviour = playerBehaviourMoving;
        currentBehaviour.Enter();
    }

    public void ChangeBehaviour()
    {
        currentBehaviour.Exit();

        switch (currentBehaviourType)
        {
            case BehaviourType.MOVING:
                currentBehaviourType = BehaviourType.SHOOTING;
                currentBehaviour = playerBehaviourShooting;
                break;
            case BehaviourType.SHOOTING:
                currentBehaviourType = BehaviourType.MOVING;
                currentBehaviour = playerBehaviourMoving;
                break;
            default:
                break;
        }

        currentBehaviour.Enter();
    }

    private void Update()
    {
        // Rotation on mouse movement
        mouseLook.RotateToMouseLook();

        currentBehaviour?.Update();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Left
            inventory.ChangeSelectedSlot(false);
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Right
            inventory.ChangeSelectedSlot(true);
            return;
        }
    }
}
