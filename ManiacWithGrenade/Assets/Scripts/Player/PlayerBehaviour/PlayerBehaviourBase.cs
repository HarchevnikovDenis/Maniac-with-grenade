using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehaviourBase
{
    protected readonly PlayerController playerController;

    public PlayerBehaviourBase(PlayerController playerController)
    {
        this.playerController = playerController;
    }
}
