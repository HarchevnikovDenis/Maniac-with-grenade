using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GrenadeCollision : MonoBehaviour
{
    private Grenade grenade;

    private bool isPhysic => grenade.IsPhysic;

    private void Awake()
    {
        grenade = gameObject.GetComponent<Grenade>();

        if (!grenade) throw new NullReferenceException();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isPhysic) return;

        if (collision.gameObject.GetComponentInChildren<Enemy>() is Enemy enemy)
        {
            // TODO: Calculate Damage
            StartCoroutine(BoomWithDelay(() =>
            {
                enemy.GetDamage(25.0f);
                GameManager.Instance.GrenadePool.AddGrenadeToPool(grenade);
            }));
            return;
        }

        if (collision.gameObject.GetComponent<Ground>())
        {
            StartCoroutine(BoomWithDelay(() =>
            {
                GameManager.Instance.GrenadePool.AddGrenadeToPool(grenade);
            }));
            return;
        }
    }

    private IEnumerator BoomWithDelay(UnityAction action)
    {
        yield return new WaitForSeconds(0.25f);

        action.Invoke();
    }
}
