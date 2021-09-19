using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private new Transform transform;

    private Transform target => GameManager.Instance.BillboardTarget;

    private void Awake()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (target)
        {
            transform.LookAt(target);
        }
    }
}
