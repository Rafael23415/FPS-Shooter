using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteLook : MonoBehaviour
{
    private Transform target;
    public bool canLookVertically;

    void Start()
    {
        target = FindObjectOfType<PlayerMove>().transform;
    }

    void Update()
    {
        if (canLookVertically)
        {
            transform.LookAt(target);
        }
        else
        {
            Vector3 modifiedTrarget = target.position;
            modifiedTrarget.y = transform.position.y;

            transform.LookAt(modifiedTrarget);
        }
    }
}
