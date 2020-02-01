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
    public AudioClip hornSound;
    public AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        carBody = this.GetComponent<Rigidbody2D>();
        aSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.H) && !aSource.isPlaying)
        {
            Debug.Log("Where's my horn?");
            Debug.Log("audio source: " + this.GetComponent<AudioSource>());
            aSource.PlayOneShot(hornSound);
        }
        curSpeed = new Vector2(carBody.velocity.x, carBody.velocity.y);
        if (curSpeed.magnitude > maxSpeed)
        {
            curSpeed = curSpeed.normalized;
            curSpeed *= maxSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            carBody.AddForce(transform.up * power);
            //carBody.drag = friction;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            carBody.AddForce(-(transform.up * power / 2));
            carBody.drag = friction;
        }

        if (Input.GetKey(KeyCode.A))
        {
            float modifiedTurnPower = turnPower * curSpeed.magnitude;
            modifiedTurnPower = modifiedTurnPower > turnPower ? turnPower : modifiedTurnPower;
            transform.Rotate(Vector3.forward * modifiedTurnPower);
        }

        if (Input.GetKey(KeyCode.D))
        {
            float modifiedTurnPower = turnPower * curSpeed.magnitude;
            modifiedTurnPower = modifiedTurnPower > turnPower ? turnPower : modifiedTurnPower;
            transform.Rotate(Vector3.forward * -modifiedTurnPower);
        }

        float driftForce = Vector2.Dot(carBody.velocity, carBody.GetRelativeVector(Vector2.left)) * 2.0f;
        Vector2 relativeForce = Vector2.right * driftForce;
        Debug.DrawLine(carBody.position, carBody.GetRelativePoint(relativeForce), Color.green);
        carBody.AddForce(carBody.GetRelativeVector(relativeForce));

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
