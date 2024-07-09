using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    private GameObject PatrolPointsListParent;
 
    private List<Transform> PatrolPoints;
    [SerializeField]
    private int targetPoint;
    [SerializeField]
    private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField]
    private bool straight = true;
    [SerializeField]
    private bool cycle = false;

    private void Awake()
    {
        PatrolPoints = new List<Transform> ();
        if (PatrolPointsListParent != null)
        {
            ExtractListFromGameObject(PatrolPointsListParent, ref PatrolPoints);
        }
    }
    void Start()
    {
        targetPoint = 0;
     
        
    }

    void Update()
    {

        Vector3 direction = PatrolPoints[targetPoint].position - transform.position;
        print(direction);
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0,rotation.y,0,rotation.w), Time.deltaTime * turnSpeed);
        }
        transform.position = Vector3.MoveTowards(transform.position, PatrolPoints[targetPoint].position, speed * Time.deltaTime);
        if (transform.position == PatrolPoints[targetPoint].position)
        {
            if (targetPoint == PatrolPoints.Count - 1)
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

    private void ExtractListFromGameObject(GameObject ParentGameObject, ref List<Transform> PointList)
    {
        Transform objectTransform = ParentGameObject.transform;
        for (int i = 0; i < objectTransform.childCount; i++)
        {
        
            PointList.Add(objectTransform.GetChild(i).transform);
        }
        
    }
}

