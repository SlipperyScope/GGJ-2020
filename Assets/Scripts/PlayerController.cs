using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject truck;
    public GameObject person;
    // Start is called before the first frame update
    void Start()
    {
        person.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (person.activeSelf)
            {
                person.SetActive(false);
                truck.GetComponent<CarController>().ToggleOn();
            } else
            {
                truck.GetComponent<CarController>().ToggleOff();
                person.transform.position = new Vector2(truck.transform.position.x - 1, truck.transform.position.y);
                person.SetActive(true);
            }
        }
        
    }
}
