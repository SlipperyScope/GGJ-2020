using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform carLocation;
    public float distanceFromCar = 10f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = carLocation.position + new Vector3(0, 0, -distanceFromCar);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = carLocation.position + new Vector3(0, 0, -distanceFromCar);
    }
}
