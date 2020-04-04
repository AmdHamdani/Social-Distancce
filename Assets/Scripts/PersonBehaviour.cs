using UnityEngine;

public class PersonBehaviour : MonoBehaviour
{

    public float speed;
    [Range(0, 2)]
    public float stopRange;
    public Transform target;

    private float stopPoint;
    private bool isDragged;

    private void Start()
    {
        SetStopPoint();
    }

    private void Update()
    {
        MoveToTarget();

        MoveAgentByMouse();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            isDragged = true;
        }

    }

    private void MoveAgentByMouse()
    {
        if (isDragged)
        {
            transform.position = GetMousePosition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragged = false;
            SetStopPoint();
        }
    }

    private void MoveToTarget()
    {
        if ((Vector3.Distance(transform.position, target.position) > stopPoint) && !isDragged)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void SetStopPoint()
    {
        stopPoint = Random.Range(0, stopRange);
    }

    private Vector3 GetMousePosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }
}
