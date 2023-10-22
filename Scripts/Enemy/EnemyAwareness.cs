using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius;
    public bool isAggro;
    private Transform playersTransform;

    private void Start()
    {
        playersTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playersTransform.position);

        if(dist < awarenessRadius)
        {
            isAggro = true;
        }

        if(isAggro)
        {
            GetComponentInChildren<Animator>().SetBool("isAggro", true);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("isAggro", false);
        }
    }
}
