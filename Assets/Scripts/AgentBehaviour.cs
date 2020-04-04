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
    private bool isDragged;

    private void Start()
    {
        stopPoint = Random.Range(0, stopRange);
    }

    private void Update()
    {
        if ((Vector3.Distance(transform.position, target.position) > stopPoint) && !isDragged)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (isDragged)
        {
            transform.position = GetMousePosition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragged = false;
        }
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButton(0))
        {
            isDragged = true;
        } 
        
    }

    private Vector3 GetMousePosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }
}
