using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("Player prefab")]
    public GameObject Player;


    [Tooltip("Height of camera in the car")]
    public float InCarSize = 10f;

    [Tooltip("Height of camera on foot")]
    public float OnFootSize = 5f;

    [Tooltip("Time it takes the camera to zoon in seconds")]
    public float CameraZoomTime = 0.5f;

    private Transform ToFollow;
    private float TargetSize;
    private float DampVelocity;

    private Camera Camera;

    private void Awake()
    {
        if (Player is null)
            Debug.LogError("Player was never specified");

        Camera = gameObject.GetComponent<Camera>();
        Camera.orthographicSize = InCarSize * 2f;

        //TODO: Make these events happen
        //Player.InCar += UseCarCam;
        //Player.OnFoot += UseFootCam;
        var Controller = Player.GetComponent<PlayerController>();
        if (Controller != null)
        {
            Controller.ModeChanged += ModeChanged;
        }
    }

    private void ModeChanged(object sender, ModeChangedEventArgs e)
    {
        ToFollow = e.Follow;
        switch (e.Mode)
        {
            case Mode.Truck:
                TargetSize = InCarSize;
                break;
            case Mode.Person:
                TargetSize = OnFootSize;
                break;
            default:
                break;
        }
    }

    void Start()
    {
        TargetSize = InCarSize;
    }

    private void UseCarCam(object sender, EventArgs e)
    {
        TargetSize = InCarSize;
    }

    private void UseFootCam(object sender, EventArgs e)
    {
        TargetSize = OnFootSize;
    }

    void Update()
    {
        var CameraPosition = ToFollow.position;
        CameraPosition.z = transform.position.z;
        transform.position = CameraPosition;

        var CamSize = Camera.orthographicSize;
        Camera.orthographicSize = Mathf.SmoothDamp(CamSize, TargetSize, ref DampVelocity, CameraZoomTime);
    }
}
