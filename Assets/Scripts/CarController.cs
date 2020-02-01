using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float power     = 8;
    public float maxSpeed  = 50;
    public float turnPower = 5;
    public float friction  = 2;

    public Vector2 curSpeed;
    public Rigidbody2D carBody;

    // Start is called before the first frame update
    void Start()
    {
        carBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        curSpeed = new Vector2(carBody.velocity.x, carBody.velocity.y);
        if (curSpeed.magnitude > maxSpeed)
        {
            curSpeed = curSpeed.normalized;
            curSpeed *= maxSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            carBody.AddForce(transform.up * power);
            carBody.drag = friction;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            carBody.AddForce(-(transform.up * power / 2));
            carBody.drag = friction;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * turnPower);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -turnPower);
        }

        noGas();
    }

    void noGas()
    {
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
        {
            carBody.drag = friction;
        }
    }
}
