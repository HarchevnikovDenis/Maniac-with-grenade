using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePool : MonoBehaviour
{
    private List<Grenade> grenades = new List<Grenade>();

    public void AddGrenadeToPool(Grenade grenade)
    {
        grenade.SetPhysicActive(false);
        grenade.gameObject.SetActive(false);
        grenades.Add(grenade);
    }

    public Grenade GetGrenadeFromPool(GrenadeType grenadeType)
    {
        Grenade grenade = grenades.Find(t => t.TypeOfGrenade.Equals(grenadeType));

        if (grenade)
        {
            grenade.gameObject.SetActive(true);
            grenades.Remove(grenade);
        }

        return grenade;
    }
}
