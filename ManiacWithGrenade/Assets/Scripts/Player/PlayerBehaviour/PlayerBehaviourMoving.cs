using UnityEngine;

public class PlayerBehaviourMoving : PlayerBehaviourBase, IPlayerBehaviour
{
    private RaycastHit hit;
    private Vector3 movingDirection;
    private float inputX, inputZ;

    private Transform playerTransform => playerController.Transform;
    private Vector3 raycastDirection => playerController.RaycastDirection * 10.0f;

    public PlayerBehaviourMoving(PlayerController playerController) : base(playerController) { }

    public void Enter()
    {

    }

    public void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        if (!CanMoving()) inputZ = 0.0f;

        movingDirection = playerController.Transform.forward * inputZ + playerController.Transform.right * inputX;
        movingDirection.y = 0.0f;
        movingDirection = Vector3.ClampMagnitude(movingDirection, 1.0f);

        playerController.Transform.position += movingDirection * playerController.MovingSpeed * Time.deltaTime;

        if (Input.GetMouseButton(0) && !playerController.Inventory.IsCurrentSelectedSlotEmpty)
        {
            playerController.ChangeBehaviour();
        }
    }

    private bool CanMoving()
    {
        if (Physics.Raycast(playerTransform.position, playerTransform.position + raycastDirection, out hit, playerController.GroundLayer))
        {
            if (hit.collider.gameObject.GetComponent<Ground>())
            {
                return true;
            }

            if (hit.collider.isTrigger)
            {
                return true;
            }
        }

        return false;
    }

    public void Exit()
    {

    }
}
