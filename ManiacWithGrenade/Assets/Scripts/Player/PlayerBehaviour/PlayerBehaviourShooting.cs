using UnityEngine;

public class PlayerBehaviourShooting : PlayerBehaviourBase, IPlayerBehaviour
{
    private GrenadeShooter grenadeShooter => playerController.GrenadeShooter;

    public PlayerBehaviourShooting(PlayerController playerController) : base(playerController) { }

    public void Enter()
    {
        // Create grenade in hand
        grenadeShooter.CreateGrenadeWithTypeInHand(playerController.Inventory.CurrentGrenadeType);
    }

    public void Update()
    {
        // Throw trajectory
        grenadeShooter.ProjectTranjectory();

        // Throw a grenade
        if (Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0))
        {
            playerController.GrenadeShooter.ThrowGrenade();
            playerController.Inventory.DecreaseGrenade();
            playerController.ChangeBehaviour();
        }
    }

    public void Exit()
    {
        // Hide Trajectory
        grenadeShooter.HideTrajectory();
    }
}
