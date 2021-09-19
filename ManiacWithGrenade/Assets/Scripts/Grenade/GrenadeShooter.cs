using System.Collections.Generic;
using UnityEngine;

public class GrenadeShooter : MonoBehaviour
{
    [SerializeField] private List<Grenade> grenadePrefabList;
    [SerializeField] private TrajectoryRenderer trajectoryRenderer;
    [SerializeField] private Transform grenadeContainer;
    [SerializeField] private float throwingPower;

    private Grenade currentGrenade;
    private new Transform transform;

    private void Awake()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    public void CreateGrenadeWithTypeInHand(GrenadeType grenadeType)
    {
        int grenadeIndex = 0;
        for (int i = 0; i < grenadePrefabList.Count; i++)
        {
            if (grenadePrefabList[i].TypeOfGrenade.Equals(grenadeType))
            {
                grenadeIndex = i;
                break;
            }
        }

        currentGrenade = GameManager.Instance.GrenadePool.GetGrenadeFromPool(grenadeType);
        if (currentGrenade)
        {
            currentGrenade.transform.SetParent(transform);
        }
        else
        {
            currentGrenade = Instantiate(grenadePrefabList[grenadeIndex], transform);
        }

        currentGrenade.Transform.position = base.transform.position;
        currentGrenade.Transform.rotation = base.transform.rotation;
    }

    public void ProjectTranjectory()
    {
        trajectoryRenderer.ShowTrajectory(transform.position, transform.forward, throwingPower);
    }

    public void HideTrajectory()
    {
        trajectoryRenderer.HideTrajectory();
    }

    public void ThrowGrenade()
    {
        currentGrenade.transform.SetParent(grenadeContainer);
        currentGrenade.SetPhysicActive(true);
        currentGrenade.Rigidbody.AddForce(currentGrenade.Transform.forward * throwingPower, ForceMode.VelocityChange);
        currentGrenade = null;
    }
}
