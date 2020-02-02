using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public float moveSpeed = 2;
    public float thrust = .5f;
    public float rotationRate = 600;
    public bool canMove;
    private float rightAxis;
    private float upAxis;
    private float changeSpeed;
    private Vector2 velocity;
    private Vector2 direction;

    protected void Awake()
    {
        velocity = Vector2.zero;
        direction = transform.up;
        changeSpeed = moveSpeed / thrust;
    }

    void Start()
    {
        Activate();
    }

    void Activate()
    {
        canMove = true;
        enabled = true;
    }

    void Update()
    {
        if (canMove)
        {
            rightAxis = Input.GetAxis("Horizontal");
            upAxis = Input.GetAxis("Vertical");

            UpdateMove();
        }
    }

    private void UpdateMove()
    {
        Vector2 axisDirection = new Vector2(rightAxis, upAxis);
        Vector2 desiredDirection = axisDirection == Vector2.zero ? direction : axisDirection;

        if (desiredDirection != direction)
        {
            direction = Vector3.RotateTowards(direction, desiredDirection, Mathf.Deg2Rad * rotationRate * Time.deltaTime, 0f);
        }

        transform.rotation = Quaternion.LookRotation(transform.forward, direction);

        Vector2 currentVelocity = velocity;
        Vector2 desiredVelocity = axisDirection * moveSpeed;

        if (axisDirection == Vector2.zero)
        {
            desiredVelocity = Vector2.zero;
        }

        float velocityBoost = 2f - Vector2.Dot(currentVelocity.normalized, desiredVelocity.normalized);
        currentVelocity = Vector2.MoveTowards(currentVelocity, desiredVelocity, changeSpeed * velocityBoost * Time.deltaTime);

        Vector2 velocityChange = desiredVelocity * Time.deltaTime;
        transform.position += new Vector3(velocityChange.x, velocityChange.y, 0);
    }
}
 