using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject truck;
    public GameObject person;

    void Start()
    {
        person.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (person.activeSelf)
            {
                SwitchToInCar();
            } else
            {
                SwitchToOnFoot();
            }
        }
    }

    public void SwitchToOnFoot()
    {
        truck.GetComponent<CarController>().ToggleOff();
        person.transform.position = new Vector2(truck.transform.position.x - 1, truck.transform.position.y);
        person.SetActive(true);
    }

    public void SwitchToInCar()
    {
        person.SetActive(false);
        truck.GetComponent<CarController>().ToggleOn();
    }
}
