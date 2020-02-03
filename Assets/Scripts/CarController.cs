using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float power     = 30;
    public float maxSpeed  = 40;
    public float turnPower = 0.35f;
    public float friction  = 3;
    public bool  canMove   = true;

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
        if (canMove)
        {
            if (Input.GetKey(KeyCode.H) && !aSource.isPlaying)
            {
                aSource.PlayOneShot(hornSound);
            }
            curSpeed = new Vector2(carBody.velocity.x, carBody.velocity.y);
            if (curSpeed.magnitude > maxSpeed)
            {
                curSpeed = curSpeed.normalized;
                curSpeed *= maxSpeed;
                carBody.velocity = curSpeed;
            }

            float inputForce = Input.GetAxis("Vertical");
            float reverseMod = 1;
            if (inputForce < 0)
            {
                inputForce /= 2;
                reverseMod = -1;
            }

            bool braked = false;
            if (Input.GetKey(KeyCode.Space))
            {
                braked = true;
                if (inputForce > 0 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    inputForce /= 2;
                }
            }
            carBody.AddForce(transform.up * power * inputForce);

            if (Input.GetKey(KeyCode.A))
            {
                float modifiedTurnPower = turnPower * (braked ? 15 : curSpeed.magnitude) * reverseMod;
                transform.Rotate(Vector3.forward * modifiedTurnPower);
            }

            if (Input.GetKey(KeyCode.D))
            {
                float modifiedTurnPower = turnPower * (braked ? 15 : curSpeed.magnitude) * reverseMod;
                transform.Rotate(Vector3.forward * -modifiedTurnPower);
            }

            float driftForce = Vector2.Dot(carBody.velocity, carBody.GetRelativeVector(Vector2.left)) * 2.0f;
            Vector2 relativeForce = Vector2.right * driftForce;
            carBody.AddForce(carBody.GetRelativeVector(relativeForce));

            noGas();
        }
    }

    void noGas()
    {
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
        {
            carBody.drag = friction;
        }
    }

    public void ToggleOn()
    {
        canMove = true;
    }

    public void ToggleOff()
    {
        canMove = false;
        carBody.velocity = new Vector2(0, 0);
    }
}
