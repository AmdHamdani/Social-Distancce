using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour
{

    public float speed;
    [Range(0, 2)]
    public float stopRange;
    public Transform target;

    private float stopPoint;

    private void Start()
    {
        stopPoint = Random.Range(0, stopRange);
    }

    private void Update()
    {
        MoveTo();
    }


    private void MoveTo()
    {
        if(Vector3.Distance(transform.position, target.position) > stopPoint)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
