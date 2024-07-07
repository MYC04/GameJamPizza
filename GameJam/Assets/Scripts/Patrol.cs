using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    private Transform[] PatrolPoints;
    [SerializeField]
    private int targetPoint;
    [SerializeField]
    private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField]
    private bool straight = true;
    [SerializeField]
    private bool cycle = false;

    void Start()
    {
        targetPoint = 0;
    }

    void Update()
    {
        Vector3 direction = PatrolPoints[targetPoint].position - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        }
        transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[targetPoint].position, speed * Time.deltaTime);
        if (transform.position == PatrolPoints[targetPoint].position)
        {
            if (targetPoint == PatrolPoints.Length - 1)
            {
                if (cycle)
                {
                    targetPoint = -1;
                }
                else
                {
                    straight = false;
                }
            }
            if (targetPoint == 0)
            {
                straight = true;
            }
            increaseTargetPoint();
        }

    }

    private void increaseTargetPoint()
    {
        if (straight)
        {
            targetPoint += 1;
        }
        else
        {
            targetPoint -= 1;
        }
    }
}

